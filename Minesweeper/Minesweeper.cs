using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper;

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        public event EventHandler<ClickEventargs> Button_click;
        public event EventHandler<GridEventargs> Grid_Reset_Menu;
        public void Trigger_Button(object sender, ClickEventargs e)
        {
            EventHandler<ClickEventargs> Bu = Button_click;
            if (Bu != null)
            {
                Bu(sender, e);
            }
            else
            {
                Console.WriteLine("Event handler not found");
            }

        }
        public void Button_array_click(EventHandler<ClickEventargs> handler)
        {
            Console.WriteLine("Set up event handler");
            Button_click += handler;
        }
        private Bitmap[,] Picturedata = new Bitmap[width_cap, height_cap];
        private int width_b = 0, height_b = 0, width_i = 0, height_i = 0;
        private double button_default_ratio = 0;
        private const int width_cap = 35, height_cap = 35;
        private bool form_shown = false,Resizable = true,Resized = false,freeform = false,Resetting = false;
        public Button[,] Button_array =new Button[width_cap, height_cap]; // capped at 35, can change if needed
        public Minesweeper(int width_s = 20, int height_s = 20)
        {
            Console.WriteLine("Form- Init");
            InitializeComponent();
            Console.WriteLine("Form- Setting event for form to show...");
            this.Shown += Shown_event_handler;
            width_i = width_s;
            height_i = height_s;
        }
        private void Shown_event_handler(object sender, EventArgs e)
        {
            Console.WriteLine("Form- Form processed shown");
            form_shown = true;
            init_array(width_i, height_i, 40, 40);
            
            this.Text = "Minesweeper("+width_b+"x"+height_b+")";
            this.Layout += Size_change_handler;
            this.ResizeEnd += Resize_end_handler;
            this.ResizeBegin += Resize_begin_handler;
            this.Click += On_click_handler;
        }
        public void Reset(Sizes size)
        {
            Resetting = true;
            for (int x_loop = 0; x_loop < width_b; x_loop++)
            {
                for (int y_loop = 0; y_loop < height_b; y_loop++)
                {
                    this.Controls.Remove(Button_array[x_loop, y_loop]);
                }
            }
            Button_array = new Button[width_cap, height_cap];
            width_i = size.X;
            height_i = size.Y;
            init_array(width_i, height_i, 40, 40);

            this.Text = "Minesweeper(" + width_b + "x" + height_b + ")";
            Resetting = false;
        }
        private void On_click_handler(object sender, EventArgs e)
        {
            /*SetNum(0, 0, 1);
            SetNum(0, 0, 0);
            SetNum(1, 0, 1);
            SetNum(2, 0, 2);
            SetNum(3, 0, 3);
            SetNum(4, 0, 4);
            SetNum(5, 0, 5);
            SetNum(6, 0, 6);
            SetNum(7, 0, 7);
            SetNum(8, 0, 8);
            SetNum(9, 0, 9);
            SetNum(10, 0, 10);
            SetNum(11, 0, 11);
            SetNum(12, 0, 12);*/
        }
        private void Resize_end_handler(object sender, EventArgs e)
        {
            if (Resizable)
            {
                Resize_button(this.Width - 20, this.Height - 40);// top border and overlap
            }
            Resized = false;
        }
        private void Resize_begin_handler(object sender, EventArgs e)
        {
         
            Resized = true;
        }
        private void On_button_click_handler(object sender, MouseEventArgs e, Button b, int x, int y)
        {
            //Console.WriteLine("Button" + x + " " + y + " clicked ");
            ClickEventargs eo = new ClickEventargs();
            eo.E = e;
            eo.X = x;
            eo.Y = y;
            Trigger_Button(this,eo);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridEventargs eo = new GridEventargs();
            Form2 Dialog = new Form2();
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (Dialog.ShowDialog(this) == DialogResult.Cancel)
            {
                // Read the contents of testDialog's TextBox.
                return;
            }
            
            eo.E = e;
            eo.Width = Dialog.W();
            eo.Height = Dialog.H();
            eo.Mine = Dialog.M();
            Dialog.Dispose();
            if( Grid_Reset_Menu != null ) Grid_Reset_Menu(this, eo);
        }

        private void beginner16x16With10BombsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridEventargs eo = new GridEventargs();
            eo.E = e;
            eo.Width = 8;
            eo.Height = 8;
            eo.Mine = 10;
            if (Grid_Reset_Menu != null) Grid_Reset_Menu(this, eo);
        }

        private void advanced30x16With99MineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridEventargs eo = new GridEventargs();
            eo.E = e;
            eo.Width = 30;
            eo.Height = 16;
            eo.Mine = 99;
            if (Grid_Reset_Menu != null) Grid_Reset_Menu(this, eo);
        }

        private void intermidiate16x16With40MineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridEventargs eo = new GridEventargs();
            eo.E = e;
            eo.Width = 16;
            eo.Height = 16;
            eo.Mine = 40;
            if (Grid_Reset_Menu != null) Grid_Reset_Menu(this, eo);
        }

        private void Size_change_handler(object sender, EventArgs e)
        {
            //MessageBox.Show("The size of the 'Button' control has changed");
            //Console.WriteLine(this.Width + " " + this.Height);
            if (Resizable&&!Resized&&!Resetting)
            {
                Resize_button(this.Width-20, this.Height-40);// top border and overlap
            }
        }
        private void Resize_button(int w, int h)
        {
            int button_x,button_y,offset_x = 0,offset_y = gameToolStripMenuItem.Size.Height;
            int width = w-offset_x;
            int height = h-offset_y;
            if (freeform)
            {
                button_x = ((width - (width % width_b)) / width_b);
                button_y = ((height - (height % height_b)) / height_b);
            }
            else
            {
                if (((width - (width % width_b)) / width_b) / button_default_ratio > ((height - (height % height_b)) / height_b) * button_default_ratio)
                {
                    button_x = Convert.ToInt32(((height - (height % height_b)) / height_b)*button_default_ratio);
                    button_y = Convert.ToInt32(((height - (height % height_b)) / height_b));
                }
                else
                {
                    button_x = Convert.ToInt32(((width - (width % width_b)) / width_b));
                    button_y = Convert.ToInt32(((width - (width % width_b)) / width_b) / button_default_ratio);
                }
                
            }
            for (int x_loop = 0; x_loop < width_b; x_loop++)
            {
                for (int y_loop = 0; y_loop < height_b; y_loop++)
                {
                    Button_array[x_loop, y_loop].Location = new Point(x_loop * button_x+offset_x, y_loop * button_y+offset_y);
                    Button_array[x_loop, y_loop].Size = new Size(button_x, button_y);
                    if(Button_array[x_loop, y_loop].Image != null)
                    {
                        Update_Picture(x_loop,y_loop);
                    }
                }
            }
        }
        public void init_array(int width, int height, int button_x = 20, int button_y = 20)
        {
            this.MinimumSize = new Size(width * button_x, height * button_y);
            this.Size = new Size(width * button_x, height * button_y);
            if (width > width_cap)
            {
                throw new ArgumentException("Width:Index is out of range");
            }
            if (height > height_cap)
            {
                throw new ArgumentException("Height:Index is out of range");
            }
            button_default_ratio = Convert.ToDouble(button_x) / Convert.ToDouble(button_y);
            width_b = width;
            height_b = height;
            for(int x_loop = 0;x_loop<width; x_loop++)
            {
                for (int y_loop = 0; y_loop < height; y_loop++)
                {
                    
                    Button_array[x_loop,y_loop] = new Button();
                    Controls.Add(Button_array[x_loop,y_loop]);
                    Button_array[x_loop, y_loop].Location = new Point(x_loop*button_x,y_loop*button_y);
                    Button_array[x_loop, y_loop].Size = new Size(button_x,button_y);
                    int x = x_loop, y = y_loop;
                    Button_array[x_loop, y_loop].MouseDown += (sender, args) => On_button_click_handler(sender, args, Button_array[x, y],x,y);
                    //Console.WriteLine("Button" + x_loop+ " " + y_loop+" AT:" + x_loop * button_x + ","+ y_loop * button_y);
                }
            }
            Resize_button(this.Width - 20, this.Height - 40);
        }
        public void Set_Picture(int x, int y,Bitmap picture)
        {
            Picturedata[x, y] = picture;
            Update_Picture(x, y);
        }
        public void Remove_Picture(int x, int y)
        {
            Picturedata[x, y] = null;
            Update_Picture(x, y);
        }
        public void Update_Picture(int x, int y)
        {
            if (Picturedata[x, y] == null)
            {
                Button_array[x, y].Image = null;
            }
            else {
                Bitmap temporary_pic = Picturedata[x, y];
                try
                {
                    Button_array[x, y].Image = new Bitmap(temporary_pic, Button_array[x, y].Size);
                }
                catch
                {
                    Console.WriteLine("Window hidden");
                }
            }
        }
        public void SetNum(int x, int y, int num)
        {
            //Console.WriteLine("Set num " + num + " at " + x + " " + y);
            switch(num){
                case 0:
                    Remove_Picture(x, y);
                    break;
                case 1:
                    Set_Picture(x, y, Properties.Resources.N1);
                    break;
                case 2:
                    Set_Picture(x, y, Properties.Resources.N2);
                    break;
                case 3:
                    Set_Picture(x, y, Properties.Resources.N3);
                    break;
                case 4:
                    Set_Picture(x, y, Properties.Resources.N4);
                    break;
                case 5:
                    Set_Picture(x, y, Properties.Resources.N5);
                    break;
                case 6:
                    Set_Picture(x, y, Properties.Resources.N6);
                    break;
                case 7:
                    Set_Picture(x, y, Properties.Resources.N7);
                    break;
                case 8:
                    Set_Picture(x, y, Properties.Resources.N8);
                    break;
                case 9:
                    Set_Picture(x, y, Properties.Resources.Mine);
                    break;
                case 10:
                    Set_Picture(x, y, Properties.Resources.Flag);
                    break;
                case 11:
                    Set_Picture(x, y, Properties.Resources.MineDefuse);
                    break;
                case 12:
                    Set_Picture(x, y, Properties.Resources.MineExplode);
                    break;
                case 13:
                    Set_Picture(x, y, Properties.Resources.Mark);
                    break;
                case 14:
                    Set_Picture(x, y, Properties.Resources.Hidden);
                    break;
                default:
                    break;
            }
        }
        public bool LosePrompt()
        {
            Form1 Dialog = new Form1("You Lost");
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (Dialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                return true;
            }
            else
            {
                return false;
            }
            Dialog.Dispose();
        }
        public bool WinPrompt()
        {
            Form1 Dialog = new Form1("You Win");
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (Dialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                return true;
            }
            else
            {
                return false;
            }
            Dialog.Dispose();
        }

    }

    public struct Coords
    {
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => $"({X}, {Y})";
    }
    public struct Sizes
    {
        public Sizes(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => $"({X}, {Y})";
    }
    public class ClickEventargs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
        public MouseEventArgs E { get; set; }
    }
    public class GridEventargs : EventArgs
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Mine { get; set; }
        public EventArgs E { get; set; }
    }
}
