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
        
        public static void SaveSuccessLog<T>(this ApiResultDTO<T> model, string methodName,string? content)
        {
            model.Success = true;
            Log.Information($"method_name:{methodName}, LogType: {(int)LogType.Success}, date_time: {DateTime.Now:yyyy-mm-dd}, content: {content}");
        }

        public static void SaveErrorLog<T>(this ApiResultDTO<T> model, Exception ex, string methodName)
        {
            model.Success = false;
            model.Error = "Error Occured!";
            string errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.ToString();
            Log.Information($"method_name:{methodName}, LogType: {(int)LogType.Error}, date_time: {DateTime.Now:yyyy-mm-dd}, " +
                $"content: {errorMessage}");
        }
    }
}
