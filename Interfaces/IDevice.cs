/****************/
// 202418929
// Hoàng Chí Kiệt
/****************/

namespace SmartHomeMini.Interfaces
{
    /// <summary>
    /// Giao diện chung cho tất cả các thiết bị thông minh có thể bật và tắt.
    /// </summary>
    public interface IDevice
    {
        /// <summary>
        /// Tên định danh của thiết bị.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Trạng thái nguồn hiện tại của thiết bị (true = đang bật, false = đang tắt).
        /// </summary>
        bool IsOn { get; }

        /// <summary>
        /// Bật thiết bị.
        /// </summary>
        void TurnOn();

        /// <summary>
        /// Tắt thiết bị.
        /// </summary>
        void TurnOff();
    }
}