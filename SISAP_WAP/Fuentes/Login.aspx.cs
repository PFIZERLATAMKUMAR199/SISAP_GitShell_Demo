using System;
using System.Data;
using System.Web.UI;
using proveedor;
using WebApplication2.Autenticar;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
    }

    protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        lblError.Text = "";
        string ldap = System.Configuration.ConfigurationManager.AppSettings["LDAP"];
        string ldap_wyeth = System.Configuration.ConfigurationManager.AppSettings["LDAP_WYETH"];
        string dominio = System.Configuration.ConfigurationManager.AppSettings["DOMINIO"];
        string perfil;
        bool testLogon = System.Boolean.Parse(System.Configuration.ConfigurationManager.AppSettings["TEST_LOGON"]);
        DataSet ds = new DataSet();

        Procesar_proveedor tabla = new Procesar_proveedor(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

        Autenticar oAutenticar = new Autenticar();

        //oAutenticar.Url = System.Configuration.ConfigurationManager.AppSettings["Url_WS_Autenticar"];

        try
        {
            if (!testLogon)
            {
                if (oAutenticar.IsAutenticado(ldap, txtUsuario.Text.Trim(), txtClave.Text.Trim(), dominio))
                {
                    ds = tabla.Existe(txtUsuario.Text.Trim());

                    if (ds.Tables["tabla"].Rows.Count > 0)
                    {
                        perfil = ds.Tables["tabla"].Rows[0]["COD_PERFIL"].ToString();

                        //if (perfil == "4" || perfil =="5")
                        //{
                        //    Response.Redirect("Aprobar_proveedor.aspx", false);
                        //}
                        //else
                        //{
                        //    if (perfil == "1")
                        //    {
                        //        Response.Redirect("Bancos.aspx", false);
                        //    }
                        //    else if (perfil == "3")
                        //    {
                        //        Response.Redirect("Consulta_proveedor.aspx", false);
                        //    }
                        //    else
                        //    {
                        //        Response.Redirect("Index.aspx", false);
                        //    }
                        //}
                        Response.Redirect("Inicio.aspx", false);
                        Session["Usuario"] = txtUsuario.Text.Trim();
                    }
                    else
                    {
                        this.lblError.Text = "Acceso Denegado, por favor comuníquese con el departamento de Tecnología para procesar su acceso.";
                        return;
                    }
                }
                else
                {
                    this.lblError.Text = "Acceso Denegado, por favor verifique sus datos.";
                    return;
                }
            }
            else
            {
                ds = tabla.Existe(txtUsuario.Text.Trim());
                if (ds.Tables["tabla"].Rows.Count > 0)
                {
                    perfil = ds.Tables["tabla"].Rows[0]["COD_PERFIL"].ToString();

                    //if (perfil == "4" || perfil =="5")
                    //{
                    //    Response.Redirect("Aprobar_proveedor.aspx", false);
                    //}
                    //else
                    //{
                    //    if (perfil == "1")
                    //    {
                    //        Response.Redirect("Bancos.aspx", false);
                    //    }
                    //    else if (perfil == "3")
                    //    {
                    //        Response.Redirect("Consulta_proveedor.aspx", false);
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("Index.aspx", false);
                    //    }
                    //}
                    Response.Redirect("Inicio.aspx", false);
                    Session["Usuario"] = txtUsuario.Text.Trim();
                }
                else
                {
                    this.lblError.Text = "Acceso Denegado, por favor comuníquese con el departamento de Tecnología para procesar su acceso.";
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                if (oAutenticar.IsAutenticado(ldap_wyeth, txtUsuario.Text.Trim(), txtClave.Text.Trim(), dominio))
                {
                    ds = tabla.Existe(txtUsuario.Text.Trim());
                    if (ds.Tables["tabla"].Rows.Count > 0)
                    {
                        perfil = ds.Tables["tabla"].Rows[0]["COD_PERFIL"].ToString();
                        Response.Redirect("Inicio.aspx", false);
                        Session["Usuario"] = txtUsuario.Text.Trim();
                    }
                    else
                    {
                        this.lblError.Text = "Acceso Denegado, por favor comuníquese con el departamento de Tecnología para procesar su acceso.";
                        return;
                    }
                }
            }
            catch (Exception ex2)
            {
                if (ex2.Message.IndexOf("Logon failure") != -1)
                {
                    lblError.Text = "El Nombre de Usuario o la Contraseña son incorrectos, por favor verifique sus datos e inténtelo de nuevo.";
                }
                else
                {
                    lblError.Text = ex2.Message.ToString();
                }
            }

            if (ex.Message.IndexOf("Logon failure") != -1)
            {
                lblError.Text = "El Nombre de Usuario o la Contraseña son incorrectos, por favor verifique sus datos e inténtelo de nuevo.";
            }
            else
            {
                lblError.Text = ex.Message.ToString();
            }
        }
    }
}