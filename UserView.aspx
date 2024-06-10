<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserView.aspx.vb" Inherits="UserView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="styles.css"/>
</head>
<body style="background-color:#faf5e4;">
    <form id="form1" runat="server">
       
<div class="input">
     <h1>Welcome To QuizBank!</h1>
     <label style="font-size:20px;">Instructions:</label><br />
    <asp:Label ID="qlbl" runat="server" Text="This quiz consist of 10 questions.You are allowed three attempts.The
         scores for the final attempt will be counted towards final grade.Click attempt to continue!" Font-Size="Large"></asp:Label><br /><br />
   
    <asp:Button ID="OK" runat="server" Text="Attempt" CssClass="button" PostBackUrl="~/AttemptTest.aspx"/>
</div>
<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
