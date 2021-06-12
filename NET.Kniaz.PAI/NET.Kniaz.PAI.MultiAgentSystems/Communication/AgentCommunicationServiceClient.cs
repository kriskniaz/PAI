using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace NET.Kniaz.PAI.MultiAgentSystems.Communication
{
    public class AgentCommunicationServiceClient : DuplexClientBase<IAgentCommunicationService>, IAgentCommunicationService
    {
        public AgentCommunicationServiceClient(InstanceContext callbackInstance, WSDualHttpBinding binding, EndpointAddress endpointAddress)
            : base(callbackInstance, binding, endpointAddress) { }


        public void Connect(string id)
        {
            Channel.Connect(id);
        }

        public void Send(string from, string to, string message)
        {
            Channel.Send(from, to, message);
        }
    }
}
