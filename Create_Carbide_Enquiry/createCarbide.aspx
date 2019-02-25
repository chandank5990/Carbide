<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="createCarbide.aspx.cs" Inherits="Create_Carbide_Enquiry.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <br />
    <h2 style="text-align: center; color: rosybrown;">Create Carbide Enquiry</h2>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <br />

    <div>
         <table style="margin: 0px auto;">
             <tr>
                 <td>

                 </td>
             </tr>
             <tr>
                 <td>

                 </td>
             </tr>
            <tr>
                <td>
                    <b>
                        <asp:Label ID="Label1" runat="server" Text="Customer ID"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label></b>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="250px" Style="text-align: center"></asp:TextBox>&nbsp;&nbsp;                
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="250px" Style="text-align: center"></asp:TextBox>
                </td>
            </tr>
             
        </table>
    </div>
    <div style="margin-left: 900px;color:rosybrown">
        <table>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Width="100" Text="Insert" OnClick="Button1_Click" />&nbsp;&nbsp;
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Width="100" Text="Submit"  OnClick="Button2_Click" />&nbsp;&nbsp;<!--PostBackUrl="~/printCarbide.aspx"-->
            </td>
           
        </tr>
    </table>

    </div>
    <br />
    <div>
         <table style="margin: 0px auto;">
            <tr>
                <td>
                    <b>
                        <asp:Label ID="Label3" runat="server" Text="UID" Width="100px"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label4" runat="server" Text="Description" Width="100px"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label5" runat="server" Text="Multiplier" Width="100px"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label6" runat="server" Text="Order Quantity" Width="100px"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label7" runat="server" Text="Total" Width="100px"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label8" runat="server" Text="Quantity To Order" Width="100px"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label9" runat="server" Text="Grade" Width="100px"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label10" runat="server" Text="Model" Width="100px"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label11" runat="server" Text="Outer Diameter" Width="100px"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label12" runat="server" Text="Length" Width="100px"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="Label13" runat="server" Text="Internal Diameter" Width="100px"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="100px" AutoPostBack="true" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="100px" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Width="100px"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Width="100px"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server" Width="100px"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server" Width="100px"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" Width="100px"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Width="100px"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server" Width="100px"></asp:TextBox>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBox13" runat="server" Width="100px"></asp:TextBox>&nbsp;&nbsp;
                </td>
            </tr>

        </table>
    </div>
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" Width="100%" HorizontalAlign="Center" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete Row" ShowHeader="True" Text="Delete" />
            <asp:TemplateField HeaderText="UID">
                <ItemTemplate>
                    <asp:Label ID="ArtOrd" runat="server" Text='<%#Eval("UID")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Article">
                <ItemTemplate>
                    <asp:Label ID="article" runat="server" Text='<%#Eval("Article")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="desc" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qty">
                <ItemTemplate>
                    <asp:Label ID="qty" runat="server" Text='<%#Eval("Qty")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <asp:Label ID="total" runat="server" Text='<%#Eval("Total")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="quan" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Order Qty">
                <ItemTemplate>
                    <asp:Label ID="orderqty" runat="server" Text='<%#Eval("Order Qty")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Grade">
                <ItemTemplate>
                    <asp:Label ID="grade" runat="server" Text='<%#Eval("Grade")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Model">
                <ItemTemplate>
                    <asp:Label ID="model" runat="server" Text='<%#Eval("Model")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="OD">
                <ItemTemplate>
                    <asp:Label ID="od" runat="server" Text='<%#Eval("OD")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Length">
                <ItemTemplate>
                    <asp:Label ID="length" runat="server" Text='<%#Eval("Length")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="id" runat="server" Text='<%#Eval("ID")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />



    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ErrorMessage="Please Enter UID" ControlToValidate="TextBox3" Style="z-index: 1; position: absolute; top: 286px; left: 21px; width: 72px; height: 9px"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" DisplayMode="SingleParagraph" />
    <!--
    <div class="row">
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
        <div class="col-sm-1">.col-sm-4</div>
    </div>
    -->
</asp:Content>
