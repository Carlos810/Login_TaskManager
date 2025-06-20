using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entity;

namespace Data
{
    public class LoginData
    {
        public LoginData()
        {
                
        }

        #region AcessoBaseDatos
        public bool ValidandoAccesoUsuario(LoginUsuarios credentials)
        {
            var accesoPermitido = false;
            using (SqlConnection conn = new SqlConnection(ConfiguracionGlobal.CadenaConexion))
            {
                try
                {
                    conn.Open();
                    string query = BuscaUsuario();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", credentials.usuario);
                        cmd.Parameters.AddWithValue("@contrasenia", credentials.contrasenia);

                        int count = (int)cmd.ExecuteScalar();
                        accesoPermitido = count > 0;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    conn.Close();
                }

            }
            return accesoPermitido;
        }
        #endregion


        #region queries-Sql
        internal string BuscaUsuario()
        {
            string resp = "";
            resp = "SELECT COUNT(*) FROM [usuarios_thona_test] WHERE Usuario = @usuario AND Contrasenia = @contrasenia";
            return resp;
        }
        #endregion
    }
}
