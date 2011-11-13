using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TTTVService
{
    [DataContract]
    public class TrackedFault
    {
        #region Private fields
        Guid _trackingId;
        string _details;
        DateTime _dateTime;
        #endregion

        #region Properties
        [DataMember]
        public Guid TrackingId
        {
            get { return _trackingId; }
            set { _trackingId = value; }
        }

        [DataMember]
        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }

        [DataMember]
        public DateTime DateAndTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }
        #endregion

        public TrackedFault(Guid id, string details, DateTime dateTime)
        {
            _trackingId = id;
            _details = details;
            _dateTime = dateTime;
        }
    }
}
