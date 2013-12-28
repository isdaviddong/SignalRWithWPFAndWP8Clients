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
using Microsoft.AspNet.SignalR.Client;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;
        IHubProxy proxy;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //建立connection, proxy
            connection = new HubConnection("http://signalrtestsite.azurewebsites.net"); //測試位置，請自行建立
            proxy = connection.CreateHubProxy("MyHub1");
            connection.Start();
            //listen broadcastMessage
            proxy.On<string, string>(
                "broadcastMessage", (name, msg) =>
                 {
                     //非同步(在非UI執行序中)顯示訊息
                     this.Dispatcher.Invoke(
                          () => { lblShow.Content = "" + name + ":" + msg + "\n" + lblShow.Content; });
                 }
            );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //從Client端送訊息
            proxy.Invoke("Send", TxbName.Text, TxbMessage.Text);
        }
    }
}
