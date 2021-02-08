using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using URL_Shortener.Models;

namespace URL_Shortener
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Functions.isValidUrl(url.Value))
            {
                String ShortLink = Functions.AddNewLinkToDB(url.Value);
                String ShortLink2 = Functions.AddNewLinkToDB(url.Value);
                String HostName = Request.Url.Host;
                String domainName = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

                ShortLink = domainName + "/" + ShortLink;
                ShortLink2 = domainName + "/" + ShortLink2;
                data_place.InnerHtml = @"<div class='alert alert-success'><a href='" + ShortLink + "' target='blanc'>" + ShortLink + "</div><div class='alert alert-success'><a href='" + ShortLink2 + "' target='blanc'>" + ShortLink2 + "</div>";
            }
            else
            {
                data_place.InnerHtml = "<div class='alert alert-danger'> Provoni me URL valide! </div>";
            }


        }
    }
}