using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.FactoryPattern.SimpleFactory
{
    enum BankType
    {
        DABank = 1,
        ACBBAnk = 2
    }
    class DABank
    {
        public string getBankName() => "DABank";
    }
    class ACBBank
    {
        public string getBankName() => "ACBBAnk";
    }
    class SimpleFactory
    {
        public static dynamic getBank(string bankType)
        {
            // can not use var
            dynamic bank = null;
            switch (bankType)
            {
                case "DABank": bank = new DABank(); break;
                case "ACBBank": bank = new ACBBank(); break;
            }
            return bank;
        }
    }
}
