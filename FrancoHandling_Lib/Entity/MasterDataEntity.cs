using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrancoHandling_Lib.Model;


namespace FrancoHandling_Lib.Entity
{
    public class MasterDataEntity
    {

        #region Master Data Driver
        public static List<MasterDataModel.MasterDataDriver> GetMasterDataDriver()                                                                                                                                                                 
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataDriver>("sp_GetMasterDataDriver", true);
        }

        public static List<MasterDataModel.MasterDataDriver> GetMasterDataDriver(CommonDataModel.ActiveType activetype)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataDriver>("sp_GetMasterDataDriver", new { ActiveType = (int)activetype }, true);
        }

        public static List<MasterDataModel.MasterDataDriver> GetMasterDataDriver_CMB()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataDriver>("sp_GetMasterDataDriver_CMB", true);
        }

        public static List<MasterDataModel.MasterDataDriver> GetMasterDataDriverByTransporterID_CMB(int transporter_ID)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataDriver>("sp_GetMasterDataDriver_CMB", new { transporter_ID = transporter_ID }, true);
        }

        public static string AddMasterDataDriver(MasterDataModel.MasterDataDriver item)
        {
            string res = DbTransaction.DbToString("sp_AddMasterDataDriver",
                            new
                            {
                                Transporter_ID = item.Transporter_ID,
                                ImageName = item.ImageName,
                                ImageBytes = item.ImageBytes,
                                Name = item.Name,
                                Birthday = item.Birthday,
                                Address = item.Address,
                                Email = item.Email,
                                Phone1 = item.Phone1,
                                Phone2 = item.Phone2,
                                CreationBy = item.CreationBy
                            }, true);

            return res;
        }

        public static string EditMasterDataDriver(MasterDataModel.MasterDataDriver item)
        {
            string res = DbTransaction.DbToString("sp_EditMasterDataDriver",
                            new
                            {
                                Driver_ID = item.Driver_ID,
                                Transporter_ID = item.Transporter_ID,
                                ImageName = item.ImageName,
                                ImageBytes = item.ImageBytes,
                                Name = item.Name,
                                Birthday = item.Birthday,
                                Address = item.Address,
                                Email = item.Email,
                                Phone1 = item.Phone1,
                                Phone2 = item.Phone2,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }

        public static string DeleteMasterDataDriver(MasterDataModel.MasterDataDriver item)
        {
            string res = DbTransaction.DbToString("sp_DeleteMasterDataDriver",
                            new
                            {
                                Driver_ID = item.Driver_ID,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }
        #endregion

        #region Master Data Distance

        public static List<MasterDataModel.MasterDataDistance> GetMasterDataDistance()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataDistance>("sp_GetMasterDataDistance", true);
        }

        public static List<MasterDataModel.MasterDataDistance> GetMasterDataDistance(CommonDataModel.ActiveType activetype)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataDistance>("sp_GetMasterDataDistance", new { ActiveType = (int)activetype }, true);
        }

        public static string EditMasterDataDistance(MasterDataModel.MasterDataDistance item)
        {
            string res = DbTransaction.DbToString("sp_EditMasterDataDistance",
                            new
                            {
                                TBBM_ID = item.TBBM_ID,
                                SPSH_ID = item.SPSH_ID,
                                Distance = item.Distance,
                                NormalRate = item.NormalRate,
                                SpecialRate = item.SpecialRate,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }
        #endregion

        #region Master Data Region
        public static List<MasterDataModel.MasterDataRegion> GetMasterDataRegion()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataRegion>("sp_GetMasterDataRegion", true);
        }
        #endregion

        #region Master Data SPSH
        public static List<MasterDataModel.MasterDataSPSH> GetMasterDataSPSH()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataSPSH>("sp_GetMasterDataSPSH", true);
        }

        public static List<MasterDataModel.MasterDataSPSH> GetMasterDataSPSH(CommonDataModel.ActiveType activetype)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataSPSH>("sp_GetMasterDataSPSH", new { ActiveType = (int)activetype }, true);
        }

        public static List<MasterDataModel.MasterDataSPSH> GetMasterDataSPSH_CMB()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataSPSH>("sp_GetMasterDataSPSH_CMB", true);
        }

        public static string AddMasterDataSPSH(MasterDataModel.MasterDataSPSH item)
        {
            string res = DbTransaction.DbToString("sp_AddMasterDataSPSH",
                            new
                            {
                                NewSPSH_ID = item.NewSPSH_ID,
                                Region_ID = item.Region_ID,
                                Name = item.Name,
                                Address = item.Address,
                                Telp = item.Telp,
                                Email = item.Email,
                                CreationBy = item.CreationBy
                            }, true);

            return res;
        }

        public static string EditMasterDataSPSH(MasterDataModel.MasterDataSPSH item)
        {
            string res = DbTransaction.DbToString("sp_EditMasterDataSPSH",
                            new
                            {
                                SPSH_ID = item.SPSH_ID,
                                NewSPSH_ID = item.NewSPSH_ID,
                                Region_ID = item.Region_ID,
                                Name = item.Name,
                                Address = item.Address,
                                Telp = item.Telp,
                                Email = item.Email,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }

        public static string DeleteMasterDataSPSH(MasterDataModel.MasterDataSPSH item)
        {
            string res = DbTransaction.DbToString("sp_DeleteMasterDataSPSH",
                            new
                            {
                                SPSH_ID = item.SPSH_ID,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }
        #endregion

        #region Master Data TBBM
        public static List<MasterDataModel.MasterDataTBBM> GetMasterDataTBBM()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTBBM>("sp_GetMasterDataTBBM", true);
        }

        public static List<MasterDataModel.MasterDataTBBM> GetMasterDataTBBM(CommonDataModel.ActiveType activetype)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTBBM>("sp_GetMasterDataTBBM", new { ActiveType = (int)activetype }, true);
        }

        public static List<MasterDataModel.MasterDataTBBM> GetMasterDataTBBM_CMB()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTBBM>("sp_GetMasterDataTBBM_CMB", true);
        }

        public static string AddMasterDataTBBM(MasterDataModel.MasterDataTBBM item)
        {
            string res = DbTransaction.DbToString("sp_AddMasterDataTBBM",
                            new
                            {
                                Region_ID_FK = item.Region_ID_FK,
                                Name = item.Name,
                                Address = item.Address,
                                Telp = item.Telp,
                                Email = item.Email,
                                CreationBy = item.CreationBy
                            }, true);

            return res;
        }

        public static string EditMasterDataTBBM(MasterDataModel.MasterDataTBBM item)
        {
            string res = DbTransaction.DbToString("sp_EditMasterDataTBBM",
                            new
                            {
                                TBBM_ID_PK = item.TBBM_ID_PK,
                                Region_ID_FK = item.Region_ID_FK,
                                Name = item.Name,
                                Address = item.Address,
                                Telp = item.Telp,
                                Email = item.Email,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }

        public static string DeleteMasterDataTBBM(MasterDataModel.MasterDataTBBM item)
        {
            string res = DbTransaction.DbToString("sp_DeleteMasterDataTBBM",
                            new
                            {
                                TBBM_ID_PK = item.TBBM_ID_PK,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }
        #endregion

        #region Master Data Transporter
        public static List<MasterDataModel.MasterDataTransporter> GetMasterDataTransporter()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTransporter>("sp_GetMasterDataTransporter", true);
        }
        
        public static List<MasterDataModel.MasterDataTransporter> GetMasterDataTransporter(CommonDataModel.ActiveType activetype)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTransporter>("sp_GetMasterDataTransporter", new { ActiveType = (int)activetype }, true);
        }

        public static List<MasterDataModel.MasterDataTransporter> GetMasterDataTransporter_CMB()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTransporter>("sp_GetMasterDataTransporter_CMB", true);
        }
        
        public static List<MasterDataModel.MasterDataTransporter> GetMasterDataTransporter_CMB(int quantityVolume)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTransporter>("sp_GetMasterDataTransporter_CMB", new { quantityVolume = quantityVolume }, true);
        }

        public static string AddMasterDataTransporter(MasterDataModel.MasterDataTransporter item)
        {
            string res = DbTransaction.DbToString("sp_AddMasterDataTransporter",
                            new
                            {
                                TransporterName = item.TransporterName,
                                Address = item.Address,
                                Phone = item.Phone,
                                Email = item.Email,
                                Contact1 = item.Contact1,
                                Contact2 = item.Contact2,
                                CreationBy = item.CreationBy
                            }, true);

            return res;
        }

        public static string EditMasterDataTransporter(MasterDataModel.MasterDataTransporter item)
        {
            string res = DbTransaction.DbToString("sp_EditMasterDataTransporter",
                            new
                            {
                                Transporter_ID = item.Transporter_ID,
                                TransporterName = item.TransporterName,
                                Address = item.Address,
                                Phone = item.Phone,
                                Email = item.Email,
                                Contact1 = item.Contact1,
                                Contact2 = item.Contact2,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }

        public static string DeleteMasterDataTransporter(MasterDataModel.MasterDataTransporter item)
        {
            string res = DbTransaction.DbToString("sp_DeleteMasterDataTransporter",
                            new
                            {
                                Transporter_ID = item.Transporter_ID,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }
        #endregion

        #region Master Data Transporter Fee
        public static List<MasterDataModel.MasterDataTransporterFee> GetMasterDataTransporterFee()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTransporterFee>("sp_GetMasterDataTransporterFee", true);
        }

        public static List<MasterDataModel.MasterDataTransporterFee> GetMasterDataTransporterFee(int transporter_ID)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTransporterFee>("sp_GetMasterDataTransporterFee", new { Transporter_ID = transporter_ID }, true);
        }

        public static List<MasterDataModel.MasterDataTransporterFee> GetMasterDataTransporterFee(CommonDataModel.ActiveType activetype)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTransporterFee>("sp_GetMasterDataTransporterFee", new { ActiveType = (int)activetype }, true);
        }

        public static List<MasterDataModel.MasterDataTransporterFee> GetMasterDataTransporterFee(int transporter_ID, CommonDataModel.ActiveType activetype)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataTransporterFee>("sp_GetMasterDataTransporterFee", new { Transporter_ID = transporter_ID, ActiveType = (int)activetype }, true);
        }

        public static string EditMasterDataTransporterFee(MasterDataModel.MasterDataTransporterFee item)
        {
            string res = DbTransaction.DbToString("sp_EditMasterDataTransporterFee",
                            new
                            {
                                Transporter_ID = item.Transporter_ID,
                                Region_ID = item.Region_ID,
                                HandlingFee = item.HandlingFee,
                                OATDistanceLimit = item.OATDistanceLimit,
                                OATPriceUnderEqualLimit = item.OATPriceUnderEqualLimit,
                                OATPriceAboveLimit = item.OATPriceAboveLimit,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }
        #endregion

        #region Master Data Vehicle
        public static List<MasterDataModel.MasterDataDriver> GetMasterDataVehicle()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataDriver>("sp_GetMasterDataVehicle", true);
        }

        public static List<MasterDataModel.MasterDataKendaraan> GetMasterDataVehicle(CommonDataModel.ActiveType activetype)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataKendaraan>("sp_GetMasterDataVehicle", new { ActiveType = (int)activetype }, true);
        }

        public static string AddMasterDataVehicle(MasterDataModel.MasterDataKendaraan item)
        {
            string res = DbTransaction.DbToString("sp_AddMasterDataVehicle",
                            new
                            {
                                Transporter_ID = item.Transporter_ID,
                                Number = item.Number,
                                Code = item.Code,
                                Merk = item.Merk,
                                YearManufacture = item.YearManufacture,
                                Type_ID = item.Type_ID,
                                VehicleCategory_ID = item.VehicleCategory_ID,
                                Capacity = item.Capacity,
                                UnitCapacity_ID = item.UnitCapacity_ID,
                                CreationBy = item.CreationBy
        }, true);

            return res;
        }

        public static string EditMasterDataVehicle(MasterDataModel.MasterDataKendaraan item)
        {
            string res = DbTransaction.DbToString("sp_EditMasterDataVehicle",
                            new
                            {
                                Vehicle_ID = item.Vehicle_ID,
                                Transporter_ID = item.Transporter_ID,
                                Number = item.Number,
                                Code = item.Code,
                                Merk = item.Merk,
                                YearManufacture = item.YearManufacture,
                                Type_ID = item.Type_ID,
                                VehicleCategory_ID = item.VehicleCategory_ID,
                                Capacity = item.Capacity,
                                UnitCapacity_ID = item.UnitCapacity_ID,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }

        public static string DeleteMasterDataVehicle(MasterDataModel.MasterDataKendaraan item)
        {
            string res = DbTransaction.DbToString("sp_DeleteMasterDataVehicle",
                            new
                            {
                                Vehicle_ID = item.Vehicle_ID,
                                UpdateBy = item.UpdateBy
                            }, true);

            return res;
        }
        #endregion

        #region Master Data VehicleCategory
        public static List<MasterDataModel.MasterDataKendaraan> GetMasterDataVehicleCategory_CMB()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataKendaraan>("sp_GetMasterDataVehicleCategory_CMB", true);
        }

        #endregion

        #region Master Data VehicleNumber
        public static List<MasterDataModel.MasterDataKendaraan> GetMasterDataVehicleNumber_CMB()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataKendaraan>("sp_GetMasterDataVehicleNumber_CMB", true);
        }

        public static List<MasterDataModel.MasterDataKendaraan> GetMasterDataVehicleNumber_CMB(int transporter_ID, int vehicleType_ID)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataKendaraan>("sp_GetMasterDataVehicleNumber_CMB", new { transporter_ID = transporter_ID, vehicleType_ID = vehicleType_ID }, true);
        }

        #endregion

        #region Master Data VehicleType
        public static List<MasterDataModel.MasterDataKendaraan> GetMasterDataVehicleType_CMB()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataKendaraan>("sp_GetMasterDataVehicleType_CMB", true);
        }

        public static List<MasterDataModel.MasterDataKendaraan> GetMasterDataVehicleType_CMB(int transporter_ID)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataKendaraan>("sp_GetMasterDataVehicleType_CMB", new { transporter_ID = transporter_ID }, true);
        }

        public static List<MasterDataModel.MasterDataKendaraan> GetMasterDataVehicleType_CMB(int transporter_ID, int quantityVolume)
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataKendaraan>("sp_GetMasterDataVehicleType_CMB", new { transporter_ID = transporter_ID, quantityVolume = quantityVolume }, true);
        }
        #endregion

        #region Master Data UnitCapacity
        public static List<MasterDataModel.MasterDataKendaraan> GetMasterDataUnitCapacity_CMB()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataKendaraan>("sp_GetMasterDataUnitCapacity_CMB", true);
        }
        #endregion

        #region Master Data Force
        public static List<MasterDataModel.MasterDataForce> GetMasterDataForce()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataForce>("sp_GetMasterDataForce", true);
        }
        #endregion

        #region Master Data Unity
        public static List<MasterDataModel.MasterDataUnity> GetMasterDataUnity()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataUnity>("sp_GetMasterDataUnity", true);
        }
        #endregion

        #region Master Data Product
        public List<MasterDataModel.MasterDataProduct> GetMasterDataProduct()
        {
            return DbTransaction.DbToList<MasterDataModel.MasterDataProduct>("dbo.sp_GetMasterDataProduct", true);
        }
        #endregion

    }
}
