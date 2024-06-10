<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserInterface.aspx.vb" Inherits="UserInterface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="left-div">
       </div>
        <div class="outer-div">
          <div class="right-div">
              <asp:Label ID="Selection" runat="server" Text="Select type Of Account" CssClass="label"></asp:Label>
              <asp:RadioButtonList ID="rrl" runat="server">
                  <asp:ListItem Text="Admin" Style="margin-top:4px;"></asp:ListItem>
                   <asp:ListItem Text="User" Style="margin-top:4px;"></asp:ListItem>
              </asp:RadioButtonList><br />
               <asp:Label ID="UserN" runat="server" Text="Username" Visible="True" Style="margin-top:3px;margin-bottom:3px;"></asp:Label><br />
               <asp:TextBox ID="UserName" runat="server"  Visible="True" CssClass="textbox"></asp:TextBox><br />
               <asp:Label ID="Pword" runat="server" Text="Password"  Visible="True" Style="margin-top:5px;margin-bottom:5px;"></asp:Label><br />
               <asp:TextBox ID="Password" runat="server"  Visible="True" CssClass="textbox"></asp:TextBox>
              
              <br />
              <asp:Button ID="LogIn" runat="server" Text="Log In"  CssClass="button"/><br />
              <asp:Button ID="Reg" runat="server" Text="Register" CssClass="button"/>

              </div>
      </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
