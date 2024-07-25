namespace ExtendMethod0725
{
    
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("아이디를 입력하세요 : ");
            string id = Console.ReadLine();

            if (id.IsAllowedID())
            {
                Console.WriteLine("ID가 유효합니다.");
            }
            else
            {
                Console.WriteLine("ID에 허용되지 않는 특수문자가 있습니다.");
            }
        }    
    }
    public static class Extended
    {
        public static bool IsAllowedID(this string id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                if (!char.IsLetterOrDigit(id[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }


}
