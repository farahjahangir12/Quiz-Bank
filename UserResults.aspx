<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserResults.aspx.vb" Inherits="UserResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Results</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="USER_ID" HeaderText="User ID" />
                    <asp:BoundField DataField="USERNAME" HeaderText="Username" />
                    <asp:BoundField DataField="SCORE" HeaderText="Score" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
