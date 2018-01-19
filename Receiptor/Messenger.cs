using System.Windows;
using Xceed.Wpf.Toolkit;

namespace Receiptor
{
    static class Messenger
    {
        public static void AlertUser(string _title, string _message, string _messageLevel)
        {
            MessageBoxImage mbi;
            switch (_messageLevel)
            {
                case "Info":
                    mbi = MessageBoxImage.Information;
                    break;
                case "Error":
                    mbi = MessageBoxImage.Error;
                    break;
                case "Debug":
                    mbi = MessageBoxImage.Warning;
                    break;
                default:
                    mbi = MessageBoxImage.Information;
                    break;
            }
            Xceed.Wpf.Toolkit.MessageBox.Show(_message, _title, MessageBoxButton.OK, mbi);
        }
    }
}
