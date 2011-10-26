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
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract(Name = "AuthorInformation")]
        string GetAuthor();

        [OperationContract]
        string GetInfoByName(string Name);

        [OperationContract]
        string GetInfoByAddress(string Adress);
    }
}
