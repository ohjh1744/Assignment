using System.Numerics;

namespace Constructor
{
    internal class Program
    {

        public abstract class Monster
        {
            protected Tuple<string, int>[] monsterStatus;
            public abstract void CreateMonster(int num, string name, int hp);
            public abstract void ShowMonster(int num);

        }

        public class Trainer : Monster
        {
            private string name;

            public Trainer(string name)
            {
                this.name = name;
                base.monsterStatus = new Tuple<string, int>[6];
            }
            public override void CreateMonster(int num, string name, int hp)
            {
                monsterStatus[num] = new Tuple<string, int>(name, hp);
            }
            public override void ShowMonster(int num)
            {
                Console.WriteLine($"{num}번째 몬스터이름: {monsterStatus[num].Item1} ");
                Console.WriteLine($"{num}번째 체력: {monsterStatus[num].Item2} ");
            }

        }
        static void Main(string[] args)
        {

            Trainer trainer = new Trainer("오준혁");
            trainer.CreateMonster(1, "피카츄", 50);
            trainer.CreateMonster(2, "가라도스", 60);
            trainer.ShowMonster(1);
            trainer.ShowMonster(2);

        }

    }


}
