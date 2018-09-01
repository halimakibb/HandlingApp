using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHandling_Lib.Model
{
    public class CommonDataModel
    {

        public enum ActiveType { NotActive, Active }
        public enum SaveType { Add, Edit }

        public class ErrorLog
        {
            public string errorSource { get; set; }
            public string errorMessage { get; set; }
            public string stackTrace { get; set; }
        }

        public class UserProfile
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Telephone { get; set; }
            public string Role { get; set; }
            public string AuthParameter { get; set; }
            public List<MasterDataModel.MasterDataRole> Roles { get; set; }
            public List<MasterDataModel.AuthParameter> AuthParameters { get; set; }

        }

    }
}
