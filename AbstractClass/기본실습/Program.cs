namespace Abstract
{
    internal class Program
    {


        public abstract class LolChampion
        {
            protected string name;
            protected int hp;
            protected int level;
            public abstract void DoSkillQ();

            public abstract void DoSkillW();

            public abstract void DoSkillE();

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

        //과제 2
        // 추상클래스: 직접적으로 인스턴스를 생성 할 수 없는 클래스로, 다른 클래스들이 주로 상속받아 사용하도록 하는 클래스
        // 오버라이딩:상속관계에서 부모 클래스의 메서드를 자식 클래스에서 재정의하는 다형성 방법중 하나
        // 오버로딩: 메서드 명은 동일하지만, 매개변수와 반환타을 다르게한 다형성 방법중 하나
        static void Main(string[] args)
        {
           

        }
    }
}
