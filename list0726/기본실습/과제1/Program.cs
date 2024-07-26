namespace list0726
{
    enum EItem { Potion, Weapon, Armor, Accessory, Food }
    public class Inventory
    {
        private List<Item> itemInventory = new List<Item>(9);
        private int itemCount = 0;
        public void AddInventory(Item item)
        {
            if(itemCount >= 9)
            {
                Console.WriteLine("더 이상 인벤토리에 추가 할수 없습니다.");
            }
            else
            {
                itemInventory.Insert(0, item);
                itemCount++;
            }
        }
        public void RemoveInventory(int numItem)
        {
            if (numItem > 0 && numItem <= itemCount)
            {
                itemInventory.RemoveAt(numItem - 1);
                itemCount--;
            }
            else
            {
                Console.WriteLine($"인벤토리에 {numItem}번째 아이템이 없습니다.");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("인벤토리 상황");
            for(int i = 0; i < itemCount; i++)
            {
                Console.WriteLine($"{i+1}번째 아이템: {itemInventory[i].GetName}");
            }
        }

        public int ItemCount { get { return itemCount; } }
    }

    public abstract class Item
    {
        private string name;

        protected Item(string name)
        {
            this.name = name;
        }
        public string GetName
        {
            get { return name; }
        }
    }

    public class Potion : Item
    {
        public Potion(string name) : base(name) { }
    }

    public class Weapon : Item
    {
        public Weapon(string name) : base(name) { }
    }

    public class Armor : Item
    {
        public Armor(string name) : base(name) { }
    }

    public class Accessory : Item
    {
        public Accessory(string name) : base(name) { }
    }

    public class Food : Item
    {
        public Food(string name) : base(name) { }
    }

    class Program
    {
        //따로 static함수로 빼놓긴 했지만, 추상팩토리로 구현하면 더 괜찮을까요?
        static public void CreateItem(ref Inventory inventory, EItem randomItem)
        {
            switch (randomItem)
            {
                case EItem.Potion:
                    Item item = new Potion("포션");
                    inventory.AddInventory(item);
                    break;
                case EItem.Weapon:
                    item = new Weapon("무기");
                    inventory.AddInventory(item);
                    break;
                case EItem.Armor:
                    item = new Armor("방어구");
                    inventory.AddInventory(item);
                    break;
                case EItem.Accessory:
                    item = new Accessory("악세사리");
                    inventory.AddInventory(item);
                    break;
                case EItem.Food:
                    item = new Food("음식");
                    inventory.AddInventory(item);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Random random = new Random();
            int num;
            while (true)
            {
                Console.Clear();
                inventory.ShowInventory();
                do
                {
                    Console.WriteLine("숫자키 1~9를 입력하세요. 0: 랜덤으로 아이템획특, 1~9: 해당 위치 아이템 삭제. 10: 프로그램 종료");
                } while (int.TryParse(Console.ReadLine(), out num) == false || (num < 0 || num >10));

                if (num == 10)
                {
                    break;
                }
                else if (num == 0)
                {
                    int randomItemIndex = random.Next(0, 5);
                    EItem randomItem = (EItem)randomItemIndex;
                    Program.CreateItem(ref inventory, randomItem);
                }
                else
                {
                    inventory.RemoveInventory(num);
                }
            }
        }
    }


}