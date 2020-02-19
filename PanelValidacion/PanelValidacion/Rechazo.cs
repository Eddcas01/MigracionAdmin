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
    public partial class Rechazo : Form
    {

        SQL_Rechazo rechazar = new SQL_Rechazo();

        string user = "";
        string datos = "";
        public Rechazo(string cui)
        {

            user = cui;
            InitializeComponent();
            label3.Text = user;
        }




        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            datos = Txt_rechazo.Text;
            rechazar.llenarrechazo(user,datos);
            Form1 frm2 = new Form1();
            frm2.Show();
            this.Hide();
         
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm2 = new Form1();
            frm2.Show();



        }

        private void Rechazo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
