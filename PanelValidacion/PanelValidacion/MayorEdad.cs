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
    public partial class MayorEdad : Form
    {

        string user = "";
        string dato = "";
        string boleto = "";
        string boleta = "";

        SQL_Conexion conectar = new SQL_Conexion();
        public void llenardatap1(string cui)
        {

            dato = cui;


            string sql2 = "SELECT cui_progenitor FROM dpis_progenitores WHERE  cui_menor = '" + dato + "'; ";
            OdbcCommand command2 = new OdbcCommand(sql2, conectar.conexion());
            OdbcDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {

                string dpi1 = reader2.GetValue(0).ToString();



                if (dpi1 != null)
                {

                    Lbl_dpiprog.Text = dpi1;






                }
                else
                {

                    button3.BackColor = Color.Red;
                    button4.BackColor = Color.Red;
                }



            }

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

        public void llenardatapboleto(string cui)
        {

            dato = cui;

            string sql = "SELECT no_documento FROM  documentos WHERE  cui = '" + dato + "' AND nombre_documento = 'boleto_ornato' AND estado_documento = 'Activo'; ";
            OdbcCommand command = new OdbcCommand(sql, conectar.conexion());
            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string no_boleto = reader.GetValue(0).ToString();

                if (no_boleto != " ")
                {
                    string sql2 = "SELECT * FROM  boletos WHERE  no_boleto = '" + no_boleto + "'; ";
                    OdbcCommand command2 = new OdbcCommand(sql2, conectar.conexion());
                    OdbcDataReader reader2 = command2.ExecuteReader();


                    if (reader2.Read() != false)
                    {

                        OdbcCommand command3 = new OdbcCommand(sql2, conectar.conexion());
                        OdbcDataReader reader3 = command3.ExecuteReader();


                        while (reader3.Read())
                        {
                            Lbl_boleto.Text = reader3.GetValue(1).ToString();
                            Lbl_fecha1.Text = reader3.GetValue(2).ToString();
                            Lbl_estado1.Text = reader3.GetValue(3).ToString();


                        }

                    }
                    else
                    {

                        MessageBox.Show("El numero de boleto no existe en la base de datos de la Municipalidad ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        button1.BackColor = Color.Red;
                    }
                }
                else
                {

                    MessageBox.Show("Documento no subido ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

            }







        }

        public void llenardatapago(string cui)
        {

            dato = cui;


            string sql = "SELECT no_documento FROM  documentos WHERE  cui = '" + dato + "' AND nombre_documento = 'boleta_pago' AND estado_documento = 'Activo'; ";
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
                            Lbl_fecha.Text = reader3.GetValue(2).ToString();
                            Lbl_estadobol.Text = reader3.GetValue(3).ToString();


                        }

                    }
                    else
                    {

                        MessageBox.Show("El numero de boleto no existe en la base de datos de la Municipalidad ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        button1.BackColor = Color.Red;
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
