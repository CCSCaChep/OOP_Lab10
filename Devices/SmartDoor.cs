/****************/
// 202418929
// Hoàng Chí Kiệt
/****************/

using System;
using SmartHomeMini.Interfaces;

namespace SmartHomeMini.Devices
{
    /// <summary>
    /// Thiết bị cửa thông minh hỗ trợ bật/tắt nguồn và khóa/mở khóa.
    /// </summary>
    public class SmartDoor : IDevice, ILockable
    {
        public string Name { get; }
        public bool IsOn { get; private set; }
        public bool IsLocked { get; private set; }

        /// <summary>
        /// Khởi tạo cửa thông minh với tên riêng.
        /// </summary>
        /// <param name="name">Tên của cửa.</param>
        public SmartDoor(string name)
        {
            Name = name;
            IsOn = false;
            IsLocked = false;
        }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name}: ON");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name}: OFF");
        }

        public void Lock()
        {
            IsLocked = true;
            Console.WriteLine($"{Name}: LOCKED");
        }

        public void Unlock()
        {
            IsLocked = false;
            Console.WriteLine($"{Name}: UNLOCKED");
        }
    }
}