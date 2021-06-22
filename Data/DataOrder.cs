using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU21_Final_Project.Data
{
    class DataOrder
    {
        public int OrderNum { get; set; } 

        public int PersonID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShipDate { get; set; }

        public string DiscountCode { get; set; }

        public double DiscountAmount { get; set; }

        public double Shipping { get; set; }

        public double Total { get; set; }

        public string CardType { get; set; }

        public int CardNumber { get; set; }
        
        public string CardeExperation { get; set; }

        public static void setOrder()
        {

        }
    }
}
