<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        管理員說:<asp:TextBox ID="TextBox1" runat="server" Width="286px">哈囉，我是阿管~</asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send(from Server)" Width="133px" />
    
    </div>
    </form>
</body>
</html>
