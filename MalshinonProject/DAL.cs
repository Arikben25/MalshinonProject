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
            string query = "SELECT `secretCode` FROM `reporters`;";
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
    // הפונקציה יוצרת משתמש חדש
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
            string query = $"INSERT INTO reporters(`reporterName`,`secretCode`)VALUES(@fullName, @password);";
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


    // פונקציה הבודקת אם טרוריסט קיים במערכת

    internal bool check_name_terorrist(string[] check_name)
    {

        bool my_bool = false;
        try
        {
            conn.Open();
            string query = "SELECT `terorristName` FROM `terorrists`;";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString("secretCode");
                if (name == check_name[0]) { my_bool = true; }

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
    //---------------------------------------------------------------------------------

    //פונקציה שיוצרת טרורוסט חדש

    internal void create_new_terorrist(string name)
    {
        try
        {
            
            conn.Open();
            string query = $"INSERT INTO terorrists(`terorristName`)VALUES(@name);";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();

            Console.WriteLine("added terorrist");
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

// ---------------------------------------------------------------------
    



}