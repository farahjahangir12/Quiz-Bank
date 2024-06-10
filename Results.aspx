<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Results.aspx.vb" Inherits="Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body style="background-color:#faf5e4;">
    <form id="form1" runat="server">
     <h2 style="margin:10px auto;text-align:center;">Results</h2>
     <asp:Table ID="table" runat="server" class="qtable" Visible="True">
         <asp:TableHeaderRow CssClass="qrow">
             <asp:TableHeaderCell Text="No." CssClass="count1">
             </asp:TableHeaderCell>
              <asp:TableHeaderCell Text="Student ID" CssClass="qcell1">
             </asp:TableHeaderCell>
              <asp:TableHeaderCell Text="User Name" CssClass="optcell1">
              </asp:TableHeaderCell>
              <asp:TableHeaderCell Text="Score" CssClass="correctcell1">
              </asp:TableHeaderCell>
         </asp:TableHeaderRow>
     </asp:Table>
       
     <asp:Label ID="Label1" runat="server" ></asp:Label>
 </form>
</body>
</html>
