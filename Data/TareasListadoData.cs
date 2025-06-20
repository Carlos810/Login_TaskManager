using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public class TareasListadoData
    {
        #region AcessoBaseDatos
        public DataTable ObtenerTareasDt()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfiguracionGlobal.CadenaConexion))
            {
                try
                {
                    string query = ListarTareas();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
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
            return dt;
        }
        public List<Tarea> ConvertirDataTableALista(DataTable dt)
        {
            var lista = new List<Tarea>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Tarea
                {
                    Id = row["IdTask"] != DBNull.Value ? Convert.ToInt32(row["IdTask"]) : 0,
                    Titulo = row["tituloTask"] != DBNull.Value ? row["tituloTask"].ToString() : string.Empty,
                    FechaAsignacion = row["FechaAsignacion"] != DBNull.Value
                    ? Convert.ToDateTime(row["FechaAsignacion"]).ToString("yyyy-MM-dd")
                    : DateTime.Now.ToString("yyyy-MM-dd"),
                                FechaVencimiento = row["fechaVencimiento"] != DBNull.Value
                    ? Convert.ToDateTime(row["fechaVencimiento"]).ToString("yyyy-MM-dd")
                    : DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),
                                EstatusTarea = row["IdEstatusTarea"] != DBNull.Value
                    ? Convert.ToInt32(row["IdEstatusTarea"])
                    : 0
                });
            }

            return lista;
        }

        public bool EditarTarea(Tarea tarea)
        {
            using (SqlConnection conn = new SqlConnection(ConfiguracionGlobal.CadenaConexion))
            {
                try
                {
                    string query = EditarTarea();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", tarea.Id);
                        cmd.Parameters.AddWithValue("@Titulo", tarea.Titulo);
                        cmd.Parameters.AddWithValue("@FechaVencimiento", tarea.FechaVencimiento);
                        cmd.Parameters.AddWithValue("@EstatusTarea", tarea.EstatusTarea);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        public bool AgregarTarea(Tarea tarea)
        {
            using (SqlConnection conn = new SqlConnection(ConfiguracionGlobal.CadenaConexion))
            {
                try
                {
                    string query = AgregarTarea();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", tarea.Titulo);
                        cmd.Parameters.AddWithValue("@FechaAsignacion", tarea.FechaAsignacion);
                        cmd.Parameters.AddWithValue("@FechaVencimiento", tarea.FechaVencimiento);
                        cmd.Parameters.AddWithValue("@EstatusTarea", tarea.EstatusTarea);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public bool EliminarTarea(Tarea tarea)
        {
            using (SqlConnection conn = new SqlConnection(ConfiguracionGlobal.CadenaConexion))
            {
                try
                {
                    string query = EliminarTarea();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", tarea.Id);

                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion


        #region queries-Sql
        internal string ListarTareas()
        {
            string resp = "";
            resp = "SELECT * FROM Tareas_thona_test";
            return resp;
        }

        internal string EliminarTarea()
        {
            string resp = "";
            resp = "DELETE FROM Tareas_thona_test WHERE IdTask = @Id";
            return resp;
        }
        internal string EditarTarea()
        {
            string resp = "";
            resp = @"UPDATE Tareas_thona_test 
                             SET tituloTask = @Titulo, 
                                 fechaVencimiento = @FechaVencimiento, 
                                 IdEstatusTarea = @EstatusTarea 
                             WHERE IdTask = @Id";
            return resp;
        }

        internal string AgregarTarea()
        {
            string resp = "";
            resp = @"INSERT INTO Tareas_thona_test 
                    (tituloTask,fechaAsignacion,fechaVencimiento, IdEstatusTarea ) 
                    VALUES(@Titulo,@FechaAsignacion,@FechaVencimiento,@EstatusTarea)";
            
            return resp;
        }
        #endregion
    }
}
