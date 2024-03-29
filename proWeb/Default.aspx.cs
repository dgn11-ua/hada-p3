using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CADCategory aux = new CADCategory();

            }
        }

        protected void read_click(object sender, EventArgs e)
        {
            if (TextBox_code.Text == "" || TextBox_name.Text == "" || TextBox_amount.Text == "")
            {
                message.Text = "ERROR --> Please, fill the gaps before!";
            }
            else
            {
                ENProduct en = new ENProduct();
                en.SetName = TextBox_name.Text;

                if (en.Read())
                {
                    TextBox_code.Text = en.SetCode ;
                    TextBox_name.Text = en.SetName ;
                    TextBox_amount.Text = en.SetAmount.ToString();
                    TextBox_price.Text = en.SetPrice.ToString();
                    TextBox_date.Text = en.SetDate.ToString();
                }
                else
                {
                    message.Text = "ERROR --> The product does not exist";
                }

            }
        }

        protected void read_first_click(object sender, EventArgs e)
        {
            ENProduct en = new ENProduct();

            if (en.ReadFirst())
            {
                TextBox_code.Text = en.SetCode;
                TextBox_name.Text = en.SetName;
                TextBox_amount.Text = en.SetAmount.ToString();
                TextBox_price.Text = en.SetPrice.ToString();
                TextBox_date.Text = en.SetDate.ToString();
                message.Text = " First product read succesfully!";

            }
            else
            {
                message.Text = "ERROR --> There are not any products!";
            }
        }

        protected void read_prev_click(object sender, EventArgs e)
        {
            if (TextBox_code.Text == "" )
            {
                message.Text = "ERROR --> Please, fill the gaps!";
            }
            else
            {
                ENProduct en = new ENProduct();
                en.SetName = TextBox_name.Text;

                if (en.ReadPrev())
                {
                    TextBox_code.Text = en.SetCode;
                    TextBox_name.Text = en.SetName;
                    TextBox_amount.Text = en.SetAmount.ToString();
                    TextBox_price.Text = en.SetPrice.ToString();
                    TextBox_date.Text = en.SetDate.ToString();
                    message.Text = " Previous product read succesfully!";

                }
                else
                {
                    TextBox_code.Text = en.SetCode;
                    TextBox_name.Text = en.SetName;
                    TextBox_amount.Text = en.SetAmount.ToString();
                    TextBox_price.Text = en.SetPrice.ToString();
                    TextBox_date.Text = en.SetDate.ToString();
                    message.Text = "ERROR --> The previous product does not exist";
                }

            }
        }

        protected void read_next_click(object sender, EventArgs e)
        {
            if (TextBox_code.Text == "")
            {
                message.Text = "Error! Please, fill the gaps!";
            }
            else
            {
                ENProduct en = new ENProduct();
                en.SetName = TextBox_name.Text;

                if (en.ReadNext())
                {
                    TextBox_code.Text = en.SetCode;
                    TextBox_name.Text = en.SetName;
                    TextBox_amount.Text = en.SetAmount.ToString();
                    TextBox_price.Text = en.SetPrice.ToString();
                    TextBox_date.Text = en.SetDate.ToString();
                    message.Text = " Next product read succesfully!";

                }
                else
                {
                    TextBox_code.Text = en.SetCode;
                    TextBox_name.Text = en.SetName;
                    TextBox_amount.Text = en.SetAmount.ToString();
                    TextBox_price.Text = en.SetPrice.ToString();
                    TextBox_date.Text = en.SetDate.ToString();
                    message.Text = "ERROR --> The next product does not exist";
                }

            }
        }


        protected void create_click(object sender, EventArgs e)
        {

            if (TextBox_code.Text == "" || TextBox_name.Text == "" || TextBox_amount.Text == "")
            {
                message.Text = "ERROR --> Please, fill the gaps before!";
            }
            else
            {
                ENProduct en = new ENProduct(TextBox_code.Text.ToString(), TextBox_name.Text.ToString(), int.Parse(TextBox_amount.Text.ToString()), float.Parse(TextBox_price.Text.ToString()), DateTime.Parse(TextBox_date.Text.ToString()));
                message.Text = "Created succesfully!";
                if (!en.Create())
                {
                    message.Text = "ERROR --> The product already exists! ";

                }

            }
        }

        protected void update_click(object sender, EventArgs e)
        {

            if (TextBox_code.Text == "" || TextBox_name.Text == "" || TextBox_amount.Text == "")
            {
                message.Text = "ERROR --> Please, fill the gaps before!";
            }
            else
            {
                ENProduct en = new ENProduct();
                en.SetCode = TextBox_code.Text;
                en.SetName = TextBox_name.Text;
                en.SetAmount = int.Parse(TextBox_amount.Text);
                en.SetPrice = float.Parse(TextBox_price.Text);
                en.SetDate = DateTime.Parse(TextBox_date.Text);

                if (en.Update())
                {
                    message.Text = "Product already updated!";
                }
                else
                {
                    message.Text = "ERROR --> The urser is not updated!";
                }
            }
        }

        protected void delete_click(object sender, EventArgs e)
        {

            if (TextBox_code.Text == "" || TextBox_name.Text == "" || TextBox_amount.Text == "")
            {
                message.Text = "ERROR --> Please, fill the gaps before!";
            }
            else
            {
                ENProduct en = new ENProduct(TextBox_code.Text.ToString(), TextBox_name.Text.ToString(), int.Parse(TextBox_amount.Text.ToString()), float.Parse(TextBox_price.Text.ToString()), DateTime.Parse(TextBox_date.Text.ToString()));
                if (en.Delete())
                {
                    message.Text = "Product deleted! ";

                }
                else
                {
                    message.Text = "ERROR --> The product has not been deleted ! ";

                }

            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}