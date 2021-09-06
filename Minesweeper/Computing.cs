using System;
using System.Linq;

namespace Minesweeper
{
    public class Computing
    {
        public event EventHandler Win;
        public event EventHandler Lose;
        private int Fill_type = 0;
        /*0 = recursive flood fill,1 = queue flood fill*/
        private const int width_cap = 35, height_cap = 35;
        private int[,] Bomb_Grid = new int[width_cap, height_cap];
        private int[,] Open_Grid = new int[width_cap, height_cap];
        private int[,] ODat_Grid = new int[width_cap, height_cap];
        private Random Rand = new Random();
        Sizes gridsize;
        public int[,] Bomb_Array(Sizes size)
        {
            return Resize_2darray(Bomb_Grid,size);
        }
        public int[,] Data_Array(Sizes size)
        {
            return Resize_2darray(ODat_Grid, size);
        }
        public int[,]Open_Array(Sizes size)
        {
            return Resize_2darray(Open_Grid, size);
        }
        private int[,] Resize_2darray(int[,] i,Sizes size)
        {
            int[,] outarr = new int[size.X, size.Y];
            for (int x = 0;x < size.X;x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    outarr[x, y] = i[x, y];
                }
            }
            return outarr;
        }
        private bool[,] Resize_2darray(bool[,] i, Sizes size)
        {
            bool[,] outarr = new bool[size.X, size.Y];
            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    outarr[x, y] = i[x, y];
                }
            }
            return outarr;
        }
        public bool Verify_Coordinates(Coords coord,Sizes size_grid)
        {
            if(coord.X >= size_grid.X)
            {
                return false;
            }
            if(coord.X < 0)
            {
                return false;
            }
            if (coord.Y >= size_grid.Y)
            {
                return false;
            }
            if (coord.Y < 0)
            {
                return false;
            }
            return true;
        }
        public Coords[] Get_SurroundingCoord(Coords coord, Sizes size_grid)
        {
            Coords[] Output = {};
            int X = coord.X;
            int Y = coord.Y;
            for (int x = X-1; x <= X+1; x++)
            {
                for (int y = Y-1; y <= Y+1; y++)
                {
                    //Console.Write(x + "," + y + "\t");
                    if (Verify_Coordinates(new Coords(x, y), size_grid) &&( x != X || y != Y))
                    {
                        Output = Output.Concat(new[] {new Coords(x, y)}).ToArray();
                        //Console.Write("t\t");
                    }
                }
            }
            //Console.WriteLine(Output.Length);
            return Output;
        }
        public void SetBombGrid(int[,] input,Sizes size)
        {
            Bomb_Grid = input;
            gridsize = size;
        }
        public bool Check_isBomb(Coords coord)
        {
            if (Verify_Coordinates(coord, gridsize))
            {
                return Bomb_Grid[coord.X, coord.Y] == 1;
            }
            return false;
        }
        public bool Check_isOpen(Coords coord)
        {
            if (Verify_Coordinates(coord, gridsize))
            {
                return Open_Grid[coord.X, coord.Y] == 0;
            }
            return false;
        }
        public int Check_BombSurround(Coords coord)
        {
            //Console.Write(coord.ToString() + "\t");
            int count = 0;
            Coords[] corlis = Get_SurroundingCoord(coord,gridsize);
            if (Check_isBomb(coord) || !Verify_Coordinates(coord, gridsize))
            {
                return -1;
            }
            foreach(Coords cp in corlis)
            {
                if (Check_isBomb(cp))
                {
                    count += 1;
                }
                //Console.Write(cp.ToString()+" ");
            }
            //Console.WriteLine("SIZE"+gridsize.ToString());
            return count;
        }
        public void Ran_mine(int bomb_num)
        {
            for(int b = 0;b < bomb_num;b++)
            {
                int w = Rand.Next() % gridsize.X;
                int h = Rand.Next() % gridsize.X;
                if (Bomb_Grid[w, h] !=0)
                {
                    b--;
                    continue;
                }
                Bomb_Grid[w, h] = 1;
            }
            return;
        }
        public void Open_at(Coords pos, Sizes size,bool isrecur = false)
        {
            Coords[] queue = {};
            //Console.Write(pos.ToString());
            if (Verify_Coordinates(pos, size)) 
            {
                switch (Fill_type)
                {
                    case 0:
                        if (Check_isBomb(pos))
                        {
                            if (!isrecur)
                            {
                                if (Lose != null) Lose(this, EventArgs.Empty);
                                Console.WriteLine("Boom");
                            }
                            break;//alert
                        }
                        if (!Check_isOpen(pos))
                        {
                            break;
                        }
                        //Console.Write("Correct");
                        ODat_Grid[pos.X, pos.Y] = Check_BombSurround(pos);
                        Open_Grid[pos.X, pos.Y] = 1;
                        //Console.WriteLine(Check_BombSurround(pos));
                        if (Check_BombSurround(pos) == 0)
                        {
                            Open_at(new Coords(pos.X + 1, pos.Y), size, true);
                            Open_at(new Coords(pos.X - 1, pos.Y), size, true);
                            Open_at(new Coords(pos.X, pos.Y + 1), size, true);
                            Open_at(new Coords(pos.X, pos.Y - 1), size, true);
                            Open_at(new Coords(pos.X + 1, pos.Y + 1), size, true);
                            Open_at(new Coords(pos.X - 1, pos.Y + 1), size, true);
                            Open_at(new Coords(pos.X + 1, pos.Y - 1), size, true);
                            Open_at(new Coords(pos.X - 1, pos.Y - 1), size, true);
                            //recursive loop
                        }
                        break;
                    case 1:
                        queue[0] = pos;
                        while (queue.Length != 0)
                        {
                            Coords cpos = queue[queue.Length - 1];
                            Array.Resize(ref queue, queue.Length - 1);

                        }
                        break;
                    default:
                        break;
                }
            }
            Check_Win();
        }
        public void setflag(Coords pos)
        {
            if (Open_Grid[pos.X, pos.Y] == 0 || Open_Grid[pos.X, pos.Y] == 2 || Open_Grid[pos.X, pos.Y] == 3) Open_Grid[pos.X,pos.Y] = 2;
        }
        public void setquestion(Coords pos)
        {
            if (Open_Grid[pos.X, pos.Y] == 0 || Open_Grid[pos.X, pos.Y] == 2 || Open_Grid[pos.X, pos.Y] == 3) Open_Grid[pos.X, pos.Y] = 3;
        }
        public void setfree(Coords pos)
        {
            if (Open_Grid[pos.X, pos.Y] == 0 || Open_Grid[pos.X, pos.Y] == 2 || Open_Grid[pos.X, pos.Y] == 3) Open_Grid[pos.X, pos.Y] = 0;
        }
        public void print_console()
        {
            for (int i = 0; i < gridsize.X; i++)
            {
                for (int j = 0; j < gridsize.Y; j++)
                {
                    if (Open_Grid[i, j] == 0)
                    {
                        Console.Write("_\t");
                    }
                    else if (Open_Grid[i, j] == 2)
                    {
                        Console.Write("<\t");
                    }
                    else if (Open_Grid[i, j] == 3)
                    {
                        Console.Write("?\t");
                    }
                    else if (Bomb_Array(gridsize)[i, j] == 1)
                    {
                        Console.Write("*\t");
                    }
                    else
                    {
                        Console.Write(Data_Array(gridsize)[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
        }
        public void Print2d(int[,] i)
        {
            Print2DArray(i);
        }
        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void Check_Win()
        {
            if (Win != null && Check_ifwin()) Win(this, EventArgs.Empty);
        }
        private bool Check_ifwin()
        {
            int correct = 0;
            for (int i = 0; i < gridsize.X; i++)
            {
                for (int j = 0; j < gridsize.Y; j++)
                {
                    if (Bomb_Grid[i,j] == 0 && Open_Grid[i, j] == 1)
                    {
                        correct++;
                    }
                }
            }
            Console.WriteLine(correct + " " + Bomb_count());
            if ((Bomb_count() + correct) == (gridsize.X*gridsize.Y)) {
                return true;
            }return false;
        }
        public int Bomb_count()
        {
            int correct = 0;
            for (int i = 0; i < gridsize.X; i++)
            {
                for (int j = 0; j < gridsize.Y; j++)
                {
                    if (Bomb_Array(gridsize)[i,j] == 1)
                    {
                        correct++;
                    }
                }
            }
            return correct;
        }
        public void Reset(Sizes size,int mine)
        {
            gridsize = size;
            SetBombGrid(new int[width_cap, height_cap], size);
            Open_Grid = new int[width_cap, height_cap];
            ODat_Grid = new int[width_cap, height_cap];
            Ran_mine(mine);
            Console.WriteLine("Resetted");
        }
    }
}
