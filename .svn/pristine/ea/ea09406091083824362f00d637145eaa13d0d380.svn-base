using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using FrancoHandling_Lib.Model;

namespace FrancoHandling_Lib
{
    public class UserProfile
    {
        public const string USER_INTERNAL = "USER_INTERNAL";
        public const string USER_EKSTERNAL = "USER_EKSTERNAL";
        public const string USER_ADMIN = "USER_ADMIN";
        public const string USER_REPORT = "USER_REPORT";

        protected const string spGetUserProfileIsValidate = "[dbo].[sp_GetUserProfileIsValid]";
        protected const string spGetUserProfile = "[dbo].[sp_GetUserProfile]";

        public static string GetUserProfileIsValidate(string Username, string Password)
        {
            return DbTransaction.DbToString(spGetUserProfileIsValidate, new { Username = Username, Password = Password }, true);                
        }

        public static void GetUserProfile(string Username)
        {
            List<CommonDataModel.UserProfile> listuser = DbTransaction.DbToList<CommonDataModel.UserProfile>(spGetUserProfile, new { username = Username }, true);
            if (listuser.Count > 0)
                HttpContext.Current.Session["UserProfile"] = listuser;
            else
                HttpContext.Current.Session.Clear();
                
        }

        public static List<CommonDataModel.UserProfile> ListUserProfile()
        {
            //set userprofile from session
            List<CommonDataModel.UserProfile> userprofile = HttpContext.Current.Session["UserProfile"] as List<CommonDataModel.UserProfile>;

            //set userprofile and list role
            if (userprofile.Count > 0)
            {
                //add role to list role in user preofile
                string role = userprofile[0].Role;
                
                List<MasterDataModel.MasterDataRole> roles = new List<MasterDataModel.MasterDataRole>();
                foreach(string item in role.Split('|'))
                {
                    roles.Add(new MasterDataModel.MasterDataRole { 
                        RoleID = new Guid(item.Split(';')[0]),
                        RoleName = item.Split(';')[1]
                    });
                }

                //set user profile dan list role
                userprofile.Add(new CommonDataModel.UserProfile
                {
                    Username = userprofile[0].Username,
                    Email = userprofile[0].Email,
                    Telephone = userprofile[0].Telephone,
                    Role = userprofile[0].Role,
                    Roles = roles
                });
            }

            return userprofile;
        }

        public static void SetUserProfile()
        {
            //set userprofile from session
            List<CommonDataModel.UserProfile> userprofile = HttpContext.Current.Session["UserProfile"] as List<CommonDataModel.UserProfile>;

            //set userprofile and list role
            if (userprofile.Count > 0)
            {
                //add role to list role in user preofile
                string role = userprofile[0].Role;

                List<MasterDataModel.MasterDataRole> roles = new List<MasterDataModel.MasterDataRole>();
                foreach (string item in role.Split('|'))
                {
                    roles.Add(new MasterDataModel.MasterDataRole
                    {
                        RoleID = new Guid(item.Split(';')[0]),
                        RoleName = item.Split(';')[1]
                    });
                }

                //add role to list role in user preofile
                string auth = userprofile[0].AuthParameter;
                List<MasterDataModel.AuthParameter> auths = new List<MasterDataModel.AuthParameter>();

                if (!string.IsNullOrEmpty(auth))
                {
                    foreach (string item in auth.Split('|'))
                    {
                        auths.Add(new MasterDataModel.AuthParameter
                        {
                            ParameterName = item.Split(';')[0],
                            ParameterValue = item.Split(';')[1]
                        });
                    }
                }

                //set static value userprofile               
                Username = userprofile[0].Username;
                Email = userprofile[0].Email;
                Telephone = userprofile[0].Telephone;
                Roles = roles;
                AuthParameters = auths;
            }
        }

        public static void Clear()
        {      
            Username = string.Empty;
            Email = string.Empty;
            Telephone = string.Empty;
            Roles = null;
            AuthParameters = null;
        }

        public static void SetAuthorization(string Role)
        {
            if (UserProfile.Roles == null)
            {
                HttpContext.Current.Response.Redirect("~/Pages/Home.aspx", false);
                return;
            }

            bool foundrole = false;
            foreach (MasterDataModel.MasterDataRole role in UserProfile.Roles)
            {
                if (role.RoleName.Contains(Role))
                {
                    foundrole = true; 
                    break;
                }
            }

            if (!foundrole)
            {
                HttpContext.Current.Response.Redirect("~/Pages/ErrorPage/Unauthorized.aspx", false);
                return;
            }
        }

        public static void SetAuthorization(string[] Roles)
        {
            if (UserProfile.Roles == null)
            {
                HttpContext.Current.Response.Redirect("~/Pages/Home.aspx", false);
                return;
            }

            bool foundrole = false;
            foreach (MasterDataModel.MasterDataRole role in UserProfile.Roles)
            {
                foreach (string item in Roles)
                {
                    if (role.RoleName.Contains(item))
                    {
                        foundrole = true; 
                        break;
                    }
                }
            }

            if (!foundrole)
            {
                HttpContext.Current.Response.Redirect("~/Pages/ErrorPage/Unauthorized.aspx", false);
                return;
            }
        }


        public static string Username { get; set; }
        public static string Email { get; set; }
        public static string Telephone { get; set; }
        public static List<MasterDataModel.MasterDataRole> Roles { get; set; }
        public static List<MasterDataModel.AuthParameter> AuthParameters { get; set; } 

    }
}
