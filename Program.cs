namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] labirynth1 = new int[,]
            {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {2, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 2, 0, 1, 1, 1 },
            {1, 1, 1, 2, 1, 1, 1 }
            };
            /*if (HasExix(1, 1, labirynth1))
                Console.WriteLine("выход");
            else Console.WriteLine("тупик");*/

            Console.WriteLine(HasExix(1, 1, labirynth1));

            static int HasExix(int startI, int startJ, int[,] lab)
            {
                int counter = 0;
                Queue<(int, int)> coords = new();
                if (lab[startI, startJ] != 1)
                {
                    coords.Enqueue((startI, startJ));
                }
                while (coords.Count > 0)
                {
                    (int i, int j) = coords.Dequeue();
                    if (lab[i, j] == 2) counter++;

                    lab[i, j] = 1;
                    if (i - 1 >= 0 && (lab[i - 1, j] != 1)) coords.Enqueue((i - 1, j));
                    if (i + 1 < lab.GetLength(0) && (lab[i + 1, j] != 1)) coords.Enqueue((i + 1, j));
                    if (j - 1 >= 0 && (lab[i, j - 1] != 1)) coords.Enqueue((i, j - 1));
                    if (j + 1 < lab.GetLength(1) && (lab[i, j + 1] != 1)) coords.Enqueue((i, j + 1));                    
                }
                return counter;
            }
        }
    }
}
