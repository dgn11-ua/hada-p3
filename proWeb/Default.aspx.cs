using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CADCategory aux = new CADCategory();

                ListBox1.DataSource = aux.readAll();
                //ListBox1.DataTextField = "Name";
                ListBox1.DataBind();
            }
        }
    }
}