using System;
using NET.Kniaz.PAI.Model.Simple;
using NET.Kniaz.PAI.Model.PropositionalLogic;

namespace NET.Kniaz.PAI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            RunSimple.Run();
            RunPropositionalLogic.RunDPLL1();
            RunPropositionalLogic.RunDpll2();
            RunPropositionalLogic.RunDpll3();
            RunPropositionalLogic.RunDpll4();
            RunPropositionalLogic.RunPigeonHole();
            RunCleaningRobot.Run();
            RunCleaningRobot.RunLarge();
            RunCleaningAgent.RunLarge();
            bool endrun = true;
        }

    }
}
