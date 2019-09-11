using System;
namespace DesignPattern.FactoryPattern.AbstractFactory
{
    public class AbtractFactory
    {

    }
    interface IChair
    {
        void create();
    }
    interface ITable
    {
        void create();
    }
    interface IFurnitureAbstractFactory
    {
        IChair createChair();
        ITable createTable();
    }

    public class FurnitureFactory
    {
        public static dynamic getFactory(MaterialType type)
        {
            IFurnitureAbstractFactory factory = null;
            switch (type)
            {
                case MaterialType.FLASTIC: factory = new PlasticFactory(); break;
                case MaterialType.WOOD: factory = new WoodFactory(); break;
                default: throw new NotImplementedException();
            }
            return factory;
        }
        public static dynamic createFurniture(MaterialType mType, FurnitureType fType)
        {
            IFurnitureAbstractFactory factory = null;
            switch (mType)
            {
                case MaterialType.FLASTIC: factory = new PlasticFactory(); break;
                case MaterialType.WOOD: factory = new WoodFactory(); break;
                default: throw new NotImplementedException();
            }
            dynamic furniture = null;
            switch (fType)
            {
                case FurnitureType.CHAIR: furniture = factory.createChair(); break;
                case FurnitureType.TABLE: furniture = factory.createTable(); break;
            }
            return furniture;
        }
    }
    public class PlasticFactory : IFurnitureAbstractFactory
    {
        IChair IFurnitureAbstractFactory.createChair()
        {
            return new PlasticChair();
        }

        ITable IFurnitureAbstractFactory.createTable()
        {
            return new PlasticTable();
        }
    }

    public class WoodFactory : IFurnitureAbstractFactory
    {
        IChair IFurnitureAbstractFactory.createChair()
        {
            return new WoodChair();
        }

        ITable IFurnitureAbstractFactory.createTable()
        {
            return new WoodTable();
        }
    }
    public class WoodTable : ITable
    {
        void ITable.create()
        {
            Console.WriteLine("create a Wood Table");
        }
    }
    public class PlasticTable : ITable
    {
        void ITable.create()
        {
            Console.WriteLine("create a Plastis Table");
        }
    }
    public class WoodChair : IChair
    {
        void IChair.create()
        {
            Console.WriteLine("create a Wood Chair");
        }
    }
    public class PlasticChair : IChair
    {
        void IChair.create()
        {
            Console.WriteLine("create a Plastis Chair");
        }
    }
}
