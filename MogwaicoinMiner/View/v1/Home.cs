﻿using MogwaicoinMiner.Core;
using MogwaicoinMiner.Core.Interfaces;
using MogwaicoinMiner.View.v1.AddMinerScreen;
using MogwaicoinMiner.View.v1.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MogwaicoinMiner.View.v1
{
    public partial class Home : Form
    {

        public IMiner Miner { get; set; }
        MainForm m_Parent = null;
        public Home(IMiner miner, MainForm parent)
        {
            Miner = miner;
            m_Parent = parent;

            InitializeComponent();


            /*
            lblCoinType.Text = Miner.MainCoin.Name;
            lblMinername.Text = Miner.Name;
            */
        }
        public void Setlabels()
        {
            lblMinername.Text = Miner.Name;
            lblAlgorithm.Text = Miner.MainCoin.Algorithm.Name;
            lblPool.Text = Miner.MainCoin.SettingsScreen.Pool;
            lblWallet.Text = Miner.MainCoin.SettingsScreen.Wallet;

        }
        public void SetIntensityControl()
        {
            //if (!Miner.DefaultMiner)
            //{
            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(SliderEx))
                {
                    this.Controls.Remove(item);
                }
            }
            List<Label> placeHolders = new List<Label>();
            placeHolders.Add(lblSliderLocation1);
            placeHolders.Add(lblSliderLocation2);
            int i = 0;
            foreach (IMinerProgram item in Miner.ActualMinerPrograms)
            {
                SliderEx ex = new SliderEx();
                ex.Location = placeHolders[i].Location;
                ex.Low = item.MiningIntensityLow;
                ex.Value = item.MiningIntensity;
                ex.High = item.MiningIntensityHigh;
                ex.Name = item.Type;
                ex.Program = item;
                this.Controls.Add(ex);
                i++;
            }
            // }
        }
        private void Home_Load(object sender, EventArgs e)
        {
            SetIntensityControl();
            Setlabels();

            /*
            this.ContextMenuStrip = optionsMenu;
            pbTemplate.Click += FormFocus_handler_Click;
            lblCoinType.Click += FormFocus_handler_Click;
            lblMinername.Click += FormFocus_handler_Click;
            lblMinerState.Click += FormFocus_handler_Click;
            pnlTemplate.Click += FormFocus_handler_Click;
            */
        }
    

        void FormFocus_handler_Click(object sender, EventArgs e)
        {
            //m_Parent.ChangeMiningView(this);
        }
        public void UpdateState(bool reDrawAll)
        {
            CalculateTotalHashrate();
            Setlabels();
            if (reDrawAll)
                SetIntensityControl();                
            UiStateUtil.UpdateState(Miner,lblMinerState, btnStartMining,null);
        }
        public void CalculateTotalHashrate()
        {
            try
            {
                string hashrate = "", shares = "Shares: ";
                if (Miner.MinerState == MinerProgramState.Running)
                {
                    int totalHashrate = 0;
                    int totalShares = 0;
                    int totalSharesRejected = 0;
                    List<IMinerProgram> programs = Miner.ActualMinerPrograms;
                    
                    foreach (IMinerProgram item in programs)
                    {
                        MinerDataResult result = item.OutputReader.MinerResult;
                        Logger.Instance.LogInfo("Miner.Totalhashrate: " + result.TotalHashrate.ToString());

                        totalHashrate += result.TotalHashrate;
                        totalShares += result.TotalShares;
                        totalSharesRejected += result.Rejected;
                    }
                    if (totalHashrate > 10 * 1024)
                    {
                        float conversion = totalHashrate / 1000;// 1024;
                        if (conversion > 10000)//quick fix for increased hashrate issue
                            conversion /= 1000;
                        hashrate = conversion.ToString() + " MH/s";
                        Miner.HashRate = (totalHashrate * 1000).ToString("F1");
                        
                        //Todo: this will write to file always. change this
                        Factory.Instance.Model.AddMiner(Miner);

                    }
                    else
                    {
                        hashrate = totalHashrate.ToString() + " KH/s";
                    }
                    shares += " A: " + totalShares.ToString() + "   R: " + totalSharesRejected.ToString();
                    lblShares.Text = shares;
                    lblTotalHashrate.Text = hashrate;
                    Logger.Instance.LogInfo("Hashrate printed: " + lblTotalHashrate.Text);


                }
                else
                {
                    lblShares.Text = "";
                    lblTotalHashrate.Text = "0 MH/s";
                }
            }
            catch (Exception e)
            {
            }

        }


        private void btnStartMining_Click_1(object sender, EventArgs e)
        {
            UiStateUtil.MiningStartAction(Miner);

        }

        private void lnlMainCoinPool_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Miner.MainCoin.SettingsScreen.PoolAccount);
            }
            catch (Exception se)
            {
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IMiner miner = Factory.Instance.CoreObject.SelectedMiner;
            EditMinerContainer editMiner = new EditMinerContainer();
            editMiner.LoadInfo(miner);
            editMiner.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Miner.MainCoin.SettingsScreen.PoolAccount);
            }
            catch (Exception se)
            {
            }
        }





    }
}
