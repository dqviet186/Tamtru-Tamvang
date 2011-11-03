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
        string GetInfoByName(string Name);

        // Find information by Address
        [OperationContract(Name="FindInfoByPhone")]
        string GetInfoByPhone(string Phone);

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
    }
}
