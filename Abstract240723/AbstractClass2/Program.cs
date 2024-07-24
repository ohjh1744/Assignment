using static AbstractClass2.Program;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace AbstractClass2
{
    internal class Program
    {
        //각 포켓몬마다 상속을 하고, Trainer함수의 UpdateMonster의 매개변수로 사용하여 포켓몬의 정보를 가져옴.
        public interface ITakeMonster
        {
            public Monster TakeMonster();
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

        public class Pikachu: Monster, ITakeMonster
        {
            public Pikachu(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
      
            public override void BaseAttack()
            {
                Console.WriteLine("전광석화");
            }

            public Monster TakeMonster()
            {
                return this;
            }
        }
        public class Squirtle : Monster, ITakeMonster
        {
            public Squirtle(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
            public override void BaseAttack()
            {
                Console.WriteLine("물총발사");
            }

            public Monster TakeMonster()
            {
                return this;
            }
        }
        public class Bulbasaur : Monster, ITakeMonster
        {
            public Bulbasaur(string name, int level, MobType mobtype) : base(name, level, mobtype) { }

            public override void BaseAttack()
            {
                Console.WriteLine("덩굴채찍");
            }

            public Monster TakeMonster()
            {
                return this;
            }
        }
        public class Charmander : Monster, ITakeMonster
        {
            public Charmander(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
            public override void BaseAttack()
            {
                Console.WriteLine("화염방사");
            }
            public Monster TakeMonster()
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

            public void UpdateMonster(ITakeMonster itakeMonster, int num)
            {
                Monster monster = itakeMonster.TakeMonster();
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
                    monster.BaseAttack();
                }
            }

        }

        static void Main(string[] args)
        {
            
            Trainer trainer = new Trainer();
            ITakeMonster charmander = new Charmander("Charmander", 5, MobType.Fire);
            trainer.UpdateMonster(charmander, 2);

            ITakeMonster bulbasaur = new Bulbasaur("Bulbasaur", 3, MobType.Grass);
            trainer.UpdateMonster(bulbasaur, 3);

            trainer.AllAttack();
        }
    }
}
