using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TTTVService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    //[ServiceContract (Name="pis",Namespace="http://www.tamtrutamvang.com/", SessionMode=SessionMode.Allowed)]
    [ServiceContract(Name = "pis", Namespace = "http://www.tamtrutamvang.com/", SessionMode = SessionMode.Required)]
    public interface IService1
    {
        // TODO: Add your service operations here
        // Get information of author
        [OperationContract(Name = "GetAuthorInfo")]
        [FaultContract(typeof(TrackedFault))]
        string GetAuthor();

        // Find information by Name
        [OperationContract(Name="FindInfoByName")]
        [FaultContract(typeof(TrackedFault))]
        TranferRecord[] GetInfoByName(string Name, string type);

        // Find information by Address
        [OperationContract(Name="FindInfoByPhone")]
        [FaultContract(typeof(TrackedFault))]
        TranferRecord[] GetInfoByPhone(string Phone, string type);

        // Find information by IdNumber
        [OperationContract(Name="FindInfoByIdNumber")]
        [FaultContract(typeof(TrackedFault))]
        TranferRecord[] GetInfoByIdNumber(string IdNumber, string type);

        // Find information by Email
        [OperationContract(Name = "FindInfoByEmail")]
        [FaultContract(typeof(TrackedFault))]
        TranferRecord[] GetInfoByEmail(string Email, string type);

        // Find information by sex
        [OperationContract(Name="ListPersonBySex")]
        [FaultContract(typeof(TrackedFault))]
        TranferRecord[] GetInfoBySex(string Address, string Sex, string type);

        // Get all person are in this address
        [OperationContract(Name="ListPersonByAddress")]
        [FaultContract(typeof(TrackedFault))]
        TranferRecord[] GetListByAddress(string Address, string type);

        // Get all person are in this address from date to date
        [OperationContract(Name="ListPersonByDate")]
        [FaultContract(typeof(TrackedFault))]
        TranferRecord[] GetListByDate(string Address, DateTime FromDate, DateTime ToDate, string type);

        // report occupation in this address
        [OperationContract(Name="ListOccupationByAddress")]
        [FaultContract(typeof(TrackedFault))]
        TranferRecord[] GetListOccupationByAddress(string Address, string type);

        // Count how many male/ female in this address
        [OperationContract(Name="CountSexByAddress")]
        [FaultContract(typeof(TrackedFault))]
        TranferRecord[] CountSexByAddress(string Address, string type);

        // For Select, insert, update, delete data
        [OperationContract(Name="LoadData")]
        [FaultContract(typeof(TrackedFault))]
        TranferRecord[] GetData();

        //[OperationContract(Name = "Login")]
        //[FaultContract(typeof(TrackedFault))]
        //int Login(string username, string password);

        [OperationContract(Name = "ImportDataFromFile", IsOneWay = true)]
        void ImportData(string[] file);

        [OperationContract(Name="InsertInfomation", IsOneWay=true)]
        void InsertData(TranferRecord data);

        [OperationContract(Name = "UpdatInformation", IsOneWay = true)]
        void UpdateData(int Id, TranferRecord data);

        [OperationContract(Name = "DeleteInformation", IsOneWay = true)]
        void DeleteData(int Id);
    }

    [DataContract]
    public class TranferRecord
    {
        [DataMember]
        public int Total;

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

    //[DataContract]
    //public class UserRecord
    //{
    //    [DataMember]
    //    public string username;

    //    [DataMember]
    //    public string password;
    //}
}
