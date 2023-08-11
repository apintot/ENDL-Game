using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ednl
{
    internal class DAL
    {
        private BDConexion conexion = new BDConexion();
        public DAL() { }
        public Respuesta getQuestion(int number)
        {
            MySqlDataReader mysqldatareader = null;
            string consulta = "select * from preguntas where id =" + number;
            if(conexion  != null)
            {
                MySqlCommand mysqlcommand = new MySqlCommand(consulta);
                mysqlcommand.Connection = conexion.getConexion();
                mysqldatareader = mysqlcommand.ExecuteReader();

                Respuesta respuesta = new Respuesta();

                while (mysqldatareader.Read())
                {
                    respuesta.pregunta = mysqldatareader.GetString(1);
                    respuesta.respuesta = mysqldatareader.GetInt16(2);
                }

                mysqldatareader.Close();
                return respuesta;
            }
            else
            {
                Respuesta res = new Respuesta();
                res.respuesta = 0;
                res.pregunta = string.Empty;
                return res;
            }
        }
    }
}
