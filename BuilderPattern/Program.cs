namespace BuilderPattern
{
    //                               
    //                                  (의존)                        (의존)
    //          animal (추상클래스)     <----       AnimalBuilder     ------>     Factory   (추상클래스)  
    //            ^                                                                  ^ 
    //            |                                                                  |
    //   Mammalia    Bird  (일반클래스)                               MammaliaCreate   BirdCreate (일반클래스)  
    //
    //

    public abstract class Animal
    {
        protected string name;
        protected string prey;
        protected int price;
        public Animal() { }
        public string Name { get { return name; } set { name = value; } }
        public string Prey { get { return prey; } set { prey = value; } }
        public int Price { get { return price; } set { price = value; } }
    }

    public class Mammalia : Animal
    {
        public Mammalia()
        {
            base.name = "";
            base.prey = "";
            base.price = 0;
        }
    }

    public class Bird : Animal
    {
        public Bird()
        {
            base.name = "";
            base.prey = "";
            base.price = 0;
        }
    }

    public abstract class Factory
    {
        public abstract Animal AnimalCreate();
    }

    public class MammaliaCreate : Factory
    {
        public override Animal AnimalCreate()
        {
            return new Mammalia();
        }
    }

    public class BirdCreate : Factory
    {
        public override Animal AnimalCreate()
        {
            return new Bird();
        }
    }

    public  class AnimalBuilder
    {
        private Animal animal;   
        public AnimalBuilder(Factory factory)
        {
            animal = factory.AnimalCreate();
        }

        public void SetName(string name)
        {
            animal.Name = name;
        }

        public void SetPrey(string prey)
        {
            animal.Prey = prey;
        }

        public void SetPrice(int price)
        {
            animal.Price = price;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new MammaliaCreate();
            AnimalBuilder animalBuilder = new AnimalBuilder(factory);

            animalBuilder.SetName("바다사자");
            animalBuilder.SetPrey("참치");
            animalBuilder.SetPrice(1000000);

            factory = new BirdCreate();
            AnimalBuilder animalBuilder2 = new AnimalBuilder(factory);

            animalBuilder.SetName("비둘기");
            animalBuilder.SetPrey("과자");
            animalBuilder.SetPrice(5000);

        }
    }
}
