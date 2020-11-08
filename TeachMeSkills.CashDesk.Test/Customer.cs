using System;
using System.Collections.Generic;
using System.Text;

namespace TeachMeSkills.CashDesk.Test
{
    public class Customer
    {
        public List<Product> Basket { get; set; }
        public string Id { get; set; }
        public Customer()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 5);
            Basket = new List<Product>();
            Random rand = new Random();
            for(int i = 0; i < rand.Next(1, 10); i++)
            {
                Basket.Add(new Product());
            }
        }
    }
}
