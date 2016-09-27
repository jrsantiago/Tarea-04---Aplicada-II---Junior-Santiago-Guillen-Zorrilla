using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace Bll
{
  public class BllPersonaTelefono
    {
        DbPersona conect = new DbPersona();
        public int Id;
        public int PersonasId;
        public string TipoTelefono;
        public string Telefono;
        public List<PersonaTelefonoDetalle> PTelefono; 

        public BllPersonaTelefono()
        {
            Id = 0;
            PersonasId = 0;
            TipoTelefono = "";
            Telefono = "";
            PTelefono = new List<PersonaTelefonoDetalle>();
        }
        public DbPersona Buscar(Int32 idBuscar)
        {
            this.PersonasId = idBuscar;
            bool encontro = false;
            DataTable dt = new DataTable();
            //string perid = "";
             conect.ObtenerDatos("select * from PersonasTelefonos where PersonasID =" + idBuscar);
            if (idBuscar != 0)
                encontro = true;

            return conect;
        }
        public DataTable Listado(int id)
        {
            return conect.ObtenerDatos("select * from PersonasTelefonos where PersonasId ="+id);
        }
        public bool Insertar(String datos)
        {
            bool retorno = false;
            try
            {
                conect.Ejecutar(string.Format(datos));
                retorno = true;
            }catch(Exception)
            {
                retorno = false;
            }
            return retorno;
        }
        public bool InsertarGrid()
        {
            int retorno = 0;

            try
            {
               retorno = Convert.ToInt32(conect.ObtenerValor(String.Format("Insert Into PersonasTelefonos (PersonasId,TipoTelefono,Telefono) Values({0},'{1}','{2}'); SELECT SCOPE_IDENTITY(); --", this.PersonasId, this.TipoTelefono, this.Telefono)));
                if (retorno > 0)
                {

                    foreach (PersonaTelefonoDetalle pd in PTelefono)
                    {
                        conect.Ejecutar("Insert Into PersonasTelefonos (PersonasId,TipoTelefono,Telefono) Values("+retorno+",'"+pd.TipoTelefono+"','"+pd.Telefono+"')--");
                    }
                }
            }catch
            {
                retorno = 0;
            }
            return retorno > 0;
        }
        public void AgregarDetalle(int personaid,string tipoTelefono,string telefono)
        {
            this.PTelefono.Add(new PersonaTelefonoDetalle(personaid, tipoTelefono, telefono));
        }
        
    }
}
