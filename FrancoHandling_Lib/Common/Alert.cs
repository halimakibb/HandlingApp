using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace FrancoHandling_Lib
{
    public class Alert
    {        
        public const string SUCCESS = "success";
        public const string ERROR = "error";
        public const string INFO = "info";
        public const string WARNING = "warning";


        public void MessageString(string AlertType, string Message, Control page, object theObject)
        {
            string Title = string.Empty;
            switch (AlertType)
            {
                case "success":
                    Title = "Success";
                    break;
                case "error":
                    Title = "Error";
                    break;
                case "warning":
                    Title = "Warning";
                    break;
                default:
                    Title = "Info";
                    break;
            }

            string _Message = Message.Replace("'", "\"");
            ScriptManager.RegisterStartupScript(page.Page, theObject.GetType(), "text", "Alert('" + AlertType + "', '" + Title + "', '" + _Message + "')", true);
        }
        public void MessageString(string AlertType, string Title, string Message, Control page, object theObject)
        {
            string _Message = Message.Replace("'", "\"");
            _Message = Message.Replace(Environment.NewLine, "<br>");

            ScriptManager.RegisterStartupScript(page.Page, theObject.GetType(), "text", string.Format("Alert('{0}', '{1}', '{2}')", AlertType, Title, _Message), true);
        }


        //public string ListStringJson(List<string> args_list)
        //{
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    string myJSON = jss.Serialize(args_list);
        //    myJSON = myJSON.Replace("\"", "'");
        //    return myJSON;
        //}
        //public string ListString(List<string> args_list)
        //{
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    string myJSON = jss.Serialize(args_list);
        //    myJSON = myJSON.Replace("\"", "");
        //    myJSON = myJSON.Replace("[", "");
        //    myJSON = myJSON.Replace("]", "");
        //    myJSON = myJSON.Replace(",", "~");
        //    return myJSON;
        //}
        //public string ListIntJson(List<int> args_list)
        //{
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    string myJSON = jss.Serialize(args_list);
        //    myJSON = myJSON.Replace("\"", "'");
        //    return myJSON;
        //}
        //public string ListFloatJson(List<int> args_list)
        //{
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    string myJSON = jss.Serialize(args_list);
        //    myJSON = myJSON.Replace("\"", "'");
        //    return myJSON;
        //}
        ////seng only a string
        //public void MessageString(Control page, object theObject, string arg_theMessage,string arg_msgType)
        //{
        //    List<string> oneString = new List<string>();
        //    oneString.Add(arg_theMessage);
        //    string theMessage = ListStringJson(oneString);
        //    string startScript = DefineMsgType(arg_msgType);
        //    ScriptManager.RegisterStartupScript(page.Page, theObject.GetType(), "tmp", startScript + theMessage + Alert.END_PARAMETER, false);
        //}

        //public void MessageList(Control page, object theObject, List<string> arg_listOfString, string arg_msgType)
        //{
        //    string startScript = DefineMsgType(arg_msgType);
        //    string theMessage = ListStringJson(arg_listOfString);
        //    ScriptManager.RegisterStartupScript(page.Page, theObject.GetType(), "tmp", startScript + theMessage + Alert.END_PARAMETER, false);
        //}
        
        //public void MessageList(Control page, object theObject)
        //{
        //    MessageList(page, theObject, this._MessageList, this._MessageType);
        //}

        //public void MessageJson(Control page, object theObject, string arg_theMessage, string arg_msgType)
        //{
        //    string startScript = DefineMsgType(arg_msgType);
        //    ScriptManager.RegisterStartupScript(page.Page, theObject.GetType(), "tmp", startScript + arg_theMessage + Alert.END_PARAMETER, false);
        //}

        //public void CloseMessage(Control page, object theObject)
        //{
        //    ScriptManager.RegisterStartupScript(page.Page, theObject.GetType(), "tmp", Alert.CLOSE_MESSAGE, false);
        //}

    }
}
