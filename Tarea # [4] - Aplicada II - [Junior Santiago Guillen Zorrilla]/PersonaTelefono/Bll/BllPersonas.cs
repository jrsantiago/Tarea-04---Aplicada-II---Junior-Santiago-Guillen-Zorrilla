using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace Bll
{
   public class BllPersonas
    {
        DbPersona conect = new DbPersona();
         
        public int PersonasId;
        public string Nombre;
        public string sexo;

        public BllPersonas()
        {
            PersonasId = 0;
            Nombre = "";
            sexo = "";
        }

        public bool Insertar()
        {
            bool retorno = false;
            try
            {
                conect.Ejecutar(string.Format("Insert into Personas(Nombres,Sexo) values('{0}','{1}')", this.Nombre, this.sexo));
                retorno = true;
            }
            catch (Exception)
            {
                retorno =  false;
            }
            return retorno;
        }
        public bool Editar()
        {
            bool paso = false;

            paso = conect.Ejecutar(string.Format("Update Personas set Nombres ='{0}',Sexo='{1}' where PersonasId={2}",this.Nombre,this.sexo,this.PersonasId));
            return paso;
        }
        public bool Eliminar()
        {
            bool retorno = false;
            try
            {
              retorno = conect.Ejecutar(string.Format("delete  from Personas where id = {0}", this.PersonasId));
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                retorno = false;
            }
            return retorno;
           
        }
        public bool Buscar(Int32 IdBuscar)
        {
            bool encontro = false;

            DataTable dt = new DataTable();

            dt = conect.ObtenerDatos("select * from Personas where PersonasId =" + IdBuscar);
            if (dt.Rows.Count > 0)
            {
                encontro = true;
                this.Nombre = (string)dt.Rows[0]["Nombres"];
                this.sexo = (string)dt.Rows[0]["Sexo"];
            }
            return encontro;

        }
    }
}
