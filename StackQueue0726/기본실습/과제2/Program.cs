namespace StackQueue2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int day = 1;
            int remainTime = 8;
            Queue<int> queue = new Queue<int>();
            int[] result;
            int index = 0;

            // 작업배열 수 입력
            int.TryParse(Console.ReadLine(), out n);
            result = new int[n];

            // 각 작업의 걸리는 시간 입력
            for (int i = 0; i < n; i++)
            {
                int work = int.Parse(Console.ReadLine());
                queue.Enqueue(work);
            }

            // 작업 처리
            while (queue.Count > 0)
            {
                int work = queue.Dequeue();

                while (remainTime < work)
                {
                    work -= remainTime;
                    day++;
                    remainTime = 8;
                }

                result[index++] = day;
                remainTime -= work;

                // 작업시간이 8시간 딱떨어지면 초기화
                if (remainTime == 0)
                {
                    day++;
                    remainTime = 8;
                }
            }

            // 결과 출력
            foreach(int i in result)
            {
                Console.Write(i);
                Console.Write(" ");
            }

           
        }
    }
}