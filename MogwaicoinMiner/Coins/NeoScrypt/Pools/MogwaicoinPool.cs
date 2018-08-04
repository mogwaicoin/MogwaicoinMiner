using MogwaicoinMiner.Core.Interfaces;
using System;

namespace MogwaicoinMiner.NeoScrypt
{
    partial class Mogwaicoin
    {
        class MogwaicoinPool : Pool
        {
            public MogwaicoinPool(string name, string url)
                : base(name, url)
            {
                WrongWallet = "Should be Account.Workername";

            }
            bool FormatValid(string format)
            {
                string allowableLetters = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

                foreach (char c in format)
                {
                    if (!allowableLetters.Contains(c.ToString()))
                        return false;
                }
                return true;
            }

            public override bool ValidateAddress(string address)
            {
                if (!FormatValid(address) || !address.StartsWith("M") || address.Length != 34)
                    return false;

                return true;
            }
            public override string GetAccountLink(string wallet)
            {
                string acc = "";
                try
                {
                    acc = "https://pool.mogwaicoin.net/?address=" + wallet;
                    
                }
                catch (Exception)
                {
                }
                return acc;
            }
        }
 
    }
}
