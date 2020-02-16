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
    public partial class MayorEdad : Form
    {
        string user;
        public MayorEdad(string cui)
        {
            InitializeComponent();
            user = cui;
            label3.Text = user;
        }

        private void HideAllTabsOnTabControl(TabControl theTabControl)
        {
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;
        }
        private void MayorEdad_Load(object sender, EventArgs e)
        {
            HideAllTabsOnTabControl(tabControl1);
        }
    }
}
