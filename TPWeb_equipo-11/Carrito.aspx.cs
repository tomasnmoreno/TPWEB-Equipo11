using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_11
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<dominio.Carrito> listaCarrito;
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    
                    listaCarrito = (List<dominio.Carrito>)Session["listaCarrito"];
                    repCarrito.DataSource = listaCarrito;
                    repCarrito.DataBind();

                    decimal totalCarrito = CalcularTotalCarrito(listaCarrito);
                    lblTotalCarrito.Text = "Total del Carrito: $" + totalCarrito.ToString("0.00");
                }
            //if (Session["listaCarrito"] != null)
            //{
            //    List<dominio.Carrito> listaCarrito = (List<dominio.Carrito>)Session["listaCarrito"];
            //    //List<Articulo> listaCarritoArticulos = (List<Articulo>)Session["listaCarrito"];


            //}
        }
            private decimal CalcularTotalCarrito(List<dominio.Carrito> articulos)
            {
                decimal total = 0;

                foreach (var articulo in articulos)
                {
                    total += articulo.agregado.precio * articulo.cantidad;
                }

                return total;
            }
        
    }
}
