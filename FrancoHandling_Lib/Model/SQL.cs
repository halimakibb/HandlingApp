using ComLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHandling_Lib
{
    public class SQL
    {
        private static DbTransaction dbtran = new DbTransaction(ConfigurationManager.ConnectionStrings["DB_FrancoHandling"].ConnectionString);

        public enum ActiveType
        {
            NotActive,
            Active
        }
        public static List<Entity.MasterDataDriver> GetMasterDataDriver()
        {
            List<Entity.MasterDataDriver> li = dbtran.DbToList<Entity.MasterDataDriver>("sp_GetMasterDataDriver", true);
            return li;
        }

        public static List<Entity.MasterDataDriver> GetMasterDataDriver(ActiveType activeType)
        {
            List<Entity.MasterDataDriver> li =  dbtran.DbToList<Entity.MasterDataDriver>("sp_GetMasterDataDriver", new { ActiveType = activeType }, true);
            return li;
        }

        public static string AddMasterDataDriver(Entity.MasterDataDriver item, string loginUser)
        {
            string res = dbtran.DbToString("sp_AddMasterDataDriver", 
                            new {
                                    FileName = item.FileName ,
                                    FileBytes = item.FileBytes,
                                    LoginUser = loginUser,
                                    Name = item.Name,
                                    Address = item.Address,
                                    Birthday = item.Birthday,
                                    Phone1 = item.Phone1,
                                    Phone2 = item.Phone2,
                                    Email = item.Email
                                }, true);

            return res;
        }

        public static string EditMasterDataDriver(Entity.MasterDataDriver item, string loginUser)
        {
            string res = dbtran.DbToString("sp_EditMasterDataDriver",
                            new
                            {
                                Driver_ID_PK = item.Driver_ID_PK,
                                FileName = item.FileName,
                                FileBytes = item.FileBytes,
                                LoginUser = loginUser,
                                Name = item.Name,
                                Address = item.Address,
                                Birthday = item.Birthday,
                                Phone1 = item.Phone1,
                                Phone2 = item.Phone2,
                                Email = item.Email
                            }, true);

            return res;
        }
        public static string DeleteMasterDataDriver(Int64 driverID, string loginUser)
        {
            string res = dbtran.DbToString("sp_DeleteMasterDataDriver",
                            new
                            {
                                Driver_ID_PK = driverID,
                                LoginUser = loginUser
                            }, true);

            return res;
        }
    }
}
