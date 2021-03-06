﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using System.Data;
using System.Windows.Forms;
using HouseSelection.Utility;
using HouseSelection.Provider.Client.Request;
using HouseSelection.Provider.Client.Response;
using HouseSelection.NetworkHelper;
using HouseSelection.Model;
using System.Reflection;

namespace HouseSelection.Provider
{
    public class BaseProvide
    {
        private GeneralClient Client = new GeneralClient();
        private string action = string.Empty;

        private List<T> ReadDataTable<T>(DataTable tableData, string columns)
        {
            if (tableData == null || tableData.Rows.Count == 0 || columns.Length == 0)
            {
                return null;
            }
            var columnArray = columns.Split(',');
            var columnsLength = columnArray.Length;
            var result = new List<T>();
            for (int i = 0; i < tableData.Rows.Count; i++)
            {
                var rowEntity = Activator.CreateInstance<T>();
                for (int j = 0; j < columnsLength; j++)
                {
                    var currentValue = tableData.Rows[i][j].ToString();
                    var propertyName = columnArray[j];
                    foreach (var item in typeof(T).GetProperties())
                    {
                        if (item.Name == propertyName)
                        {
                            if (item.PropertyType == typeof(int))
                            {
                                int finalValue;
                                if (!int.TryParse(currentValue, out finalValue))
                                {
                                    //Logger.LogWarning(string.Format("转化EXCEL表内容数据类型失败！不可以将值：{0}赋值给{1}类型的字段：{2}", currentValue, item.PropertyType, item.Name), LOG_CLASS_NAME, MethodBase.GetCurrentMethod().Name);
                                }
                                item.SetValue(rowEntity, finalValue, null);
                            }
                            else if (item.PropertyType == typeof(float))
                            {
                                float finalValue;
                                if (!float.TryParse(currentValue, out finalValue))
                                {
                                    //Logger.LogWarning(string.Format("转化EXCEL表内容数据类型失败！不可以将值：{0}赋值给{1}类型的字段：{2}", currentValue, item.PropertyType, item.Name), LOG_CLASS_NAME, MethodBase.GetCurrentMethod().Name);
                                }
                                item.SetValue(rowEntity, finalValue, null);
                            }
                            else if (item.PropertyType == typeof(string))
                            {
                                item.SetValue(rowEntity, currentValue, null);
                            }
                            else if (item.PropertyType == typeof(decimal))
                            {
                                decimal finalValue;
                                if (!decimal.TryParse(currentValue, out finalValue))
                                {
                                    //Logger.LogWarning(string.Format("转化EXCEL表内容数据类型失败！不可以将值：{0}赋值给{1}类型的字段：{2}", currentValue, item.PropertyType, item.Name), LOG_CLASS_NAME, MethodBase.GetCurrentMethod().Name);
                                }
                                item.SetValue(rowEntity, finalValue, null);
                            }

                            break;
                        }
                    }
                }
                result.Add(rowEntity);
            }
            return result;
        }

        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        public DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        public TokenResultEntity GetToken()
        {
            bool bgetToken = false;
            TokenResultEntity result = new TokenResultEntity();
            try
            {
                if (string.IsNullOrEmpty(GlobalTokenHelper.gToken))
                {
                    bgetToken = true;
                }
                else
                {
                    System.DateTime currentTime = System.DateTime.Now;
                    System.TimeSpan TS = currentTime - GlobalTokenHelper.gTokenDateTime;
                    if (TS.TotalSeconds >= GlobalTokenHelper.Expiry-60) { bgetToken = true; }
                }

                if (bgetToken == true)
                {
                    var request = new GetTokenRequest()
                    {
                        AppId = "SYY",
                        AppSecret = "0B2223C37F54864403847E762E1F87F3"
                    };

                    result = this.Client.InvokeAPI<TokenResultEntity>(request);
                    if (result == null)
                    {
                        result = new TokenResultEntity();
                        result.Code = 100;
                        result.ErrMsg = "网络连接异常，请检查网络！";
                    }
                    else
                    {
                        if (result.Code == 0)
                        {
                            GlobalTokenHelper.gToken = result.Access_Token;
                            GlobalTokenHelper.Expiry = result.Expiry;
                            GlobalTokenHelper.gTokenDateTime = System.DateTime.Now;
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public BaseResultEntity CheckBackEndAccount(string sAccount,string sPassword)
        {
            BaseResultEntity result = new BaseResultEntity();
            try
            {
                var request = new CheckBackEndAccountRequest()
                {
                    Account = sAccount,
                    Password= sPassword
                };

                result = this.Client.InvokeAPI<BaseResultEntity>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public ProjectEntityResponse GetAllProjects(int pageIndex,int pageSize)
        {
            ProjectEntityResponse result = new ProjectEntityResponse();
            try
            {
                var request = new GetAllProjectsRequest()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };

                result = this.Client.InvokeAPI<ProjectEntityResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public ProjectEntityResponse GetProjects(string searchStr,int pageIndex,int pageSize)
        {
            ProjectEntityResponse result = new ProjectEntityResponse();
            try
            {
                var request = new GetProjectsRequest()
                {
                    SearchStr= searchStr,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };

                result = this.Client.InvokeAPI<ProjectEntityResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetProjectGroupResponse GetProjectGroup(int projectId)
        {
            GetProjectGroupResponse result = new GetProjectGroupResponse();
            try
            {
                var request = new GetProjectGroupRequest()
                {
                    ProjectID = projectId,
                    PageIndex = 1,
                    PageSize = 999999
                    
                };

                result = this.Client.InvokeAPI<GetProjectGroupResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetHouseEstatesResponse GetAllHouseEstateInfo()
        {
            GetHouseEstatesResponse result = new GetHouseEstatesResponse();
            try
            {
                var request = new GetAllHouseEstateInfoRequest()
                {
                    PageIndex = 1,
                    PageSize = 99999
                };

                result = this.Client.InvokeAPI<GetHouseEstatesResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetHouseEstatesResponse GetHouseEstates(string searchStr)
        {
            GetHouseEstatesResponse result = new GetHouseEstatesResponse();
            try
            {
                var request = new GetHouseEstatesRequest()
                {
                    SearchStr = searchStr,
                    PageIndex = 1,
                    PageSize = 99999
                };

                result = this.Client.InvokeAPI<GetHouseEstatesResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }


        public GetShakingNumbersResponse GetShakingNumbers(int projectId)
        {
            GetShakingNumbersResponse result = new GetShakingNumbersResponse();
            try
            {
                var request = new GetShakingNumbersRequest()
                {
                    ProjectGroupID = projectId,
                    PageIndex = 1,
                    PageSize = 100
                };

                result = this.Client.InvokeAPI<GetShakingNumbersResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public BaseResultEntity AddProject(AddProjectRequest request)
        {
            BaseResultEntity result = new BaseResultEntity();
            try
            {
                result = this.Client.InvokeAPI<BaseResultEntity>(request);
            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public BaseResultEntity EditProject(EditProjectRequest request)
        {
            BaseResultEntity result = new BaseResultEntity();
            try
            {
                result = this.Client.InvokeAPI<BaseResultEntity>(request);
            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public SubscriberEntityResponse GetAllSubscribers()
        {
            SubscriberEntityResponse result = new SubscriberEntityResponse();
            try
            {
                var request = new GetAllSubscribersReguest
                {
                    PageIndex = 1,
                    PageSize = 999999
                };

                result = this.Client.InvokeAPI<SubscriberEntityResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public SubscriberEntityResponse GetSubscribers(string searchStr)
        {
            SubscriberEntityResponse result = new SubscriberEntityResponse();
            try
            {
                var request = new GetSubscribersRequest()
                {
                    SearchStr = searchStr,
                    PageIndex = 1,
                    PageSize = 999999
                };

                result = this.Client.InvokeAPI<SubscriberEntityResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public string ImportHouseInfo(DataTable tData, int pId, string houseEstate)
        {
            #region 定义参数

            string msg = string.Empty;
            int dtcolcount = tData.Columns.Count;
            string sCol = string.Empty;

            #endregion
            try
            {
                action = "_生成业务级数据";
                #region 清洗数据

                if (dtcolcount == 13)
                {
                    sCol = "SerialNumber,Group,Block,Building,Unit,RoomNumber,RoomType,Toward,RoomCode,EstimateBuiltUpArea,EstimateLivingArea,AreaUnitPrice,TotalPrice";
                }
                else
                {
                    sCol = "SerialNumber,Group,Building,Unit,RoomNumber,RoomType,Toward,RoomCode,EstimateBuiltUpArea,EstimateLivingArea,AreaUnitPrice,TotalPrice";
                }
                List<HouseInfoTable> lDataList = ReadDataTable<HouseInfoTable>(tData, sCol);

                if (lDataList == null || lDataList.Count == 0)
                {
                    msg = "读取EXCEL数据失败！";
                    return msg;
                }
                List<HouseInfoTable> listtemp = new List<HouseInfoTable>();
                for (int i = 0; i < lDataList.Count; i++)
                {
                    listtemp.Add(lDataList[i]);
                    if (i != 0 && i % 100 == 0)
                    {
                        ImportHouseInfoRequest requestInfo = new ImportHouseInfoRequest();
                        requestInfo.ProjectID = pId;
                        requestInfo.HouseEstate = houseEstate;
                        foreach (var item in listtemp)
                        {
                            HouseInfoTable houseInfo = new HouseInfoTable();

                            houseInfo.SerialNumber = item.SerialNumber;
                            houseInfo.Group = item.Group;
                            if (dtcolcount == 13) { houseInfo.Block = item.Block; }
                            houseInfo.Building = item.Building;
                            houseInfo.Unit = item.Unit;
                            houseInfo.RoomNumber = item.RoomNumber;
                            houseInfo.RoomType = item.RoomType;
                            houseInfo.Toward = item.Toward;
                            houseInfo.RoomCode = item.RoomCode;
                            houseInfo.EstimateBuiltUpArea = item.EstimateBuiltUpArea;
                            houseInfo.EstimateLivingArea = item.EstimateLivingArea;
                            houseInfo.AreaUnitPrice = item.AreaUnitPrice;
                            houseInfo.TotalPrice = item.TotalPrice;

                            requestInfo.HouseList.Add(houseInfo);
                        }

                        #endregion
                        action = "_调用接口";
                        #region 调用接口

                        BaseResultEntity result = this.Client.InvokeAPI<BaseResultEntity>(requestInfo);

                        // 同步数据库内容
                        if (result != null && result.Code != 0)
                        {
                            msg = "上传认购人信息失败, 错误信息！";
                            return msg;
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                msg = "上传认购人信息失败, 错误信息：" + ex.Message;
            }

            return msg;
        }

        public string ImportSubscriber(DataTable tData, int pId, string pGroup)
        {
            #region 定义参数

            string msg = string.Empty;

            #endregion
            try
            {

                action = "_生成业务级数据";
                #region 清洗数据

                string sCol = "No,SelectHouseSequance,Name,IdentityNumber,ShakingNumber,Telephone,Address,ZipCode,MaritalStatus,ResidenceArea,WorkArea,SubscriberFamilyMemberEntity";
                List<SubscriberTable> lDataList = ReadDataTable<SubscriberTable>(tData, sCol);

                if (lDataList == null || lDataList.Count == 0)
                {
                    msg = "读取EXCEL数据失败！";
                    return msg;
                }

                List<SubscriberTable> listtemp = new List<SubscriberTable>();
                for (int i = 0; i < lDataList.Count; i++)
                {
                    listtemp.Add(lDataList[i]);
                    if (i != 0 && i % 100 == 0)
                    {
                        ImportSubscriberRequest requestInfo = new ImportSubscriberRequest();
                        requestInfo.ProjectID = pId;
                        requestInfo.ProjectGroup = pGroup;

                        //foreach (var item in lDataList)
                        foreach (var item in listtemp)
                        {
                            ShakingNumberResultEntitytemp shakingNumberResultEntity = new ShakingNumberResultEntitytemp();

                            shakingNumberResultEntity.ShakingNumberSequance = item.No;
                            shakingNumberResultEntity.SelectHouseSequance = item.SelectHouseSequance;
                            shakingNumberResultEntity.ShakingNumber = item.ShakingNumber;

                            SubscriberEntitytemp subscriberEntitytemp = new SubscriberEntitytemp();

                            subscriberEntitytemp.Name = item.Name;
                            subscriberEntitytemp.IdentityNumber = item.IdentityNumber;
                            subscriberEntitytemp.Telephone = item.Telephone;
                            subscriberEntitytemp.Address = item.Address;
                            subscriberEntitytemp.ZipCode = item.ZipCode;
                            subscriberEntitytemp.MaritalStatus = item.MaritalStatus;
                            subscriberEntitytemp.ResidenceArea = item.ResidenceArea;
                            subscriberEntitytemp.WorkArea = item.WorkArea;

                            shakingNumberResultEntity.Subscriber = subscriberEntitytemp;

                            List<SubscriberFamilyMemberEntitytemp> subscriberFamilyMemberEntitytemp = new List<SubscriberFamilyMemberEntitytemp>();

                            string[] tempsplit1st = item.SubscriberFamilyMemberEntity.Split('<');
                            foreach (string fm in tempsplit1st)
                            {
                                if (fm != "")
                                {
                                    SubscriberFamilyMemberEntitytemp temp = new SubscriberFamilyMemberEntitytemp();
                                    string[] tempsplit2nd = fm.Split('>');
                                    temp.Relationship = tempsplit2nd[0];

                                    string[] tempsplit3rd = tempsplit2nd[1].Split(',');
                                    temp.SubscriberIdentityNumber = item.IdentityNumber;
                                    temp.Name = tempsplit3rd[0];
                                    temp.IdentityNumber = tempsplit3rd[2];
                                    temp.Area = tempsplit3rd[3];
                                    if (temp.Relationship != "申请人") { subscriberFamilyMemberEntitytemp.Add(temp); }
                                }

                            }

                            shakingNumberResultEntity.FamilyMemberList = subscriberFamilyMemberEntitytemp;

                            requestInfo.ShakingNumberList.Add(shakingNumberResultEntity);

                        }

                        #endregion
                        action = "_调用接口";
                        #region 调用接口

                        BaseResultEntity result = this.Client.InvokeAPI<BaseResultEntity>(requestInfo);

                        // 同步数据库内容
                        if (result != null && result.Code != 0)
                        {
                            msg = "上传认购人信息失败, 错误信息！";
                            return msg;
                        }
                        else
                        {
                            listtemp.Clear();
                        }
                        
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                msg = "上传认购人信息失败, 错误信息：" + ex.Message;
            }

            return msg;
        }

        public BaseResultEntity AddFrontEndAccount(List<int> projrctId, string account, string password)
        {
            BaseResultEntity result = new BaseResultEntity();
            try
            {
                var request = new AddFrontEndAccountRequest()
                {
                    ProjectID = projrctId,
                    Account = account,
                    Password = password
                };

                result = this.Client.InvokeAPI<BaseResultEntity>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetFrontEndAccountResponse GetAllFrontEndAccount()
        {
            GetFrontEndAccountResponse result = new GetFrontEndAccountResponse();
            try
            {
                var request = new GetAllFrontEndAccountRequest()
                {
                    //ProjectID = projectId,
                    PageIndex = 1,
                    PageSize = 99999
                };

                result = this.Client.InvokeAPI<GetFrontEndAccountResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetFrontEndAccountResponse GetFrontEndAccount(string searchStr)
        {
            GetFrontEndAccountResponse result = new GetFrontEndAccountResponse();
            try
            {
                var request = new GetFrontEndAccountRequest()
                {
                    ProjectID = 0,
                    SearchStr = searchStr,
                    PageIndex = 1,
                    PageSize = 99999
                };

                result = this.Client.InvokeAPI<GetFrontEndAccountResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public BaseResultEntity EditFrontEndAccount(int id, string account, string passwordold, string password, List<int> projrctId)
        {
            BaseResultEntity result = new BaseResultEntity();
            try
            {
                var request = new EditFrontEndAccountRequest()
                {
                    AccountID=id,
                    Account = account,
                    BeforePassword = passwordold,
                    Password = password,
                    ProjectID = projrctId
                };

                result = this.Client.InvokeAPI<BaseResultEntity>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public BaseResultEntity AddSelectTimePeriod(List<SelectTimePeriodEntityTemp> list,int projectgroupId)
        {
            BaseResultEntity result = new BaseResultEntity();
            try
            {
                var request = new AddSelectTimePeriodRequest()
                {
                    ProjectGroupID = projectgroupId,
                    SelectTimeList = list
                };

                result = this.Client.InvokeAPI<BaseResultEntity>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public BaseResultEntity EditSelectTimePeriod(List<SelectTimePeriodEntityTemp> list, int projectgroupId)
        {
            BaseResultEntity result = new BaseResultEntity();
            try
            {
                var request = new EditSelectTimePeriodRequest()
                {
                    ProjectGroupID = projectgroupId,
                    SelectTimeList = list
                };

                result = this.Client.InvokeAPI<BaseResultEntity>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetSelectTimePeriodResponse GetSelectTimePeriod(int projectgroupId)
        {
            GetSelectTimePeriodResponse result = new GetSelectTimePeriodResponse();
            try
            {
                var request = new GetSelectTimePeriodRequest()
                {
                    ProjectGroupID = projectgroupId
                };

                result = this.Client.InvokeAPI<GetSelectTimePeriodResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetHousesResponse GetAllHouseInfo(int houseEstateID)
        {
            GetHousesResponse result = new GetHousesResponse();
            try
            {
                var request = new GetAllHouseInfoRequest()
                {
                    HouseEstateID = houseEstateID,
                    PageIndex = 1,
                    PageSize = 99999
                };

                result = this.Client.InvokeAPI<GetHousesResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetHousesResponse GetHouses(int houseEstateID, string searchStr)
        {
            GetHousesResponse result = new GetHousesResponse();
            try
            {
                var request = new GetHousesRequest()
                {
                    HouseEstateID = houseEstateID,
                    SearchStr = searchStr,
                    PageIndex = 1,
                    PageSize = 99999
                };

                result = this.Client.InvokeAPI<GetHousesResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetSubscriberByHouseIDResponse GetSubscriberByHouseID(int houseId)
        {
            GetSubscriberByHouseIDResponse result = new GetSubscriberByHouseIDResponse();
            try
            {
                var request = new GetSubscriberByHouseIDRequest()
                {
                    HouseID = houseId
                };

                result = this.Client.InvokeAPI<GetSubscriberByHouseIDResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetProjectRoleBaseInfoResponse GetProjectRoleBaseInfo(int projectId)
        {
            GetProjectRoleBaseInfoResponse result = new GetProjectRoleBaseInfoResponse();
            try
            {
                var request = new GetProjectRoleBaseInfoRequest()
                {
                    ProjectID = projectId
                };

                result = this.Client.InvokeAPI<GetProjectRoleBaseInfoResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public BaseResultEntity AddSelectRole(int projectId, List<ProjectGroupAndRoomTypeRoleTemp> list1, List<FamilyNumberAndRoomTypeRoleTemp> list2, List<ProjectGroupAndHouseGroupRoleTemp> list3 )
        {
            BaseResultEntity result = new BaseResultEntity();
            try
            {
                var request = new AddSelectRoleRequest()
                {
                    ProjectID = projectId,
                    ProjectGroupAndRoomTypeRoleList = list1,
                    FamilyNumberAndRoomTypeRoleList = list2,
                    ProjectGroupAndHouseGroupRoleList = list3
                };

                result = this.Client.InvokeAPI<BaseResultEntity>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetSelectRoleByProjectIDResponse GetSelectRoleByProjectID(int projectId)
        {
            GetSelectRoleByProjectIDResponse result = new GetSelectRoleByProjectIDResponse();
            try
            {
                var request = new GetSelectRoleByProjectIDRequest()
                {
                    ProjectID = projectId
                };

                result = this.Client.InvokeAPI<GetSelectRoleByProjectIDResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public BaseResultEntity EditSelectRole(int projectId, List<ProjectGroupAndRoomTypeRoleTemp> list1, List<FamilyNumberAndRoomTypeRoleTemp> list2, List<ProjectGroupAndHouseGroupRoleTemp> list3)
        {
            BaseResultEntity result = new BaseResultEntity();
            try
            {
                var request = new AddSelectRoleRequest()
                {
                    ProjectID = projectId,
                    ProjectGroupAndRoomTypeRoleList = list1,
                    FamilyNumberAndRoomTypeRoleList = list2,
                    ProjectGroupAndHouseGroupRoleList = list3
                };

                result = this.Client.InvokeAPI<BaseResultEntity>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetSubscriberSelectionHistoryResponse GetSubscriberSelectionHistory(int Id)
        {
            GetSubscriberSelectionHistoryResponse result = new GetSubscriberSelectionHistoryResponse();
            try
            {
                var request = new GetSubscriberSelectionHistoryRequest()
                {
                    SubscriberID = Id
                };

                result = this.Client.InvokeAPI<GetSubscriberSelectionHistoryResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        public GetSelectionDetailResponse GetSelectionDetail(int Id)
        {
            GetSelectionDetailResponse result = new GetSelectionDetailResponse();
            try
            {
                var request = new GetSelectionDetailRequest()
                {
                    SelectionID = Id
                };

                result = this.Client.InvokeAPI<GetSelectionDetailResponse>(request);

            }
            catch (Exception ex)
            {
                result.Code = 9999;
                result.ErrMsg = ex.Message;
            }

            return result;

        }
    }
}
