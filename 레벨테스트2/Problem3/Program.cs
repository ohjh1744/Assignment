namespace Problem3
{
    internal class Program
    {
        //테스트 케이스 확인
        static void Main(string[] args)
        {
            List<int> array = new List<int>();
            List<int> answer = new List<int>();
            array.Add(4);
            array.Add(4);
            array.Add(4);
            array.Add(3);
            array.Add(3);

            answer = Solution(array);
            
            foreach(int i in answer)
            {
                Console.WriteLine(i);
            }
        }

        public static List<int> Solution(List<int> array)
        {
            List<int> answer = new List<int>();
            Queue<int> q = new Queue<int>();
            
            foreach(int i in array)
            {
                q.Enqueue(i);
            }

            int prevNum = 10;

            while(q.Count > 0)
            {
                int num = q.Dequeue();
                if(prevNum != num)
                {
                    answer.Add(num);
                    prevNum = num;
                }
            }
            return answer;
        }

       
    }
}
