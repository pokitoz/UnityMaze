using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RandomizedPRims
{
    class Program
    {

        const int WALL = 0;
        const int MAZE_X = 11;
        const int MAZE_Y = 11;

        public static List<Tuple<Tuple<int, int>, Tuple<int, int>>> wall_list;
        public static int[,] maze;

        static void Main(string[] args)
        {

            wall_list = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
            maze = new int[MAZE_X, MAZE_Y];

            
            for (int row = 0; row < MAZE_X; row++)
            {
                for (int col = 0; col < MAZE_Y; col++)
                {
                    maze[row, col] = WALL;
                }
            }

            Tuple<int, int> previous = new Tuple<int, int>(1, 1);
            maze[previous.Item1, previous.Item2] = 1;

            
            Random rngesus = new Random();
            addWall(previous);

            while (wall_list.Count != 0)
            {

                int element = (rngesus.Next(0, wall_list.Count));
                previous = wall_list[element].Item1;
                Tuple<int, int> current = wall_list[element].Item2;
                Tuple<int, int> op = new Tuple<int, int>(current.Item1 * 2 - previous.Item1, current.Item2 * 2 - previous.Item2);
                try
                {
                    if (maze[op.Item1, op.Item2] == WALL)
                    {
                        maze[current.Item1, current.Item2] = 1;
                        maze[op.Item1, op.Item2] = 1;
                        addWall(op);
                    }
                }
                catch (System.IndexOutOfRangeException e)
                {

                }
                finally
                {
                    wall_list.RemoveAt(element);
                }
            }

            for (int row = 0; row < MAZE_X; row++)
            {
                for (int col = 0; col < MAZE_Y; col++)
                {
                    if (maze[row, col] == WALL) {
                        Console.Write("X");   
                    }
                    else {
                        Console.Write("O");
                    }
                }
                Console.WriteLine("");
            }



            Console.ReadKey();

        }

        private static void addWall(Tuple<int, int> current)
        {

            if (current.Item1 != 0)
            {
                Tuple<int, int> new_tupple = new Tuple<int, int>(current.Item1 - 1, current.Item2);
                if(maze[new_tupple.Item1, new_tupple.Item2] == WALL)
                    wall_list.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(current, new_tupple));
            }


            if (current.Item1 != MAZE_X -1 )
            {
                Tuple<int, int> new_tupple = new Tuple<int, int>(current.Item1 + 1, current.Item2);
                if (maze[new_tupple.Item1, new_tupple.Item2] == WALL)
                    wall_list.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(current, new_tupple));
            }

            if (current.Item2 != 0)
            {
                Tuple<int, int> new_tupple = new Tuple<int, int>(current.Item1, current.Item2-1);
                if (maze[new_tupple.Item1, new_tupple.Item2] == WALL)
                    wall_list.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(current, new_tupple));
            }

            if (current.Item2 != MAZE_Y - 1)
            {
                Tuple<int, int> new_tupple = new Tuple<int, int>(current.Item1, current.Item2 + 1);
                if (maze[new_tupple.Item1, new_tupple.Item2] == WALL)
                    wall_list.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(current, new_tupple));
            }
        



            /*
             * 
             * 
             * for(int i = -1; i < 1; i++)
             *  for(int j = -1; j < 1; j++)
             *      if(
             * 
             * */
        
        }







    }
}
