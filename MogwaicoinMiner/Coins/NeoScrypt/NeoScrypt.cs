using MogwaicoinMiner.Core;
using MogwaicoinMiner.Core.Interfaces;
using MogwaicoinMiner.Model.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MogwaicoinMiner.NeoScrypt
{
    public class NeoScrypt : IHashAlgorithm
    {
        enum NeoScryptCoins{
            Mogwaicoin=0,
            End
        }

        List<ICoin> m_SupportedDualCoins = new List<ICoin>();
        List<ICoin> m_SupportedCoins = new List<ICoin>();
        Hashtable m_CoinsHash = new Hashtable();

        public NeoScrypt()
        {
            m_CoinsHash[NeoScryptCoins.Mogwaicoin] = new Mogwaicoin(this);

            //Now add it to the lists
            m_SupportedCoins.Add(m_CoinsHash[NeoScryptCoins.Mogwaicoin] as ICoin);

        }
        public string Name
        {
            get
            {
                return "Neoscrypt";
            }
           
        }

        public List<ICoin> SupportedCoins 
        { 
            get 
            {
                return m_SupportedCoins;
            } 
        }

        public bool SupportsDualMining
        {
            get { return false; }
        }

        public List<ICoin> SupportedDualCoins
        {
            get
            {
                return m_SupportedDualCoins;
            }

        }
        public ICoin DefaultCoin
        {
            get
            {
                return m_CoinsHash[NeoScryptCoins.Mogwaicoin] as ICoin;
            }

        }

        public ICoin DefaultDualCoin
        {
            get
            {
                return null;
            }

        }
        string GenerateUniqueID()
        {
            string id=Factory.Instance.Model.GenerateUniqueID();
            return id;
        }
        
        public IMiner DefaultMiner()
        {
            IMiner miner = null;
            try
            {
                ICoin mainCoin = DefaultCoin;
                ICoin dualCoin = null;

                if (mainCoin != null)
                {
                    ICoinConfigurer mainCoinConfigurer = mainCoin.SettingsScreen;
                    List<Pool> pools = mainCoin.GetPools();
                    mainCoinConfigurer.Wallet = "MSpncy3YsEK2PGkEvkwNwYDzTBiMjFPSAG";
                    mainCoinConfigurer.Password = "c=MOG";
                    if(pools.Count>0)
                    {
                        Pool pool = pools[0];
                        mainCoinConfigurer.Pool = pool.Link;
                        mainCoinConfigurer.PoolAccount = pool.GetAccountLink(mainCoinConfigurer.Wallet);
                    }
                    else
                        mainCoinConfigurer.Pool = "stratum+tcp://pool.mogwaicoin.net:4233";
                }
                miner = CreateMiner(GenerateUniqueID(), mainCoin, false, null, "Default Miner",null);
                miner.DefaultMiner = true;

            }
            catch (Exception e)
            {
                miner = null;
            }
            return miner;

        }

        public IMiner CreateMiner(ICoin mainCoin, bool dualMining, ICoin dualCoin, string minerName)
        {

            IMiner miner = CreateMiner(GenerateUniqueID(), mainCoin, dualMining, dualCoin, minerName,null);
            return miner;
        }
        private ICoin CreateCoinObject(string name)
        {
            ICoin coin = null;
            switch (name)
            {
                case "Mogwaicoin":
                    coin = m_CoinsHash[NeoScryptCoins.Mogwaicoin] as ICoin;
                    break;
            }
            return coin;
        }
        public IMiner RegenerateMiner(IMinerData minerData)
        {
            IMiner miner=null;
            try
            {
                ICoin mainCoin = CreateCoinObject(minerData.MainCoin);
                ICoin dualCoin = null;

                if (mainCoin != null)
                {
                    ICoinConfigurer mainCoinConfigurer = mainCoin.SettingsScreen;
                    mainCoinConfigurer.Pool = minerData.MainCoinPool;
                    mainCoinConfigurer.Wallet = minerData.MainCoinWallet;
                    mainCoinConfigurer.Password = minerData.MainCoinPassword;
                    mainCoinConfigurer.PoolAccount = minerData.MainCoinPoolAccount;
                    if (minerData.DualMining)
                    {
                        dualCoin = CreateCoinObject(minerData.DualCoin);
                        if (dualCoin != null)
                        {
                            ICoinConfigurer dualCoinConfigurer = dualCoin.SettingsScreen;
                            dualCoinConfigurer.Pool = minerData.DualCoinPool;
                            dualCoinConfigurer.Wallet = minerData.DualCoinWallet;
                            dualCoinConfigurer.PoolAccount = minerData.DualCoinPoolAccount;

                        }
                    }
                }
                miner = CreateMiner(minerData.Id, mainCoin, minerData.DualMining, dualCoin, minerData.Name,minerData);
                miner.HashRate = minerData.HashRate;
               // miner.MinerGpuType = minerData.MinerGpuType;
                miner.InitializePrograms();

            }
            catch (Exception e)
            {
                miner = null;
            }
            return miner;
        }

        private  IMiner CreateMiner(string id,ICoin mainCoin, bool dualMining, ICoin dualCoin, string minerName,IMinerData data)
        {

            IMiner miner = new MogMiner(id, mainCoin, dualMining, dualCoin, minerName, data);
            return miner;
        }


    }
}
