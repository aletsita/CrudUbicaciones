using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Capas
using BLL;
using DALL;

namespace CrudUbicaciones
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        ubicaciones_BLL oubicacionesBLL;
        UbicacionesDALL oubicacionesDALL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUbicaciones();
            }
        }

        //Metodo encargado de listar los datos de la BD en un GRIDView
        public void ListarUbicaciones() 
        {
            oubicacionesDALL = new UbicacionesDALL();
            gvUbicaciones.DataSource = oubicacionesDALL.Listar();
            gvUbicaciones.DataBind();
        }

        //Metodo encargado de recolectar los datos de nuestra interfaz!
        public ubicaciones_BLL datosUbicacion() 
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);

            //Recolectar datos para la capa de presentacion
            oubicacionesBLL = new ubicaciones_BLL();
            oubicacionesBLL.ID = ID;
            oubicacionesBLL.Ubicacion = txtUbicacion.Text;
            oubicacionesBLL.Latitud = txtLat.Text;
            oubicacionesBLL.Longitud = txtLong.Text;

            return oubicacionesBLL;
        }

    }
}