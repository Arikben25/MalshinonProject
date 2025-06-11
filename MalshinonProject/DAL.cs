using System;
using MySql.Data.MySqlClient;

internal class Dal 
{
    private string connStr = "server=localhost;username=root;password=;database=malshinonproject";
    private MySqlConnection conn;

    internal Dal()
    {
        conn = new MySqlConnection(connStr);
    }

    // הפונקציה מחזירה ערך בוליאני האם המשתמש קיים כבר או לא
    internal bool chack_code_agent()
    {
        Agent s = new Agent();
        string code = s.enter_password();
        bool my_bool = false;
        try
        {
            conn.Open();
            string query = "SELECT `secretCode` FROM `reporter`;";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string secretCode = reader.GetString("secretCode");
                if (secretCode == code) { my_bool = true; }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"err: {ex}");
        }
        finally
        {
            conn.Close();
        }
        return my_bool;
    }
//--------------------------------------------------------

    internal void create_agent()
    {
        Console.WriteLine("plise enter your name ");
        // צריך לבדוק את הקלט
        string fullName = Console.ReadLine();
        Console.WriteLine("plise enter new password ");
        string password = Console.ReadLine();

        try
        {
            conn.Open();
            string query = $"INSERT INTO reporter(`reporterName`,`secretCode`)VALUES(@fullName, @password);";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@fullName", fullName);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();

            Console.WriteLine("added user");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"err: {ex}");
        }
        finally
        {
            conn.Close();
        }
       
    }
//--------------------------------------------------------

    
}