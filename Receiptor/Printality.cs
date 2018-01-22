using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Controls;

namespace Receiptor
{
    static class Printality
    {
        private static SolidBrush Blk = new SolidBrush(Color.Black);
        private static Font CourierBody = new Font("Courier New", 12);
        private static Font LucidaBody = new Font("Lucida Sans", 12);
        private static Font LucidaHeader = new Font("Lucida Sans", 18);
        private static StringFormat fmt;

        public static void PrintReciept(Receipt _rec)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            //Messenger.AlertUser("Receipt to Print", _rec.ToString(), "Info");
            doc.PrintPage += (sender, e) => pd_printPage(sender, e, _rec);
        }

        private static void pd_printPage(object sender, PrintPageEventArgs e, Receipt _rec)
        {
            Graphics gfx = e.Graphics;
            fmt = new StringFormat(StringFormatFlags.DirectionVertical);
            Receipt.validateReceipt(_rec);
        }

        internal static void PrintStandard(Receipt rec)
        {
            Messenger.AlertUser("Standard Receipt is Ready to Print.", "All checks pass, and reciept should print properly", "Info");
        }

        internal static void PrintBirthday(Receipt rec)
        {
            Messenger.AlertUser("Birthday Receipt is Ready to Print.", "All Checks Pass, and receipt should print properly", "Info");
        }
    }
}
