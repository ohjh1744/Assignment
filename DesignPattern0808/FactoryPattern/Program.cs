namespace FactoryPattern
{
    public enum ItemType { Potion, Weapon, Armor, Food }

    public class ItemFactory
    {
        public static IItem Create(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Potion:
                    return new Potion();
                case ItemType.Weapon:
                    return new Weapon();
                case ItemType.Armor:
                    return new Armor();
                case ItemType.Food:
                    return new Food();
                default:
                    throw new ArgumentException();
            }
        }
    }

    public interface IItem
    {
        void Name();
    }

    public class Potion : IItem
    {
        public void Name()
        {
            Console.WriteLine("포션");
        }
    }

    public class Weapon : IItem
    {
        public void Name()
        {
            Console.WriteLine("무기");
        }
    }

    public class Armor : IItem
    {
        public void Name()
        {
            Console.WriteLine("방어구");
        }
    }

    public class Food : IItem
    {
        public void Name()
        {
            Console.WriteLine("음식");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IItem item1 = ItemFactory.Create(ItemType.Potion);
            item1.Name(); 

            IItem item2 = ItemFactory.Create(ItemType.Weapon);
            item2.Name(); 

            IItem item3 = ItemFactory.Create(ItemType.Armor);
            item3.Name(); 

            IItem item4 = ItemFactory.Create(ItemType.Food);
            item4.Name(); 
        }
    }
}