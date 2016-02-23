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
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class Reporte_ReporteSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //        int Proceso_Reporte = Convert.ToInt32(Session["Proceso_Reporte"]);
        //        string sqlCommandText = @"SELECT dbo.PROVEEDOR.COD_PROCESO, dbo.PROVEEDOR.RIF, dbo.PROVEEDOR.LOOKUP, dbo.PROVEEDOR.RAZON_SOCIAL, dbo.PROVEEDOR.NAT_JUR,
        //dbo.PROVEEDOR.DIRECCION, dbo.PROVEEDOR.TELEFONO, dbo.PROVEEDOR.FAX, dbo.PROVEEDOR.CONTACTO, dbo.PROVEEDOR.E_MAIL,
        //dbo.PROVEEDOR.WEB_PAGE, dbo.PROVEEDOR.CUENTA_BANCO, dbo.PROVEEDOR.TIPO_CTA_BANCO, dbo.PROVEEDOR.PAIS,
        //dbo.PROVEEDOR.OBSERVACIONES, dbo.BANCO.DESCRIPCION, dbo.CIUDAD.DESCRIPCION AS CIUDAD, dbo.ESTADO.DESCRIPCION AS ESTADO,
        //dbo.PROVEEDOR.CONV_CNTRL, dbo.PROVEEDOR.CONV_CODE, E.NAME AS TIPO_SERVICIO, F.NAME AS TIPO_SERVICIO2, U.NOMBRE,
        //U2.NOMBRE AS APROBADOR, CASE dbo.PROVEEDOR.ANAL_C4 WHEN '0' THEN 'No' ELSE 'Si' END AS ANAL_C4,
        //CASE WHEN dbo.PROVEEDOR.ANAL_C5 = '0' THEN 'No' ELSE 'Si' END AS ANAL_C5, LTRIM(RTRIM(dbo.PROVEEDOR.COD_POSTAL)) AS COD_POSTAL
        //FROM dbo.PROVEEDOR INNER JOIN
        //dbo.BANCO ON dbo.PROVEEDOR.COD_BANCO = dbo.BANCO.COD_BANCO INNER JOIN
        //dbo.CIUDAD ON dbo.PROVEEDOR.COD_CIUDAD = dbo.CIUDAD.COD_CIUDAD INNER JOIN
        //dbo.ESTADO ON dbo.CIUDAD.COD_ESTADO = dbo.ESTADO.COD_ESTADO INNER JOIN
        //SISAP.SUNDB433_VE_P.dbo.SSRFANV AS E ON E.CODE = dbo.PROVEEDOR.TIPO_SERVICIO COLLATE Latin1_General_Bin AND E.SUN_DB = 'PVL' AND
        //E.CATEGORY = 'C1' INNER JOIN
        //SISAP.SUNDB433_VE_P.dbo.SSRFANV AS F ON F.CODE = dbo.PROVEEDOR.TIPO_SERVICIO2 COLLATE Latin1_General_Bin AND F.SUN_DB = 'PVL' AND
        //F.CATEGORY = 'C1' INNER JOIN
        //dbo.USUARIOS AS U ON dbo.PROVEEDOR.COD_SOLICITANTE = U.COD_USUARIO INNER JOIN
        //dbo.USUARIOS AS U2 ON dbo.PROVEEDOR.COD_APROB1 = U2.COD_USUARIO
        //WHERE (dbo.PROVEEDOR.COD_PROCESO = " + Proceso_Reporte + ")";

        //        DataSet proveedordetails = new DataSet();
        //        SqlConnection conobj = new SqlConnection(WebConfigurationManager.AppSettings["ConnectionString"].ToString());

        //        conobj.Open();
        //        //SqlCommand cmdobj = new SqlCommand(sqlCommandText, conobj);
        //        SqlDataAdapter adpobj = new SqlDataAdapter(sqlCommandText, conobj);
        //        adpobj.Fill(proveedordetails);
        //        ReportViewer1.LocalReport.DataSources = proveedordetails;

        //        conobj.Close();
    }

}
