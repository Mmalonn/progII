using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository2025.Data
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            //_connection = new SqlConnection(@"Data Source=DESKTOP-VCSD500\SQLEXPRESS;Initial Catalog=db_almacen;Integrated Security=True;Trust Server Certificate=True");
            _connection = new SqlConnection(Properties.Resources.CadenaConexionLocal);
        }
        //hacer singleton
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }
        //crear metodo que consulta a procedimiento almacenado
        //y lo ejecuta en un try y catch
        public DataTable ExecuteSPQuery(string sp)
        {
            DataTable? dt = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                dt.Load(cmd.ExecuteReader());
                _connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                dt = null;
            }
            finally
            {
                _connection.Close();
            }
            return dt;
        }

        public DataTable ExecuteSPQuery2(string sp, int codigo)
        {
            DataTable? dt = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                dt = null;
            }
            finally
            {
                _connection.Close();
            }
            return dt;
        }
        public bool ExecuteSPQuery3(string sp, Dictionary<string, object> parametros)
        {
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var param in parametros)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}