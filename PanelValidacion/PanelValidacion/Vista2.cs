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
    public partial class Vista2 : Form
    {

      
        public void setButtonsColors(Button c)
        {
            System.Drawing.Color CelesteGob = System.Drawing.ColorTranslator.FromHtml("#bdbfbe");
            Btn_dpi.BackColor = Color.White;
            Btn_dpi.ForeColor = Color.Black;
            Btn_dpi.FlatAppearance.MouseOverBackColor = Color.LightGray;
            Btn_ornato.BackColor = Color.White;
            Btn_ornato.ForeColor = Color.Black;
            Btn_ornato.FlatAppearance.MouseOverBackColor = Color.LightGray;
            Btn_pago.BackColor = Color.White;
            Btn_pago.ForeColor = Color.Black;
            Btn_pago.FlatAppearance.MouseOverBackColor = Color.LightGray;
            Btn_estatus.BackColor = Color.White;
            Btn_estatus.ForeColor = Color.Black;
            Btn_estatus.FlatAppearance.MouseOverBackColor = Color.LightGray;
 

            c.BackColor = CelesteGob;
            c.ForeColor = Color.White;
            c.FlatAppearance.MouseOverBackColor = CelesteGob;
        }
        public Vista2()
        {
            InitializeComponent();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
       private void TableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void HideAllTabsOnTabControl(TabControl theTabControl)
		{
			theTabControl.Appearance = TabAppearance.FlatButtons;
			theTabControl.ItemSize = new Size(0, 1);
			theTabControl.SizeMode = TabSizeMode.Fixed;
		}

        private void Vista2_Load(object sender, EventArgs e)
        {
            HideAllTabsOnTabControl(tabControl1);
            setButtonsColors(Btn_dpi);
        }

        private void TableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
       
        }

        private void Button8_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            
         
        }

        private void Button9_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            setButtonsColors(Btn_ornato);
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Btn_rechazar_Click(object sender, EventArgs e)
        {
            Rechazo frm = new Rechazo();
            frm.Show();
        }

        private void Btn_validardoc_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            setButtonsColors(Btn_pago);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            setButtonsColors(Btn_estatus);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            setButtonsColors(Btn_dpi);
        }

        private void Btn_rechazar2_Click(object sender, EventArgs e)
        {
            Rechazo frm = new Rechazo();
            frm.Show();
        }

        private void Button8_Click_1(object sender, EventArgs e)
        {
            Rechazo frm = new Rechazo();
            frm.Show();
        }

        private void Button8_Click_2(object sender, EventArgs e)
        {
            Rechazo frm = new Rechazo();
            frm.Show();

        }

        private void Button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            setButtonsColors(Btn_carta);

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            setButtonsColors(Btn_ornato);
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            setButtonsColors(Btn_pago);
        }
    }
}
