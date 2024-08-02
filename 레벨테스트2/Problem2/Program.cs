namespace Problem2
{
    public abstract class Monster
    {
        protected string name;

        protected Monster() { }
  
        protected Monster(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public abstract void Attack();
    
    }

    public class Pikachu : Monster
    {
        public Pikachu()
        {
            base.name = "피카츄";
        }
        public Pikachu(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine("백만볼트!");
        }
    }

    public class Charmander : Monster
    {
        public Charmander()
        {
            base.name = "파이리";
        }
        public Charmander(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine("화염방사!");
        }
    }

    public class Squirtle : Monster
    {
        public Squirtle()
        {
            base.name = "꼬북이";
        }
        public Squirtle(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine("물총발사!");
        }
    }

    public class Bulbasaur : Monster
    {
        public Bulbasaur()
        {
            base.name = "이상해씨";
        }
        public Bulbasaur(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine("덩굴채찍!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Monster[] monsters = new Monster[5];
            monsters[0] = new Pikachu();
            monsters[1] = new Charmander();
            monsters[2] = new Squirtle();
            monsters[3] = new Bulbasaur();
            monsters[4] = new Pikachu("털뭉치");

            foreach(Monster monster in monsters)
            {
                Console.WriteLine($"{monster.Name} 공격해!");
                monster.Attack();
                Console.WriteLine();
            }
        }
    }
}
