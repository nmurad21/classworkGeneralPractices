using System;
using System.Collections.Generic;
using System.Text;
using Utils.Enums;

namespace Entities.Models
{
    class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Platform Platform{ get; set; }
        public double Price { get; set; }
        public double DiscountPercent { get; set; }
        public string Publisher { get; set; }
        public bool IsDeleted { get; set; }
        public void ShowInfo()
        {
            Console.WriteLine($"Id--{Id} \n Name--{Name} \n Platform--{Platform} \n Price--{Price} \n Discount percent-- {DiscountPercent} \n Publisher -- {Publisher} \n Is deleted--{IsDeleted}");
        } 
        public double GetDiscountedPrice()
        {
            return Price - Price * (DiscountPercent / 100);
        }

    }
}
