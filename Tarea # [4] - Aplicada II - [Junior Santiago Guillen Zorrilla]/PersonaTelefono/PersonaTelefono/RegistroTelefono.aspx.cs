using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace PersonaTelefono
{
    public partial class RegistroTelefono : System.Web.UI.Page
    {
        BllPersonaTelefono persona = new BllPersonaTelefono();
       public int IdPersona;
       public  string TipoTelefono;
        public RegistroTelefono()
        {
            IdPersona = 0;
            TipoTelefono = "";
            
        }
        public void LlenarDatos(BllPersonaTelefono per)
        {
            if (RadioBuCelular.Checked == true)
            {
                TipoTelefono = "Celular";
            }
            else if (RadioBuLocal.Checked == true)
            {
                TipoTelefono = "Local";
            }
            per.PersonasId = Convert.ToInt32(TextbBuscarId.Text);
            //per.TipoTelefono = this.TipoTelefono;
            //per.Telefono = TextBTelefono.Text;

            per.TipoTelefono = TipoTelefono;
            per.Telefono = TextBTelefono.Text;

            foreach(GridViewRow dr in GridViewTelefono.Rows)
            {
                per.AgregarDetalle(Convert.ToInt32(dr.Cells[0].Text),Convert.ToString(dr.Cells[1]),Convert.ToString(dr.Cells[2]));
            }

          
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtBuscarId_Click(object sender, EventArgs e)
        {
           
            if(string.IsNullOrWhiteSpace(TextbBuscarId.Text))
            {
                Response.Write("<script>window.alert('Introdusca el Id');</script>");
            }
            else
            {
               this.IdPersona = int.Parse(TextbBuscarId.Text);             

               GridViewTelefono.DataSource = persona.Listado(IdPersona);
               GridViewTelefono.DataBind();
            }

            
        }
        public void llenarClase(BllPersonaTelefono per)
        {
            if(RadioBuCelular.Checked==true)
            {
                this.TipoTelefono = "Celular";
            }
            else if (RadioBuLocal.Checked==true)
            {
                this.TipoTelefono = "Local";
            }

            per.PersonasId = IdPersona;
            per.Telefono = TextBTelefono.Text;
            per.TipoTelefono = TipoTelefono;
            
            
        }
        public DataTable LlenarGri()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PersonaId", typeof(string));
            dt.Columns.Add("TipoTelefono", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            return dt;
        }
        public void Limpiar()
        {
            RadioBuCelular.Checked = false;
            RadioBuLocal.Checked = false;
            TextBTelefono.Text = "";
        }
        public void llenarCampo(BllPersonaTelefono per)
        {
            TipoTelefono = per.TipoTelefono;
            if(TipoTelefono=="Local")
            {
                RadioBuLocal.Checked = true;

            }else if(TipoTelefono=="Celular")
            {
                RadioBuCelular.Checked = true;
            }
            TextBTelefono.Text = per.Telefono;
          
        }
        protected void ButtGuardar_Click(object sender, EventArgs e)
        {
            BllPersonaTelefono perso = new BllPersonaTelefono();

            LlenarDatos(perso);
            perso.InsertarGrid();
            
               Response.Write("<script>window.alert('Guardado');</script>");
            
            
                
            
        }
        protected void ButtAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
           
        }
        protected void ButtLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistroTelefono.aspx");
        }
        public DataTable Agregar()
        {
            //GridViewTelefono.DataSource = llenarGrid();
            //GridViewTelefono.DataBind();
            llenarClase(persona);
            LlenarDatos(persona);
            DataTable tabla;

            if (Session["dt"] == null)
            {
                DataTable dt = LlenarGri();
                DataRow Row1;
                Row1 = dt.NewRow();
                Row1["PersonaId"] = TextbBuscarId.Text;
                Row1["TipoTelefono"] = this.TipoTelefono;
                Row1["Telefono"] = TextBTelefono.Text;

                dt.Rows.Add(Row1);
                GridViewTelefono.DataSource = dt;
                GridViewTelefono.DataBind();
                Session["dt"] = dt;
                tabla = dt;
            }
            else
            {
                DataTable dt = (Session["dt"]) as DataTable;
                DataRow Row1;
                Row1 = dt.NewRow();
                Row1["PersonaId"] = TextbBuscarId.Text;
                Row1["TipoTelefono"] = this.TipoTelefono;
                Row1["Telefono"] = TextBTelefono.Text;
                dt.Rows.Add(Row1);
                GridViewTelefono.DataSource = dt;
                GridViewTelefono.DataBind();
                Session["dt"] = dt;
                tabla = dt;
            }
            Response.Write("<script>window.alert('Agregado');</script>");
              //Limpiar();
           
            return tabla;
            
        }
    
    }
}