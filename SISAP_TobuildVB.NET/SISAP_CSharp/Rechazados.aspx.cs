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
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Rechazados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["NOMBRE"].ToString()) || string.IsNullOrEmpty(Session["UserNTID"].ToString()))
        {
            Response.Redirect("Inicio.aspx");
        }
        else
        {
            DataSet grdvProveedorSource = new DataSet();
            using (SqlConnection conobj = new SqlConnection(WebConfigurationManager.AppSettings["ConnectionString"].ToString()))
            {
                conobj.Open();
                string nombre = Session["NOMBRE"].ToString();
                string userNTID = Session["UserNTID"].ToString();
                SqlCommand cmdobj = new SqlCommand("sp_dsAprobaciones", conobj);
                cmdobj.CommandType = CommandType.StoredProcedure;
                cmdobj.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre;
                cmdobj.Parameters.Add("@NTID", SqlDbType.VarChar).Value = userNTID;
                SqlDataAdapter adppbj = new SqlDataAdapter(cmdobj);
                adppbj.Fill(grdvProveedorSource);
                conobj.Close();
            }
            grdvProveedor.DataSource = grdvProveedorSource.Tables[0];
            grdvProveedor.DataSourceID = null;
            grdvProveedor.DataBind();
        }
    }
}
