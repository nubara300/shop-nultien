using System.Collections.Generic;

namespace NultienShop.Common.ViewModels
{
    public class ValidationResponse
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public bool IsSuccess { get; set; }
    }
}