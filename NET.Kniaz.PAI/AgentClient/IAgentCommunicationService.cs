using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NET.Kniaz.PAI.AgentClient
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAgentCommunicationService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IAgentCommunicationCallback))]
    public interface IAgentCommunicationService
    {
        [OperationContract(IsOneWay = true)]
        void Subscribe();

        [OperationContract(IsOneWay = true)]
        void Send(string from, string to, string message);

    }


    public interface IAgentCommunicationCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendUpdatedList(List<string> messages);

    }
}
