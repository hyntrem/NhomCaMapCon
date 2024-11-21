using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace SellKoiWeb.Pages
{
    public class CheckoutModel : PageModel
    {
        // Thuộc tính để bind dữ liệu từ form
        [BindProperty]
        public string FishId { get; set; }

        [BindProperty]
        public string BuyerName { get; set; }

        [BindProperty]
        public string BuyerEmail { get; set; }

        [BindProperty]
        public string Address { get; set; }

        // Biến để lưu thông báo thành công
        public string SuccessMessage { get; set; }

        // Dữ liệu mẫu cho danh sách cá Koi (có thể thay thế bằng dữ liệu thực tế từ cơ sở dữ liệu)
        public List<dynamic> KoiFishList { get; set; }

        // Biến để lưu thông tin cá được chọn
        public dynamic SelectedFish { get; set; }

        public void OnGet()
        {
            // Dữ liệu mẫu danh sách cá Koi
            KoiFishList = new List<dynamic>
            {
                new { Id = "001", Name = "Cá 001", Price = "5,000,000 VND", Rating = "9/10", Image = "/images/images (2).jpg" },
                new { Id = "002", Name = "Cá 002", Price = "5,250,000 VND", Rating = "9.5/10", Image = "/images/koi3.jpg" },
                new { Id = "003", Name = "Cá 003", Price = "5,500,000 VND", Rating = "9.5/10", Image = "/images/Untitled.jpg" },
                new { Id = "004", Name = "Cá 004", Price = "5,750,000 VND", Rating = "9/10", Image = "/images/koi3.jpg" },
                new { Id = "005", Name = "Cá 005", Price = "6,000,000 VND", Rating = "8.5/10", Image = "/images/koi5.jpg" },
                new { Id = "006", Name = "Cá 006", Price = "6,250,000 VND", Rating = "9/10", Image = "/images/images (1).jpg" },
                new { Id = "007", Name = "Cá 007", Price = "6,500,000 VND", Rating = "9.5/10", Image = "/images/images (2).jpg" },
                new { Id = "008", Name = "Cá 008", Price = "6,800,000 VND", Rating = "9/10", Image = "/images/images (3).jpg" },
                new { Id = "009", Name = "Cá 009", Price = "7,000,000 VND", Rating = "9.5/10", Image = "/images/koi3.jpg" },
                new { Id = "010", Name = "Cá 010", Price = "7,500,000 VND", Rating = "9.8/10", Image = "/images/images.jpg" }
            };

            // Lấy fish_id từ query string để tìm thông tin cá được chọn
            string fishId = Request.Query["fish_id"];
            SelectedFish = KoiFishList.FirstOrDefault(fish => fish.Id == fishId);
        }

        // Xử lý khi người dùng gửi form thanh toán
        public IActionResult OnPost()
        {
            // Kiểm tra các trường thông tin nhập vào
            if (string.IsNullOrEmpty(FishId) || string.IsNullOrEmpty(BuyerName) || string.IsNullOrEmpty(BuyerEmail) || string.IsNullOrEmpty(Address))
            {
                TempData["ErrorMessage"] = "Vui lòng Điền thông tin!";
                return RedirectToPage(); // Trả lại trang Checkout nếu có lỗi
            }

            // Xử lý logic thanh toán hoặc lưu thông tin vào cơ sở dữ liệu (nếu có)
            TempData["SuccessMessage"] = "Đặt hàng thành công!"; // Lưu thông báo thành công vào TempData
            return RedirectToPage("Success"); // Chuyển hướng tới trang thành công
        }
    }
}
