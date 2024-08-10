namespace Graph0801
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(8);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 0);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 6);
            graph.AddEdge(3, 1);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 7);
            graph.AddEdge(5, 1);
            graph.AddEdge(5, 3);
            graph.AddEdge(6, 2);
            graph.AddEdge(6, 4);
            graph.AddEdge(6, 5);
            graph.AddEdge(6, 7);

            graph.PrintGraph();

        }
    }

    public class Graph
    {
        private List<int>[] _list;

        public Graph(int n)
        {
            _list = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                _list[i] = new List<int>();
            }
        }
        public void AddEdge(int from, int to)
        {
            _list[from].Add(to);
        }

        public void RemoveEdge(int from, int to)
        {
            _list[from].Remove(to);
        }

        public void PrintGraph()
        {
            for(int i = 0; i < _list.Length; i++)
            {
                Console.WriteLine($"노드: {i}");
                foreach(int node in _list[i])
                {
                    Console.WriteLine($"   {node}노드");
                }
            }
        }

    }

   
    

}
