using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int W()
        {
            return Convert.ToInt32(Math.Round(numericUpDown1.Value));
        }
        public int H()
        {
            return Convert.ToInt32(Math.Round(numericUpDown2.Value));
        }
        public int M()
        {
            return Convert.ToInt32(Math.Round(numericUpDown3.Value));
        }
    }
}
