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
        Dal dal = new Dal();
        bool name_terorrist = dal.check_name_terorrist(message_correct);
        if (!name_terorrist) { dal.create_new_terorrist(message_correct[0]);}

        int length = length_massege(message_correct[1]);
        // מכניס את תוכן ופרטי ההודעה
        Agent agent = new Agent();
        string[] name_pass = agent.enter_password_and_name();
        string nameAegnt = name_pass[0];
        dal.enter_report_to_table(message_correct[1], length, message_correct[0], name_pass[0]);
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
    





    internal int length_massege(string massege)
    {
        int lenght = massege.Length;
        Console.WriteLine(lenght);
        return lenght;
    }


    
}