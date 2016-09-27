using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
  public class PersonaTelefonoDetalle
    {
        public int PersonasId;
        public string TipoTelefono;
        public string Telefono;

        public PersonaTelefonoDetalle(int PersonasId,string TipoTelefono,string Telefono)
        {
            this.PersonasId = PersonasId;
            this.TipoTelefono = TipoTelefono;
            this.Telefono = Telefono;
        }
    }
}
