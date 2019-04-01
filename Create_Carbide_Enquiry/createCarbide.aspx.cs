using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Create_Carbide_Enquiry
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField3.Value = Session["companyID"] as String;

            Label14.Text = HiddenField3.Value;
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


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.ToString() == "--select--")
            {
                DropDownList1.BackColor = Color.Red;
            }
            if (IsPostBack)
            {/*
                if (TextBox5.Text == "" & TextBox6.Text == "" & TextBox7.Text == "" & TextBox8.Text == "" & TextBox9.Text == "" & TextBox10.Text == "" & TextBox11.Text == "" & TextBox12.Text == "" & TextBox13.Text == "")
                {
            */
                if (TextBox5.Text == "")
                {
                    TextBox5.BackColor = Color.Red;
                }
                else { TextBox5.BackColor = Color.Transparent; }
                if (TextBox6.Text == "")
                {
                    TextBox6.BackColor = Color.Red;
                }
                else { TextBox6.BackColor = Color.Transparent; }
                if (TextBox7.Text == "")
                {
                    TextBox7.BackColor = Color.Red;
                }
                else { TextBox7.BackColor = Color.Transparent; }

                if (TextBox8.Text == "")
                {
                    TextBox8.BackColor = Color.Red;
                }
                else { TextBox8.BackColor = Color.Transparent; }
                if (TextBox9.Text == "")
                {
                    TextBox9.BackColor = Color.Red;
                }
                else { TextBox9.BackColor = Color.Transparent; }
                if (TextBox10.Text == "")
                {
                    TextBox10.BackColor = Color.Red;
                }
                else { TextBox10.BackColor = Color.Transparent; }
                if (TextBox11.Text == "")
                {
                    TextBox11.BackColor = Color.Red;
                }
                else { TextBox11.BackColor = Color.Transparent; }
                if (TextBox12.Text == "")
                {
                    TextBox12.BackColor = Color.Red;
                }
                else { TextBox12.BackColor = Color.Transparent; }
                if (TextBox13.Text == "")
                {
                    TextBox13.BackColor = Color.Red;
                }
                else { TextBox13.BackColor = Color.Transparent; }

            }
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

        protected void Button2_Click(object sender, EventArgs e)//submit
        {
            //Order No

            try
            {
                string MyConnection3 = "datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
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
                sqlConnection3.Close();
            }
            catch (Exception ex)
            {
                Response.Write("try1");
            }
            //Order Details
            try
            {
                DateTime TodayDate = DateTime.Today;
                string dt = TodayDate.ToString("yyyy-MM-dd");
                string MyConnection4 = "datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
                string Query4 = "INSERT INTO `ofertas (cabeceras)` (NumOfe,FecOfe) VALUES (" + HiddenField2.Value + ", '" + dt + "')";

                MySqlConnection sqlConnection4 = new MySqlConnection(MyConnection4);
                MySqlCommand sqlCommand4 = new MySqlCommand(Query4, sqlConnection4);
                MySqlDataReader dataReader4;

                sqlConnection4.Open();
                sqlCommand4.ExecuteNonQuery();

                sqlConnection4.Close();
            }
            catch (Exception ex1)
            {
                Response.Write("try2");
            }
            //carbide table
            try
            {

                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string order = HiddenField2.Value;
                        Label ArtOrd = row.FindControl("ArtOrd") as Label;
                        Label desc = row.FindControl("desc") as Label;
                        Label total = row.FindControl("total") as Label;
                        Label od = row.FindControl("od") as Label;
                        Label id = row.FindControl("id") as Label;
                        Label length = row.FindControl("length") as Label;

                        string MyConnection5 = "datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
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
                    }
                }
            }
            catch (Exception ex2)
            {
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

                        string MyConnection6 = "datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
                        string Query6 = "SELECT CodArt,CodPie FROM new_rschema.`artículos de clientes (piezas)` WHERE CodArt = '" + article.Text + "' AND CodPie = '" + desc.Text + "'";
                        MySqlConnection sqlConnection6 = new MySqlConnection(MyConnection6);
                        MySqlCommand sqlCommand6 = new MySqlCommand(Query6, sqlConnection6);
                        MySqlDataReader dataReader6;
                        sqlConnection6.Open();
                        dataReader6 = sqlCommand6.ExecuteReader();

                        if (dataReader6.Read())
                        {
                            string MyConnetion7 = "datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
                            string Query7 = "UPDATE new_rschema.`artículos de clientes (piezas)` SET CalPie = @CalPie, DiaExt = @DiaExt , Longit = @Longit, DiaInt = @DiaInt WHERE CodArt = '" + article.Text + "' AND CodPie = '" + desc.Text + "'";
                            MySqlConnection sqlConnection7 = new MySqlConnection(MyConnetion7);
                            MySqlCommand sqlCommand7 = new MySqlCommand(Query7, sqlConnection7);
                            MySqlDataReader dataReader7;

                            sqlConnection7.Open();
                            sqlCommand7.Parameters.Add("@CalPie", MySqlDbType.VarChar).Value = TextBox9.Text;
                            sqlCommand7.Parameters.Add("@DiaExt", MySqlDbType.Decimal).Value = od.Text;
                            sqlCommand7.Parameters.Add("@DiaInt", MySqlDbType.Decimal).Value = id.Text;
                            sqlCommand7.Parameters.Add("@Longit", MySqlDbType.Decimal).Value = length.Text;
                            dataReader7 = sqlCommand7.ExecuteReader();

                            sqlConnection7.Close();
                        }
                        else
                        {
                            article = row.FindControl("article") as Label;
                            desc = row.FindControl("desc") as Label;
                            total = row.FindControl("total") as Label;
                            od = row.FindControl("od") as Label;
                            id = row.FindControl("id") as Label;
                            length = row.FindControl("length") as Label;

                            string MyConnection8 = "datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
                            string Query8 = "INSERT INTO new_rschema.`artículos de clientes (piezas)` (CodArt, CodPie, CalPie, ModPie, DiaExt, DiaInt, Longit,CtdPie) VALUES (@NumOfe,@NumOrd,@CalPie,@CodPie,@Dimen1,@Dimen2,@Dimen3,@CtdPie)";
                            MySqlConnection sqlConnection8 = new MySqlConnection(MyConnection8);
                            MySqlCommand sqlCommand8 = new MySqlCommand(Query8, sqlConnection8);
                            MySqlDataReader dataReader8;
                            sqlConnection8.Open();
                            //sqlCommand8.Parameters.Add("");
                            sqlCommand8.Parameters.Add("@NumOfe", MySqlDbType.VarChar).Value = article.Text;
                            sqlCommand8.Parameters.Add("@NumOrd", MySqlDbType.VarChar).Value = desc.Text;
                            sqlCommand8.Parameters.Add("@CalPie", MySqlDbType.VarChar).Value = TextBox9.Text;
                            sqlCommand8.Parameters.Add("@CodPie", MySqlDbType.VarChar).Value = total.Text;
                            sqlCommand8.Parameters.Add("@Dimen1", MySqlDbType.Decimal).Value = od.Text;
                            sqlCommand8.Parameters.Add("@Dimen2", MySqlDbType.Decimal).Value = id.Text;
                            sqlCommand8.Parameters.Add("@Dimen3", MySqlDbType.Decimal).Value = length.Text;
                            sqlCommand8.Parameters.Add("@CtdPie", MySqlDbType.Int32).Value = 1;

                            dataReader8 = sqlCommand8.ExecuteReader();
                            sqlConnection8.Close();
                        }
                        sqlConnection6.Close();                    
                    }
                }
            }
            catch (Exception ae)
            {

            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('successful')", true);

            Response.Redirect("printCarbide.aspx");
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

            if (TextBox3.Text == "")
                TextBox3.BackColor = Color.Red;
            else
                TextBox3.BackColor = Color.Transparent;

            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";

            DropDownList1.Items.Clear();
            try
            {
                string MyConnection = "datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
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
                string MyConnection = "datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
                string Query = "SELECT codart,codpie FROM new_rschema.`artículos de clientes (piezas)` where codart='" + HiddenField1.Value + "';";
                MySqlConnection sqlConnection = new MySqlConnection(MyConnection);
                MySqlCommand sqlCommand = new MySqlCommand(Query, sqlConnection);
                MySqlDataReader dataReader;
                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("--select--");
                int i = 1;
                while (dataReader.Read())
                {
                    if (i == 1)
                    {
                        ++i;
                    }

                    if (!dataReader["codpie"].ToString().Equals("A") & !dataReader["codpie"].ToString().Equals("A1") & !dataReader["codpie"].ToString().Equals("A2") & !dataReader["codpie"].ToString().Equals("A3") & !dataReader["codpie"].ToString().Equals("A4") & !dataReader["codpie"].ToString().Equals("A5") & !dataReader["codpie"].ToString().Equals("A6"))
                    {
                        DropDownList1.Items.Add(dataReader.GetString("codpie"));
                    }
                }

                if (DropDownList1.Items.Count == 1)
                {
                    TextBox5.Text = "";
                    TextBox6.Text = "1";
                    TextBox7.Text = "1";
                    TextBox8.Text = "";
                    TextBox9.Text = "";
                    TextBox10.Text = "";
                    TextBox11.Text = "";
                    TextBox12.Text = "";
                    TextBox13.Text = "";
                    DropDownList1.Items.Add("B1");
                    DropDownList1.Items.Add("B2");
                    DropDownList1.Items.Add("B3");
                    DropDownList1.Items.Add("B4");
                    DropDownList1.Items.Add("B5");
                    i--;
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

            try
            {
                string MyConnection = "datasource=localhost;port=3306;username=root;password=mysql12;Database=new_rschema;";
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
                    TextBox9.Text = dataReader2["calpie"].ToString();
                    TextBox10.Text = dataReader2["modpie"].ToString();
                    TextBox11.Text = dataReader2["diaext"].ToString();
                    TextBox12.Text = dataReader2["longit"].ToString();
                    TextBox13.Text = dataReader2["diaint"].ToString();
                }
                else
                {
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    TextBox8.Text = "";
                    TextBox9.Text = "";
                    TextBox10.Text = "";
                    TextBox11.Text = "";
                    TextBox12.Text = "";
                    TextBox13.Text = "";
                }
                // }
                if (DropDownList1.SelectedItem.ToString() != "--select--")
                {
                    DropDownList1.BackColor = Color.Transparent;
                }
            }
            catch (Exception kk)
            {

            }
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

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (TextBox5.Text == "")
                TextBox5.BackColor = Color.Red;
            else
                TextBox5.BackColor = Color.Transparent;


        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (TextBox6.Text != "")
            {
                TextBox6.BackColor = Color.Transparent;
            }
            TextBox7_TextChanged(sender, e);
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
            if (TextBox7.Text != "")
            {
                TextBox7.BackColor = Color.Transparent;
            }
            else
            {
                TextBox7.Text = Convert.ToString(Convert.ToInt32(TextBox6.Text) * Convert.ToInt32(TextBox5.Text));
                TextBox7.BackColor = Color.Transparent;
            }
        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (TextBox8.Text != "")
            {
                TextBox8.BackColor = Color.Transparent;
            }
        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {
            if (TextBox9.Text != "")
            {
                TextBox9.BackColor = Color.Transparent;
            }
        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (TextBox10.Text != "")
            {
                TextBox10.BackColor = Color.Transparent;
            }
        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {
            if (TextBox11.Text != "")
            {
                TextBox11.BackColor = Color.Transparent;
            }
        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {
            if (TextBox12.Text != "")
            {
                TextBox12.BackColor = Color.Transparent;
            }
        }

        protected void TextBox13_TextChanged(object sender, EventArgs e)
        {
            if (TextBox13.Text != "")
            {
                TextBox13.BackColor = Color.Transparent;
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sBooks = null;
            sBooks = TextBox4.Text.Trim();

            // CHECK IF TEXTBOX HAS ANY VALUE BEFORE ADDING.    

            if (!string.IsNullOrEmpty(sBooks.Trim()))
            {
                // IN-ADDITION, CHECK IF THE ENTERED VALUE (BOOK) ALREADY EXISTS IN THE LIST,
                // TO AVOID DUPLICATE ENTRIES.   
                if ((DropDownList1.Items.FindByText(sBooks) == null))
                {
                    DropDownList1.Items.Add(new ListItem(sBooks, sBooks));

                    TextBox4.Text = "";

                    int iBooksCount = DropDownList1.Items.Count - 1;
                    //lblMessage.Text = "A new book added to the list. <br />" +
                    //    "Now you have <b>" + iBooksCount + "</b> item(s) in the list.";
                }
                else
                {
                    //lblMessage.Text = "Item <b>" + sBooks.Trim() +
                    //   "</b> already exists in the list. <br />" + "Add another book.";
                }

                TextBox4.Text = "";
                TextBox4.Focus();
            }
        }
    }
}