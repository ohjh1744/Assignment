namespace AbstractClass2
{
    // 문제에서 Trainer 클래스 생성자에 자동으로 피카츄를 배열의 첫 번째에 담기게 하는 코드를 작성하라했지만
    // 개인적으로 피카츄뿐만 아니라 원하는 포켓몬을 배열의 첫 번째에 담기게 하도록 코드를 구성해보고 싶어서 새롭게 구현해봤습니다.
    // 인터페이스와 추상클래스, solid원칙을 공부한 시점에서 최대한 solid원칙을 지키면서 구현해봤습니다.
    // 추상클래스 Monster와 인터페이스 Itameable을 만들어 각 포켓몬클래스에 상속을 받도록하였고,
    // Trainer 클래스는 일반 포켓몬 클래스가 아닌, 추상클래스 Monster와 인터페이스 Itameable을 의존하도록 구현하여.
    // Solid원칙에 위배되지 않게 잘 구현했는지 피드백해주셨으면 감사하겠습니다!
    // 또 그 외에 피드백도 환영입니다!
    internal class Program
    {
        //길들일 수 있는 포켓몬이면 그 포켓몬 return
        public interface ITameable
        {
            public Monster TameableMonster();
        }
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

        public class Pikachu : Monster, ITameable
        {
            public Pikachu(string name, int level, MobType mobtype) : base(name, level, mobtype) { }

            public override void BaseAttack()
            {
                Console.WriteLine("전광석화");
            }

            public Monster TameableMonster()
            {
                return this;
            }
        }
        public class Squirtle : Monster, ITameable
        {
            public Squirtle(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
            public override void BaseAttack()
            {
                Console.WriteLine("물총발사");
            }

            public Monster TameableMonster()
            {
                return this;
            }
        }
        public class Bulbasaur : Monster, ITameable
        {
            public Bulbasaur(string name, int level, MobType mobtype) : base(name, level, mobtype) { }

            public override void BaseAttack()
            {
                Console.WriteLine("덩굴채찍");
            }

            public Monster TameableMonster()
            {
                return this;
            }
        }
        public class Charmander : Monster, ITameable
        {
            public Charmander(string name, int level, MobType mobtype) : base(name, level, mobtype) { }
            public override void BaseAttack()
            {
                Console.WriteLine("화염방사");
            }
            public Monster TameableMonster()
            {
                return this;
            }

        }

        public class Trainer
        {
            Monster[] monsters;
            public int monsterNum;

            public Trainer(ITameable itameMonster)
            {
                monsters = new Monster[6];
                monsterNum = 0;
                //만약 생성자안에 꼭 포켓몬을 배열에 넣을 필요가 없다면 UpdateMonster함수 내용과 비슷하기때문에
                //(개인적으로는 아래 두줄은 생략하고싶긴합니다!)
                monsters[monsterNum] = itameMonster.TameableMonster();
                monsterNum++;
            }

            public void UpdateMonster(ITameable itameMonster)
            {
                Monster monster = itameMonster.TameableMonster();
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

            ITameable pikachu = new Pikachu("Pikachu", 2, MobType.Electric);
            Trainer trainer = new Trainer(pikachu);

            ITameable charmander = new Charmander("Charmander", 5, MobType.Fire);
            trainer.UpdateMonster(charmander);

            ITameable bulbasaur = new Bulbasaur("Bulbasaur", 3, MobType.Grass);
            trainer.UpdateMonster(bulbasaur);

            trainer.AllAttack();
        }
    }
}