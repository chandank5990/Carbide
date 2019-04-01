<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="carbideOrder.aspx.cs" Inherits="Create_Carbide_Enquiry.WebForm2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2 style="text-align: center; color: rosybrown;">Order Carbide</h2>
    <br />

    <div>
        <table style="margin: 0px auto;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Order"></asp:Label>&nbsp;&nbsp;
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Button ID="Button4" Width="100px" runat="server" Text="View" />&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Button ID="Button5" Width="100px" runat="server" Text="Print" />&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Button ID="Button6" Width="100px" runat="server" Text="Save" />&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Enquiry Order"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Vendor"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Vender Name"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Current"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Delivery Date"></asp:Label>&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="100px"></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
