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

    internal bool chack_code_agent()
    {
        Agent s = new Agent();
        string code = s.check_agent();
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
}