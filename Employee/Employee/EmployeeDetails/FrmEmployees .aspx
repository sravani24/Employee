<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEmployees .aspx.cs" Inherits="EmployeeDetails.FrmEmployees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 651px">
    <form id="form1" runat="server">
    <div style="height: 591px">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CheckBoxField  HeaderText="Select" SortExpression="checkbox" />
                <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Contact_No" HeaderText="Contact_No" SortExpression="Contact_No" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EmployeeDBConnectionString %>" SelectCommand="SELECT [First_Name] AS First_Name, [Email], [City], [Contact_No] AS Contact_No FROM [Employee]"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" Width="51px" />
&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="Delete" />
    
    </div>
    </form>
</body>
</html>
