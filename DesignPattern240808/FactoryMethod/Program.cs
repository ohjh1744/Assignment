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
            return new Gunsan();  //CreateGunsan이라는 구체적 클래스에서 Gunsan이라는 구체적 클래스를 return값으로 받지만, Type은 Stage이므로 추상클래스에 의존하여
        }                         //의존성 역전원칙에 위배되는게 아닌지?
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
            StageFactory factory = new CreateGunsan(); // 마찬가지로 Program이라는 구체적클래스에서 CreateGunsan이라는 구체적 클래스를 사용하지만, StageFactory를 type으로 사용하므로 추상클래스를 의존하여 의존성 역전원칙을 위반하는게 아닌지?
            Stage stage = factory.CreateStage();
        }
    }
}
