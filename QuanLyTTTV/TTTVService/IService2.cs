using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TTTVService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract(Name = "WSLogin", Namespace = "http://www.tamtrutamvang.com/", SessionMode = SessionMode.Required)]
    public interface IService2
    {
        [OperationContract(Name = "Login")]
        [FaultContract(typeof(TrackedFault))]
        int Login(string username, string password);
    }

    [DataContract]
    public class UserRecord
    {
        [DataMember]
        public string username;

        [DataMember]
        public string password;
    }
}
