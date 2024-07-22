using System.Numerics;

namespace Constructor
{
    internal class Program
    {
        class Monster
        {
            private int hp;

            public Monster(int hp)
            {
                this.hp = hp;
            }
            public int ShowHp
            {
                get { return hp; }
            }

        }
        class Trainer
        {
            private string name;
            private List<Monster> monsters;

            public Trainer(string name)
            {
                this.name = name;
                this.monsters = new List<Monster>();
            }

            public void CreateMonster(int hp)
            {
                monsters.Add(new Monster(hp));
            }

            public void ShowInformation()
            {
                Console.WriteLine($"트레이너 이름은: {name}");

                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.WriteLine($"{i}번째 몬스터의 체력: {monsters[i].ShowHp}");
                }
            }

        }
        static void Main(string[] args)
        {

            Trainer trainer = new Trainer("오준혁");
            trainer.CreateMonster(50);
            trainer.CreateMonster(60);
            trainer.ShowInformation();
        }

    }


}
