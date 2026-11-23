/****************/
// 202418929
// Hoàng Chí Kiệt
/****************/

using System;
using SmartHomeMini.Devices;
using SmartHomeMini.Interfaces;

namespace SmartHomeMini.Patterns
{
    /// <summary>
    /// Factory tạo các đối tượng thiết bị thông minh theo loại được chỉ định.
    /// </summary>
    public static class DeviceFactory
    {
        /// <summary>
        /// Tạo mới một thiết bị dựa trên chuỗi loại (không phân biệt chữ hoa/thường).
        /// </summary>
        /// <param name="type">Loại thiết bị ("light", "fan", "door").</param>
        /// <param name="name">Tên hiển thị của thiết bị.</param>
        /// <returns>Thể hiện thiết bị thông qua giao diện IDevice.</returns>
        /// <exception cref="ArgumentException">Ném ra khi loại thiết bị rỗng hoặc chưa được hỗ trợ.</exception>
        public static IDevice Create(string type, string name)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Device type cannot be null or empty.", nameof(type));
            }

            return type.Trim().ToLowerInvariant() switch
            {
                "light" => new SmartLight(name),
                "fan" => new SmartFan(name),
                "door" => new SmartDoor(name),
                _ => throw new ArgumentException($"Unsupported device type: {type}", nameof(type))
            };
        }
    }
}