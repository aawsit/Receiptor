using System;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Receipt rcpt = new Receipt(ReceiptType.SelectedIndex);
            rcpt.primary = pullPrimaryAddress();
            if (ck_alt.IsChecked.Value)
            {
                rcpt.alternateAddress = true;
                rcpt.alternate = pullAlternateAddress();
            }
            rcpt.Contrib = pullContribInfo();
            Printality.PrintReciept(rcpt);
        }

        private Contribution pullContribInfo()
        {
            Contribution cont = new Contribution(ctb_info_amt.Text, ctb_info_gsn.Text, ctb_info_grpName.Text, rcpt_date.SelectedDate.Value, ctb_info_payer.Text, ctb_info_honoree.Text, ctb_info_srcCode.Text);
            return cont;
        }

        private Address pullAlternateAddress()
        {
            Address add = new Address(ad2_line1.Text, ad2_line2.Text, ad2_city.Text, ad2_state.Text, ad2_zip.Text, ad2_canadian_bool.IsChecked.Value);
            return add;
        }

        private Address pullPrimaryAddress()
        {
            Address add = new Address(ad1_line1.Text, ad1_line2.Text, ad1_city.Text, ad1_state.Text, ad1_zip.Text, ad1_canadian_bool.IsChecked.Value);
            return add;
        }

        private void ad1_line1_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "Address 1")
            {
                tx.Text = "";
            }
        }

        private void ad1_line1_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "")
            {
                tx.Text = "Address 1";
            }
        }

        private void ad1_line2_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "")
            {
                tx.Text = "Address 2";
            }
        }

        private void ad1_city_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "")
            {
                tx.Text = "City";
            }
        }

        private void ad1_state_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "")
            {
                tx.Text = "State/Province";
            }
        }

        private void ad1_zip_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "")
            {
                tx.Text = "Zip/Postal Code";
            }
        }

        private void ad2_line1_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "")
            {
                tx.Text = "Address 1";
            }
        }

        private void ad2_line2_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "")
            {
                tx.Text = "Address 2";
            }
        }

        private void ad2_city_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "")
            {
                tx.Text = "City";
            }
        }

        private void ad2_state_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "")
            {
                tx.Text = "State/Province";
            }
        }

        private void ad2_zip_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "")
            {
                tx.Text = "Zip/Postal Code";
            }
        }

        private void ctb_info_amt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "")
            {
                tx.Text = "Contribution Amount";
            }
        }

        private void ctb_info_payer_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "")
            {
                tx.Text = "Contributer Name";
            }
        }

        private void ctb_info_honoree_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "")
            {
                tx.Text = "Contribution Honoree";
            }
        }

        private void ctb_info_gsn_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "")
            {
                tx.Text = "Group Service Number";
            }
        }

        private void ctb_info_srcCode_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "")
            {
                tx.Text = "Source Code";
            }
        }

        private void ctb_info_grpName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "")
            {
                tx.Text = "Group Name";
            }
        }

        private void ad1_line2_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "Address 2")
            {
                tx.Text = "";
            }
        }

        private void ad1_city_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "City")
            {
                tx.Text = "";
            }
        }

        private void ad1_state_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "State/Province")
            {
                tx.Text = "";
            }
        }

        private void ad1_zip_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text ==  "Zip/Postal Code")
            {
                tx.Text = "";
            }
        }

        private void ad2_line1_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "Address 1")
            {
                tx.Text = "";
            }
        }

        private void ad2_line2_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "Address 2")
            {
                tx.Text = "";
            }
        }

        private void ad2_city_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "City")
            {
                tx.Text = "";
            }
        }

        private void ad2_state_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "State/Province")
            {
                tx.Text = "";
            }
        }

        private void ad2_zip_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "Zip/Postal Code")
            {
                tx.Text = "";
            }
        }

        private void ctb_info_amt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "Contribution Amount")
            {
                tx.Text = "";
            }
        }

        private void ctb_info_payer_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "Contributer Name")
            {
                tx.Text = "";
            }
        }

        private void ctb_info_honoree_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "Contribution Honoree")
            {
                tx.Text = "";
            }
        }

        private void ctb_info_gsn_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx.Text == "Group Service Number") {
                tx.Text = "";
            }
        }

        private void ctb_info_srcCode_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "Source Code")
            {
                tx.Text = "";
            }
        }

        private void ctb_info_grpName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if(tx.Text == "Group Name")
            {
                tx.Text = "";
            }
        }
    }
}
