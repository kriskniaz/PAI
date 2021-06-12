using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.AgentClient
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public class AgentCommunicationCallback : IAgentCommunicationCallback
    {
        private SynchronizationContext _syncContext = AsyncOperationManager.SynchronizationContext;
        public event EventHandler<UpdatedListEventArgs> ServiceCallbackEvent;
        public void SendUpdatedList(List<string> messages)
        {
            _syncContext.Post(new SendOrPostCallback(OnServiceCallbackEvent), new UpdatedListEventArgs(messages));

        }

        private void OnServiceCallbackEvent(object state)
        {
            EventHandler<UpdatedListEventArgs> handler = ServiceCallbackEvent;
            var e = state as UpdatedListEventArgs;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
