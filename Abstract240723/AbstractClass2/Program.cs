using static AbstractClass2.Program;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace AbstractClass2
{
    internal class Program
    {
        public enum MobType { Electric, Fire, Water, Grass , None}
        public abstract class Monster
        {
           
            private int level;
            private MobType mobtype = MobType.Electric;
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

        public class Pikachu: Monster
        {
            public Pikachu(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
      
            public override void BaseAttack()
            {
                Console.WriteLine("전광석화");
            }
        }
        public class Squirtle : Monster
        {
            public Squirtle(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
            public override void BaseAttack()
            {
                Console.WriteLine("물총발사");
            }
        }
        public class Bulbasaur : Monster
        {
            public Bulbasaur(string name, int level, MobType mobtype) : base(name, level, mobtype) { }

            public override void BaseAttack()
            {
                Console.WriteLine("덩굴채찍");
            }
        }
        public class Charmander : Monster
        {
            public Charmander(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
            public override void BaseAttack()
            {
                Console.WriteLine("화염방사");
            }
        }

        public class Trainer
        {
            Monster[] monsters = new Monster[6];
           
            
            public Trainer()
            {
                for(int i = 0; i <6; i++)
                {
                    monsters[i] = new Pikachu("없음", 0, MobType.None);
                }
                monsters[0] = new Pikachu("Pikachu", 3, MobType.Electric);
            }

            public void CreateMonster(int num , string name, int level, MobType mobtype)
            {
                switch (name)
                {
                    case "Pikachu":
                        monsters[num] = new Pikachu(name, level, mobtype);
                        break;
                    case "Squirtle":
                        monsters[num] = new Squirtle(name, level, mobtype);
                        break;
                    case "Bulbasaur":
                        monsters[num] = new Bulbasaur(name, level, mobtype);
                        break;
                    case "Charmander":
                        monsters[num] = new Charmander(name, level, mobtype);
                        break;
                }
                 
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
            trainer.CreateMonster(1, "Charmander", 5, MobType.Fire);
            trainer.AllAttack();
        

        }
    }
}
