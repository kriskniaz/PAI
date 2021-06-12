using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace NET.Kniaz.PAI.MultiAgentSystems.Communication
{
    public interface IAgentCommunicationCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendUpdatedList(List<string> messages);
    }
}
