using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transitions
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TransitionsFun.ShowUI("TransitionsFun.ShowUI");
            Thread.Sleep(10000);
            TransitionsFun.CloseUI();
        }
    }
}
