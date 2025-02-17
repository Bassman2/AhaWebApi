using AVMHomeAutomation;

namespace AVMHomeAutomationReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AVM Home Automation Report");
            Console.WriteLine("AVMHomeAutomationReport -login:login -passwd:Password {-url:http://fritz.box}");
            Uri host =  new("http://fritz.box");
            string login = "Demo";
            string password = "Demo-1234";
            foreach (string arg in args)
            {
                string[] ar = arg.Split(':');
                switch (ar[0])
                {
                case "-url":
                    host = new Uri(ar[1]);    
                    break;
                case "-login":
                    login = ar[1];
                    break;
                case "-passwd":
                    password = ar[1];
                    break;

                }
            }

            try
            {
                using var client = new HomeAutomation(login, password, host);
                client.CreateBugReportFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}