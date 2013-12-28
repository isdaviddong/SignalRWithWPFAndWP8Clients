using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WP8Client.Resources;

namespace WP8Client
{
    public partial class MainPage : PhoneApplicationPage
    {
        HubConnection connection;
        IHubProxy proxy;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
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
                    this.Dispatcher.BeginInvoke(
                         () => { lblShow.Text = "" + name + ":" + msg + "\n" + lblShow.Text; });
                }
            );
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            //從Client端送訊息
            proxy.Invoke("Send", TxbName.Text, TxbMessage.Text);
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}