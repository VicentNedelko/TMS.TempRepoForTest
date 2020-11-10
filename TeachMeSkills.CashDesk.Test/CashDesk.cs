using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TeachMeSkills.CashDesk.Test.Enums;

namespace TeachMeSkills.CashDesk.Test
{
    public class CashDesk
    {
        public Speed Speed { get; set; }
        public int maxCustomerNumber { get; set; }
        public Queue<Customer> cashDeskQueue { get; set; }
        public Thread cashDeskThread { get; set; }
        private static Semaphore semaphore = new Semaphore(0, 5);
        public List<TimeSpan> servingTime { get; set; }
        public CashDesk()
        {
            cashDeskQueue = new Queue<Customer>();
            servingTime = new List<TimeSpan>();
            switch (new Random().Next(1, 3))
            {
                case 1:
                    Speed = Speed.Slow;
                    break;
                case 2:
                    Speed = Speed.Normal;
                    break;
                case 3:
                    Speed = Speed.Fast;
                    break;
            }
            cashDeskThread = new Thread(() => Service());
        }
        public void Service()
        {
            DateTime startTime;
            DateTime finishTime;
            while(maxCustomerNumber > 0 || cashDeskQueue.Count > 0)
            {
                if (cashDeskQueue.Count > 0)
                {
                    startTime = DateTime.Now;
                    Thread.Sleep(cashDeskQueue.Peek().Basket.Count * 1000);
                    finishTime = DateTime.Now;
                    servingTime.Add(finishTime - startTime);
                    Console.WriteLine($"Customer served in {(finishTime - startTime).TotalSeconds} sec");
                    cashDeskQueue.Dequeue();
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("SERVICE FINISHED");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
