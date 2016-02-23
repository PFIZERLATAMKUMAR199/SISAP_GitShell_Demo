using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Web;
using System.DirectoryServices.AccountManagement;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2
{
    public class ADAuthorizationUtil
    {
        private string _path;
        private string _filterAttribute;

        public const string SISAPAdmin = "CCS-SISAP-ADMIN-L";
        public const string SISAPSOLICITANTE = "CCS-SISAP-SOLICITANTE-L";
        public const string SISAPPAprobadorL = "CCS-SISAP-PAprobador-L";
        public const string SISAPSAprobadorL = "CCS-SISAP-SAprobador-L";
        public const string comma = ",";
        public const string AllADgroups = SISAPAdmin + comma + SISAPSOLICITANTE + comma + SISAPPAprobadorL + comma + SISAPSAprobadorL;

        //public ADAuthorizationUtil(string path)
        //{
        //    _path = path;
        //}

        public bool IsAuthenticated(string ADgroup)
        {
            var context = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["DOMINIO"].ToString());
            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, HttpContext.Current.User.Identity.Name);
            //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\BIRAJN");

            var adGroups = ADgroup.Split(new char[1] { ',' });
            foreach (var group in adGroups)
            {
                bool isExist = IsExistADGroup(group);

                if (isExist)
                {
                    if (userPrincipal.IsMemberOf(context, IdentityType.Name, group))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsExistADGroup(string group)
        {
            try
            {
                using (var context = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["DOMINIO"].ToString()))
                {
                    var groupPrincipal = GroupPrincipal.FindByIdentity(context, group);

                    if (groupPrincipal != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetGroupsForUser()
        {
            try
            {
                List<string> result = new List<string>();
                var adGroups = AllADgroups.Split(new char[1] { ',' });
                var context = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["DOMINIO"].ToString());
                var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, HttpContext.Current.User.Identity.Name);
                //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\BIRAJN");

                foreach (var group in adGroups)
                {
                    bool isExist = IsExistADGroup(group);

                    if (isExist)
                    {
                        if (userPrincipal.IsMemberOf(context, IdentityType.Name, group))
                        {
                            result.Add(group);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Temp code
        public string GetUserADGroup(string username)
        {
            //ADO code for getting the ADGroupName.
            string ADGroupName = "";
            using (SqlConnection conobj = new SqlConnection(WebConfigurationManager.AppSettings["ConnectionString"].ToString()))
            {
                conobj.Open();
                SqlCommand cmdobj = new SqlCommand("Select GroupName from  dbo.ADGroupUsuarioMapping where COD_USUARIO = '" + username + "'", conobj);
                SqlDataReader rd = cmdobj.ExecuteReader();

                while (rd.Read())
                {
                    ADGroupName = rd.GetString(0);
                }

            }

            return ADGroupName;
        }

        public DataTable GetMembersFromADGroup(string ADGroupname)
        {
            DataTable dtMembers = new DataTable();
            dtMembers.Columns.Add("NOMBRE", typeof(string));
            dtMembers.Columns.Add("COD_USUARIO", typeof(string));
            dtMembers.Rows.Add("", "");
            var context = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["DOMINIO"].ToString());
            string domain = WebConfigurationManager.AppSettings["DOMINIO"].ToString();

            var groupPrincipal = GroupPrincipal.FindByIdentity(context, ADGroupname);

            if (groupPrincipal != null)
            {
                // iterate over members
                foreach (Principal p in groupPrincipal.GetMembers())
                {
                    //Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
                    string displayname = p.DisplayName;
                    string objectclass = p.StructuralObjectClass;
                    // do whatever you need to do to those members
                    UserPrincipal theUser = p as UserPrincipal;

                    if (theUser != null)
                    {
                        if (!theUser.IsAccountLockedOut())
                        {
                            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, domain + "\\" + theUser.ToString());
                            dtMembers.Rows.Add(userPrincipal.GivenName + " " + userPrincipal.Surname, theUser.ToString());
                        }
                    }
                }
            }
            return dtMembers;
        }

        public string GetNombreByNTID(string NTID)
        {
            string NTIDWithDomain = "AMER\\" + NTID;
            var context = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["DOMINIO"].ToString());
            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, NTIDWithDomain);
            return userPrincipal.GivenName + " " + userPrincipal.Surname;
        }

        public string GetEmailByNTID(string NTID)
        {
            string NTIDWithDomain = "AMER\\" + NTID;
            var context = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["DOMINIO"].ToString());
            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, NTIDWithDomain);
            return (userPrincipal.EmailAddress).ToString();
        }
    }
}