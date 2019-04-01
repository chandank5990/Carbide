<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="printCarbide.aspx.cs" Inherits="Create_Carbide_Enquiry.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <br />
    <div style="text-align:left">
    <b><asp:Label ID="Label4" runat="server"  Text="Label" style="font-size: large"></asp:Label></b>
    </div>
    <br>
        <h2 style="text-align:center; color:rosybrown;">FINAL DIMENSION</h2>
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
        <tr >
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="100px" style="text-align: center"></asp:TextBox>&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="100px" style="text-align: center"></asp:TextBox>&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Width="100px" style="text-align: center"></asp:TextBox>&nbsp;&nbsp;
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Print"  OnClick="Button1_Click" Width="80px"/>&nbsp;&nbsp;
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Export" OnClick="Button2_Click" Width="80px"/>&nbsp;&nbsp;
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1. KENNAMETAL" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2. CB CARBIDE" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3. STOCK KENNAMETAL" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4. STOCK CB CARBIDE" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5. STOCK WROLES" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6. STOCK ANU" Value="6"></asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
            </td>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Place Order"  Width="100px" OnClick="Button3_Click"/>
            </td>
        </tr>
    </table>
    
    <br />
    <br />
    <br />
    <br />
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" Width="75%">
        <Columns>
            <asp:BoundField DataField="NumOrd" HeaderText="UID" ReadOnly="true"/>
            <asp:BoundField DataField="PinOrd" HeaderText="PT" ReadOnly="true"/>
           
            <asp:BoundField DataField="CodPie" HeaderText="Part"/>
            <asp:BoundField DataField="TotPie" HeaderText="Qty"/>
            <asp:BoundField DataField="DiaExt" HeaderText="OD" />
            <asp:BoundField DataField="Longit" HeaderText="Length"/>
            <asp:BoundField DataField="DiaInt" HeaderText="ID"/>
            <asp:BoundField DataField="CalPie" HeaderText="Grade"/>
            <asp:BoundField DataField="Datos"  HeaderText="Remarks" ReadOnly="true" />
            <asp:BoundField DataField="EntOrd" HeaderText="Delivery Date" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="True"/>
             <asp:TemplateField HeaderText="Vendor">
                <ItemTemplate>
                    <asp:Label ID="ven" runat="server" Text='<%#Bind("Vendor")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
   
</asp:Content>
