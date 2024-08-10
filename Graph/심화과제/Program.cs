namespace Graph2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] graph;
            graph = new bool[,]
            {
                {true, false, false, true, false, false, false, false},
                {true, true, false, false, false, false, false, false},
                {true, false, true, false, false, false, true, false},
                {false, true, false, true, false, true, false, false},
                {false, false, false, false, true, false, false, true},
                {false, true, false, true, false, true, false, false},
                {false, false, true, false, true, true, true, true},
                {false, false, false, false, false, false, false, true}
            };

            for(int i = 0; i < 8; i++)
            {
                Console.WriteLine($"{i}노드: ");
                for(int j = 0; j < 8; j++)
                {
                    if (graph[i,j] == true && (i != j))
                    {
                        Console.WriteLine($"   {j}노드");
                    }
                }
            }





         
            
        }
    }

}
