using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace URL_Shortener.Models
{
    public class Functions
    {
        //Merr URL origjinal
        public static String GetOriginUrl(String ShortLink)
        {
            var param = new Dictionary<string, object>() { { "@ShortLink", ShortLink } };
            DataSet ds = new dbconfig().querySelect("SELECT * FROM links WHERE ShortLink=@ShortLink", param);
            return ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["OriginUrl"].ToString() : null;
        }

        //Shto linkun ne databaze
        public static String AddNewLinkToDB(String url)
        {
            String ShortLink = generateShortLink();
            var param = new Dictionary<string, object>() { { "@OriginUrl", url }, { "@ShortLink", ShortLink } };
            new dbconfig().queryUpdate("INSERT INTO links (OriginUrl,ShortLink) VALUES (@OriginUrl,@ShortLink)", param);
            return ShortLink;
        }

        //gjeneron nje string random te madhesise (length = 5) dhe verifikon se a egziston ne databaze
        public static String generateShortLink()
        {
            String ShortLink = RandomString(5);
            while (GetOriginUrl(ShortLink) != null)
            {
                ShortLink = RandomString(5);
            }
            return ShortLink;
        }

        //gjeneron string random me madhesi specifike
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //kontrollon nese stringu eshte URL valide
        public static bool isValidUrl(String uriName)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }
    }
}