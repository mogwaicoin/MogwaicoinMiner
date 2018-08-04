using MogwaicoinMiner.Core;
using MogwaicoinMiner.Core.Interfaces;
using MogwaicoinMiner.View.v1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MogwaicoinMiner.NeoScrypt
{
    /// <summary>
    /// These classes dont store user data. They are to drive the UI
    /// </summary>
    partial class Mogwaicoin : ICoin
    {
        public IHashAlgorithm Algorithm { get; set; }

        ICoinConfigurer Configurer;

        public string DefaultAddress { get; set; }

        public Mogwaicoin(IHashAlgorithm algo)
        {
            Algorithm = algo;

            //This is only used in Debug mode for quick testing of the miner
            DefaultAddress = "MSpncy3YsEK2PGkEvkwNwYDzTBiMjFPSAG";

        }
        public  string Name
        {
            get { return "Mogwaicoin"; }
        }

        public Bitmap Logo
        {
            get { return MogwaicoinMiner.Properties.Resources.mogwai; }
            
        }

        public ICoinConfigurer SettingsScreen
        {
            get
            {
                if (Configurer == null)
                {
                    Configurer = new ConfigureMiner();
                    Configurer.AssignCoin(this);
                }
                return Configurer;
            }
        }
        public List<Pool> GetPools()
        {
            List<Pool> pools = new List<Pool>();
            try
            {
                Pool pool1 = new MogwaicoinPool("Mogwaicoin Team Pool", "stratum+tcp://pool.mogwaicoin.net:4233");
                Pool pool2 = new AltcoinPool("Altcoin Pool", "stratum+tcp://altcoinpool.club:4233");
                Pool pool3 = new MKTechWorld("MK Tech World", "stratum+tcp://mktechpools.xyz:4233");
                Pool pool4 = new BsodPool("The BSOD Pool (EU)", "stratum+tcp://eu.bsod.pw:2334");
                
                pools.Add(pool1);
                pools.Add(pool2);
                pools.Add(pool3);
                pools.Add(pool4);

                return pools;
            }
            catch (Exception e)
            {
            }
            return pools;
        }
        public string GetScript(string script)
        {
            return script;
        }
 
    }
}
