using System;
using System.Collections.Generic;
using System.Text;
using TeachMeSkills.CashDesk.Test.Enums;

namespace TeachMeSkills.CashDesk.Test
{
    public class Product
    {
        public ProdList Name { get; set; }
        public decimal Price { get; set; }
        public Product()
        {
            Random rand = new Random();
            Random rPrice = new Random();
            switch(rand.Next(1, 10))
            {
                case 1:
                    Name = ProdList.Prod1;
                    break;
                case 2:
                    Name = ProdList.Prod2;
                    break;
                case 3:
                    Name = ProdList.Prod3;
                    break;
                case 4:
                    Name = ProdList.Prod4;
                    break;
                case 5:
                    Name = ProdList.Prod5;
                    break;
                case 6:
                    Name = ProdList.Prod6;
                    break;
                case 7:
                    Name = ProdList.Prod7;
                    break;
                case 8:
                    Name = ProdList.Prod8;
                    break;
                case 9:
                    Name = ProdList.Prod9;
                    break;
                case 10:
                    Name = ProdList.Prod10;
                    break;
            }
            Price = (decimal)rPrice.NextDouble() * 10;
        }
    }
}
