using System;

namespace Receiptor
{
    internal class Contribution
    {
        public string amount { get; set; }
        public string svcNumber { get; set; }
        public string grpName { get; set; }
        public DateTime ContributionDate { get; set; }
        public string honoree { get; set; }
        public string contributor { get; set; }
        public string srcCode { get; set; }
        public Contribution(string _amt, string _svcNo, string _grpName, DateTime _contribDate, string _contributor, string _honor, string _srcC)
        {
            this.amount = _amt;
            this.svcNumber = _svcNo;
            this.grpName = _grpName;
            this.ContributionDate = _contribDate;
            this.honoree = _honor;
            this.contributor = _contributor;
            this.srcCode = _srcC;
        }
    }

    internal class Address
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public bool canadian { get; set; }
        public Address(string _add1, string _add2, string _city, string _state, string _zip, bool _can)
        {
            this.address1 = _add1;
            this.address2 = _add2;
            this.city = _city;
            this.state = _state;
            this.zip = _zip;
            this.canadian = _can;
        }
    }
    class Receipt
    {
        public Contribution Contrib { get; set; }
        public Address primary { get; set; }
        public Address alternate { get; set; }
        public int receiptType { get; set; }
        public bool alternateAddress { get; set; }
        public Receipt(int _rt)
        {
            this.receiptType = _rt;
        }
        public static void validateReceipt(Receipt _rec)
        {
            if (_rec.receiptType == 0) //standard Receipt
            {
                validatestandard(_rec);
            }
            else if (_rec.receiptType == 1)//birthday
            {
                validateBd(_rec);
            }
            else if (_rec.receiptType == 2) //Memorial
            {
                validateMemorial(_rec);
            }
        }

        private static void validateMemorial(Receipt rec)
        {

        }

        private static void validateBd(Receipt rec)
        {
            if(rec.Contrib.amount == "" || rec.Contrib.amount == "Contribution Amount")
            {
                Messenger.AlertUser("No Contribution Amount set.", "Please Provide an amount for this Contribution.", "Error");
                return;
            }else if(rec.Contrib.ContributionDate <= DateTime.MinValue)
            {
                Messenger.AlertUser("No Date Set", "Please Provide a Date for this Contribution", "Error");
                return;
            }else if(rec.Contrib.srcCode == "" || rec.Contrib.srcCode == "Source Code")
            {
                Messenger.AlertUser("No Source Code Provided.", "Please Provide a Source Code for this Birthday Contribution", "Error");
                return;
            }else if(rec.Contrib.contributor == "" || rec.Contrib.contributor == "Contributer Name")
            {
                Messenger.AlertUser("No Contributer Name", "Please Provide a Contributer Name for this Contribution", "Error");
                return;
            }
            if (rec.alternateAddress)
            {
                bool altPass = validateAlternate(rec.alternate);
                if (!altPass)
                {
                    return;
                }
            }
            if(rec.Contrib.grpName == "" || rec.Contrib.grpName == "Group Name")
            {
                Messenger.AlertUser("No Group Name Provided", "Although Group Name is Desired, it is not required. Printing will continue.", "Info");
                rec.Contrib.grpName = "";
            }
            bool priPass = validatePrimary(rec.primary);
            if (!priPass)
            {
                return;
            }
            Messenger.AlertUser("Successful Validation, Sending to Printer", "All Validation has passed.", "Info");
            Printality.PrintBirthday(rec);
        }

        private static void validatestandard(Receipt rec)
        {
            if (rec.Contrib.amount == "" || rec.Contrib.amount == "Contribution Amount")
            {
                Messenger.AlertUser("No Contribution Set", "Please Provide an Amount for this Contribution", "Error");
                return;
            }
            else if (rec.Contrib.ContributionDate <= DateTime.MinValue)
            {
                Messenger.AlertUser("No Date Set", "Please Select a Date for this Contribution", "Error");
                return;
            }
            else if (rec.Contrib.grpName == "" || rec.Contrib.grpName == "Group Name")
            {
                Messenger.AlertUser("No Group Name Set", "Please Provide a Group Name for this Contribution", "Error");
                return;
            }
            else if (rec.alternateAddress)
            {
                bool altPass = validateAlternate(rec.alternate);
                if (!altPass)
                {
                    return;
                }
            }
            bool priPass = validatePrimary(rec.primary);
            if (!priPass)
            {
                return;
            }
            Messenger.AlertUser("Validation Successful", "All validations pass. Sending to Printer", "Info");
            Printality.PrintStandard(rec);
        }

        private static bool validatePrimary(Address primary)
        {
            if (primary.address1 == "" || primary.address1 == "Address 1")
            {
                Messenger.AlertUser("Address Not Provided", "Please Provide Address Line 1 for the Primary Address", "Error");
                return false;
            }
            else if (primary.city == "" || primary.city == "City")
            {
                Messenger.AlertUser("Missing City.", "Please Provide a City for the Primary Address", "Error");
                return false;
            }
            else if (primary.state == "" || primary.state == "State/Province")
            {
                Messenger.AlertUser("Missing State/Province", "Please Enter a State or Province for the Primary Address", "Error");
                return false;
            }
            else if (primary.zip == "" || primary.zip == "Zip/Postal Code")
            {
                Messenger.AlertUser("Missing Zip/Postal Code", "Please Provide a Zip or Postal Code for the Primary Address.", "Error");
                return false;
            }
            return true;
        }
        private static bool validateAlternate(Address alternate)
        {
            if (alternate.address1 == "" || alternate.address1 == "Address 1")
            {
                Messenger.AlertUser("Alternate Address Requested, but Not Provided", "Please Provide Address Line 1 to Continue", "Error");
                return false;
            }
            else if (alternate.city == "" || alternate.city == "City")
            {
                Messenger.AlertUser("Alternate Address Requested, but Missing City.", "Please Provide a City for the Alternate Address", "Error");
                return false;
            }
            else if (alternate.state == "" || alternate.state == "State/Province")
            {
                Messenger.AlertUser("Alternate Address Requested, but Missing State/Province", "Please Enter a State or Province for the Alternate Address", "Error");
                return false;
            }
            else if (alternate.zip == "" || alternate.zip == "Zip/Postal Code")
            {
                Messenger.AlertUser("Alternate Address Requested, but Missing Zip/Postal Code", "Please Provide a Zip or Postal Code for the Alternate Address.", "Error");
                return false;
            }
            return true;
        }
    }
}

