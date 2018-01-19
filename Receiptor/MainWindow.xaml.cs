using System.Windows;
using System.Windows.Controls;

namespace Receiptor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ck_alt_Checked(object sender, RoutedEventArgs e)
        {
            ad2_line1.IsEnabled = true;
            ad2_line2.IsEnabled = true;
            ad2_city.IsEnabled = true;
            ad2_state.IsEnabled = true;
            ad2_zip.IsEnabled = true;
            ad2_canadian_bool.IsEnabled = true;
            ctb_info_honoree.IsEnabled = true;
        }

        private void ck_alt_Unchecked(object sender, RoutedEventArgs e)
        {
            ad2_line1.IsEnabled = false;
            ad2_line2.IsEnabled = false;
            ad2_city.IsEnabled = false;
            ad2_state.IsEnabled = false;
            ad2_zip.IsEnabled = false;
            ad2_canadian_bool.IsEnabled = false;
            ctb_info_honoree.IsEnabled = false;
        }

        private void ReceiptType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ReceiptType.SelectedIndex == 0)
            {
                ctb_info_honoree.IsEnabled = false;
                ctb_info_srcCode.IsEnabled = false;
            }else if(ReceiptType.SelectedIndex == 1)
            {
                ctb_info_honoree.IsEnabled = false;
                ctb_info_srcCode.IsEnabled = true;
                ctb_info_grpName.IsEnabled = true;
                ctb_info_gsn.IsEnabled = true;
            }else if(ReceiptType.SelectedIndex == 2)
            {
                ctb_info_honoree.IsEnabled = true;
                ctb_info_srcCode.IsEnabled = false;
                ck_alt.IsChecked = true;
            }
        }
    }
}
