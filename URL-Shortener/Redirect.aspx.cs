using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using URL_Shortener.Models;

namespace URL_Shortener
{
    public partial class Redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    String ShortLink = "";
                    ShortLink = Page.RouteData.Values["ShortLink"] as String;
                    String originUrl = Functions.GetOriginUrl(ShortLink);
                    if (originUrl != null)
                    {
                        result_area.InnerHtml = @"<h4>Linku juaj eshte gati.</h4> 
                                              <a class='btn btn-primary' href='" + originUrl + "'> Hap faqen </a>";
                    }
                    else
                    {
                        result_area.InnerHtml = @"<h4> Faqja nuk u gjet! </h4>";
                    }
                }
                catch (Exception)
                {

                    Response.Redirect("~/");
                }
            }
        }
    }
}