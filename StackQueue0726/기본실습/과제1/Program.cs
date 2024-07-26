namespace StackQueue1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '[' || input[i] == '{' || input[i] == '(')
                {
                    stack.Push(input[i]);
                    continue;
                }
                else
                {
                    switch (input[i])
                    {
                        case ']':
                            if (stack.Peek() == '[')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                Console.WriteLine("미완성");
                                return;
                            }
                            break;
                        case '}':
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                Console.WriteLine("미완성");
                                return;
                            }
                            break;
                        case ')':
                            if (stack.Peek() == '(')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                Console.WriteLine("미완성");
                                return;
                            }
                            break;
                    }

                }
            }

            if(stack.Count > 0)
            {
                Console.WriteLine("미완성");
            }
            else
            {
                Console.WriteLine("완성");
            }






        }



    }
}
