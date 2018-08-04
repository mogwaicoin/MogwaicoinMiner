﻿using MogwaicoinMiner.Core.Interfaces;
using MogwaicoinMiner.View.v1.ExtraScreens;
using MogwaicoinMiner.View.v1.MiningInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
///Use below link if needed to show ui in transparent way
///https://www.codeproject.com/Articles/42933/Creating-Transparent-Controls-in-NET-Compact-Frame
namespace MogwaicoinMiner.View.v1
{
    public partial class MinerInfo : Form
    {

        public IMiner Miner { get; set; }
        
        MainForm m_Parent = null;
        List<Button> m_tabButtons = new List<Button>();
        public IMinerInfoTab CurrentTab { get; set; }

        

        Control m_Summary = null;
        Control m_Script = null;
        Control m_Logs = null;
        public MinerInfo(IMiner miner, MainForm parent)
        {
            Miner = miner;
            m_Parent = parent;

            m_Summary = new MinerInfoSummary(Miner, this);
            m_Script = new MinerInfoScript(Miner, this);
            m_Logs = new MinerInfoLogs(Miner, this);
            InitializeComponent();
        }
        public void SelectView(Button btn)
        {
            foreach (Button item in m_tabButtons)
            {
                if(btn==item)
                {
                    item.BackColor = Color.SteelBlue;
                    item.ForeColor = Color.White;
                }
                else
                {
                    item.BackColor = Color.LightSteelBlue;
                    item.ForeColor = Color.Black;
                }
            }


        }


        private void MinerInfo_Load(object sender, EventArgs e)
        {


            m_tabButtons.Add(btntabInfo);
            m_tabButtons.Add(btntabLogs);
            m_tabButtons.Add(btntabScript);
            //btntabInfo.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            SelectView(btntabInfo);
            ShowTabInfo(m_Summary);
        }
        public void ShowTabInfo(Control form)
        {
            pnlMinerInfo.Controls.Clear();
            pnlMinerInfo.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            IMinerInfoTab tab = form as IMinerInfoTab;
            if (tab != null)
                tab.UpdateUI();
            CurrentTab = tab;//its ok if its null after cast
            form.Show();
        }

        public void UpdateState()
        {
            //Enable this if we want to keep back hashrate etc at minerinfo
            //UiStateUtil.UpdateState(Miner, lblMinerState, btnStartMining, null);
        }
       
        public void UpdateUI()
        {
            if(CurrentTab!=null)
            {
                CurrentTab.UpdateUI();
            }
        }

        
        private void btntabInfo_Click(object sender, EventArgs e)
        {
            SelectView(sender as Button) ;
            ShowTabInfo(m_Summary);
        }

        private void btntabScript_Click(object sender, EventArgs e)
        {
            SelectView(sender as Button);
            ShowTabInfo(m_Script);


        }

        private void btntabLogs_Click(object sender, EventArgs e)
        {
            SelectView(sender as Button);
            ShowTabInfo(m_Logs);


        }

        private void btnStartMining_Click(object sender, EventArgs e)
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

        private void lnDualCoinPool_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Miner.DualCoin.SettingsScreen.PoolAccount);
            }
            catch (Exception se)
            {
            }
        }

        private void lnkKnowMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
