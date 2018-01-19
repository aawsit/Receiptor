using System;

namespace Receiptor
{
    internal class Contribution
    {
        public double amount { get; set; }
        public string svcNumber { get; set; }
        public string receiptNumber { get; set; }
        public string grpName { get; set; }
        public DateTime ContributionDate { get; set; }
        public string honoree { get; set; }
        public string contributor { get; set; }
    }

    internal class Address
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public bool canadian { get; set; }
    }
    class Receipt
    {
        public Contribution Contrib { get; set; }
        public Address primary { get; set; }
        public Address alternate { get; set; }

    }
}
