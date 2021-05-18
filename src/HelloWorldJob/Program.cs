using System;

namespace HelloWorldJob
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine($"Hello World Job running in {env}!");
        }
    }
}
