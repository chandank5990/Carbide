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
            HiddenField2.Value = Session["companyID"] as String;

            Label4.Text = HiddenField2.Value;
            if (!IsPostBack) {
                HiddenField1.Value = Session["PTNo"] as String;

                string conString = @"datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "select new_rschema.`Ofertas (líneas)`.NumOrd,new_rschema.`Ordenes de fabricación`.PinOrd,new_rschema.`Ordenes de fabricación`.Datos,new_rschema.`Ordenes de fabricación`.EntOrd,new_rschema.`ofertas (líneas)`.NumOfe,new_rschema.`artículos de clientes (piezas)`.CodPie,new_rschema.`ofertas (líneas)`.TotPie,new_rschema.`artículos de clientes (piezas)`.DiaExt,new_rschema.`artículos de clientes (piezas)`.Longit,new_rschema.`artículos de clientes (piezas)`.DiaInt,new_rschema.`artículos de clientes (piezas)`.CalPie,new_rschema.`ofertas (cabeceras)`.NumOfe,new_rschema.`ofertas (cabeceras)`.FecOfe FROM new_rschema.`ofertas (líneas)` INNER JOIN new_rschema.`artículos de clientes (piezas)` INNER JOIN new_rschema.`Ordenes de fabricación` ON new_rschema.`Ordenes de fabricación`.ArtOrd = new_rschema.`artículos de clientes (piezas)`.CodArt ON new_rschema.`Ordenes de fabricación`.NumOrd = new_rschema.`ofertas (líneas)`.NumOrd INNER JOIN new_rschema.`ofertas (cabeceras)` ON new_rschema.`ofertas (líneas)`.NumOfe = new_rschema.`ofertas (cabeceras)`.NumOfe WHERE new_rschema.`ofertas (líneas)`.NumOfe = '" + HiddenField1.Value + "' AND new_rschema.`ofertas (líneas)`.CodPie LIKE new_rschema.`artículos de clientes (piezas)`.CodPie; ", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                DataRow dataRow = null;
                                sda.Fill(dt);
                                dt.Columns.Add("Vendor");
                                dt.TableName = "vendor";
                                dt.AcceptChanges();
                                ViewState["vendor"] = dt;
                                GridView1.DataSource = dt;

                                GridView1.DataBind();

                                DateTime TodayDate = DateTime.Today;
                                string t = TodayDate.ToString("dd-MM-yyyy");

                                TextBox1.Text = t;
                                TextBox2.Text = dt.Rows[0][11].ToString();
                                TextBox3.Text = TodayDate.AddDays(2).ToString("dd-MM-yyyy");
                            }
                        }
                    }
                    con.Close();
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "0")
            {
                DropDownList1.BackColor = Color.Red;
            }
            else { DropDownList1.BackColor = Color.Transparent;
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(string), "print", "window.print();", true);
            }
            
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
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue!="0")
            {
                DropDownList1.BackColor = Color.Transparent;
                DataTable dataTable = (DataTable)ViewState["vendor"];

                int i = 0;
                foreach (DataRow dr in dataTable.Rows ) {
                    
                dataTable.Rows[i][13] = DropDownList1.SelectedItem;
                    //dataTable.AcceptChanges();
                    i++;
                }
                i = 0;
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
                
            }
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            /*
             //incrementing value direct in database
            try { 
            string source = "datasource=localhost;port=3306;username=root;password=mysql12;database=new_rschema;";
            string query = "update  new_rschema.`parámetros` set    valpar=valpar+1    where codpar='Último pedido (fases externas)';";
            MySqlConnection connection = new MySqlConnection(source);
            MySqlCommand command = new MySqlCommand(query,connection);
            MySqlDataReader reader;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            }
            catch(Exception aa){ }

           */
            DateTime TodayDate = DateTime.Today;
            string t = TodayDate.ToString("yyyy-MM-dd");
            try {               
                        string source = "datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
                        string query = "SELECT DISTINCTROW NumPed FROM new_rschema.`pedidos a proveedor (cabeceras)` ORDER BY `pedidos a proveedor (cabeceras)`.NumPed DESC";
                        MySqlConnection connection = new MySqlConnection(source);
                        MySqlCommand command = new MySqlCommand(query,connection);
                        MySqlDataReader reader;

                        connection.Open();
                        reader = command.ExecuteReader();
                        if (reader.Read()) {
                            if (reader.FieldCount>0) {
                                HiddenField3.Value = (Convert.ToInt32(reader["NumPed"] )+ 1).ToString();
                                Session["orderNo"] = HiddenField3.Value;
                            }                            
                        }
                        connection.Close();                                             
                  
            }
            catch (Exception kk) {
                Response.Write(kk);
            }
            
            try
            {
                string source2 = "datasource=localhost;port=3306;username=root;password=mysql12;database=new_rschema;";
                string query2 = "insert into `pedidos a proveedor (cabeceras)` (NumPed, FecPed, NumOfe, ProPed) values ('" + HiddenField3.Value+"','"+ t + "','"+HiddenField1.Value+"','"+DropDownList1.SelectedValue+"');";
                MySqlConnection connection2 = new MySqlConnection(source2);
                MySqlCommand command2 = new MySqlCommand(query2,connection2);
                MySqlDataReader reader2;

                connection2.Open();
                command2.ExecuteNonQuery();
                connection2.Close();
            }
            catch (Exception ass) { }

            try{
                string source3 = "datasource=localhost;port=3306;username=root;password=mysql12;database=new_rschema;";
                string query3 = "UPDATE new_rschema.`ofertas (cabeceras)`  SET `Numped` = '"+HiddenField3.Value+"' WHERE `numofe` = '"+HiddenField1.Value+"';  ";
                MySqlConnection connection3 = new MySqlConnection(source3);
                MySqlCommand command3 = new MySqlCommand(query3,connection3);
                MySqlDataReader reader;

                connection3.Open();
                command3.ExecuteNonQuery();
                connection3.Close();

            }
            catch (Exception aq) { }

            string Today2  = (Convert.ToDateTime(TextBox3.Text)).ToString("yyyy/MM/dd"); 
           // string day = Today2.ToString("yyyy-MM-dd");
            try {
                int i = 0,j=1;
                foreach (GridViewRow row in GridView1.Rows) {
                    if (row.RowType == DataControlRowType.DataRow) {

                        string source4 = "datasource=localhost;port=3306;username=root;password=mysql12;database=new_rschema;";
                        string query4 = "insert into new_rschema.`pedidos a proveedor (líneas)` (NumPed,NumOrd,CodPie,PiePed,PlaPie) values ('"+HiddenField3.Value+"','"+GridView1.Rows[i].Cells[0].Text+"','"+GridView1.Rows[i].Cells[2].Text+"','"+GridView1.Rows[i].Cells[3].Text+"','"+ Today2 + "');";
                        MySqlConnection connection4 = new MySqlConnection(source4);
                        MySqlCommand command4 = new MySqlCommand(query4,connection4);
                        MySqlDataReader reader4;

                        connection4.Open();
                        command4.ExecuteNonQuery();
                        connection4.Close();

                    }
                    i++;
                }
                i = 0;
               // command.Parameters.Add("NumOrd", MySqlDbType.Int32).Value = TextBox2.Text;
               // command.Parameters.Add("PinOrd", MySqlDbType.Int32).Value = GridView1.Rows[i].Cells[1].Text;
               // command.Parameters.Add("CodPie", MySqlDbType.VarChar).Value = GridView1.Rows[i].Cells[2].Text;
               // command.Parameters.Add();

            }
            catch (Exception lk) { }


        }
    }
}
 