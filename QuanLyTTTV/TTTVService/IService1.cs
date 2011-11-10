using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TTTVService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract (Name="pis",Namespace="http://www.tamtrutamvang.com/")]
    public interface IService1
    {
        // TODO: Add your service operations here
        // Get information of author
        [OperationContract(Name = "GetAuthorInfo")]
        string GetAuthor();

        // Find information by Name
        [OperationContract(Name="FindInfoByName")]
        TranferRecord[] GetInfoByName(string Name, string type);

        // Find information by Address
        [OperationContract(Name="FindInfoByPhone")]
        TranferRecord[] GetInfoByPhone(string Phone, string type);

        // Find information by IdNumber
        [OperationContract(Name="FindInfoByIdNumber")]
        string GetInfoByIdNumber(string IdNumber);

        // Find information by sex
        [OperationContract(Name="ListPersonBySex")]
        int GetInfoBySex(string Address, string Sex);

        // Get all person are in this address
        [OperationContract(Name="ListPersonByAddress")]
        string GetListByAddress(string Address);

        // Get all person are in this address from date to date
        [OperationContract(Name="ListPersonByDate")]
        string GetListByDate(string Address, DateTime FromDate, DateTime ToDate);

        // report occupation in this address
        [OperationContract(Name="ListOccupationByAddress")]
        string GetListOccupationByAddress(string Address);

        // Count how many male/ female in this address
        [OperationContract(Name="CountSexByAddress")]
        int CountSexByAddress(string Address);

        // For Select, insert, update, delete data
        [OperationContract(Name="LoadData")]
        TranferRecord[] GetData();

        //[OperationContract(Name="InsertInfomation", IsOneWay=true)]
        //void InsertData();

        //[OperationContract(Name = "UpdatInformation", IsOneWay = true)]
        //void UpdateData(int Id);

        //[OperationContract(Name = "DeleteInformation", IsOneWay = true)]
        //void DeleteData(int Id);
        // For Insert, update, delete data
    }

    [DataContract]
    public class TranferRecord
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string FullName;

        [DataMember]
        public string PhoneNumber;

        [DataMember]
        public string Email;

        [DataMember]
        public DateTime Birthday;

        [DataMember]
        public string Sex;

        [DataMember]
        public string OriginalAddress;

        [DataMember]
        public string IDNumber;

        [DataMember]
        public string Occupation;

        [DataMember]
        public string CurrentAddress;

        [DataMember]
        public DateTime FromDate;

        [DataMember]
        public DateTime ToDate;

        [DataMember]
        public string Reason;

        [DataMember]
        public string Description;

        [DataMember]
        public string Type;
    }
}
