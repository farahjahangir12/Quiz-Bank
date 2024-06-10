<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewQuestion.aspx.vb" Inherits="ViewQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="styles.css"/>
</head>
<body style="background-color:#faf5e4;">
    <form id="form1" runat="server">
        <h2 style="margin:10px auto;text-align:center;">Added Questions</h2>
        <asp:Table ID="qtable" runat="server" class="qtable">
            <asp:TableHeaderRow CssClass="qrow">
                <asp:TableHeaderCell Text="No." CssClass="count">
                </asp:TableHeaderCell>
                 <asp:TableHeaderCell Text="Statement" CssClass="qcell">
                </asp:TableHeaderCell>
                 <asp:TableHeaderCell Text="Options" CssClass="optcell">
                 </asp:TableHeaderCell>
                 <asp:TableHeaderCell Text="Correct Choice" CssClass="correctcell">
                 </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Label ID="Label1" runat="server" ></asp:Label>
    </form>
</body>
</html>
