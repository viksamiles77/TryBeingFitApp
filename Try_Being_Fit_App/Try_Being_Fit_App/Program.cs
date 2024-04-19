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

            uiService.ShowMenu();
        }
    }
}
