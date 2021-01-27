using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    /// <summary>
    /// For testing 
    /// </summary>
    public static class ProductUrl
    {
        public static string ReturnProductPictureUrl(this string source)
        {
            return "https://localhost:5001/" + source;
        }
    }
}
