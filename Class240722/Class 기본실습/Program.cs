using System.Runtime.InteropServices;

namespace StudyClass
{
    class Chracter
    {
        protected int level;
        protected float hp = 100;
        protected float speed;
        protected float damage;

        public void ForWard()
        {
            Console.WriteLine("전진!");
        }

        public void BackWard()
        {
            Console.WriteLine("후진!");
        }

        public void Left()
        {
            Console.WriteLine("좌회전(90도)!");
        }

        public void Right()
        {
            Console.WriteLine("우회전(90도)!");
        }
        public void Attack()
        {
            Console.WriteLine("공격!");
        }

        public void GetDamage()
        {
            hp -= 10;
            Console.WriteLine("피격!");
        }

    }
    
    internal class Program
    {
       
    }
}
