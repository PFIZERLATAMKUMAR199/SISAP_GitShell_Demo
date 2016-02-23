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

namespace SISAP.Utility
{
    public class ADAuthorizationUtil
    {

        public const string SISAPAdmin = "CCS-SISAP-ADMIN-L";
        public const string SISAPSOLICITANTE = "CCS-SISAP-SOLICITANTE-L";
        public const string SISAPPAprobadorL = "CCS-SISAP-PAprobador-L";
        public const string SISAPSAprobadorL = "CCS-SISAP-SAprobador-L";
        public const string comma = ",";
        public const string slashSeparator = "\\";
        public const string AllADgroups = SISAPAdmin + comma + SISAPSOLICITANTE + comma + SISAPPAprobadorL + comma + SISAPSAprobadorL;

        public bool IsAuthenticated(string ADgroup)
        {
            var context = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["DOMINIO"].ToString());
            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, HttpContext.Current.User.Identity.Name);

            // Below Lines are kept for testing purpose
            //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\KUMAR199");
            //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\BIRAJN");
            //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\AGARWD06");
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
                // Below Lines are kept for testing purpose

                //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\KUMAR199");
                //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\BIRAJN");
                //var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "AMER\\AGARWD06");

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
                foreach (Principal p in groupPrincipal.GetMembers())
                {
                    string displayname = p.DisplayName;
                    string objectclass = p.StructuralObjectClass;
                    UserPrincipal theUser = p as UserPrincipal;

                    if (theUser != null)
                    {
                        if (!theUser.IsAccountLockedOut())
                        {
                            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, domain + slashSeparator + theUser.ToString());
                            dtMembers.Rows.Add(userPrincipal.GivenName + " " + userPrincipal.Surname, theUser.ToString());
                        }
                    }
                }
            }
            return dtMembers;
        }

        public string GetNombreByNTID(string NTID)
        {
            string NTIDWithDomain = WebConfigurationManager.AppSettings["DOMINIO"].ToString() + slashSeparator + NTID;
            var context = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["DOMINIO"].ToString());
            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, NTIDWithDomain);
            return userPrincipal.GivenName + " " + userPrincipal.Surname;
        }

        public string GetEmailByNTID(string NTID)
        {
            string NTIDWithDomain = WebConfigurationManager.AppSettings["DOMINIO"].ToString()+ slashSeparator + NTID;
            var context = new PrincipalContext(ContextType.Domain, WebConfigurationManager.AppSettings["DOMINIO"].ToString());
            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, NTIDWithDomain);
            return (userPrincipal.EmailAddress).ToString();
        }
    }
}