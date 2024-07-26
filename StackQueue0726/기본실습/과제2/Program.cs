namespace StackQueue2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int day = 1;
            int[] temp;
       
            //작업배열 수 입력
            int.TryParse(Console.ReadLine(), out n);
            temp = new int[n];

            //각 작업의 걸리는 시간 입력
            for(int i = 0; i < n; i++)
            {
                int.TryParse(Console.ReadLine(), out temp[i]);
            }


            int num = 0;
            int curtime = 0;
            int nexttime = 0;
            Queue<int> queue = new Queue<int>();

            while (num < n)
            {
                int work = temp[num];
                curtime = nexttime;
                nexttime = curtime + work;

                if (nexttime < 8)
                {
                    queue.Enqueue(day);
                    num++;
                }
                else if(nexttime == 8)
                {
                    queue.Enqueue(day);
                    num++;
                    nexttime = 0;
                    day++;
                }
                else if(nexttime > 8)
                {
                    day++;
                    temp[num] = work - (8-curtime);
                    nexttime = 0;
                }
            }
           

            while (queue.Count > 0)
            {
                Console.Write($"{queue.Dequeue()}");
            }

        }
    }
}
