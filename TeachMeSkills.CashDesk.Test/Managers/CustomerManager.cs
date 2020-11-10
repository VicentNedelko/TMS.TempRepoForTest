using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TeachMeSkills.CashDesk.Test
{
    public class CustomerManager
    {

        public int maxCustomerNumber { get; set; } = 20;
        Random rand = new Random();
        public Queue<Customer> commonQueue;
        public Thread commonQueueThread;

        public CustomerManager()
        {
            commonQueue = new Queue<Customer>();
            commonQueueThread = new Thread(() => CustomerGenerator());
        }
        public void CustomerGenerator()
        {
            while (maxCustomerNumber > 0)
            {
                Thread.Sleep(rand.Next(1000, 3000));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("New Customer generated.");
                Console.ForegroundColor = ConsoleColor.White;
                commonQueue.Enqueue(new Customer());
                maxCustomerNumber--;
            }
        }
    }
}
