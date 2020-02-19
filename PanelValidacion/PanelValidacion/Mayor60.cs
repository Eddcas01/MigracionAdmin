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
        string user=  "";
        string dato = "";
        string boleto = "";
        string boleta = "";
        SQL_Conexion conectar = new SQL_Conexion();
        public void llenardatap1(string cui)
        {

            dato = cui;


        
            string sql = "SELECT * FROM dpis WHERE  cui = '" + dato + "'; ";
            OdbcCommand command = new OdbcCommand(sql, conectar.conexion());
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Lbb_dpi2.Text = reader.GetValue(1).ToString();
                Lbl_nombre2.Text = reader.GetValue(2).ToString();
                Lbl_apellidos.Text = reader.GetValue(3).ToString();
                Lbl_sexo.Text = reader.GetValue(4).ToString();
                Lbl_estado.Text = reader.GetValue(5).ToString();

            }





        }

          public void llenardatapago(string cui)
        {

            dato = cui;


            string sql = "SELECT no_documento FROM  documentos WHERE  cui = '" + dato + "' AND nombre_documento = 'No_boleta' AND estado_documento = 'Activado'; ";
            OdbcCommand command = new OdbcCommand(sql, conectar.conexion());
            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string no_boleta = reader.GetValue(0).ToString();

                if (no_boleta != " ")
                {
                    string sql2 = "SELECT * FROM  boletas_bancos WHERE  no_boleta = '" + no_boleta + "'; ";
                    OdbcCommand command2 = new OdbcCommand(sql2, conectar.conexion());
                    OdbcDataReader reader2 = command2.ExecuteReader();


                    if (reader2.Read() != false)
                    {

                        OdbcCommand command3 = new OdbcCommand(sql2, conectar.conexion());
                        OdbcDataReader reader3 = command3.ExecuteReader();


                        while (reader3.Read())
                        {
                            Lbl_noBoleta.Text = reader3.GetValue(1).ToString();
                            Lbl_fecha.Text = reader3.GetValue(3).ToString();
                            Lbl_estadobol.Text = reader3.GetValue(5).ToString();


                        }

                    }
                    else
                    {

                        MessageBox.Show("El numero de boleto no existe en la base de datos de la Municipalidad ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        button2.BackColor = Color.Red;
                    }
                }
                else
                {

                    MessageBox.Show("Documento no subido ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

            }


        }
        public void llenarestatus(string cui)
        {



            dato = cui;


            string sql = "SELECT nombres_dpi, apellidos_dpi FROM  dpis WHERE  cui = '" + dato + "' AND  estado_dpi = 'Activo'; ";
            OdbcCommand command = new OdbcCommand(sql, conectar.conexion());
            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                Lbl_Dpi2.Text = dato;
                Lbl_nombres2.Text = reader.GetValue(0).ToString();
                Lbl_apellidos2.Text = reader.GetValue(1).ToString();

            }

            string sql2 = "SELECT estatus_migratorio FROM  estatus_migratorios WHERE  cui = '" + dato + "' AND  estado_estatus_migratorio = 'Activo'; ";
            OdbcCommand command2 = new OdbcCommand(sql2, conectar.conexion());
            OdbcDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {

                Lbl_estatus2.Text = reader2.GetValue(0).ToString();


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
        public Mayor60(string cui)
        {
            InitializeComponent();
            user = cui;
        
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
                Lbb_dpi2.Text = reader.GetValue(1).ToString();
                Lbl_nombre2.Text = reader.GetValue(2).ToString();
                Lbl_apellidos.Text = reader.GetValue(3).ToString();
                Lbl_sexo.Text = reader.GetValue(4).ToString();
                Lbl_estado.Text = reader.GetValue(5).ToString();

            }
            


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

        private void Button12_Click(object sender, EventArgs e)
        {

        }

        private void Button13_Click(object sender, EventArgs e)
        {

        }

        private void Btn_validar_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            setButtonsColors(Btn_pago);
            llenardatapago(user);
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            setButtonsColors(Btn_estatus);
            llenarestatus(user);
        }

        private void Button12_Click_1(object sender, EventArgs e)
        {
            string fecha;

            DialogResult resul = MessageBox.Show("¿Esta seguro que desea validar los documentos? ", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resul == DialogResult.Yes)
            {


                fecha = DateTime.Now.ToString("yyyy-MM-dd");

                string sql = "iNSERT INTO aceptaciones_documentos (cui, id_recepcion, fecha_aceptacion ) VALUES ('" + dato + "', (SELECT id_recepcion FROM recepciones_documentos WHERE cui = '" + dato + "' AND estado_recepcion = 'Activo') , '" + fecha + "')";
                OdbcCommand command = new OdbcCommand(sql, conectar.conexion());
                OdbcDataReader reader = command.ExecuteReader();

                string sql2 = "UPDATE recepciones_documentos SET estado_recepcion='Inactivo' WHERE cui = " + dato;
                OdbcCommand command2 = new OdbcCommand(sql2, conectar.conexion());
                OdbcDataReader reader2 = command2.ExecuteReader();

                Form1 frm = new Form1();
                frm.Show();
                this.Hide();

            }

            else
            {

                Form1 frm = new Form1();
                frm.Show();
                this.Hide();


            }
        }

        private void Mayor60_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void Btn_rechazar_Click(object sender, EventArgs e)
        {
            Rechazo frm = new Rechazo(user);
            frm.Show();
            this.Hide();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Rechazo frm = new Rechazo(user);
            frm.Show();
            this.Hide();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            setButtonsColors(Btn_dpi);
        }

        private void Button13_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            setButtonsColors(Btn_pago);
        }

        private void Btn_regresar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();

            this.Hide();
        }
    }
}
