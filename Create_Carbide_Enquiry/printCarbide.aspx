<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="printCarbide.aspx.cs" Inherits="Create_Carbide_Enquiry.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="HiddenField1" runat="server" />
    <br>
        <h2 style="text-align:center; color:rosybrown;">Print Carbide Enquiry</h2>
    <br />
    

    <table style="margin: 0px auto;">
        <tr >
            <td>
               <b><asp:Label ID="Label1" runat="server" Text="Offer Date"></asp:Label></b> &nbsp;&nbsp;
            </td>
            <td>
                <b><asp:Label ID="Label2" runat="server" Text="Offer Number"></asp:Label></b> &nbsp;&nbsp;
            </td>
            <td>
                <b><asp:Label ID="Label3" runat="server" Text="Delivery Date"></asp:Label></b> &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Print"  OnClick="Button1_Click" Width="100"/>&nbsp;&nbsp;
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Export" OnClick="Button2_Click" Width="100"/>&nbsp;&nbsp;
            </td>
        </tr>
        
    </table>
    
    <br />
    <br />
    <br />
    <br />
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" Width="1000px">
        <Columns>
            
            <asp:BoundField DataField="PinOrd" HeaderText="PT" ReadOnly="true"/>
            <asp:BoundField DataField="NumOrd" HeaderText="UID" ReadOnly="true"/>
            
            <asp:BoundField DataField="CodPie" HeaderText="Part"/>
            <asp:BoundField DataField="TotPie" HeaderText="Qty"/>
            <asp:BoundField DataField="DiaExt" HeaderText="OD" />
            <asp:BoundField DataField="Longit" HeaderText="Length"/>
            <asp:BoundField DataField="DiaInt" HeaderText="ID"/>
            <asp:BoundField DataField="CalPie" HeaderText="Grade"/>
            <asp:BoundField DataField="Datos"  HeaderText="Remarks" ReadOnly="true" />
            <asp:BoundField DataField="EntOrd" HeaderText="Delivery Date"/>
            
            
        </Columns>
    </asp:GridView>
   
</asp:Content>
