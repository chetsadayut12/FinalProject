using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

public class DeleteEmailModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int EmailID { get; set; }

    public IActionResult OnGet()
    {
        // Fetch email details and pass it to the view
        // Example: Model = emailService.GetEmailById(EmailID);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            // Your database connection string
            string connectionString = "Server=tcp:abcdgroup.database.windows.net,1433;Initial Catalog=DBforProjectCS;Persist Security Info=False;User ID=abcd;Password=cs4361234.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // SQL query to delete email by ID
                string sql = "DELETE FROM Emails WHERE EmailID = @emailid";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@emailid", EmailID);

                    // Execute the query
                    await command.ExecuteNonQueryAsync();
                }
            }

            // Redirect to the index page after successful deletion
            return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., log, display error message)
            return Page();
        }
    }
}
