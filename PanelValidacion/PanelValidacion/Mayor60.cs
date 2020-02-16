using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace PanelValidacion
{
    public partial class Mayor60 : Form
    {
        string user;
        string dato;
        SQL_Conexion conectar = new SQL_Conexion();

        public Mayor60(string cui)
        {
            InitializeComponent();
            user = cui;
            label3.Text = user;
            llenardata(user);
        }

        public void llenardata(string cui)
        {

            dato = cui;





            string sql = "SELECT * FROM dpis WHERE  cui = '" + dato + "'; ";
            OdbcCommand command = new OdbcCommand(sql, conectar.conexion());
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Lbl_dpi.Text = reader.GetValue(1).ToString();
                Lbl_nombre2.Text = reader.GetValue(2).ToString();
                Lbl_apellido2.Text = reader.GetValue(3).ToString();
                Lbl_sexo.Text = reader.GetValue(4).ToString();
                Lbl_estado.Text = reader.GetValue(5).ToString();

            }



        }
        public void setButtonsColors(Button c)
        {
            System.Drawing.Color CelesteGob = System.Drawing.ColorTranslator.FromHtml("#bdbfbe");
            Btn_dpi.BackColor = Color.White;
            Btn_dpi.ForeColor = Color.Black;
            Btn_dpi.FlatAppearance.MouseOverBackColor = Color.LightGray;
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

        private void HideAllTabsOnTabControl(TabControl theTabControl)
        {
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;
        }
        private void Mayor60_Load(object sender, EventArgs e)
        {
            HideAllTabsOnTabControl(tabControl1);
         
            setButtonsColors(Btn_dpi);
        }

        private void Btn_validar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            setButtonsColors(Btn_pago);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            setButtonsColors(Btn_estatus);
        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }
    }
}
