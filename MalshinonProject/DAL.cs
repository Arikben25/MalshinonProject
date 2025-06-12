using System;
using System.Xml.Linq;
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
        string[] name_code = s.enter_password_and_name();
        string name = name_code[0];
        string code = name_code[1];
        bool my_bool = false;
        try
        {
            conn.Open();
            string query = "SELECT `secretCode`,`reporterName` FROM `reporters`;";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string secretCode = reader.GetString("secretCode");
                string reporterName = reader.GetString("reporterName");
                if (secretCode == code && reporterName == name ) { my_bool = true; }

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
    internal void create_agent(string fullName, string password)
    {
        

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

    // פונקציה המכניסה הודעה לטבלה ומעדכנת את שאר הטבלאות

    internal void enter_report_to_table(string reportText, int length,string reporterName, string terroristName)
    {

        try
        {
            conn.Open();
            string query = @"INSERT INTO intelligence(`reportText`,`textLength`,`reporterName`,`terroristName`) VALUES(@reportText,@textLength,@reporterName,@terroristName);";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@reportText", reportText);
            cmd.Parameters.AddWithValue("@textLength", length);
            cmd.Parameters.AddWithValue("@reporterName", reporterName);
            cmd.Parameters.AddWithValue("@terroristName", terroristName);
            cmd.ExecuteNonQuery();
            // עדכון שתי הטבלאות האחרות
            Update_message_count(terroristName);
            Update_report_count(reporterName);


            Console.WriteLine("The intelligence table has been updated.");
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
    //--------------------------------------------------------------------------------------------------

    // פונקציה שמעלה ערך 1 בטרוריסט

    internal void Update_message_count(string terorrist_name)
    {
        try
        {

            conn.Open();
            string query = $"UPDATE terrorists SET num_mentions = IFNULL(num_mentions, 0) + 1 WHERE terroristName = @terroristName;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@terroristName", terorrist_name);
            cmd.ExecuteNonQuery();

            Console.WriteLine("add 1 of terorrist");
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

    //פונקציה שמעלה ערך אחד בסוכן 
    internal void Update_report_count(string agent_name)
    {
        try
        {
            conn.Open();
            string query = "UPDATE reporters SET num_reports = IFNULL(num_reports, 0) + 1 WHERE reporterName = @reporterName;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@reporterName", agent_name);
            cmd.ExecuteNonQuery();

            Console.WriteLine("add 1 to reporter");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"err: {ex.Message}");
        }
        finally
        {
            conn.Close();
        }
    }


}