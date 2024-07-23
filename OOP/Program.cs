namespace OOP
{
    internal class Program
    {

        //(참고)정보처리기사도서, 마이크로소프트공식문서.
        //객체지향 구현이란?
        // 모든 대상을 객체로 나누고, 객체의 행동과 고유한 값을 정의하여 설꼐하는 방법
        // 객체를 만들고 조작하며 객체끼리 관계를 맺음으로써 다수의 객체가 함께 수행될수 있도록함
        // -> 절차지향 구현과 반대되는 개념, 코드 절차와 상관없는 구현! 
        // 객체지향 구현은 단위 모듈 구현!
        // 장점
        // 1. 효율적 관리 및 성능 향상 2. 전체적인 소프트웨어 복잡성 감소 3. 테스트 및 변경용이 4. 유지보수 용이
        // 이를 위해선 응집도는 높이고, 결합도는 낮춰야한다
        // 응집도와 결합도?
        //모듈: 독립된 하나의 소프트웨어 또는 하드웨어, 코드에서 하나의 함수, 클래스 등이 모듈이 될수있음.
        //응집도: 모듈 내부에서 구성요소 간에 밀접한 관계를 맺고 있는 정도 ex) 더하기라는 하나의 기능을 위해 모듈 내 요소들이 뭉침. 
        //결합도: 모듈과 모듈간의 관련성/의존 정도 ex)다른 클래스에서 다른 클래스의 함수를 호출.
        // 모듈의 독립성이 강해져 모듈내부는 견고해지고, 확장 및 유지보수가 좋아짐!

        //Solid
        //1. 단일 책임 원칙: 한 클래스는 하나의 기능만 책임진다 
        //2. 개방 폐쇄 원칙: 확장에는 열려있고, 수정에는 닫혀있다 -> 기존의 코드는 변경하지 않으면서 기능 추가.
        //3. 리스코프 치환원칙: 자식클래스는 언제나 자신의 부모클래스를 대체할 수 있어야 한다. -> 부모 클래스가 들어갈 자리에 자식 클래스를 넣어도 계획대로 진행!
        //4. 인터페이스 분리 원칙: 자신이 사용하지 않는 인터페이스는 구현x -> 사용하지 않은 인터페이스에 영향을 받으면 안된다
        //5. 의존성 역전 원칙: 자주 변화하는 것보단 변화가 거의 없는 거에 의존해야한다. -> 구체적 클래스보단 인터페이스나 추상클래스에 의존관계를 맺자.

        //1. 단일 책임원칙 예시
        //안좋은 예시
        class Human
        {
            //사람관련 기능
            public void Eat() { Console.WriteLine("먹다"); }
            public void Sleep() { Console.WriteLine("자다"); }
            public void Walk() { Console.WriteLine("걷다"); }

            //프로그래머관련 기능
            public void Develop() { Console.WriteLine("개발하다"); }
            public void ReFactoring() { Console.WriteLine("재개발하다"); }
            public void Maintain() { Console.WriteLine("유지하다"); }
        }

        //좋은 예시
        class HumanGood
        {
            //사람관련 기능
            public void Eat() { Console.WriteLine("먹다"); }
            public void Sleep() { Console.WriteLine("자다"); }
            public void Walk() { Console.WriteLine("걷다"); }

        }

        class Programmer
        {
            //프로그래머관련 기능
            public void Develop() { Console.WriteLine("개발하다"); }
            public void ReFactoring() { Console.WriteLine("재개발하다"); }
            public void Maintain() { Console.WriteLine("유지하다"); }
        }

        //2. 개방-폐쇄 원칙과 의존성 역전 원칙
        //안좋은 예시  Desiner가 introduce 함수를 사용하려면 introduce 안에 switch문이나 오버로딩을 하는 등 기존 클래스를 수정해야한다.
        class HumanBad2
        {
            public void Introduce(ProgrammerBad2 programmer, string name)
            {
                Console.WriteLine($"내이름은 {name}이고, 프로그래머다");
            }
        }
        class ProgrammerBad2
        {
            string name;
        }
        class DesignerBad2
        {
            string name;
        }

        
        //3. 리스코프 치환 원칙 -> 자식인 Designer가 부모 Programmer를 대신해서 일을 할수가 없다! ProgarmmerBad3 programmer = new DesignerBad()
        public class ProgrammerBad3
        {
            public virtual void DoWork()
            {
                Console.WriteLine("개발하다");
            }
        } 

        public class DesignerBad3: ProgrammerBad3
        {
            public override void DoWork()
            {
                Console.WriteLine("디자인하다");
            }
        }

        //4.인터페이스 분리 원칙 -> 디자이너는 C언어를 사용하지 않는다! 불필요한 의존
        public interface Resource
        {
            void Xecel();
            void Clanguage();
        }

        public class ProgrammerBad4: Resource
        {
            public void Xecel()
            {
                Console.WriteLine("Use Xecel");
            }
            public void Clanguage()
            {
                Console.WriteLine("Use Clanguage");
            }
        }

        public class DesignerBad4 : Resource
        {
            public void Xecel()
            {
                Console.WriteLine("Use Xecel");
            }
            public void Clanguage()
            {
                Console.WriteLine("Use Clanguage");
            }
        }
        //5.  designer 변수를 가지고 있음, 프로그래머가 디자이너를 의존하는 형태 -> 디자이너의 값이 변화함에 따라 프로그래머도 변화될수있음.
        class ProgrammerBad5
        {
            private DesignerBad2 designer;
            public ProgrammerBad5(DesignerBad5 humdesigneran)
            {
                this.designer = designer;
            }

            public void ProgrammerEat() { designer.Eat(); }

            //프로그래머관련 기능
            public void Develop() { Console.WriteLine("개발하다"); }
            public void ReFactoring() { Console.WriteLine("재개발하다"); }
            public void Maintain() { Console.WriteLine("유지하다"); }
        }
        class DesignerBad5
        {
            public void Eat() { Console.WriteLine("디자이너가 밥을 먹다"); }

            //디자이너관련 기능
            public void Draw() { Console.WriteLine("그리다"); }
            public void Erase() { Console.WriteLine("지우다"); }
            public void Design() { Console.WriteLine("디자인하다"); }
        }


        static void Main(string[] args)
        {
            ProgrammerBad3 programmer = new ProgrammerBad3();
            programmer.DoWork();
        }

        // solid원칙을 잘 지킨 코드
        public abstract class AbsHuman
        {
            public abstract void Eat();
            public abstract void Sleep();
            public abstract void Walk();
        }

        class ProgrammerGood2 : AbsHuman
        {
            public override void Eat()
            {
                Console.WriteLine("프로그래머가 밥을 먹다");
            }
            public override void Sleep()
            {
                Console.WriteLine("프로그래머가 자다");
            }
            public override void Walk()
            {
                Console.WriteLine("프로그래머가 걷다");
            }

            //프로그래머관련 기능
            public void Develop() { Console.WriteLine("개발하다"); }
            public void ReFactoring() { Console.WriteLine("재개발하다"); }
            public void Maintain() { Console.WriteLine("유지하다"); }
        }

        class DesignerGood2 : AbsHuman
        {
            public override void Eat()
            {
                Console.WriteLine("디자이너가 밥을 먹다");
            }
            public override void Sleep()
            {
                Console.WriteLine("디자이너가 자다");
            }
            public override void Walk()
            {
                Console.WriteLine("디자이너가 걷다");
            }
            //디자이너관련 기능
            public void Draw() { Console.WriteLine("그리다"); }
            public void Erase() { Console.WriteLine("지우다"); }
            public void Design() { Console.WriteLine("디자인하다"); }
        }
    }
}
