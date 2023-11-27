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
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            string connectionString = "Server=tcp:abcdgroup.database.windows.net,1433;Initial Catalog=DBforProjectCS;Persist Security Info=False;User ID=abcd;Password=cs4361234.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string sql = "DELETE FROM Emails WHERE EmailID = @emailid";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@emailid", EmailID);

                    await command.ExecuteNonQueryAsync();
                }
            }

            return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            return Page();
        }
    }
}
