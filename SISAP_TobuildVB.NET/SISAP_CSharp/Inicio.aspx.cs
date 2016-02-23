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
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Web.Configuration;


public partial class Inicio : System.Web.UI.Page
{
    public string Groups { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var context = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["DOMINIO"].ToString());
            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, HttpContext.Current.User.Identity.Name);

            // Below Lines are kept for testing purpose

            //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\KUMAR199");
            //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\BIRAJN");
            //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\AGARWD06");

            // Below Lines are kept for testing purpose
            Session["UserNTID"] = (HttpContext.Current.User.Identity.Name).Substring(5);

            //Session["UserNTID"] = ("AMER\\KUMAR199").Substring(5);
            //Session["UserNTID"] = ("AMER\\BIRAJN").Substring(5);
            //Session["UserNTID"] = ("AMER\\AGARWD06").Substring(5);
            Session["NOMBRE"] = userPrincipal.GivenName + " " + userPrincipal.Surname;

            SISAP.Utility.ADAuthorizationUtil adAuth = new SISAP.Utility.ADAuthorizationUtil();
            Groups = SISAP.Utility.ADAuthorizationUtil.AllADgroups;
            var ADgroup = Groups;

            try
            {
                if (true == adAuth.IsAuthenticated(ADgroup))
                {

                    List<string> groups = new List<string>();
                    foreach (string item in adAuth.GetGroupsForUser())
                    {
                        groups.Add(item.ToString());
                    }
                    Session["ADGroup"] = groups[0].ToString();
                }
                else
                {
                    Response.Write("Acceso Denegado, por favor comuníquese con el departamento de Tecnología para procesar su acceso.");
                }
            }
            catch (Exception)
            {
                Response.Write("Acceso Denegado, por favor comuníquese con el departamento de Tecnología para procesar su acceso.");
            }
        }
    }
}
