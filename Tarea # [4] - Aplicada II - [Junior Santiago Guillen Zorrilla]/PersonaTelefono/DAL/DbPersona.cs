using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
   public class DbPersona
    {
        private SqlConnection conect;
        private SqlCommand coman;

        public DbPersona()
        {
            conect = new SqlConnection(ConfigurationManager.ConnectionStrings["Personadb"].ConnectionString);
            coman = new SqlCommand();
        }

        public bool Ejecutar(String comandoSql)
        {
            bool retorno = false;
            try
            {
                conect.Open();
                coman.Connection = conect;
                coman.CommandText = comandoSql;
                coman.ExecuteNonQuery();
                retorno = true;

            }catch(Exception ex)
            {
                throw ex;

            }finally
            {
                conect.Close();
            }

            return retorno;
        }
        public DataTable ObtenerDatos(String comandoSql)
        {
            SqlDataAdapter adapter;
            DataTable dt = new DataTable();

            try
            {
                conect.Open();
                coman.Connection = conect;
                coman.CommandText = comandoSql;

                adapter = new SqlDataAdapter(coman);
                adapter.Fill(dt);

            }catch(Exception ex)
            {
                throw ex;

            }finally
            {
                conect.Close();
            }
            return dt;
        }
        public Object ObtenerValor(String comandoSql)
        {
            Object retorno = null;
            try
            {
                conect.Open();
                coman.Connection = conect;
                coman.CommandText = comandoSql;
                retorno = coman.ExecuteScalar();

            }catch(Exception ex)
            {
                throw ex;
            }finally
            {
                conect.Close();
            }
            return retorno;
        }
        
    }
}
