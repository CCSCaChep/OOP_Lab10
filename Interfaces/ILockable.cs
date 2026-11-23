/****************/
// 202418929
// Hoàng Chí Kiệt
/****************/

namespace SmartHomeMini.Interfaces
{
    /// <summary>
    /// Giao diện riêng cho các thiết bị có khả năng khóa và mở khóa.
    /// </summary>
    public interface ILockable
    {
        /// <summary>
        /// Trạng thái khóa hiện tại (true = đã khóa, false = đã mở khóa).
        /// </summary>
        bool IsLocked { get; }

        /// <summary>
        /// Khóa thiết bị.
        /// </summary>
        void Lock();

        /// <summary>
        /// Mở khóa thiết bị.
        /// </summary>
        void Unlock();
    }
}