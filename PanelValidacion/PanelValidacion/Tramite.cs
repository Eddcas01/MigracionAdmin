using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanelValidacion
{
    public partial class Tramite : Form
    {
        public Tramite()
        {
            InitializeComponent();
        }

        private void Tramitedll1_Load(object sender, EventArgs e)
        {

        }

        private void Tramite_FormClosed(object sender, FormClosedEventArgs e)
        {
           Form1 tr = new Form1();
            tr.Show();
        }
    }
}
