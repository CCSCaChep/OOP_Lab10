/****************/
// 202418929
// Hoàng Chí Kiệt
/****************/

using System;

namespace SmartHomeMini.Patterns
{
    /// <summary>
    /// Lớp cấu hình dùng chung duy nhất cho toàn bộ ứng dụng Smart Home (Singleton Pattern).
    /// Sử dụng Lazy&lt;T&gt; để đảm bảo an toàn đa luồng (thread-safe).
    /// </summary>
    public sealed class HomeConfiguration
    {
        private static readonly Lazy<HomeConfiguration> lazy =
            new Lazy<HomeConfiguration>(() => new HomeConfiguration());

        /// <summary>
        /// Lấy thể hiện duy nhất của HomeConfiguration.
        /// </summary>
        public static HomeConfiguration Instance => lazy.Value;

        /// <summary>
        /// Tên của ngôi nhà thông minh.
        /// </summary>
        public string HomeName { get; set; } = "My Home";

        /// <summary>
        /// Mức độ sáng đèn ngủ mặc định (%).
        /// </summary>
        public int NightLightLevel { get; set; } = 30;

        // Constructor private ngăn việc khởi tạo trực tiếp từ bên ngoài.
        private HomeConfiguration()
        {
        }
    }
}