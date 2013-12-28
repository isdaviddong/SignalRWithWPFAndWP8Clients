using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplication5
{
    public class MyHub1 : Hub //SignalR主要部分
    {
        public void Send(string name, string message)    //接收傳送來的訊息
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);  //廣播訊息 (這邊用到了動態方法)
        }
    }
}