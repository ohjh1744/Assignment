namespace AbstractClass2
{
    // 문제에서 Trainer 클래스 생성자에 자동으로 피카츄를 배열의 첫 번째에 담기게 하는 코드를 작성하라했지만
    // 개인적으로 피카츄뿐만 아니라 원하는 포켓몬을 배열의 첫 번째에 담기게 하도록 코드를 구성해보고 싶어서 새롭게 구현해봤습니다.
    // 최대한 solid원칙을 지키면서 구현해봤습니다.
    // 추상클래스 Monster를 만들어 각 포켓몬클래스에 상속하였고
    // Trainer 클래스는 일반 포켓몬 클래스가 아닌, 추상클래스 Monster 의존.
    // Solid원칙에 위배되지 않게 잘 구현했는지 피드백해주셨으면 감사하겠습니다!
    // 또 그 외에 피드백도 환영입니다!
    internal class Program
    {

        public enum MobType { Electric, Fire, Water, Grass, None }
        public abstract class Monster
        {

            private string name;
            private int level;
            private MobType type;

            protected Monster(string name, int level, MobType mobtype)
            {
                this.name = name;
                this.level = level;
                this.type = mobtype;
            }

            public abstract void BaseAttack();

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Level
            {
                get { return level; }
                set { level = value; }
            }

            public MobType Type
            {
                get { return type; }
                set { type = value; }
            }
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
            public int monsterNum;
            Monster[] monsters = new Monster[6];

            public Trainer(Monster monster)
            {
                monsterNum = 0;
                //만약 꼭 생성자안에 포켓몬을 배열에 넣을 필요가 없다면 TakeMonster 내용과 비슷하기때문에
                //(개인적으로는 아래 두줄은 생략하고싶긴합니다!)
                monsters[monsterNum] = monster;
                monsterNum++;
            }

            public void TakeMonster(Monster monster)
            {
                if(monsterNum == 6)
                {
                    Console.WriteLine("더 이상 포켓몬을 잡을 수 없습니다.");
                }
                monsters[monsterNum] = monster;
                monsterNum++;
            }

            public void AllAttack()
            {
                for (int i = 0; i < monsterNum; i++)
                {
                    if (monsters[i].Type == MobType.None)
                    {
                        continue;
                    }
                    monsters[i].BaseAttack();
                }
            }

        }

        static void Main(string[] args)
        {

            Monster pikachu = new Pikachu("Pikachu", 2, MobType.Electric);
            Trainer trainer = new Trainer(pikachu);

            Monster  charmander = new Charmander("Charmander", 5, MobType.Fire);
            trainer.TakeMonster(charmander);

            Monster bulbasaur = new Bulbasaur("Bulbasaur", 3, MobType.Grass);
            trainer.TakeMonster(bulbasaur);

            trainer.AllAttack();
        }
    }
}