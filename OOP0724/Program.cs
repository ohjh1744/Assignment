using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

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

        public class Human
        {
            Programmer programmer;
            public Human(string name)
            {
                programmer = new Programmer(name);
            }
            public void Introduce()
            {
                Console.WriteLine($"내이름은 {programmer.ShowName}이고, 프로그래머다");
            }
        }
        public class Programmer
        {
            private string name;
            public Programmer(string name)
            {
                this.name = name;
            }
            public string ShowName
            {
                get{ return name; }
            }
        }
        
        public class Designer
        {
            private string name;
            public Designer(string name)
            {
                this.name = name;
            }
            public string ShowName
            {
                get { return name; }
            }
        }

        static void Main(string[] args)
        {
       
           

        }


    }
}
