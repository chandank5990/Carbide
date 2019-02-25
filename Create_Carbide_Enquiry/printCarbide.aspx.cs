using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.IO;

namespace Create_Carbide_Enquiry
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField1.Value = Session["PTNo"] as String;

            string conString = @"datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT `ofertas (líneas)`.NumOrd, `ordenes de fabricación`.PinOrd, `ordenes de fabricación`.Datos, `ordenes de fabricación`.EntOrd, `ofertas (líneas)`.NumOfe, `artículos de clientes (piezas)`.CodPie, `ofertas (líneas)`.TotPie, `artículos de clientes (piezas)`.DiaExt, `artículos de clientes (piezas)`.Longit, `artículos de clientes (piezas)`.DiaInt, `artículos de clientes (piezas)`.CalPie, `ofertas (cabeceras)`.NumOfe, `ofertas (cabeceras)`.FecOfe FROM ((`ofertas (líneas)` INNER JOIN(`artículos de clientes (piezas)` INNER JOIN `ordenes de fabricación` ON `ordenes de fabricación`.ArtOrd = `artículos de clientes (piezas)`.CodArt) ON `ordenes de fabricación`.NumOrd = `ofertas (líneas)`.NumOrd) INNER JOIN `ofertas (cabeceras)` ON `ofertas (líneas)`.NumOfe = `ofertas (cabeceras)`.NumOfe) WHERE ((`ofertas (líneas)`.NumOfe = '18') AND `ofertas (líneas)`.CodPie LIKE `artículos de clientes (piezas)`.CodPie); ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            TextBox1.Text = (Convert.ToDateTime(dt.Rows[0][12]).ToString("dd/MM/yyyy"));
                            TextBox2.Text = dt.Rows[0][11].ToString();
                            TextBox3.Text = (Convert.ToDateTime(dt.Rows[0][3]).ToString("dd/MM/yyyy"));
                        }
                    }
                }
                con.Close();
            }
            /*
            try
            {
                string MyConnection = "datasource=localhost;port=3306;username=root;password=mysql12;";
                string Query = "SELECT new_rschema.`ofertas(líneas)`.NumOrd,`ordenes de fabricación`.PinOrd,`ordenes de fabricación`.Datos,`ordenes de fabricación`.EntOrd,`ofertas(líneas)`.NumOfe,`artículos de clientes(piezas)`.CodPie,`ofertas(líneas)`.TotPie,`artículos de clientes(piezas)`.DiaExt,`artículos de clientes(piezas)`.Longit,`artículos de clientes(piezas)`.DiaInt,`artículos de clientes(piezas)`.CalPie,`ofertas(cabeceras)`.NumOfe,`ofertas(cabeceras)`.FecOfe FROM ((`ofertas(líneas)` INNER JOIN(`artículos de clientes(piezas)` INNER JOIN `ordenes de fabricación` ON `ordenes de fabricación`.ArtOrd = `artículos de clientes(piezas)`.CodArt) ON `ordenes de fabricación`.NumOrd = `ofertas(líneas)`.NumOrd) INNER JOIN `ofertas(cabeceras)` ON `ofertas(líneas)`.NumOfe = `ofertas(cabeceras)`.NumOfe) WHERE ((`ofertas(líneas)`.NumOfe = '18') AND `ofertas(líneas)`.CodPie LIKE `artículos de clientes(piezas)`.CodPie); ";
                    
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection);
                MySqlCommand command = new MySqlCommand(Query, MyConn2);
                MySqlDataReader reader;
                MyConn2.Open();
                command.ExecuteNonQuery();
                MySqlDataAdapter MyCommand2 = new MySqlDataAdapter(Query, MyConn2);
                DataSet dataSet = new DataSet();
                MyCommand2.Fill(dataSet);
                GridView1.DataSource = dataSet;
                GridView1.DataBind();

                MyConn2.Open();
                MyConn2.Close();

                 MyConn2.Close();
             }
             catch (Exception ex)
             {
                 
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Retrived')", true);
             }
             */
            /*
            if (!this.IsPostBack)
            {
                System.Data.DataTable dt = (System.Data.DataTable)Session["order"];

                dt.Columns.Add(new System.Data.DataColumn("pt", typeof(Int32)));
                dt.Columns.Add(new System.Data.DataColumn("remarks", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("delivery Date", typeof(DateTime)));

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if(Page.PreviousPage !=null){
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Create Carbide First!!')", true);
            }
            */
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(string), "print", "window.print();", true);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string FileName = "Carbide Inquiry ( " + DateTime.Today.ToString("dd/MM/yy") + " )";
            string FileNameDateFormat = FileName;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                //GridView1.AllowPaging = false;
                //this.btnAWS2_Click(null,null);

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
}