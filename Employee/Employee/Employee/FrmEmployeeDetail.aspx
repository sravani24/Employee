<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEmployeeDetail.aspx.cs" Inherits="Employee.FrmEmployeeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 555px">
    
        <asp:Panel ID="Panel1" runat="server" Height="551px">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="28px" OnClick="Button1_Click" Text="Add" Width="58px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Update" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Delete" />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
