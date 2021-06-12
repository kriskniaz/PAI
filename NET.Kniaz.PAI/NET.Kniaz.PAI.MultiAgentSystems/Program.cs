using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using System.Windows.Forms;
using NET.Kniaz.PAI.MultiAgentSystems.Communication;
using NET.Kniaz.PAI.MultiAgentSystems.GUI;
using NET.Kniaz.PAI.MultiAgentSystems.Platform;

namespace NET.Kniaz.PAI.MultiAgentSystems
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region Multi-Agent Systems

            var room = new [,]
                           {
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                               {2, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
                           };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            const int N = 10;
            const int M = 10;
            var roomGui = new Room(N, M, room);

            InitCommunicationService();

            var clAgent1 = new MasCleaningAgent(Guid.NewGuid(), room, roomGui, 0, 0, Color.Teal);
            var clAgent2 = new MasCleaningAgent(Guid.NewGuid(), room, roomGui, 1, 1, Color.Yellow);
            var clAgent3 = new MasCleaningAgent(Guid.NewGuid(), room, roomGui, 1, 2, Color.Tomato);
            var clAgent4 = new MasCleaningAgent(Guid.NewGuid(), room, roomGui, 2, 1, Color.LightSkyBlue);
            var clAgent5 = new MasCleaningAgent(Guid.NewGuid(), room, roomGui, 2, 2, Color.Black);

            roomGui.CleaningAgents = new List<MasCleaningAgent> { clAgent1, clAgent2, clAgent3, clAgent4, clAgent5 };
            var platform = new CleaningAgentPlatform(roomGui.CleaningAgents, new CleaningTask(M, roomGui.CleaningAgents.Count));

            Application.Run(roomGui);

            #endregion
        }

        private static void InitCommunicationService()
        {
            // Step 1 Create a URI to serve as the base address.
            var baseAddress = new Uri("http://localhost:9090/");

            // Step 2 Create a ServiceHost instance
            var selfHost = new ServiceHost(typeof(AgentCommunicationService), baseAddress);

            try
            {
                // Step 3 Add a service endpoint.
                var binding = new WSDualHttpBinding(WSDualHttpSecurityMode.None);

                selfHost.AddServiceEndpoint(typeof(IAgentCommunicationService),
                    binding, "AgentCommunicationService");

                // Step 4 Enable Metadata Exchange and Add MEX endpoint
                var smb = new ServiceMetadataBehavior { HttpGetEnabled = true };
                selfHost.Description.Behaviors.Add(smb);
                selfHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                    MetadataExchangeBindings.CreateMexHttpBinding(), baseAddress + "mex");

                // Step 5 Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Listening at: {0}", baseAddress);
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
