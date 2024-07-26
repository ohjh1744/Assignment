namespace list_Josephus
{
    internal class Program
    {
        static void Main()
        {
            int n;
            int k;
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            List<int> list = new List<int>(n);
            List<int> answer = new List<int>();
            
            for(int i = 1; i <= n; i++)
            {
                list.Add(i);
            }

            int index = 0;
            while(list.Count > 0)
            {
                index = (index + k - 1) % list.Count;
                answer.Add(list[index]);
                list.RemoveAt(index);
            }

            foreach(int i in answer)
            {
                Console.Write(i);
            }


            
        }

    }
}
