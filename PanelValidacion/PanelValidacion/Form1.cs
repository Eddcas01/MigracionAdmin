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
    public partial class Form1 : Form
    {
        SQL_Conexion conec = new SQL_Conexion();
        OdbcConnection conn = new OdbcConnection("Dsn=Migracion");
        public Form1()
        {
            InitializeComponent();
            llenarTabla();
        }
        void llenarTabla()
        {
            //llenamos el DataGridView
            OdbcCommand codigo = new OdbcCommand();
            codigo.Connection = conn;
            codigo.CommandText = ("SELECT `id_recepcion`, `id_tramite`, `cui`, `fecha_recepcion`, `estado_recepcion` FROM `recepciones_documentos` WHERE estado_recepcion = 'Activo' ");
            try
            {
                OdbcDataAdapter ejecutar = new OdbcDataAdapter();
                ejecutar.SelectCommand = codigo;
                DataTable datostabla = new DataTable();
                ejecutar.Fill(datostabla);
                Dgb_solicitudes.DataSource = datostabla;
                ejecutar.Update(datostabla);
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("\t Error en llenado de Tablas!! \n\n" + e.ToString());
                conn.Close();
            }
        }
        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Btn_abrirsoli_Click(object sender, EventArgs e)
        {
            string tramite;

            
            if (Dgb_solicitudes.SelectedRows.Count == 1)
            {

                string dpi1 = Dgb_solicitudes.CurrentRow.Cells[2].Value.ToString();

                try
                {

                    conn.Open();

                    OdbcCommand command1 = new OdbcCommand("SELECT estado_dpi FROM dpis WHERE cui ='" + Dgb_solicitudes.CurrentRow.Cells[2].Value.ToString() + "'", conn);
                    OdbcDataReader reader1 = command1.ExecuteReader();
                    if (reader1.HasRows && reader1.GetValue(0).ToString() == "Activo")
                    {

                        conn.Close();
                        try
                        {

                            conn.Open();

                            OdbcCommand command = new OdbcCommand("SELECT tipo_tramite FROM tramites WHERE cui ='" + Dgb_solicitudes.CurrentRow.Cells[2].Value.ToString() + "'", conn);
                            OdbcDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {

                                tramite = reader.GetValue(0).ToString();
                                abrirfrm(dpi1, tramite);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        conn.Close();



                    }
                    else {

                        MessageBox.Show("El Dpi no existe en la base de datos de RENAP ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();




            }
            //llenar tabla 2
          /*  string cadena = "SELECT tipo_tramite FROM recepciones_documentos WHERE cui = " + Dgb_solicitudes.CurrentRow.Cells[3].Value.ToString()+"LIMIT 1";
            OdbcDataAdapter adp1 = new OdbcDataAdapter(cadena, conn);
            DataTable dt = new DataTable();
            adp1.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Dgb_solicitudes.DataSource = dt;
                Dgb_solicitudes.Refresh();
            }*/

            /*string sql = "SELECT tipo_tramite FROM recepciones_documentos WHERE cui =" + Dgb_solicitudes.CurrentRow.Cells[3].Value.ToString()+"LIMIT 1";
            OdbcCommand command = new OdbcCommand(sql, conec.conexion()); ver aqui
            OdbcDataReader reader = command.ExecuteReader();
            string tramite = reader.GetValue(1).ToString();
            string dpi1 = Dgb_solicitudes.CurrentRow.Cells[3].Value.ToString();

            abrirfrm(dpi1,tramite);*/



        } 

        public void abrirfrm (string cui, string op ){
            string op2 = op;
            string dpi = cui;
            switch (op2) {

                case "Menor":
                    Vista2 frm = new Vista2(dpi);
                    frm.Show();
                    this.Hide();
                    break;
                case "Mayor":
                    MayorEdad frm2 = new MayorEdad(dpi);
                    frm2.Show();
                    this.Hide();
                    break;
                case "Mayor 60":
                    Mayor60 frm3 = new Mayor60(dpi);
                    frm3.Show();
                    this.Hide();
                    break;



            }



        }

        private void Dgb_solicitudes_Click(object sender, EventArgs e)
        {

        }
    }
}
