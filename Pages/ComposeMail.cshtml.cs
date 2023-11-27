using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class ComposeMailModel : PageModel
    {
        [BindProperty]
        public string Recipient { get; set; }

        [BindProperty]
        public string Subject { get; set; }

        [BindProperty]
        public string Body { get; set; }

        public IActionResult OnPost()
        {
            // ตรวจสอบว่าข้อมูลถูกต้องและไม่ว่างเปล่า
            if (ModelState.IsValid)
            {
                // ดำเนินการส่งอีเมล หรือทำอย่างอื่นตามที่คุณต้องการ
                // ในที่นี้คือตัวอย่างที่ไม่ทำอะไรเลย
                // หรือคุณสามารถเรียกบริการส่งอีเมลหรือปฏิบัติการอื่น ๆ ได้ตามที่คุณต้องการ

                // สามารถใส่โค้ดส่งอีเมลหรือกระทำอื่น ๆ ที่ต้องการทำที่นี่
                // ตัวอย่าง: ส่งอีเมล

                // คืนไปยังหน้า "Compose New Email" หลังจากที่ดำเนินการเสร็จสิ้น
                return RedirectToPage("/ComposeMail");
            }

            // ถ้า ModelState ไม่ถูกต้อง กลับไปที่หน้า "Compose New Email" เพื่อแสดงข้อผิดพลาด
            return Page();
        }
    }
}
