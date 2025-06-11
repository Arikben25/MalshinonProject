using System;
using System.Deployment.Internal;
using Google.Protobuf.WellKnownTypes;

internal class Reports
{

    internal void maneger_report()
    {
        string rep = enter_reports();
        string[] massege_splited = Split_the_message(rep);
        string[] message_correct = Checks_message_content(massege_splited);
    }
    internal string enter_reports()
    {
        Console.WriteLine("Please enter the report in the following format:\r\nFull name of terrorist * Body of report");
        string report = Console.ReadLine();
        string chari = "*";
        bool contains = report.Contains(chari);
        if (contains == false)
        {
            Console.WriteLine("The message is invalid");
            enter_reports();
        }
        return report;
        
    }

    internal string[] Split_the_message(string report)
    {
        string[] report_split = report.Split('*');
        return report_split;
    }

    internal string[] Checks_message_content(string[] massage)
    {
        foreach (string word in massage)
        {
            
            if(word == "") 
            {
                Console.WriteLine("The message is invalid");
                enter_reports();
            }
        }
        return massage;
    }










    internal void check_terorrist() { }

    internal void create_new_terorrist() { }



    
}