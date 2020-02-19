using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
namespace PanelValidacion
{
    class SQL_Rechazo
    {
        SQL_Conexion conectar = new SQL_Conexion();


        string dato;
        string rejec;
        string fecha;

        public void llenarrechazo (string cui, string rechazo){

            dato = cui;
            rejec = rechazo;
          


            string sql = "iNSERT INTO rechazos_documentos (id_recepcion, cui, detalle_rechazo ) VALUES ( (SELECT id_recepcion FROM recepciones_documentos WHERE cui = '"+ dato +"' AND estado_recepcion = 'Activo') ,'" + dato + "','" + rejec + "')";
            OdbcCommand command = new OdbcCommand(sql, conectar.conexion());
            OdbcDataReader reader = command.ExecuteReader();

            string sql2 = "UPDATE recepciones_documentos SET estado_recepcion='Inactivo' WHERE cui = " + dato;
            OdbcCommand command2 = new OdbcCommand(sql2, conectar.conexion());
            OdbcDataReader reader2 = command2.ExecuteReader();



 

        }

    }
}
