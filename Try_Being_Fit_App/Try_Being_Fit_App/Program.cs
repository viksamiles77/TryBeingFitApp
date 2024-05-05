using Services;
using Services.Interfaces;
using DataAccess;
using Models;
using Services.Implementations;

namespace Try_Being_Fit_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUIService uiService = new UIService();
            bool exit = false;

            while (!exit)
            {
                uiService.ShowMenu();
                exit = AskToExit();
            }
        }

        static bool AskToExit()
        {
            Console.Write("Do you want to exit the app? (Y/N)");
            string input = Console.ReadLine().Trim().ToUpper();
            return (input == "Y");
        }
    }
}
