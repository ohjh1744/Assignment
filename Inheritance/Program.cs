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
            public virtual void DoSkillQ()
            {
                Console.WriteLine(("스킬q발사!"));
            }
            public virtual void DoSkillW()
            {
                Console.WriteLine(("스킬w발사"));
            }
            public virtual void DoSkillE()
            {
                Console.WriteLine(("스킬e발사!"));
            }
        }

        public class Garen : LolChampion
        {
            public override void DoSkillQ()
            {
                Console.WriteLine(("결정타"));
            }
            public override void DoSkillW()
            {
                Console.WriteLine(("용기"));
            }
            public override void DoSkillE()
            {
                Console.WriteLine(("심판"));
            }
        }

        public class Graves : LolChampion
        {
            public override void DoSkillQ()
            {
                Console.WriteLine(("화약 역류"));
            }
            public override void DoSkillW()
            {
                Console.WriteLine(("연막탄"));
            }
            public override void DoSkillE()
            {
                Console.WriteLine(("빨리 뽑기"));
            }
        }

        public class Gnar : LolChampion
        {
            public override void DoSkillQ()
            {
                Console.WriteLine(("부메랑 던지기"));
            }
            public override void DoSkillW()
            {
                Console.WriteLine(("슝슝"));
            }
            public override void DoSkillE()
            {
                Console.WriteLine(("폴짝"));
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
