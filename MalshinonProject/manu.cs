using System;

internal class Menu
{
    Agent agent = new Agent();
    Dal dal = new Dal();
    Reports reports = new Reports();

    internal void print_menu()
    {
        bool my_bool = true;
        while (my_bool)
        {
            Console.WriteLine(" To insert a new report, press 1. \r\n For the list of potential agents, press 2. \r\n For the list of dangerous terrorists press 3.\r\n To exit press 4.");
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    if (dal.chack_code_agent())
                    {
                        reports.maneger_report();
                    }
                    else { agent.create_user();
                            reports.maneger_report();
                    }

                    break;
                case "2":
                    agent.print_potential_agent();
                    break;
                case "3":
                    agent.print_potential_terorrist();

                    break;
                case "4":
                    my_bool = false;
                    break;
            }

        }
    }
}