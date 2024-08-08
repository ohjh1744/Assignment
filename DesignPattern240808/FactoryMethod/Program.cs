namespace FactoryMethod
{
    //                                의존관계
    //         Stage(추상클래스)    <-------      StageFactory(추상클래스)
    //           ^                                      ^
    //           |                                      |
    //     Gunsan  Junju(일반클래스)         CreateGunsan   CreateJunju(일반클래스) 
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

    public abstract class StageFactory
    {
        public abstract Stage CreateStage();

    }

    public class CreateGunsan : StageFactory
    {
        public override Stage CreateStage()
        {
            return new Gunsan();  
        }                         
    }

    public class CreateJunju : StageFactory
    {
        public override Stage CreateStage()
        {
            return new Junju();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StageFactory factory = new CreateGunsan(); //  Program과 CreateGunsan은 서로 아예 의존관계가 아니며 Program은 객체지향 구현할때 예외시켜도 됨
            Stage stage = factory.CreateStage();
        }
    }
}
