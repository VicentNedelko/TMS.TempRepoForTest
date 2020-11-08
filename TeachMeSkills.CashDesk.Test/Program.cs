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


            //// Create Threads for all CashDesks
            ////
            //List<Thread> cashDeskThreadsList = new List<Thread>();
            //for(int t = 0; t < cashDeskNumber; t++)
            //{
            //    cashDeskThreadsList.Add(new Thread(
            //        () => cashDeskManager.cashDeskList[t].Service())
            //        );
            //    Console.WriteLine($"Thread {t} added.");
            //    cashDeskThreadsList[t].Name = "Cash Desk" + (t + 1).ToString();
            //}
            ////
            ////
            ///

            Thread.Sleep(4000);
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
