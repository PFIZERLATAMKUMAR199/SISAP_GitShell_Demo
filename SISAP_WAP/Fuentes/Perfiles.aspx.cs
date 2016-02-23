using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using proveedor;

public partial class Perfiles : System.Web.UI.Page
{
    String jsID;
    DataTable TB;
    string cadena = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ibtnAgregarMenu_Click(object sender, ImageClickEventArgs e)
    {
        string CodPerfil;
        string CodMenu;

        Procesar_proveedor Datos = new Procesar_proveedor(cadena);
        try
        {
            CodPerfil = GridView1.SelectedValue.ToString();
            CodMenu = DropDownList1.SelectedValue.ToString();
            TB = Datos.TraerTabla("sp_InsertarPerfilMenu " + CodPerfil.ToString() + "," + CodMenu.ToString());

            if (TB.Rows[0]["RESULTADO"].ToString() == "2")
            {
                jsID = "<script language='javascript'>";
                jsID += "alert('El menu " + DropDownList1.SelectedItem.ToString() + " ya existe dentro del perfil. Por favor seleccione uno nuevo.');";
                jsID += "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "VentanaMensaje", jsID);
            }
            GridView2.DataBind();

        }
        catch(Exception ex)
        { 


        }       
    }
    protected void ibtnAgregarPerfil_Click(object sender, ImageClickEventArgs e)
    {
        Procesar_proveedor Datos = new Procesar_proveedor(cadena);
        try
        {
            
            TB = Datos.TraerTabla("sp_InsertarPerfil " + txtPerfil.Text.Trim());

            if (TB.Rows[0]["RESULTADO"].ToString() == "2")
            {
                jsID = "<script language='javascript'>";
                jsID += "alert('El perfil " + txtPerfil.Text.Trim() + " ya existe. Por favor seleccione uno nuevo.');";
                jsID += "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "VentanaMensaje", jsID);
            }
            GridView1.DataBind();

        }
        catch (Exception ex)
        {


        }       
    }
}
