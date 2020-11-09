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

            // Make a short pause to generate Customers in common Queue
            Thread.Sleep(200);

            // Start Cash Desk Threads - Cash Desks start working

            foreach (CashDesk cashDesk in cashDeskManager.cashDeskList)
            {
                Console.WriteLine($"Common Queue Max - {customerManager.maxCustomerNumber}");
                cashDesk.maxCustomerNumber = customerManager.maxCustomerNumber;
                cashDesk.cashDeskThread.Start();
                Console.WriteLine($"Thread CashDesk started.");
            }

            // Fill the cashDeskQueue with Customers
            while (customerManager.maxCustomerNumber > 0)
            {
                if(customerManager.commonQueue.Count > 0)
                {
                    cashDeskManager.cashDeskList[GetShortestQueue()].
                        cashDeskQueue.Enqueue(customerManager.commonQueue.Dequeue());
                    for (int c = 0; c < cashDeskManager.cashDeskList.Count; c++)
                    {
                        cashDeskManager.cashDeskList[c].maxCustomerNumber
                            = customerManager.maxCustomerNumber;
                    }
                    Console.WriteLine("Add Customer from COMMON to CASHDESK.");
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            Console.WriteLine("Finished.");


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
