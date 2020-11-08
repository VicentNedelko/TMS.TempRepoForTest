﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TeachMeSkills.CashDesk.Test
{
    public class CustomerManager
    {
        public int maxCustomerNumber = 10;
        Random rand = new Random();
        public Queue<Customer> commonQueue;
        public Thread commonQueueThread { get; set; }

        public CustomerManager()
        {
            commonQueue = new Queue<Customer>();
            commonQueueThread = new Thread(() => CustomerGenerator());
        }
        public void CustomerGenerator()
        {
            while (maxCustomerNumber > 0)
            {
                Thread.Sleep(rand.Next(100, 500));
                Console.WriteLine("New Customer generated.");
                commonQueue.Enqueue(new Customer());
                maxCustomerNumber--;
            }
        }
    }
}