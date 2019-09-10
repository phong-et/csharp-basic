using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.FactoryPattern.FactoryMethod
{

    interface IBank
    {
        string getBankName();
    }
    public class DABank : IBank
    {
        string IBank.getBankName() => "DABank";
    }
    public class ACBBank : IBank
    {
        string IBank.getBankName() => "ACBBank";
    }
    class FactoryMethod
    {
        public static dynamic getBank(string bankType)
        {
            // can not use var
            IBank bank = null;
            switch (bankType)
            {
                case "DABank": bank = new DABank(); break;
                case "ACBBank": bank = new ACBBank(); break;
            }
            return bank;
        }

    }
}
