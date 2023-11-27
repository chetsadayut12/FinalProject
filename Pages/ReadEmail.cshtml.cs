using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace FinalProject.Pages
{
    public class ReadEmailModel : PageModel
    {
        public string EmailID { get; set; }
        public string EmailSender { get; set; }
        public string EmailSubject { get; set; }
        public string EmailDate { get; set; }
        public string EmailContent { get; set; }

        public void OnGet(string emailid)
        {
            // ดึงข้อมูลอีเมลจากฐานข้อมูลตาม emailid
            // นี่คือตัวอย่างเท่านั้น ควรใช้วิธีการเชื่อมต่อกับฐานข้อมูลของคุณ

            // ให้สร้างเมธอดเพื่อดึงข้อมูลจากฐานข้อมูล
            PopulateEmailData(emailid);
        }

        private void PopulateEmailData(string emailid)
        {
            try
            {
                String connectionString = "Server=tcp:abcdgroup.database.windows.net,1433;Initial Catalog=DBforProjectCS;Persist Security Info=False;User ID=abcd;Password=cs4361234.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String sql = "SELECT * FROM emails WHERE EmailID = @EmailID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@EmailID", emailid);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                EmailID = "" + reader.GetInt32(0);
                                EmailSubject = reader.GetString(1);
                                EmailContent = reader.GetString(2);
                                EmailDate = reader.GetDateTime(3).ToString();
                                EmailSender = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }


}
