using System;
using DesignPattern.FactoryPattern.SimpleFactory;
using DesignPattern.FactoryPattern.FactoryMethod;
namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // ======== SIMPLE FACTORY ===========
            var smBank = SimpleFactory.getBank("DABank");
            Console.WriteLine(smBank.getBankName());
            //Console.Read();

            // ======== FACTORY METHOD ===========
            IBank fmBank = FactoryMethod.getBank("ACBBank");
            Console.WriteLine(fmBank.getBankName());
            Console.Read();

        }
    }
}