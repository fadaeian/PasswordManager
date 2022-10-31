using PasswordManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static PasswordManager.Service.Helper.Enums;
using Serilog;

namespace PasswordManager.Service.Helper
{
    

    //because of generic variable  it cant be implemented with interface 
    public static class SeriLogHelper
    {

        public static void SaveSuccessLog<T>(this ApiResultDTO<T> model, string methodName, string? content)
        {
            model.Success = true;
            Log.Information(string.Format("method_name:{0}," +
                "LogType:{1},date_time:{2},content:{3}", methodName, (int)LogType.Success,DateTime.Now, content));
        }

        public static void SaveFailLog<T>(this ApiResultDTO<T> model, string methodName, string? shownError)
        {
            model.Success = false;
            model.Error = shownError;
            Log.Information(string.Format("method_name:{0}," +
                "LogType:{1},date_time:{2},content:{3}", methodName, (int)LogType.Success, DateTime.Now, shownError));
        }

        public static void SaveErrorLog<T>(this ApiResultDTO<T> model, Exception ex, string methodName)
        {
            model.Success = false;
            model.Error = "Something goes wrong";
            string exError = ex.InnerException == null ? ex.Message : ex.InnerException.ToString();
            Log.Information(string.Format("method_name:{0}," +
                "LogType:{1},date_time:{2},content:{3}", methodName, (int)LogType.Success, DateTime.Now, exError));
        }
    }
}
