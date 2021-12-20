using System;

namespace NultienShop.Common.ViewModels.Helpers
{
    public class CustomException : Exception
    {
        public CustomException(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
