using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReadingTables
{
    class Program : Base
    {
        static void Main(string[] args)
        {
            Driver = new ChromeDriver();

            Driver.Navigate().GoToUrl("file:///C:/ComplexTable.html");

            TablePage page = new TablePage();

            // Read table
            Utilities.ReadTable(page.TableElement);

            // Get the cell value from the table
            Console.WriteLine(Utilities.ReadCell("Email", 2));

            Console.WriteLine("The name {0} with Email {1} and Phone {2}",
                Utilities.ReadCell("Name", 1), Utilities.ReadCell("Email", 1), Utilities.ReadCell("Phone", 1));


            // Delete Cliff
            Utilities.PerformActionOnCell("5", "Name", "Cliff", "Delete");
            Utilities.PerformActionOnCell("Option", "Name", "Cliff");



            Console.Read();

        }
    }
}
