using System;

internal class Agent
{
    internal string enter_password()
    {
        Console.WriteLine("please enter your password ");
        string password = Console.ReadLine();

        return password;
    }

    internal void check_user()
    {
        Dal user = new Dal();
        bool results = user.chack_code_agent();
        if (results)
        {
            // הוספת קוד אם משתמש קיים במערכת
        }
        else
        {
            create_user();
        }

    }

    internal void create_user()
    {
        Dal user = new Dal();
        user.create_agent();
    }

}