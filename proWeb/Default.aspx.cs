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

        protected void create_click(object sender, EventArgs e)
        {
            if (TextBox_code.Text == "" || TextBox_name.Text == "" || TextBox_amount.Text == "")
            {
                message.Text = "Error! Please, fill the gaps before!";
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
                    message.Text = "ERROR --> The product does not exists";
                }

            }
        }

        protected void update_click(object sender, EventArgs e)
        {

        }
    }
}