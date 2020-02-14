using System;

namespace SuperSimpleParser
{
    class Program
    {
        static void Test(string commanLine)
        {
            CommandLineParser parser = CommandLineParser.Parse(commanLine);
            parser.Dump();
            Console.WriteLine("---");
        }
        static void Main(string[] args)
        {
            // Ignore argument with no switch
            Test(Environment.CommandLine);
            // If you want to get module name add a switch
            Test("-program " + Environment.CommandLine);
            // You can use " ou ' for string, -zip will produce "true", same switch used more than one = get a list
            Test("-t john@acme.com -f webmaster@acme.com -o \"Test mail\" -b body.txt -j report1.pdf -j report2.pdf -zip");
            // You can read from a file that contain \r \n
            Test(System.IO.File.ReadAllText("TextFile1.txt"));

            CommandLineParser parser = CommandLineParser.Parse("-angle 180 -type deg");
            Console.WriteLine(parser.GetInt32("angle") + 10);
            Console.WriteLine(parser.GetString("type"));
        }
    }
}
