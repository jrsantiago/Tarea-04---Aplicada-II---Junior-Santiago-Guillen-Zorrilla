using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Bll;

namespace PersonaTelefono
{
    public partial class RegistroPersona : System.Web.UI.MasterPage
    {
        BllPersonas persona = new BllPersonas();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void llenarClase(BllPersonas per)
        {
            per.Nombre = TextNombre.Text;
            if(RadiButtonMasculino.Checked==true)
            {
                per.sexo = "M";
            }else if(RadioButtonFemenino.Checked==true)
            {
                per.sexo = "F";
            }
            
        }
        public void llenarCampo(BllPersonas per)
        { 
            
            TextNombre.Text = per.Nombre;
            if(per.sexo=="M")
            {
                RadiButtonMasculino.Checked = true;
                RadioButtonFemenino.Checked = false;
            }else if(per.sexo=="F")
            {
                RadioButtonFemenino.Checked = true;
                RadiButtonMasculino.Checked = false;
            }
        }
        protected void ButtAgregar_Click(object sender, EventArgs e)
        {
            Boolean paso = false;
            llenarClase(persona);
            paso = persona.Insertar();

            Response.Write("<script>window.alert('Agregado');</script>");
        }

        protected void ButBuscarId_Click(object sender, EventArgs e)
        {
            int id = 0;
            id = int.Parse(TextBuscarId.Text);
            persona.Buscar(id);
            llenarCampo(persona);
        }

        protected void ButtLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RPersonaMaster.aspx");
        }

        protected void ButtActualizar_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                if(string.IsNullOrWhiteSpace(TextBuscarId.Text))
                {
                    Response.Write("<script>window.alert('Introdusca el Id');</script>");
                }
                else
                {
                    id = int.Parse(TextBuscarId.Text);
                    persona.PersonasId = id;

                    llenarClase(persona);
                    persona.Editar();
                    Response.Write("<script>window.alert('Se Actualizó');</script>");
                }
            }
            catch (Exception) { }
        }
    }
}