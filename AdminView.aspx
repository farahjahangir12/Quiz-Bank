<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AdminView.aspx.vb" Inherits="AdminView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  rel="stylesheet" href="styles.css"/>
</head>
<body style="background-color:#faf5e4;">
    <form id="form1" runat="server">
        <div class="navbar">
            <a href="AddQuestion.aspx">Add</a>
            <a href="ViewQuestion.aspx">View</a>
            <a href="Results.aspx">Results</a>
        </div>
        <div class="input">
             <h1>Welcome To QuizBank!</h1>
             <h2>Admin Panel</h2>
            <asp:Label ID="qlbl" runat="server" Text="Enter number of questions:" Font-Size="Large"></asp:Label><br />
            <asp:TextBox ID="Input" runat="server" CssClass="textbox"></asp:TextBox><br />
            <asp:Button ID="OK" runat="server" Text="Submit" CssClass="button"/>
        </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
