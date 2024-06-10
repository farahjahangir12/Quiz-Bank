<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddQuestion.aspx.vb" Inherits="AddQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  rel="stylesheet" href="styles.css"/>
</head>
<body style="background-color:#faf5e4;">
     <div class="navbar">
     <a href="AddQuestion.aspx">Add</a>
     <a href="ViewQuestion.aspx">View</a>
     <a href="Results.aspx">Results</a>
 </div>
    <form id="form1" runat="server" class="input">
          <div id="questionBox" runat="server">
       <label style="font-size:20px;">Question Statement</label><br />
       <asp:TextBox ID="qtext" runat="server" CssClass="textbox" Width="50%" Style="Margin-top:0;" ></asp:TextBox>
       <asp:Button ID="Button1" runat="server" Text="Enter Options" class="button" Width="30%" />
  </div>
        <asp:Panel runat="server" ID="Pnldetails" Visible="false" CssClass="panel">
        <asp:Label runat="server" Text="1" CssClass="label"></asp:Label>
         <asp:CheckBox ID="OptTrue1" runat="server" class="check-box"/>
        <asp:TextBox id="opt1" runat="server" CssClass="textbox" Width="40%"></asp:TextBox><br />

        <asp:Label ID="Label2" runat="server" Text="2"  CssClass="label"></asp:Label>
         <asp:CheckBox ID="OptTrue2" runat="server" class="check-box"  />
        <asp:TextBox id="opt2" runat="server" CssClass="textbox" Width="40%"></asp:TextBox><br />

        <asp:Label ID="Label3" runat="server" Text="3"  CssClass="label"></asp:Label>
         <asp:CheckBox ID="OptTrue3" runat="server" class="check-box" />
        <asp:TextBox id="opt3" runat="server" CssClass="textbox" Width="40%"></asp:TextBox><br />

        <asp:Label ID="Label4" runat="server" Text="4"  CssClass="label"></asp:Label>
           <asp:CheckBox ID="OptTrue4" runat="server" class="check-box"/>
        <asp:TextBox id="opt4" runat="server" CssClass="textbox" Width="40%"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" Text="Add Quetsion" CssClass="button" />
     
   </asp:Panel><br />
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>  
    </form>
</body>
</html>
