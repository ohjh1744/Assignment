namespace AbstractClass2
{
    public enum MobType { Electric, Fire, Water, Grass, None }

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

        public abstract void BaseAttack();

        public int GetLevel { get { return level; } }
        public MobType GetType { get { return mobtype; } }
        public string GetName { get { return name; } }
    }

    public class Pikachu : Monster
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
        private Monster[] monsters = new Monster[6];

        public Trainer()
        {
            for (int i = 0; i < 6; i++)
            {
                monsters[i] = new Pikachu("없음", 0, MobType.None);
            }
            monsters[0] = new Pikachu("Pikachu", 3, MobType.Electric);
        }

        public void UpdateMonster(Monster monster, int num)
        {
            monsters[num - 1] = monster;
        }

        public void AllAttack()
        {
            foreach (Monster monster in monsters)
            {
                if (monster.GetType == MobType.None)
                {
                    continue;
                }
                monster.BaseAttack();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Trainer trainer = new Trainer();
            Charmander charmander = new Charmander("Charmander", 5, MobType.Fire);
            trainer.UpdateMonster(charmander, 2);

            Bulbasaur bulbasaur = new Bulbasaur("Bulbasaur", 3, MobType.Grass);
            trainer.UpdateMonster(bulbasaur, 3);

            trainer.AllAttack();
        }
    }
}
