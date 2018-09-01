using System;
using System.IO;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using FrancoHandling_Lib;


/// <summary>
/// Summary description for QueryString
/// </summary>
public class QueryStringModule : IHttpModule
{

    #region IHttpModule Members

    public void Dispose()
    {
        // Nothing to dispose
    }

    public void Init(HttpApplication context)
    {
        context.BeginRequest += new EventHandler(context_BeginRequest);
    }

    #endregion

    private const string PARAMETER_NAME = "PatLog=";
    private const string ENCRYPTION_KEY = "ptr4n14g4";

    void context_BeginRequest(object sender, EventArgs e)
    {
        HttpContext context = HttpContext.Current;
        if (context.Request.Url.OriginalString.Contains("aspx") && context.Request.RawUrl.Contains("?"))
        {
            string query = ExtractQuery(context.Request.RawUrl);
            string path = GetVirtualPath();

            if (query.StartsWith(PARAMETER_NAME, StringComparison.OrdinalIgnoreCase))
            {
                // Decrypts the query string and rewrites the path.
                string rawQuery = query.Replace(PARAMETER_NAME, string.Empty);
                string decryptedQuery = Encryption.Decrypt(rawQuery);
                context.RewritePath(path, string.Empty, decryptedQuery);
            }
            else if (context.Request.HttpMethod == "GET")
            {
                // Encrypt the query string and redirects to the encrypted URL.
                // Remove if you don't want all query strings to be encrypted automatically.
                string encryptedQuery = Encryption.Encrypt(query);
                context.Response.Redirect(path + encryptedQuery, false);
            }
        }
    }

    /// <summary>
    /// Parses the current URL and extracts the virtual path without query string.
    /// </summary>
    /// <returns>The virtual path of the current URL.</returns>
    private static string GetVirtualPath()
    {
        string path = HttpContext.Current.Request.RawUrl;
        path = path.Substring(0, path.IndexOf("?"));
        path = path.Substring(path.LastIndexOf("/") + 1);
        return path;
    }

    /// <summary>
    /// Parses a URL and returns the query string.
    /// </summary>
    /// <param name="url">The URL to parse.</param>
    /// <returns>The query string without the question mark.</returns>
    private static string ExtractQuery(string url)
    {
        int index = url.IndexOf("?") + 1;
        return url.Substring(index);
    }
    
}
