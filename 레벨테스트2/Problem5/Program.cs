namespace Problem5
{                  
    //                   
    //                                  (의존관계)
    //      IInventory(인터페이스) --------------|
    //           ^                               |
    //           |          (서로의존관계)       v                          (의존관계)
    //       Human(추상클래스)   <---->      Item(추상클래스)     <------------------------        AbstractFactory(추상클래스)
    //           ^                                ^                                                              ^
    //           |                                |                                                              | 
    //     Person(일반클래스)     LongSword  ClothArmor  StrangeCandy(일반클래스)          CreateLongSword  CreateClothArmor CreateStrangeCandy(일반클래스)
    //        
    //    
    //   1. 추상팩토리패턴을 통해 Item을 생성합니다.
    //   2. Inventory인터페이스는 아이템 판매, 구매, 사용, 출력 기능이 있고 이를 Human클래스에서 상속을 받아 정의합니다. 
    //   3. Human클래스에서는 Item 타입의 배열을 가지고 있고, Inventory에서도 Item타입을 이용합니다.
    //   4. Item에서도 추상함수에서 Human타입을 매개변수로 받습니다.
    //    -> IInventory, Human   <---->  Item   
    //    서로 의존관계입니다.
    //
    // 전 코드에 비해 많이 간략화 되었고 더 깔끔해진 것 같습니다.
    // 아쉬운 점은 Solid원칙을 준수하기 위해서 Human클래스를 상속받는 Person클래스가 여전히 추상클래스에서 따로 재정의하는 함수가 없어서 추상클래스를 이용한 점이 과연 최선이었을지...정도같습니다.
    // delegate활용하여 콜백함수를 이용하는 점은 좀 더 익숙해져야할거같습니다.

    public interface IInventory
    {
        void Sell(int sellNum);
        void Buy(Item item);
        void ShowInventory();
        void Use(int sellNum);

    }
    public abstract class Human : IInventory
    {
        private int _gold;
        private int _power;
        private int _hp;
        private int _def;
        List<Item> _items;

        public Human(int gold, int power, int hp, int def)
        {
            _gold = gold;
            _power = power;
            _hp = hp;
            _def = def;
            _items = new List<Item>();
        }

        public int Gold { get { return _gold; } set { _gold = value; } }
        public int Power { get { return _power; } set { _power = value; } }
        public int Hp { get { return _hp; } set { _hp = value; } }
        public int Def { get { return _def; } set { _def = value; } }

        public List<Item> Items { get { return _items; } }

        public void Sell(int sellNum)
        {
            if (Items.Count() == 0)
            {
                Console.WriteLine("보유하고 있는 물건이 없어 팔 수 없습니다.");
                return;
            }
            Item item = Items[sellNum - 1];
            item.DownStatus(this);
            Items.RemoveAt(sellNum - 1);
            Gold += item.Price;
            Console.WriteLine($"{item.Name} 을 / 를 판매합니다.");
            Console.WriteLine($"보유한 골드가 {item.Price}G 증가하여 {Gold}G가 됩니다.");
        }

        public void Buy(Item item)
        {
            if (Gold <= item.Price)
            {
                Console.WriteLine("돈이 부족해 구매할 수가 없습니다.");
                return;
            }
            if (Items.Count() == 6)
            {
                Console.WriteLine("인벤토리가 가득 차 더이상 살 수 없습니다.");
                return;
            }
            if (item.IsUseable == false)
            {
                item.UpStatus(this);
            }
            Items.Add(item);
            Gold -= item.Price;
            Console.WriteLine($"{item.Name} 을 / 를 구매합니다.");
            Console.WriteLine($"보유한 골드가 {item.Price}G 감소하여 {Gold}G가 됩니다.");
        }

        public void ShowInventory()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Items[i].Name}");
                Console.WriteLine($"가격 : {Items[i].Price}");
                Console.WriteLine($"설명 : {Items[i].Explain}");
                Console.WriteLine($"효과 :  {Items[i].Effect}");
                Console.WriteLine();
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"플레이어 골드 보유량: {Gold}G");
            Console.WriteLine($"플레이어 공격력 상승량: {Power}");
            Console.WriteLine($"플레이어 방어력 상승량: {Def}");
            Console.WriteLine($"플레이어 체력 상승량: {Hp}");
        }

        public void Use(int sellNum)
        {
            if (Items.Count() == 0)
            {
                Console.WriteLine("인벤토리에 아이템이 없어 사용할 수 없습니다.");
                return;
            }
            else if (Items[sellNum - 1].IsUseable == false)
            {
                Console.WriteLine("사용할 수 없는 아이템 입니다.");
                return;
            }

            Console.WriteLine($"{Items[sellNum - 1].Name} 을 / 를 사용합니다.");
            Console.WriteLine($"플레이어가 다음과 같은 효과를 얻습니다: {Items[sellNum - 1].Effect}");
            Items[sellNum - 1].UpStatus(this);
            Items.RemoveAt(sellNum - 1);
        }

    }

    public class Person : Human
    {
        public Person(int gold, int power, int hp, int def) : base(gold, power, hp, def) { }
    }


    public abstract class Item
    {
        private string _name;
        private int _price;
        private string _explain;
        private bool _isUseable;
        private string _effect;

        public Item(string name, int price, string explain, bool isUseable, string effect)
        {
            _name = name;
            _price = price;
            _explain = explain;
            _isUseable = isUseable;
            _effect = effect;
        }

        public string Name { get { return _name; } }
        public int Price { get { return _price; } }
        public string Explain { get { return _explain; } }
        public bool IsUseable { get { return _isUseable; } }
        public string Effect { get { return _effect; } }

        public abstract void UpStatus(Human human);
        public abstract void DownStatus(Human human);
    }


    public class LongSword : Item
    {
        private int _power = 15;

        public int Power { get { return _power; } set { _power = value; } }

        public LongSword(string name, int price, string explain, bool isUseable, string effect) : base(name, price, explain, isUseable, effect) { }

        public override void UpStatus(Human human)
        {
            human.Power += _power;
        }

        public override void DownStatus(Human human)
        {
            human.Power -= _power;
        }

    }

    public class ClothArmor : Item
    {
        private int _def = 15;

        public int Def { get { return _def; } set { _def = value; } }

        public ClothArmor(string name, int price, string explain, bool isUseable, string effect) : base(name, price, explain, isUseable, effect) { }

        public override void UpStatus(Human human)
        {
            human.Def += _def;
        }

        public override void DownStatus(Human human)
        {
            human.Def -= _def;
        }
    }

    public class StrangeCandy : Item
    {
        private int _hp = 300;

        public int Hp { get { return _hp; } set { _hp = value; } }

        public StrangeCandy(string name, int price, string explain, bool isUseable, string effect) : base(name, price, explain, isUseable, effect) { }

        public override void UpStatus(Human human)
        {
            human.Hp += _hp;
        }

        public override void DownStatus(Human human)
        {
            human.Hp -= _hp;
        }
    }


    public interface IAbstractFactory
    {
        Item CreateItem();
    }

    public class CreateLongSword : IAbstractFactory
    {
        public Item CreateItem()
        {
            return new LongSword("롱소드", 400, "기본적임 검이다", false, "(소유) 공격력 상승 15");
        }
    }

    public class CreateClothArmor : IAbstractFactory
    {
        public Item CreateItem()
        {
            return new ClothArmor("천갑옷", 500, "얇은 갑옷이다", false, "(소유) 방어력 상승 15");
        }
    }

    public class CreateStrangeCandy : IAbstractFactory
    {
        public Item CreateItem()
        {
            return new StrangeCandy("이상한 사탕", 800, "먹으면 신비한 효과를 일으킬 것 같다", true, "(사용) 체력 영구상승 300");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            IAbstractFactory abstractFactory = new CreateLongSword();
            Item longSword = abstractFactory.CreateItem();

            abstractFactory = new CreateClothArmor();
            Item clothArmor = abstractFactory.CreateItem();

            abstractFactory = new CreateStrangeCandy();
            Item strangeCandy = abstractFactory.CreateItem();

            Human person = new Person(3000, 0, 0, 0);

            Item[] items = new Item[3];
            items[0] = longSword;
            items[1] = clothArmor;
            items[2] = strangeCandy;

            int menuNum = 1;

            while (menuNum != 0)
            {
                do
                {
                    UIMenu();
                } while (int.TryParse(Console.ReadLine(), out menuNum) == false || (menuNum < 0 || menuNum > 3));

                int userNum = 1;
                switch (menuNum)
                {
                    //프로그램 종료
                    case 0:
                        break;
                    //아이템 구매
                    case 1:
                        UIBuy(person, items, userNum);
                        break;
                    //아이템 판매
                    case 2:
                        UISell(person, userNum);
                        break;
                    //아이템 확인
                    case 3:
                        UICheck(person, userNum);
                        break;
                }
            }
        }

        static void UIMenu()
        {
            Console.WriteLine("********************");
            Console.WriteLine("*아이템        상점*");
            Console.WriteLine("********************");
            Console.WriteLine("======== 상점 메뉴 =========");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("3. 아이템 확인");
            Console.Write("메뉴를 선택하세요(0: 종료) : ");
        }

        static void UIBuy(Human player, Item[] items, int userNum)
        {
            Console.Clear();
            Console.WriteLine("==========아이템 구매 ==========");
            Console.WriteLine($"보유한 골드 : {player.Gold}G");

            //구매 가능한 아이템들 목록 보여주기.
            for (int i = 0; i < items.Count(); i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i + 1}. {items[i].Name}");
                Console.WriteLine($"  가격: {items[i].Price}");
                Console.WriteLine($"  설명: {items[i].Explain}");
                Console.WriteLine($"  효과: {items[i].Effect}");
            }
            Console.WriteLine();

            //구매하기위해 입력한 아이템 번호(userNum)입력.
            do
            {
                Console.WriteLine("구매할 아이템을 선택하세요(뒤로가기 0) : ");

            } while (int.TryParse(Console.ReadLine(), out userNum) == false || (userNum < 0 || userNum > 3));

            //원하는 아이템 구매. 0번은 메인메뉴
            if (userNum == 0)
            {
                return;
            }
            player.Buy(items[userNum - 1]);
        }

        static void UISell(Human player, int userNum)
        {
            Console.Clear();
            Console.WriteLine("==========아이템 판매 ==========");
            Console.WriteLine($"보유한 골드 : {player.Gold}G");
            Console.WriteLine();
            player.ShowInventory();


            //판매하기위해 입력한 아이템 번호(userNum)입력
            do
            {
                Console.WriteLine("판매할 아이템을 선택하세요(뒤로가기 0) : ");

            } while (int.TryParse(Console.ReadLine(), out userNum) == false || (userNum < 0 || userNum > player.Items.Count));

            //원하는 아이템 판매.  0번은 메인메뉴
            if (userNum == 0)
            {
                return;
            }
            else
            {
                player.Sell(userNum);
            }
        }
        static void UICheck(Human player, int userNum)
        {
            Console.Clear();
            Console.WriteLine("==========아이템 확인 ==========");
            player.ShowStatus();
            Console.WriteLine();
            player.ShowInventory();

            //아이템 사용을 위해 입력한 아이템 번호(userNum)입력
            do
            {
                Console.WriteLine("사용할 아이템을 선택하세요(뒤로가기 0) : ");
            } while (int.TryParse(Console.ReadLine(), out userNum) == false || (userNum < 0 || userNum > player.Items.Count));


            //원하는 아이템 사용. 0번은 메인메뉴
            if (userNum == 0)
            {
                return;
            }
            player.Use(userNum);
        }
    }



}
