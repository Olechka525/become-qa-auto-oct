using System;
using System.Runtime.InteropServices;

namespace Became_QA_Auto.src.config
{
    //Config class is responsible to store framework's and env's configuration.

    /* The following config variables are declared:
     - timeout for request
     - username
     - environment */
    public static class Config_Easy
    {
        public const int request_timeout = 10;
        public static string username = Environment.GetEnvironmentVariable("USERNAME");
        public static string environment = Environment.GetEnvironmentVariable("BQA_ENV");
    }
}
