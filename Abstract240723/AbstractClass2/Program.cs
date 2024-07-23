using static AbstractClass2.Program;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace AbstractClass2
{
    internal class Program
    {
        public interface IGetMonster
        {
            public Monster GetMonster();
        }
        public enum MobType { Electric, Fire, Water, Grass , None}
        public abstract class Monster
        {      
            private int level;
            private MobType mobtype;
            private string name;
            protected Monster(string name, int level, MobType mobtype)
            {
                this.name = name;
                this.level = level;
                this.mobtype = mobtype;
            }
            public  abstract void BaseAttack();

            public int getLevel{ get { return level; }  }
            public MobType getType { get { return  mobtype; } }
            public string getName { get { return name; } }
        }

        public class Pikachu: Monster, IGetMonster
        {
            public Pikachu(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
      
            public override void BaseAttack()
            {
                Console.WriteLine("전광석화");
            }

            public Monster GetMonster()
            {
                return this;
            }
        }
        public class Squirtle : Monster, IGetMonster
        {
            public Squirtle(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
            public override void BaseAttack()
            {
                Console.WriteLine("물총발사");
            }

            public Monster GetMonster()
            {
                return this;
            }
        }
        public class Bulbasaur : Monster, IGetMonster
        {
            public Bulbasaur(string name, int level, MobType mobtype) : base(name, level, mobtype) { }

            public override void BaseAttack()
            {
                Console.WriteLine("덩굴채찍");
            }

            public Monster GetMonster()
            {
                return this;
            }
        }
        public class Charmander : Monster, IGetMonster
        {
            public Charmander(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
            public override void BaseAttack()
            {
                Console.WriteLine("화염방사");
            }
            public Monster GetMonster()
            {
                return this;
            }

        }

        public class Trainer
        {
            static Monster[] monsters = new Monster[6];

            public Trainer()
            {
                for(int i = 0; i <6; i++)
                {
                    monsters[i] = new Pikachu("없음", 0, MobType.None);
                }
                monsters[0] = new Pikachu("Pikachu", 3, MobType.Electric);
            }

            public void UpdateMonster(IGetMonster iGetMonster, int num)
            {
                Monster monster = iGetMonster.GetMonster();
                monsters[num-1] = monster; 
            }

            public void AllAttack()
            {
                foreach(Monster monster in monsters)
                {
                    if(monster.getType == MobType.None)
                    {
                        continue;
                    }
                    Console.WriteLine(monster.getLevel);
                    monster.BaseAttack();
                }
            }

        }

        static void Main(string[] args)
        {
            
            Trainer trainer = new Trainer();
            IGetMonster charmander = new Charmander("Charmander", 5, MobType.Fire);
            trainer.UpdateMonster(charmander, 2);

            IGetMonster bulbasaur = new Bulbasaur("Bulbasaur", 3, MobType.Grass);
            trainer.UpdateMonster(bulbasaur, 3);

            trainer.AllAttack();
        }
    }
}
