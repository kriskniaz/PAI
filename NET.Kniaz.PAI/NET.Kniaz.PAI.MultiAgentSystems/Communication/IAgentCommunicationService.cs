using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;


namespace NET.Kniaz.PAI.MultiAgentSystems.Communication
{
    [ServiceContract(CallbackContract = typeof(IAgentCommunicationCallback))]
    public interface IAgentCommunicationService
    {
        [OperationContract(IsOneWay = true)]
        void Connect(string id);

        [OperationContract(IsOneWay = true)]
        void Send(string from, string to, string message);
    }
}
