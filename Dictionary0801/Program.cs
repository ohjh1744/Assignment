namespace Dictionary0801
{
    internal class Program
    {
        public static Dictionary<string, int> dict = new Dictionary<string, int>();
        public class MonsterData
        {
            public MonsterData(string name, int level)
            {
                dict.Add(name, level);
            }

        }
        public class Monster
        {
            private string name;
            private int level;
            public Monster(string name)
            {
                this.name = name;
                dict.TryGetValue(name, out level);
            }

            public string GetName { get { return name; } }
            public int GetLevel
            {
                get { return level; }
            }
        }
        static void Main(string[] args)
        {

            MonsterData monsterData;
            monsterData = new MonsterData("피카츄", 1);
            monsterData = new MonsterData("라이츄", 2);
            monsterData = new MonsterData("파이리", 3);
            monsterData = new MonsterData("꼬부기", 4);
            monsterData = new MonsterData("가랴도스", 5);

            Monster[] monsters = new Monster[5];

            monsters[0] = new Monster("피카츄");
            monsters[1] = new Monster("라이츄");
            monsters[2] = new Monster("파이리");
            monsters[3] = new Monster("꼬부기");
            monsters[4] = new Monster("가랴도스");

            foreach (Monster monster in monsters)
            {
                Console.WriteLine($"몬스터이름: {monster.GetName} 몬스터레벨:{monster.GetLevel}");
            }


        }
    }
}

