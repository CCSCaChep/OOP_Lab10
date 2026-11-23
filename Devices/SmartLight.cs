/****************/
// 202418929
// Hoàng Chí Kiệt
/****************/

using System;
using SmartHomeMini.Interfaces;

namespace SmartHomeMini.Devices
{
    /// <summary>
    /// Thiết bị đèn thông minh.
    /// </summary>
    public class SmartLight : IDevice
    {
        public string Name { get; }
        public bool IsOn { get; private set; }

        /// <summary>
        /// Khởi tạo đèn thông minh với tên riêng.
        /// </summary>
        /// <param name="name">Tên của đèn.</param>
        public SmartLight(string name)
        {
            Name = name;
            IsOn = false;
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
    }
}