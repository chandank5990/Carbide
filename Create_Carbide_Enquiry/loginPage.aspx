<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="Create_Carbide_Enquiry.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />

    <asp:HiddenField ID="companyID" runat="server" />

    <div class="split left">
        <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <h1 class="display-4">Location</h1>
                <p class="lead">Click on AWS1 or AWS2</p>
            </div>
        </div>
    </div>

    <div class="split right">
        <div class="centered">
            <div class="row">
                <div class="col-md-4">                    
                     <p>
                        <a style="width: 150px; height: 45px;" class="btn btn-default btn-lg" runat="server" onserverclick="Unnamed_ServerClick" >
                            <span class="glyphicon glyphicon-send">&nbsp;AWS&raquo1</span>
                        </a>
                    </p>                    
                    <p>
                        <a style="width: 150px; height: 45px;" class="btn btn-default btn-lg" runat="server" onserverclick="Unnamed_ServerClick1">
                            <span class="glyphicon glyphicon-send">&nbsp;AWS&raquo2</span>
                        </a>
                    </p>                  
                </div>
            </div>
        </div>
    </div>
  <script type="text/javascript">
      function aws1() {
          alert("dddd");
}
 
</script>
</asp:Content>
