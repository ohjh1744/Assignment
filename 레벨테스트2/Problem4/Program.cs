namespace Problem4
{

    enum Place
    {
        마을, 길드, 성, 상점, 묘지, 숲, 초원, 바다
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            //마을간선
            #region
            graph.AddEdge((int)Place.마을, (int)Place.성);
            graph.AddEdge((int)Place.마을, (int)Place.묘지);
            graph.AddEdge((int)Place.길드, (int)Place.성);
            graph.AddEdge((int)Place.길드, (int)Place.상점);
            graph.AddEdge((int)Place.길드, (int)Place.숲);
            graph.AddEdge((int)Place.성, (int)Place.마을);
            graph.AddEdge((int)Place.성, (int)Place.길드);
            graph.AddEdge((int)Place.성, (int)Place.숲);
            graph.AddEdge((int)Place.성, (int)Place.초원);
            graph.AddEdge((int)Place.성, (int)Place.묘지);
            graph.AddEdge((int)Place.상점, (int)Place.길드);
            graph.AddEdge((int)Place.상점, (int)Place.숲);
            graph.AddEdge((int)Place.상점, (int)Place.바다);
            graph.AddEdge((int)Place.묘지, (int)Place.마을);
            graph.AddEdge((int)Place.묘지, (int)Place.성);
            graph.AddEdge((int)Place.묘지, (int)Place.초원);
            graph.AddEdge((int)Place.묘지, (int)Place.바다);
            graph.AddEdge((int)Place.숲, (int)Place.상점);
            graph.AddEdge((int)Place.숲, (int)Place.길드);
            graph.AddEdge((int)Place.숲, (int)Place.성);
            graph.AddEdge((int)Place.숲, (int)Place.초원);
            graph.AddEdge((int)Place.초원, (int)Place.성);
            graph.AddEdge((int)Place.초원, (int)Place.숲);
            graph.AddEdge((int)Place.초원, (int)Place.묘지);
            graph.AddEdge((int)Place.초원, (int)Place.바다);
            graph.AddEdge((int)Place.바다, (int)Place.상점);
            graph.AddEdge((int)Place.바다, (int)Place.초원);
            graph.AddEdge((int)Place.바다, (int)Place.묘지);
            #endregion

            int curPlace = (int)Place.마을;
            int playerNum = 0;
            List<Place> movetrack = new List<Place>();
            List<int> curPlaceEdge = new List<int>();
            movetrack.Add(Place.마을);

            while (playerNum != 9)
            {
                Console.Clear();
                Console.WriteLine("======맵 이동 ========");
                Console.WriteLine($"현재장소 : {(Place)curPlace}");
                Console.Write("이동경로: ");
                foreach(Place s in movetrack)
                {
                    Console.Write($"> {s} ");
                }
                Console.WriteLine();

                curPlaceEdge = graph.GetEdge(curPlace);
                for(int i = 0; i < curPlaceEdge.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {(Place)curPlaceEdge[i]}");
                }

                bool isRight;
                do
                {
                    Console.Write("이동할 장소를 선택하세요(뒤로가기 0)(머무르기 9): ");
                    Console.WriteLine("잘못된 수 입력 시 재입력합니다.");
                    isRight = int.TryParse(Console.ReadLine(), out playerNum);
                } while (isRight == false || (playerNum != 9 && (playerNum < 0 || playerNum > curPlaceEdge.Count)));

                if(playerNum == 0)
                {
                    if(movetrack.Count == 1)
                    {
                        Console.WriteLine("더 이상 뒤로 갈 수 없습니다.");
                        continue;
                    }
                    movetrack.RemoveAt(movetrack.Count - 1);
                    curPlace = (int)movetrack[movetrack.Count-1];
                }
                else if(playerNum == 9)
                {
                    Console.WriteLine("현재 장소에서 머무릅니다. 프로그램을 종료합니다.");
                }
                else
                {
                    curPlace = curPlaceEdge[playerNum - 1];
                    movetrack.Add((Place)curPlace);
                }
               
            }


        }
    }


    public class Graph
    {
        private List<int>[] _nodes;
        public Graph()
        {
            _nodes = new List<int>[8];
            for(int i = 0; i < 8; i++)
            {
                _nodes[i] = new List<int>();
            }
        }

        public void AddEdge(int from, int to)
        {
            _nodes[from].Add(to);
        }

        public List<int> GetEdge(int node)
        {
            return _nodes[node];
        }
    }
}
