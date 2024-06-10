<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AttemptTest.aspx.vb" Inherits="AttemptTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="styles.css"/>
</head>
<body style="background-color:#faf5e4;">
    <form id="form1" runat="server" class="input">
      
        <asp:Panel ID="Panel1" runat="server" Visible="True" CssClass="panel">
            <asp:Label ID="questLabel" runat="server" Text="" CssClass="textbox"></asp:Label>
            <asp:RadioButtonList ID="rrl" runat="server">
                 <asp:ListItem  ID="opt1" runat="server" class="check-box"></asp:ListItem>
                 <asp:ListItem  ID="opt2" runat="server" class="check-box"></asp:ListItem>
                 <asp:ListItem  ID="opt3" runat="server" class="check-box"></asp:ListItem>
                 <asp:ListItem  ID="opt4" runat="server" class="check-box"></asp:ListItem>
            </asp:RadioButtonList>
           

        </asp:Panel>
        <asp:Button ID="Submit" runat="server" Text="Submit" CssClass="button" /><br />
        <asp:Button ID="SubmitTest" runat="server" Text="Submit Test" Visible="False" CssClass="button"/>
        <asp:Button ID="AttemptAgain" runat="server" Text="Attempt Again" Visible="False" CssClass="button"/>
       
        <asp:Button ID="ExitTest" runat="server" Text="Exit" Visible="False" CssClass="button" /><br />
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>   
    </form>
</body>
</html>
