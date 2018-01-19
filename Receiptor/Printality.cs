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

        public static void PrintReciept(Receipt _rec)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(pd_printPage);
        }

        private static void pd_printPage(object sender, PrintPageEventArgs e)
        {
            Graphics gfx = e.Graphics;
        }
    }
}
