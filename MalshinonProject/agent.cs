using System;

internal class Agent
{
    // מכניס שם וסיסמה של משתמש
    internal string[] enter_password_and_name()
    {

        Console.WriteLine("please enter your name ");
        string name = Console.ReadLine();
        Console.WriteLine("please enter your password ");
        string password = Console.ReadLine();
        string[] name_and_password = { name, password };

        return name_and_password;
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

    //---------------------------------------
    // מחזיר שם וסיסמה חדשים של משתמש
    internal string[] enter_new_name_and_password()
    {
        Console.WriteLine("plise enter your name ");
        // צריך לבדוק את הקלט
        string fullName = Console.ReadLine();
        Console.WriteLine("plise enter new password ");
        string password = Console.ReadLine();
        string[] new_name_and_pass = { fullName, password };

        return new_name_and_pass;
    }

    internal void create_user()
    {
        string[] new_name_pass = enter_new_name_and_password();
        Dal user = new Dal();
        user.create_agent(new_name_pass[0], new_name_pass[1]);
    }

    // פונקציה שמדפיסה סוכנים פוטנציאלים
    internal void print_potential_agent() 
    {
        Dal type_agent = new Dal();
        type_agent.potential_agent();
    }
       
    // פונקציה שמדפיסה רשימת טרוריסטים מסוכנים

    internal void print_potential_terorrist()
    {
        Dal terorrist = new Dal();
        terorrist.potential_terorrist();
    }
}