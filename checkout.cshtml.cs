using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace SellKoiWeb.Pages
{
    public class CheckoutModel : PageModel
    {
        // ??c t? thu?c tính ?? bind d? li?u t? form
        [BindProperty]
        public string FishId { get; set; }

        [BindProperty]
        public string BuyerName { get; set; }

        [BindProperty]
        public string BuyerEmail { get; set; }

        [BindProperty]
        public string Address { get; set; }

        // Bi?n ?? l?u thông báo thành công
        public string SuccessMessage { get; set; }

        // D? li?u m?u cho danh sách cá Koi (có th? thay th? b?ng d? li?u th?c t? t? c? s? d? li?u)
        public List<dynamic> KoiFishList { get; set; }

        // Bi?n ?? l?u thông tin cá ???c ch?n
        public dynamic SelectedFish { get; set; }

        public void OnGet()
        {
            // D? li?u m?u danh sách cá Koi
            KoiFishList = new List<dynamic>
            {
                new { Id = "001", Name = "Cá 001", Price = "5,000,000 VND", Rating = "9/10", Image = "/images/images (2).jpg" },
                new { Id = "002", Name = "Cá 002", Price = "5,250,000 VND", Rating = "9.5/10", Image = "/images/koi3.jpg" },
                new { Id = "003", Name = "Cá 003", Price = "5,500,000 VND", Rating = "9.5/10", Image = "/images/Untitled.jpg" },
                new { Id = "004", Name = "Cá 004", Price = "5,750,000 VND", Rating = "9/10", Image = "/images/koi3.jpg" },
                new { Id = "005", Name = "Cá 005", Price = "6,000,000 VND", Rating = "8.5/10", Image = "/images/koi5.jpg" },
                new { Id = "020", Name = "Cá 020", Price = "10,000,000 VND", Rating = "10/10", Image = "/images/koi2.jpg" }
            };

            // L?y fish_id t? query string ?? tìm thông tin cá ???c ch?n
            string fishId = Request.Query["fish_id"];
            SelectedFish = KoiFishList.FirstOrDefault(fish => fish.Id == fishId);
        }

        // X? lý khi ng??i dùng g?i form thanh toán
        public IActionResult OnPost()
        {
            // Ki?m tra các tr??ng thông tin nh?p vào
            if (string.IsNullOrEmpty(FishId) || string.IsNullOrEmpty(BuyerName) || string.IsNullOrEmpty(BuyerEmail) || string.IsNullOrEmpty(Address))
            {
                TempData["ErrorMessage"] = "Vui lòng ?i?n ??y ?? thông tin!";
                return RedirectToPage(); // Tr? l?i trang Checkout n?u có l?i
            }

            // X? lý logic thanh toán ho?c l?u thông tin vào c? s? d? li?u (n?u có)
            TempData["SuccessMessage"] = "??t hàng thành công!"; // L?u thông báo thành công vào TempData
            return RedirectToPage("Success"); // Chuy?n h??ng t?i trang thành công
            
            return RedirectToPage("/");
        }
    }
}
