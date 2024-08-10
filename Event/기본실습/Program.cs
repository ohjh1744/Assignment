using System.Runtime.CompilerServices;

namespace Event
{

    public class Program
    {
        public class Player
        {
            private Armor curArmor;

            public void Equip(Armor armor)
            {
                Console.WriteLine($"플레이어가 {armor.name} 을/를 착용합니다.");
                curArmor = armor;
                curArmor.OnBreaked += UnEquip;
            }

            public void UnEquip()
            {
                Console.WriteLine($"플레이어가 {curArmor.name} 을/를 해제합니다.");
                curArmor.OnBreaked -= UnEquip;
                curArmor = null;
            }

            public void Hit()
            {
                Console.WriteLine("플레이어가 피해를 받는다.");
                curArmor.DecreaseDurability();
            }
        }

        public class Armor
        {
            public string name;
            private int durability;

            public event Action OnBreaked;

            public Armor(string name, int durability)
            {
                this.name = name;
                this.durability = durability;
            }

            public void DecreaseDurability()
            {
                durability--;
                if (durability <= 0)
                {
                    Break();
                }
            }

            private void Break()
            {
                Console.WriteLine("방어구가 부서졌습니다");
                OnBreaked?.Invoke();

            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Armor ammor = new Armor("갑옷", 3);
            player.Equip(ammor);

            player.Hit();
            player.Hit();
            player.Hit();
        }
    }

}
