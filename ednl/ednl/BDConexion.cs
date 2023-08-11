using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ednl
{
    internal class BDConexion
    {
        private MySqlConnection conexion = null;

        private string server = "localhost";
        private string database = "preguntasyrespuestas";
        private string user = "root";
        private string password = string.Empty;
        private string cadenaConexion = string.Empty;
        public BDConexion() 
        {
            cadenaConexion = "Database=" + database +
                "; DataSource=" + server +
                "; User Id=" + user +
                "; Password=" + password;
        }

        public MySqlConnection getConexion()
        {
            if(conexion == null)//la conexion ya esta abierta
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
            }

            return conexion;
        }
    }
}
