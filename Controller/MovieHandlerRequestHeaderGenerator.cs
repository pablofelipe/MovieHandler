
using System.Collections.Generic;

namespace MovieHandler.Controller
{
    public sealed class MovieHandlerRequestHeaderGenerator
    {
        public static Dictionary<string, string> Generate()
        {
            Dictionary<string, string> requestHeader = new Dictionary<string, string>
            {
                ["Content-Type"] = "application/json;charset=utf-8",
                ["Accept"] = "application/json",
            };

            return requestHeader;
        }
    }
}
