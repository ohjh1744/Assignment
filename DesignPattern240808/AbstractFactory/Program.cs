namespace AbstractFactory
{
    //  추상팩토리: 단일 개체가 아닌, 여러 클래스 종류의 개체를 생성하고 싶을때 사용.
    //
    //                                의존관계                                        의존관계
    //         Stage(추상클래스)    <-------      Congressman(추상클래스, 추상팩토리)             -------> Human(추상클래스)
    //           ^                                      ^                                                 ^
    //           |                                      |                                                 |
    //     Gunsan  Junju(일반클래스)         Congressman1   Congressman2(일반클래스)               Kim  Park(일반클래스)
    public abstract class Stage
    {
        public abstract void Name();
    }

    public class Gunsan : Stage
    {
        public override void Name()
        {
            Console.WriteLine("군산");
        }
    }

    public class Junju : Stage
    {
        public override void Name()
        {
            Console.WriteLine("전주");
        }
    }

    public abstract class Human
    {
        public abstract void Name();
    }

    public class Kim : Human
    {
        public override void Name()
        {
            Console.WriteLine("김");
        }
    }

    public class Park : Human
    {
        public override void Name()
        {
            Console.WriteLine("박");
        }
    }

    public abstract class Congressman
    {
        public abstract Stage CreateStage();
        public abstract Human CreateHuman();

    }

    public class Congressman1 : Congressman
    {
        public override Stage CreateStage()
        {
            return new Gunsan();
        }
        public override Human CreateHuman()
        {
            return new Kim();
        }
    }

    public class Congressman2 : Congressman
    {
        public override Stage CreateStage()
        {
            return new Junju();
        }
        public override Human CreateHuman()
        {
            return new Park();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Congressman abstractFactory = new Congressman1(); 
            Stage stage = abstractFactory.CreateStage();
            Human human = abstractFactory.CreateHuman();
        }
    }
}
