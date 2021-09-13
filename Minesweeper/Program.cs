using System;
using System.Threading;
using System.Windows.Forms;

namespace Minesweeper
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static Minesweeper ms;
        static Computing script;
        static Sizes Grid_size;
        static int mines;
        static bool lost = false;
        [STAThread]
        static void Main()
        {
            Grid_size = new Sizes(8,8);
            mines = 10; // beginner settings
            Console.WriteLine("Starting UP....");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("Starting form");
            ms = new Minesweeper(Grid_size.X, Grid_size.Y);
            script = new Computing();
            script.SetBombGrid(new int[Grid_size.X, Grid_size.Y], new Sizes(Grid_size.X, Grid_size.Y));
            script.Win += Win;
            script.Lose += Lose;
            ms.Button_array_click(Clicked);
            ms.Shown += Shown;
            ms.Grid_Reset_Menu += Change_Grid;
            Application.Run(ms);
        }
        static void Clicked(object sender,ClickEventargs e)
        {
            //Console.WriteLine("Button" + e.X + " " + e.Y + " clicked recieved ");
            if (e.E.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (script.Open_Array(Grid_size)[e.X, e.Y] == 0)
                {
                    script.Open_at(new Coords(e.X, e.Y), Grid_size);
                }
            }
            else if (e.E.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if(script.Open_Array(Grid_size)[e.X, e.Y] == 0)
                {
                    script.setflag(new Coords(e.X, e.Y));
                }
                else if(script.Open_Array(Grid_size)[e.X, e.Y] == 2)
                {
                    script.setquestion(new Coords(e.X, e.Y));
                }
                else if (script.Open_Array(Grid_size)[e.X, e.Y] == 3)
                {
                    script.setfree(new Coords(e.X, e.Y));
                }
            }
            Update();
            
        }
        static void Reveal_Bomb()
        {
            int[,] Open_Grid = script.Open_Array(Grid_size);
            int[,] Bomb_Grid = script.Bomb_Array(Grid_size);
            int[,] Data_Grid = script.Data_Array(Grid_size);
            for (int i = 0; i < Grid_size.X; i++)
            {
                for (int j = 0; j < Grid_size.Y; j++)
                {
                    if (Open_Grid[i, j] == 2 && Bomb_Grid[i, j] == 1)
                    {
                        ms.SetNum(i, j, 11);
                    }else if(Bomb_Grid[i, j] == 1)
                    {
                        ms.SetNum(i, j, 12);
                    }
                }
            }
            Console.WriteLine("BOOM");
            lost = true;
        }
        static void Update()
        {
            if (lost)
            {
                return;
            }
            int[,] Open_Grid = script.Open_Array(Grid_size);
            int[,] Bomb_Grid = script.Bomb_Array(Grid_size);
            int[,] Data_Grid = script.Data_Array(Grid_size);
            for (int i = 0; i < Grid_size.X; i++)
            {
                for (int j = 0; j < Grid_size.Y; j++)
                {
                    if (Open_Grid[i, j] == 0)
                    {
                        ms.SetNum(i, j, 14);
                    }
                    else if (Open_Grid[i, j] == 2)
                    {
                        ms.SetNum(i, j, 10);
                    }
                    else if (Open_Grid[i, j] == 3)
                    {
                        ms.SetNum(i, j, 13);// didnt have sprite yet
                    }
                    else if (Bomb_Grid[i, j] == 1)
                    {
                        ms.SetNum(i, j, 9);
                    }
                    else
                    {
                        ms.SetNum(i, j, Data_Grid[i, j]);
                    }
                }
            }
            
        }
        static void Shown(object sender, EventArgs e)
        {
            script.Ran_mine(mines);
            ms.Select_item_Fill_mode(script.Get_fill_mode());
            ms.Fill_Mode_clicked += Fill;
            Update();
        }
        static void Win(object sender, EventArgs e)
        {
            Console.WriteLine("Win");
            if (ms.WinPrompt())
            {
                script.Reset(Grid_size, mines);
                lost = false;
                Update();
            }
        }
        static void Fill(object sender, Intevent e)
        {
            Console.WriteLine(e.i);
            script.Set_fill_mode(e.i);
        }
        static void Change_Grid(object sender, GridEventargs e)
        {
            Console.WriteLine("Reset Grid");
            script.Reset(new Sizes(e.Width,e.Height), e.Mine);
            ms.Reset(new Sizes(e.Width, e.Height));
            lost = false;
            mines = e.Mine;
            Grid_size = new Sizes(e.Width, e.Height);
            Update();
        }
        static void Lose(object sender, EventArgs e)
        {
            Console.WriteLine("Lost");
            Reveal_Bomb();
            Thread.Sleep(500);
            if(ms.LosePrompt())
            {
                script.Reset(Grid_size,mines);
                lost = false;
                Update();
            }
        }
    }
}
