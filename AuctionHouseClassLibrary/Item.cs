using AuctionHouseClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseClassLibrary
{
    public class Item : IItem
    {
        public string name { get; set; } = null!;
        public double price { get; set; } 

        public Item(string Name, double Price)
        {
            if(name != null || name != "")
            {
                name = Name;
            }
            if (price > 0)
            {
                price = Price;
            }
        }
    }
}
