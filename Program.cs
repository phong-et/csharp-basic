using System;
using DesignPattern.FactoryPattern.SimpleFactory;
using DesignPattern.FactoryPattern.FactoryMethod;
using DesignPattern.FactoryPattern.AbstractFactory;
namespace DesignPattern
{
    public enum MaterialType
    {
        FLASTIC, WOOD
    }
    public enum FurnitureType
    {
        CHAIR, TABLE
    }
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
            //Console.Read();


            // ABSTRACT FACTORY - show screnario create factory and furniture
            IFurnitureAbstractFactory factory = FurnitureFactory.getFactory(MaterialType.FLASTIC);
            IChair chair = factory.createChair();
            chair.create(); 
            ITable table = factory.createTable();
            table.create();

            // ABSTRACT FACTORY - hide screnario create factory and furniture
            // can not use var c = ...
            IChair c = FurnitureFactory.createFurniture(MaterialType.WOOD, FurnitureType.CHAIR);
            c.create();
            Console.Read();
        }
    }
}