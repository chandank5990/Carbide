using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Create_Carbide_Enquiry
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            companyID.Value = "AWS 1";
            Session["companyID"] = companyID.Value;
            Response.Redirect("createCarbide.aspx");
        }
        
        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            companyID.Value = "AWS 2";
            Session["companyID"] = companyID.Value;
            Response.Redirect("createCarbide.aspx");
        }
    }
}