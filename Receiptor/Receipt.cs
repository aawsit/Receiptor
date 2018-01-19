using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiptor
{
    internal class Contribution
    {
        public double amount { get; set; }
        public string svcNumber { get; set; }
        public string receiptNumber { get; set; }
        public string grpName { get; set; }
        public DateTime ContributionDate { get; set; }
    }

    internal class Address
    {

    }
    class Receipt
    {
        public Contribution Contrib { get; set; }
        
    }
}
