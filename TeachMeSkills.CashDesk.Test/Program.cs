using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TeachMeSkills.CashDesk.Test.Managers;

namespace TeachMeSkills.CashDesk.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter CashDesk number : ");
            int cashDeskNumber = Int32.Parse(Console.ReadLine());
            CashDeskManager cashDeskManager =
                new CashDeskManager(cashDeskNumber);
            CustomerManager customerManager = new CustomerManager();
            customerManager.commonQueueThread.Start();

            // Fill the cashDeskQueue with Customers

            foreach(CashDesk cashDesk in cashDeskManager.cashDeskList)
            {
                cashDesk.cashDeskThread.Start();
                Console.WriteLine($"Thread CashDesk started.");
            }




            int GetShortestQueue()
            {
                int len = cashDeskManager.cashDeskList[0].cashDeskQueue.Count();
                int index = 0;
                for(int j = 0; j < cashDeskNumber; j++)
                {
                    if (cashDeskManager.cashDeskList[j].cashDeskQueue.Count() < len)
                    {
                        len = cashDeskManager.cashDeskList[j].cashDeskQueue.Count();
                        index = j;
                    }
                }
                return index;
            }
        }
    }
}
