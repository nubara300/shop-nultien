using Microsoft.AspNetCore.Mvc;
using System;

namespace NultienShopTEST.helpers
{
    public static class TestHelper
    {
        public static int GetObjectStatusResult(IActionResult iResult)
        {
            var objectResult = iResult as ObjectResult;
            if (objectResult == null)
            {
                throw new Exception("Can't convert object to ObjectResult");
            }
            return (int)objectResult.StatusCode;
        }
    }
}