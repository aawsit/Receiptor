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
            pd.PrintDocument = doc;
            Messenger.AlertUser("Receipt to Print", _rec.ToString(), "Info");
            doc.PrintPage += (sender, e) => new PrintPageEventHandler(pd_printPage(sender, e, _rec));
            DialogResult res = pd.ShowDialog();
            if(res == DialogResult.OK){
                doc.DefaultPageSettings.Landscape = true;
                doc.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Env10", 4, 8);
                doc.Print();
            }

        }

        private static void pd_printPage(object sender, PrintPageEventArgs e, Receipt _rec)
        {
            Graphics gfx = e.Graphics;
            fmt = new StringFormat(StringFormatFlags.DirectionVertical);
            Receipt.validateReceipt(_rec, e);
        }

        internal static void PrintStandard(Receipt rec, PrintPageEventArgs e)
        {
            Messenger.AlertUser("Standard Receipt is Ready to Print.", "All checks pass, and reciept should print properly", "Info");
            Graphics g = e.Graphics;
            if(rec.primary.address2 != "Address 2")
            {
                g.DrawString(rec.primary.address1, CourierBody, Blk, new PointF(130, 130), fmt);
                g.DrawString(rec.primary.address2, CourierBody, Blk, new PointF(130, 120), fmt);
            }else{
                g.DrawString(rec.primary.address1, CourierBody, Blk, new PointF(130, 120), fmt);
}
        }

        internal static void PrintBirthday(Receipt rec,  PrintPageEventArgs e)
        {
            Messenger.AlertUser("Birthday Receipt is Ready to Print.", "All Checks Pass, and receipt should print properly", "Info");
        }
    }
}
