using Became_QA_Auto.src.config;
using System;
using System.Collections.Generic;

namespace Became_QA_Auto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Results from class Config_Easy
            SeeResultsConfigEasyClass();

            //Results from class Config_Harder
            Config_Harder config = Config_Harder.GetInstance();
            Console.WriteLine("Config_harder:");

            Console.WriteLine($"USERNAME: {config.Get("USERNAME")}");
            Console.WriteLine($"BQA_ENV: {config.Get("BQA_ENV")}");
            Console.WriteLine($"PARAMETER_JSON: {config.Get("PARAMETER_JSON")}");
            Console.ReadKey();
        }
        public static void SeeResultsConfigEasyClass()
        {
            Console.WriteLine($"Easy_TimeOut: {Config_Easy.request_timeout}");
            Console.WriteLine($"Easy_Environment: {Config_Easy.environment}");
            Console.WriteLine($"Easy_Username: {Config_Easy.username}");
        }
    }
}
