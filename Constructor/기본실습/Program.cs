﻿using System.Reflection.Metadata.Ecma335;

namespace Constructor
{
    internal class Program
    {

        //  이름과 체력을 기본적으로 갖고있는 포켓몬을 잡으면
        // Trainer가 본인의 Monster배열안에 저장하는식으로 재구성해서 구현.
        // Trainer의 UpdateMonster에서 포켓몬의 속성바꾸기 가능.
        public abstract class Monster
        {
            private int hp;
            private string name;

            protected Monster(string name, int hp)
            {
                this.name = name;
                this.hp = hp;
            }
         
            public int Hp
            {
                get { return hp; }
                set { hp = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

        }

        public class Poketmon : Monster
        {
            public Poketmon(string name, int hp) : base(name, hp) { }

        }

        public class Trainer
        {
            private string name;
            private Monster[] monsters = new Monster[6];
            private int numHave = 0;

            public Trainer(string name)
            {
                this.name = name;
            }

            public void TakeMonster(Monster monster)
            {
                if (numHave >= 6)
                {
                    Console.WriteLine("포켓몬을 더이상 가질 수 없습니다.");    
                }
                else
                {
                    monsters[numHave++] = monster;
                }           
            }

            public void UpdateMonster(int monsterNum , string name, int hp)
            {
                if(monsterNum < 1 || monsterNum > numHave)
                {
                    Console.WriteLine("잘못된 포켓몬 숫자입니다.");
                }
                else
                {
                    monsters[monsterNum-1].Name = name;
                    monsters[monsterNum-1].Hp = hp;
                }
               
            }

            public void ShowInformation()
            {
                Console.WriteLine($"제 이름은 {name}입니다.");
                for (int i = 0; i < numHave; i++)
                {
                    Console.WriteLine($"{i}번째 포켓몬: {monsters[i].Name}");
                }
            }

        }

        static void Main(string[] args)
        {

            Trainer trainer = new Trainer("오준혁");
            Monster pikachu = new Poketmon("피카츄", 100);
            trainer.TakeMonster(pikachu);
            trainer.ShowInformation();
            trainer.UpdateMonster(1, "거북몬", 50);
            trainer.ShowInformation();
        }

    }


}
