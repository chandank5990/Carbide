<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="receiveOrder.aspx.cs" Inherits="Create_Carbide_Enquiry.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h2 style="text-align: center; color: rosybrown;">Receive Order</h2>
    <br />

    <div>
        <table style="margin: 0px auto;">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Order"></asp:Label>&nbsp;&nbsp;</td>
                <td><asp:Label ID="Label2" runat="server" Text="Challan No."></asp:Label>&nbsp;&nbsp;</td> 
                <td><asp:Label ID="Label3" runat="server" Text="Delivery Date"></asp:Label>&nbsp;&nbsp;</td>                
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp;</td> 
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>&nbsp;&nbsp;</td> 
                <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>&nbsp;&nbsp;</td> 
                <td><asp:Button ID="Button1" runat="server" Text="Save" Width="50px" />&nbsp;&nbsp;</td> 
                <td><asp:Button ID="Button2" runat="server" Text="Exit" Width="50px" />&nbsp;&nbsp;</td> 
            </tr>
        </table>
    </div>
</asp:Content>
