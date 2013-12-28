using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.SignalR;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //透過GlobalHost使用hub instanc
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub1>();
            //由伺服器端主動發訊息
            context.Clients.All.broadcastMessage("admin", TextBox1.Text + " " + System.DateTime.Now.ToString());
        }
    }
}