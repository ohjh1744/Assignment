namespace Problem5
{
    // 1. 상속관계
    //
    //     IInventory(인터페이스)                IItem(인터페이스)
    //        ^                                    ^    ^     ^
    //        |                                    |    |     | 
    //      Human(추상 클래스)               IWeapon   IArmor  IAccessory(인터페이스)
    //        ^                                ^         ^         ^
    //        |                                |         |         |
    //      Player(일반 클래스)          LongSword   ClothArmor  StrangeCandy  (일반 클래스)
    //
    //2. 의존관계
    // 2-1. Human 클래스에서 IItem 인터페이스 타입의 배열을 사용.
    // 2-2. IInventory 인터페이스의 Buy함수를 Human클래스에서 정의하고, 매개변수로 IItem 타입을 받음.
    // -> Human과 IItem과의 의존관계 형성.
    // 2-3.IWeapon, IArmor, IAccessory 인퍼테이스는 LongSword, ClothArmor, StrangeCandy에서 각각의 함수를 정의하고, 매개변수로 Human 타입을 받음.
    // -> LongSword, ClothArmor, StrangeCandy는 Human과 의존 관계 형성.
    //
    // 3. 현재 느낀 문제점 및 궁금한점:
    // 3-1. LongSword, ClothArmor, StrangeCandy와 Human이 의존 관계인건지, 인터페이스 IWeapon, IArmor, IAccessory와 Human이 의존 관계인건지,
    // 또는 둘다 의존관계인건지 궁금합니다...
    //
    // 3-2. Main함수 내부에 존재하는 UIBuy함수 333번째줄과 UISell함수 381번째줄을 보면,
    // 만약 IPet 처럼 IItem을 상속받는 또다른 인터페이스가 생긴다면 각각의 코드에서 if문을 더 추가하여 수정해야하는데,
    // 이러면 개방 폐쇄 원칙에 어긋나게 되어 문제가 생긴다고 생각은 들지만.. 좋은 방법이 떠오르질 않습니다..
    // 추상팩토리 패턴?같은 것을 적용하면 될까요..?
    // 특히 381줄은 현재 이름이 같은지를 비교하여 아이템을 찾아내는 방법을 사용하는데, 방법 자체도 마음에 안들기도 합니다... 이부분은 어떤식으로 수정해야할까요?
    //
    //3-3.IInventory인터페이스를 Player에 바로 상속시키지 않고, 중간에 추상클래스 Human을 만들어 Human에 상속시킨 이유는.
    //IWeapon, IArmor, IAccessory에서 각 함수들이 매개변수로 일반 하위클래스인 Player로 받으면, 의존성 역전 원칙에 위배되어 만들었습니다.
    //그런데, Human클래스에 추상함수가 없기 때문에, Player에서 따로 재정의하는 함수가 없어서.. 추상 클래스 사용이 애매한감도 없지 않아 있어서...
    // 추상클래스 내부를 수정해야할지.. 또는 구조체나.. 다른 방법을 사용하여 원칙에 준수하는 더 좋은 방법이 있을까요??
    //
    //
    // 처음에 기획 할때, event도 사용하고 싶어서 event를 첨가해 기획하려 했으나 너무 복잡해져서,
    // 일단은 사용하지 않는 식으로 기획하고, 구현하는걸 반복하면서 상속도를 계속 수정하면서
    // 현재의 코드가 나왔습니다...
    // 기획 하는데 좋은 팁 있을까요 교수님? 클래스나 상속도 같은 기본 틀을 어떻게 하면 잘 구성할 수 있을까요..
    // 디자인 패턴을 아직 활용하지 못해서 생기는 문제점일까요..?


    public interface IInventory
    {
        public void Buy(IItem item);
        public void Sell(int numSell);

        public void Use(int numUse);
        public void ShowInventory();
    }
    public abstract class Human : IInventory
    {
        private int _hp;
        private int _gold;
        private int _power;
        private int _def;
        private List<IItem> _items;

        public Human() { }
        public int Hp { get { return _hp; } set { _hp = value; } }
        public int Gold { get { return _gold; } set { _gold = value; } }
        public int Power { get { return _power; } set { _power = value; } }
        public int Def { get { return _def; } set { _def = value; } }
        public List<IItem> Items { get { return _items; } set { _items = value; } }


        public void Buy(IItem item)
        {
            if (Items.Count == 6)
            {
                Console.WriteLine("인벤토리가 가득차 더이상 구매를 할 수 없습니다.");
                return;
            }
            if (Gold < item.Price)
            {
                Console.WriteLine("돈이 부족해 구매를 할 수 없습니다.");
                return;
            }
            Console.WriteLine($"{item.Name} 을/를 구매합니다.");
            Gold -= item.Price;
            Items.Add(item);
            Console.WriteLine($"보유한 골드가 {item.Price}G 감소하여 {Gold}G가 됩니다.");
        }

        public void Sell(int numSell)
        {
            Console.WriteLine($"{Items[numSell - 1].Name} 을/를 판매합니다.");
            Gold += Items[numSell-1].Price;
            Console.WriteLine($"보유한 골드가 {Items[numSell - 1].Price}G 상승하여 {Gold}G가 됩니다.");
            Items.RemoveAt(numSell-1);
        }

        public void Use(int numUse)
        {
            Console.WriteLine($"{Items[numUse - 1].Name} 을/를 사용합니다.");
            Console.WriteLine($"플레이어가 다음과 같은 효과를 얻습니다 : {Items[numUse - 1].Effect}");
            Items.RemoveAt(numUse - 1);
        }

        public void ShowInventory()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_items[i].Name}");
                Console.WriteLine($"가격 : {_items[i].Price}");
                Console.WriteLine($"설명 : {_items[i].Content}");
                Console.WriteLine($"효과 :  {_items[i].Effect}");
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

    }

    public class Player: Human
    {
        public Player()
        {
            base.Items = new List<IItem>();
            base.Hp = 0;
            base.Gold = 3000;
            base.Power = 0;
            base.Def = 0;
        }
    }

    public interface IItem
    {
        public string Name { get;}
        public int Price { get;}
        public string Content { get;}
        public string Effect { get;}
        
        public bool Consumable { get; }
    }

    public interface IWeapon : IItem
    {
        public int Power { get; }
        public void UpPower(Human human);
        public void DownPower(Human human);
    }

    public interface IArmor: IItem
    {
        public int Def { get; }
        public void UpDef(Human human);
        public void DownDef(Human human);
    }

    public interface IAccessory: IItem
    {
        public int Hp { get; }
        public void UpHp(Human human);
    }

    public class LongSword : IWeapon
    {
        private string _name = "롱소드";
        private int _price = 400;
        private string _content = "기본적인 검이다";
        private string _effect = "(소유) 공격력 상승 15";
        private int _power = 15;
        private bool consumable = false;
        public string Name { get { return _name; } }
        public int Price { get { return _price; } }
        public string Content { get { return _content; } }
        public string Effect { get { return _effect; } }
        public int Power { get { return _power; } }

        public bool Consumable { get { return consumable; } }
        public void UpPower(Human human)
        {
            human.Power += Power;
        }

        public void DownPower(Human human)
        {
            human.Power -= Power;
        }
    }

    public class ClothArmor : IArmor
    {
        private string _name = "천갑옷";
        private int _price = 500;
        private string _content = "얇은 갑옷이다";
        private string _effect = "(소유) 방어력 상승 15";
        private int _def = 15;
        private bool consumable = false;

        public string Name { get { return _name; } }
        public int Price { get { return _price; } }
        public string Content { get { return _content; } }
        public string Effect { get { return _effect; } }
        public int Def { get { return _def; } }
        public bool Consumable { get { return consumable; } }
        public void UpDef(Human human)
        {
            human.Def += Def;
        }

        public void DownDef(Human human)
        {
            human.Def -= Def;
        }
    }

    public class StrangeCandy: IAccessory
    {
        private string _name = "이상한 사탕";
        private int _price = 800;
        private string _content = "먹으면 신비한 효과를 일으킬 것 같다";
        private string _effect = "(사용) 체력 영구상승 300";
        private int _hp = 300;
        private bool _isUseable = true;
        private bool consumable = true;

        public string Name { get { return _name; } }
        public int Price { get { return _price; } }
        public string Content { get { return _content; } }
        public string Effect { get { return _effect; } }
        public int Hp { get { return _hp; } }
        public bool IsUseable { get { return _isUseable; } }
        public bool Consumable { get { return consumable; } }
        public void UpHp(Human human)
        {
            human.Hp += Hp;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Human player = new Player();

            //추상팩토리?패턴을 이용하면 더욱 확장성 좋게 구현가능할까요..?
            IWeapon longSword = new LongSword();
            IArmor clothArmor = new ClothArmor();
            IAccessory strangeCandy = new StrangeCandy();

            //구매 가능한 상점에서 파는 아이템 목록
            IItem[] items = new IItem[3];
            items[0] = longSword;
            items[1] = clothArmor;
            items[2] = strangeCandy;

            int menuNum = 1;

            while(menuNum != 0)
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
                        UIBuy(player, items, userNum , longSword, clothArmor);
                        break;
                    //아이템 판매
                    case 2:
                        UISell(player, userNum, longSword, clothArmor, strangeCandy);
                        break;
                    //아이템 확인
                    case 3:
                        UICheck(player, userNum, strangeCandy);
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

        static void UIBuy(Human player, IItem[] items, int userNum , IWeapon longSword, IArmor clothArmor)
        {
            Console.Clear();
            Console.WriteLine("==========아이템 구매 ==========");
            Console.WriteLine($"보유한 골드 : {player.Gold}G");

            //구매 가능한 아이템들 목록 보여주기.
            for(int i = 0; i < items.Count(); i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i+1}. {items[i].Name}");
                Console.WriteLine($"  가격: {items[i].Price}");
                Console.WriteLine($"  설명: {items[i].Content}");
                Console.WriteLine($"  효과: {items[i].Effect}");
            }
            Console.WriteLine();

            //구매하기위해 입력한 아이템 번호(userNum)입력.
            do
            {
                Console.WriteLine("구매할 아이템을 선택하세요(뒤로가기 0) : ");

            } while (int.TryParse(Console.ReadLine(), out userNum) == false || (userNum < 0 || userNum > 3));

            //입력한 아이템 번호에 따라 아이템 구매 후, 인벤토리에 저장. 또한, player의 능력치 업그레이드. 0번은 메인메뉴
            if (userNum == 0)
            {
                return;
            }
            //롱소드 사기
            else if (userNum == 1)
            {
                longSword.UpPower(player);
                player.Buy(items[userNum - 1]);
            }
            //천갑옷사기
            else if (userNum == 2)
            {
                clothArmor.UpDef(player);
                player.Buy(items[userNum - 1]);
            }
            //이상한 사탕 사기
            else if (userNum == 3)
            {
                player.Buy(items[userNum - 1]);
            }
        }

        static void UISell(Human player, int userNum, IWeapon longSword, IArmor clothArmor, IAccessory strangeCandy)
        {
            Console.Clear();
            Console.WriteLine("==========아이템 판매 ==========");
            Console.WriteLine($"보유한 골드 : {player.Gold}G");
            Console.WriteLine();
            player.ShowInventory();

            //플레이어 인벤토리에 가지고 있는 아이템이 없다면 판매 불가.
            if (player.Items.Count == 0)
            {
                Console.WriteLine("판매할 아이템이 없습니다.");
                return;
            }

            //판매하기위해 입력한 아이템 번호(userNum)입력
            do
            {
                Console.WriteLine("판매할 아이템을 선택하세요(뒤로가기 0) : ");

            } while (int.TryParse(Console.ReadLine(), out userNum) == false || (userNum < 0 || userNum > player.Items.Count));

            //입력한 아이템 번호에 따라 아이템 판매 후, 인벤토리에서 제거. 또한, player의 능력치 다운그레이드. 0번은 메인메뉴
            if (userNum == 0)
            {
                return;
            }
            else
            {
                //롱소드 팔기
                if (player.Items[userNum - 1].Name == longSword.Name)
                {
                    longSword.DownPower(player);
                    player.Sell(userNum);
                }
                //천갑옷 팔기
                else if (player.Items[userNum - 1].Name == clothArmor.Name)
                {
                    clothArmor.DownDef(player);
                    player.Sell(userNum);
                }
                //이상한사탕 팔기
                else if (player.Items[userNum - 1].Name == strangeCandy.Name)
                {
                    player.Sell(userNum);
                }
            }
        }

        static void UICheck(Human player, int userNum, IAccessory strangeCandy)
        {
            Console.Clear();
            Console.WriteLine("==========아이템 확인 ==========");
            player.ShowStatus();
            Console.WriteLine();
            player.ShowInventory();

            //플레이어 인벤토리에 가지고 있는 아이템이 없다면 
            if (player.Items.Count == 0)
            {
                Console.WriteLine("사용할 아이템이 없습니다.");
                return;
            }

            //아이템 사용을 위해 입력한 아이템 번호(userNum)입력
            do
            {
                Console.WriteLine("사용할 아이템을 선택하세요(뒤로가기 0) : ");
            } while (int.TryParse(Console.ReadLine(), out userNum) == false || (userNum < 0 || userNum > player.Items.Count));


            //입력한 아이템 번호에 따라 사용가능한 아이템이면 사용 후 제거 및 player능력치 업데이트. 0번은 메인메뉴
            if (userNum == 0)
            {
                return;
            }
            if (player.Items[userNum - 1].Consumable == false)
            {
                Console.WriteLine("사용할 수 없는 아이템입니다.");
            }
            else
            {
                player.Use(userNum);
                strangeCandy.UpHp(player);
            }
        }
    }




}
