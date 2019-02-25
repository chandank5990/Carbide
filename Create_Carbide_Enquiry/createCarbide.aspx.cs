using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Create_Carbide_Enquiry
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable table = new DataTable();
                DataRow row;
                table.TableName = "order";
                table.Columns.Add(new DataColumn("UID", typeof(string)));
                table.Columns.Add(new DataColumn("Article", typeof(string)));
                table.Columns.Add(new DataColumn("Description", typeof(string)));
                table.Columns.Add(new DataColumn("Qty", typeof(double)));
                table.Columns.Add(new DataColumn("Total", typeof(int)));
                table.Columns.Add(new DataColumn("Quantity", typeof(string)));
                table.Columns.Add(new DataColumn("Order Qty",typeof(int)));
                table.Columns.Add(new DataColumn("Grade",typeof(string)));
                table.Columns.Add(new DataColumn("Model", typeof(string)));
                table.Columns.Add(new DataColumn("OD", typeof(double)));
                table.Columns.Add(new DataColumn("Length", typeof(double)));
                table.Columns.Add(new DataColumn("ID", typeof(double)));

                row = table.NewRow();
                table.Rows.Add(row);

                ViewState["order"] = table;
                GridView1.DataSource = table;
                GridView1.DataBind();
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (TextBox3.Text != "" && DropDownList1.SelectedValue != "select" && TextBox5.Text != "" && TextBox6.Text != "" && TextBox7.Text != "" && TextBox8.Text != "" && TextBox9.Text != "" && TextBox10.Text != "" && TextBox11.Text != "" && TextBox12.Text != "" && TextBox13.Text != "")
                {
                    DataTable dataTable = (DataTable)ViewState["order"];
                    DataRow dataRow = null;

                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dataTable.Rows.Count; i++)
                        {
                            dataRow = dataTable.NewRow();
                            dataRow["UID"] = TextBox3.Text;
                            dataRow["Article"] = HiddenField1.Value;
                            dataRow["Description"] = DropDownList1.SelectedValue;
                            dataRow["Qty"] = TextBox5.Text;
                            dataRow["Total"] = TextBox7.Text;
                            dataRow["Quantity"] = TextBox6.Text;
                            dataRow["Order Qty"] = TextBox8.Text;
                            dataRow["Grade"] = TextBox9.Text;
                            dataRow["Model"] = TextBox10.Text;
                            dataRow["OD"] = TextBox11.Text;
                            dataRow["Length"] = TextBox12.Text;
                            dataRow["ID"] = TextBox13.Text;
                        }
                        if (dataTable.Rows[0][0].ToString() == "")
                        {
                            dataTable.Rows[0].Delete();
                            dataTable.AcceptChanges();
                        }
                        ViewState["order"] = dataTable;
                        GridView1.DataSource = dataTable;
                        dataTable.Rows.Add(dataRow);
                        GridView1.DataBind();

                        Session["order"] = dataTable;
                    }
                }
            }
            catch (Exception lk)
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Order No
            try {
                string MyConnection3 = "datasource=localhost;port=3306;username=root;password=mysql12;";
                string Query3 = "SELECT DISTINCTROW NumOfe FROM new_rschema.`ofertas (cabeceras)` ORDER BY `ofertas (cabeceras)`.NumOfe DESC";
                MySqlConnection sqlConnection3 = new MySqlConnection(MyConnection3);
                MySqlCommand sqlCommand3 = new MySqlCommand(Query3, sqlConnection3);
                MySqlDataReader dataReader3;
                sqlConnection3.Open();
                dataReader3 = sqlCommand3.ExecuteReader();
                if (dataReader3.Read())
                {
                    if (dataReader3.FieldCount > 0)
                    {
                        HiddenField2.Value = (Convert.ToInt32(dataReader3["NumOfe"]) + 1).ToString();
                        Session["PTNo"] = HiddenField2.Value;
                    }
                    sqlConnection3.Close();
                }
            }
            catch (Exception ex) {
                Response.Write("try1");
            }
            //Order Details
            try {
                DateTime TodayDate = DateTime.Now;
                string dt = TodayDate.ToString("yyyy-MM-dd H:mm:ss");
                string MyConnection4 = "datasource=localhost;port=3306;username=root;password=mysql12;";
                string Query4 = "INSERT INTO new_rschema.`ofertas (cabeceras)` (NumOfe,FecOfe) VALUES (" + HiddenField2.Value+ ", '" + dt + "')";

                MySqlConnection sqlConnection4 = new MySqlConnection(MyConnection4);
                MySqlCommand sqlCommand4 = new MySqlCommand(Query4,sqlConnection4);
                MySqlDataReader dataReader4;

              //  sqlCommand4.Parameters.Add("?value", MySqlDbType.Int32).Value = HiddenField2.Value;
              //  sqlCommand4.Parameters.Add("?date", MySqlDbType.VarChar).Value = dt;


                sqlConnection4.Open();
               // dataReader4 = sqlCommand4.ExecuteReader();
                sqlCommand4.ExecuteNonQuery();

                sqlConnection4.Close();
            }
            catch (Exception ex1) {
                Response.Write("try2");
            }
            //carbide table
            try {

                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string order = HiddenField2.Value;
                        Label ArtOrd = row.FindControl("ArtOrd")as Label;
                        Label desc = row.FindControl("desc") as Label;
                        Label total = row.FindControl("total") as Label;
                        Label od = row.FindControl("od") as Label;
                        Label id = row.FindControl("id") as Label;
                        Label length = row.FindControl("length") as Label;


                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=mysql12;";
                        string Query5 = "INSERT INTO new_rschema.`ofertas (líneas)` (NumOfe, NumOrd, CodPie, TotPie, Dimen1, Dimen3, Dimen2) VALUES (@NumOfe,@NumOrd,@CodPie,@TotPie,@Dimen1,@Dimen2,@Dimen3)";
                        MySqlConnection sqlConnection5 = new MySqlConnection(MyConnection5);
                        MySqlCommand mySqlCommand5 = new MySqlCommand(Query5, sqlConnection5);
                        MySqlDataReader dataReader5;
                        sqlConnection5.Open();
                        mySqlCommand5.Parameters.Add("@NumOfe", MySqlDbType.Int32).Value = order;
                        mySqlCommand5.Parameters.Add("@NumOrd", MySqlDbType.Int32).Value = ArtOrd.Text;
                        mySqlCommand5.Parameters.Add("@CodPie", MySqlDbType.VarChar).Value = desc.Text;
                        mySqlCommand5.Parameters.Add("@TotPie", MySqlDbType.Int32).Value = total.Text;
                        mySqlCommand5.Parameters.Add("@Dimen1", MySqlDbType.Decimal).Value = od.Text;
                        mySqlCommand5.Parameters.Add("@Dimen2", MySqlDbType.Decimal).Value = id.Text;
                        mySqlCommand5.Parameters.Add("@Dimen3", MySqlDbType.Decimal).Value = length.Text;
                        mySqlCommand5.ExecuteNonQuery();
                        sqlConnection5.Close();
                       // dataReader5 = mySqlCommand5.ExecuteReader();
                    }
                }
            }
            catch (Exception ex2) {
                Response.Write("try3");
            }
            //article  table
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string order = HiddenField2.Value;
                        

                        Label article = row.FindControl("article") as Label;
                        Label desc = row.FindControl("desc") as Label;
                        Label total = row.FindControl("total") as Label;
                        Label od = row.FindControl("od") as Label;
                        Label id = row.FindControl("id") as Label;
                        Label length = row.FindControl("length") as Label;

                        string MyConnection6 = "datasource=localhost;port=3306;username=root;password=mysql12";
                        string Query6 = "SELECT CodArt,CodPie FROM new_rschema.`artículos de clientes (piezas)` WHERE CodArt = '" + article.Text + "' AND CodPie = '" + desc.Text + "'";
                        MySqlConnection sqlConnection6 = new MySqlConnection(MyConnection6);
                        MySqlCommand sqlCommand6 = new MySqlCommand(Query6, sqlConnection6);
                        MySqlDataReader dataReader6;
                        sqlConnection6.Open();
                       /// sqlCommand6.Parameters.Add("@CodArt", MySqlDbType.Int32);
                        dataReader6 = sqlCommand6.ExecuteReader();

                        if (dataReader6.Read())
                        {
                            string MyConnetion7 = "datasource=localhost;port=3306;username=root;password=mysql12";
                            string Query7 = "UPDATE new_rschema.`artículos de clientes (piezas)` SET CalPie = @CalPie, DiaExt = @DiaExt , Longit = @Longit, DiaInt = @DiaInt WHERE CodArt = '" + article.Text + "' AND CodPie = '" + desc.Text + "'";
                            MySqlConnection sqlConnection7 = new MySqlConnection(MyConnetion7);
                            MySqlCommand sqlCommand7 = new MySqlCommand(Query7, sqlConnection7);
                            MySqlDataReader dataReader7;

                            sqlConnection7.Open();
                            sqlCommand7.Parameters.Add("@CalPie", MySqlDbType.VarChar).Value = TextBox9.Text;
                            sqlCommand7.Parameters.Add("@DiaExt", MySqlDbType.Decimal).Value = od.Text;
                            sqlCommand7.Parameters.Add("@DiaInt", MySqlDbType.Decimal).Value = id.Text;
                            sqlCommand7.Parameters.Add("@Longit", MySqlDbType.Decimal).Value = length.Text;
                            // sqlCommand7.ExecuteNonQuery();
                            dataReader7 = sqlCommand7.ExecuteReader();

                            sqlConnection7.Close();
                        }
                        sqlConnection6.Close();
                    }
                    else {


                        Label article = row.FindControl("article") as Label;
                        Label desc = row.FindControl("desc") as Label;
                        Label total = row.FindControl("total") as Label;
                        Label od = row.FindControl("od") as Label;
                        Label id = row.FindControl("id") as Label;
                        Label length = row.FindControl("length") as Label;

                        string MyConnection8 = "datasource=localhost;port=3306;username=root;password=mysql12;";
                        string Query8 = "INSERT INTO new_rschema.`artículos de clientes (piezas)` (CodArt, CodPie, ModPie, DiaExt, DiaInt, Longit,CtdPie) VALUES (@NumOfe,@NumOrd,@CodPie,@Dimen1,@Dimen2,@Dimen3,@CtdPie)";
                        MySqlConnection sqlConnection8 = new MySqlConnection(MyConnection8);
                        MySqlCommand sqlCommand8 = new MySqlCommand(Query8, sqlConnection8);
                        MySqlDataReader dataReader8;
                        sqlConnection8.Open();
                        sqlCommand8.Parameters.Add("");
                        sqlCommand8.Parameters.Add("@NumOfe", MySqlDbType.VarChar).Value = article.Text;
                        sqlCommand8.Parameters.Add("@NumOrd", MySqlDbType.VarChar).Value = desc.Text;
                        sqlCommand8.Parameters.Add("@CodPie", MySqlDbType.VarChar).Value = total.Text;
                        sqlCommand8.Parameters.Add("@Dimen1", MySqlDbType.Decimal).Value = od.Text;
                        sqlCommand8.Parameters.Add("@Dimen2", MySqlDbType.Decimal).Value = id.Text;
                        sqlCommand8.Parameters.Add("@Dimen3", MySqlDbType.Decimal).Value = length.Text;
                        sqlCommand8.Parameters.Add("@CtdPie", MySqlDbType.Int32).Value = 1;

                        dataReader8 = sqlCommand8.ExecuteReader();
                        sqlConnection8.Close();                                                                     
                    }
                }
            }
            catch (Exception ae) {

            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('successful')", true);
            
            Response.Redirect("printCarbide.aspx");
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (TextBox3.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter A Valid UID !')", true);
            }
            DropDownList1.Items.Clear();
            try
            {
                string MyConnection = "datasource=localhost;port=3306;username=root;password=mysql12;";
                string Query = "select artord,pieord,plaord from new_rschema.`ordenes de fabricación` where numord='" + TextBox3.Text + "';";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();

                if (MyReader2.Read())
                {
                    HiddenField1.Value = MyReader2["artord"].ToString();
                    TextBox1.Text = MyReader2["artord"].ToString().Substring(0, 6);
                    TextBox2.Text = "DIE    " + MyReader2["plaord"].ToString();
                    TextBox6.Text = MyReader2["pieord"].ToString();
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Retrived')", true);
            }
            try
            {
                Response.Write(HiddenField1.Value);
                string MyConnection = "datasource=localhost;port=3306;username=root;password=mysql12;";
                string Query = "SELECT codart,codpie FROM new_rschema.`artículos de clientes (piezas)` where codart='" + HiddenField1.Value + "';";
                MySqlConnection sqlConnection = new MySqlConnection(MyConnection);
                MySqlCommand sqlCommand = new MySqlCommand(Query, sqlConnection);
                MySqlDataReader dataReader;
                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("select");

                int i = 1;
                while(dataReader.Read())
                {
                    if (i==1)
                    {
                        DropDownList1.Items.Clear();
                        ++i;
                        DropDownList1.Items.Add("select");
                    }
                    if (!dataReader["codpie"].ToString().Equals("A") & !dataReader["codpie"].ToString().Equals("A1") & !dataReader["codpie"].ToString().Equals("A2") & !dataReader["codpie"].ToString().Equals("A3") & !dataReader["codpie"].ToString().Equals("A4") & !dataReader["codpie"].ToString().Equals("A5") & !dataReader["codpie"].ToString().Equals("A6"))
                    {
                       // DropDownList1.Items.Clear();
                        DropDownList1.Items.Add(dataReader.GetString("codpie"));

                    }
                 
                    /*string valueAtIndex = DropDownList1.Items[2].Value;
                    if (valueAtIndex == "")
                    */
                    else if (!dataReader["codpie"].ToString().Equals("B") & !dataReader["codpie"].ToString().Equals("B1") & !dataReader["codpie"].ToString().Equals("B2") & !dataReader["codpie"].ToString().Equals("B3") & !dataReader["codpie"].ToString().Equals("B4") & !dataReader["codpie"].ToString().Equals("B5"))
                    {
                        DropDownList1.Items.Clear();
                        DropDownList1.Items.Add("select");
                        DropDownList1.Items.Add("B1");
                        DropDownList1.Items.Add("B2");
                        DropDownList1.Items.Add("B3");
                        DropDownList1.Items.Add("B4");
                        DropDownList1.Items.Add("B5");
                        i--;
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception eq)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Retrived')", true);
            }


            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MyConnection = "datasource=localhost;port=3306;username=root;password=mysql12;";
            string Query2 = "SELECT CtdPie,DiaExt, DiaInt, Longit,ModPie,CalPie FROM new_rschema.`Artículos de clientes (piezas)` WHERE CodArt = '" + HiddenField1.Value + "' and CodPie = '" + DropDownList1.SelectedValue + "';";
            MySqlConnection sqlConnection2 = new MySqlConnection(MyConnection);
            MySqlCommand sqlCommand2 = new MySqlCommand(Query2, sqlConnection2);
            MySqlDataReader dataReader2;
            sqlConnection2.Open();
            dataReader2 = sqlCommand2.ExecuteReader();
            if (dataReader2.Read())
            {

                TextBox5.Text = dataReader2["CtdPie"].ToString();
                TextBox7.Text = Convert.ToString(Convert.ToInt32(TextBox6.Text) * Convert.ToInt32(TextBox5.Text));
                //TextBox8.Text;
                TextBox9.Text = dataReader2["calpie"].ToString();
                TextBox10.Text = dataReader2["modpie"].ToString();
                TextBox11.Text = dataReader2["diaext"].ToString();
                TextBox12.Text = dataReader2["longit"].ToString();
                TextBox13.Text = dataReader2["diaint"].ToString();
            }
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            TextBox7.Text = Convert.ToString(Convert.ToInt32(TextBox6.Text) * Convert.ToInt32(TextBox5.Text));
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["order"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["dt"] = dt;

            GridView1.DataSource = ViewState["order"] as DataTable;
            GridView1.DataBind();

            try
            {
                if (dt.Rows[0][0].ToString() == "")
                {

                }
                
            }
            catch (Exception aa)
            {
                DataTable table = new DataTable();
                DataRow row;
                table.TableName = "order";
                table.Columns.Add(new DataColumn("UID", typeof(string)));
                table.Columns.Add(new DataColumn("Article", typeof(string)));
                table.Columns.Add(new DataColumn("Description", typeof(string)));
                table.Columns.Add(new DataColumn("Qty", typeof(double)));
                table.Columns.Add(new DataColumn("Total", typeof(int)));
                table.Columns.Add(new DataColumn("Quantity", typeof(string)));
                table.Columns.Add(new DataColumn("Order Qty", typeof(int)));
                table.Columns.Add(new DataColumn("Grade", typeof(string)));
                table.Columns.Add(new DataColumn("Model", typeof(string)));
                table.Columns.Add(new DataColumn("OD", typeof(double)));
                table.Columns.Add(new DataColumn("Length", typeof(double)));
                table.Columns.Add(new DataColumn("ID", typeof(double)));

                row = table.NewRow();
                table.Rows.Add(row);

                ViewState["order"] = table;
                GridView1.DataSource = table;
                GridView1.DataBind();

               
            }
        }

       
    }
}