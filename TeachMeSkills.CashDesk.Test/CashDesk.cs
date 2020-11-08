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
        public Queue<Customer> cashDeskQueue { get; set; }
        public Thread cashDeskThread { get; set; }
        private static Semaphore semaphore = new Semaphore(0, 5);
        public CashDesk()
        {
            cashDeskQueue = new Queue<Customer>();
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
            while(cashDeskQueue.Count > 0)
            {
                semaphore.WaitOne();
                Thread.Sleep(cashDeskQueue.Peek().Basket.Count * 100);
                cashDeskQueue.Dequeue();
                semaphore.Release();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("SERVICE FINISHED");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
