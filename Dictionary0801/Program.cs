namespace Dictionary0801
{
    internal class Program
    {
        public static Dictionary<string, Monster> dict;
        public class MonsterData
        {
            public static void Initialize()
            {
                dict = new Dictionary<string, Monster>();
                dict.Add("피카츄", new Monster("피카츄"));
                dict.Add("라이츄", new Monster("라이츄"));
                dict.Add("파이리", new Monster("파이리"));
                dict.Add("꼬부기", new Monster("꼬부기"));
                dict.Add("가랴도스", new Monster("가랴도스"));
            }
               

        }
        public class Monster
        {
            private string name;
            public Monster(string name)
            {
                this.name = name;
            }

            public string GetName { get { return name; } }
        }
        static void Main(string[] args)
        {

            MonsterData.Initialize();

            Monster[] monsters = new Monster[5];

            Monster dicmonster;
            dict.TryGetValue("피카츄", out dicmonster);
            monsters[0] = new Monster(dicmonster.GetName);

            dict.TryGetValue("라이츄", out dicmonster);
            monsters[1] = new Monster(dicmonster.GetName);

            dict.TryGetValue("파이리", out dicmonster);
            monsters[2] = new Monster(dicmonster.GetName);

            dict.TryGetValue("꼬부기", out dicmonster);
            monsters[3] = new Monster(dicmonster.GetName);

            dict.TryGetValue("가랴도스", out dicmonster);
            monsters[4] = new Monster(dicmonster.GetName);

            foreach (Monster monster in monsters)
            {
                Console.WriteLine($"몬스터이름: {monster.GetName}");
            }


        }
    }
}

