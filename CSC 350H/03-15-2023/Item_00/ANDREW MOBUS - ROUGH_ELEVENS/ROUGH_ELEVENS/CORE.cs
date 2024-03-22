namespace ROUGH_ELEVENS
{
    public class CORE
    {
        static void Main(string[] args)
        {
            HOUSE theHouse = new();
            theHouse.DaRules.Elevens();

            Console.Write("Enter option (AUTO, MANUAL): ");
            string opt = Console.ReadLine();
            bool exitCon = false;
            switch (opt)
            {
                case "AUTO":
                    for (int i = 0; exitCon != true && i < 10000; i++)
                    {
                        theHouse.PlayLoop(theHouse.DaRules,"AUTO");
                        if (theHouse.Audit.Last.action == "[V]")
                            exitCon = true;
                    }
                    break;
                case "MANUAL":
                    for (int i = 0; exitCon != true && i < 10000; i++)
                    {
                        theHouse.PlayLoop(theHouse.DaRules, "MANUAL");
                        Console.WriteLine("Enter EXIT to end program.");
                        Console.WriteLine("Otherwise, continue.");
                        string choice = Console.ReadLine();
                        if (choice == "EXIT")
                            exitCon = true;
                    }
                    break;
            } // END_SWITCH
        } // END_MAIN
    }
}
