using System.Diagnostics;

namespace Inheritance
{
    internal class Program
    {

        public class LolChampion
        {
            protected string name;
            protected int hp;
            protected int level;
            public virtual void SkillQ()
            {
                Console.WriteLine(("스킬q발사!"));
            }
            public virtual void SkillW()
            {
                Console.WriteLine(("스킬w발사"));
            }
            public virtual void SkillE()
            {
                Console.WriteLine(("스킬e발사!"));
            }
        }

        public class Garen : LolChampion
        {
            public override void SkillQ()
            {
                Console.WriteLine(("결정타"));
            }
            public override void SkillW()
            {
                Console.WriteLine(("용기"));
            }
            public override void SkillE()
            {
                Console.WriteLine(("심판"));
            }
        }

        public class Graves : LolChampion
        {
            public override void SkillQ()
            {
                Console.WriteLine(("화약 역류"));
            }
            public override void SkillW()
            {
                Console.WriteLine(("연막탄"));
            }
            public override void SkillE()
            {
                Console.WriteLine(("빨리 뽑기"));
            }
        }

        public class Gnar : LolChampion
        {
            public override void SkillQ()
            {
                Console.WriteLine(("부메랑 던지기"));
            }
            public override void SkillW()
            {
                Console.WriteLine(("슝슝"));
            }
            public override void SkillE()
            {
                Console.WriteLine(("폴짝"));
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
