using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIBotTelegram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramMessageClient client;
        public MainWindow()
        {
            InitializeComponent();

            client = new TelegramMessageClient(this);

            listMessages.ItemsSource = client.BotMessageLog;
        }

        private void btnMsgSendClick(object sender, RoutedEventArgs e)
        {
            if (TargetSend.Text != "")
            {
                client.SendMessage(txtMsgSend.Text, TargetSend.Text);
                txtMsgSend.Clear();
            }
            else
            {
                MessageBox.Show("Не выбран получатель.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnMsgSendAllClick(object sender, RoutedEventArgs e)
        {
            if (client.BotMessageLog.Count != 0)
            {
                client.SendMessageAll(txtMsgSend.Text);
                txtMsgSend.Clear();
            }
            else
            {
                MessageBox.Show("Некому отправлять", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnLoad(object sender, RoutedEventArgs e)
        {
            client.BotMessageLog = JsonHandler.Instance.Load();
        }
    }
}
