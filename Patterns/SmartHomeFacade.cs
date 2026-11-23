/****************/
// 202418929
// Hoàng Chí Kiệt
/****************/

using System;
using SmartHomeMini.Interfaces;

namespace SmartHomeMini.Patterns
{
    /// <summary>
    /// Facade cung cấp các thao tác ngữ cảnh mức cao để điều khiển đồng thời nhiều thiết bị.
    /// </summary>
    public sealed class SmartHomeFacade
    {
        private readonly IDevice light;
        private readonly IDevice fan;
        private readonly ILockable door;

        /// <summary>
        /// Khởi tạo SmartHomeFacade với các thiết bị phụ thuộc thông qua abstraction.
        /// </summary>
        public SmartHomeFacade(IDevice light, IDevice fan, ILockable door)
        {
            this.light = light ?? throw new ArgumentNullException(nameof(light));
            this.fan = fan ?? throw new ArgumentNullException(nameof(fan));
            this.door = door ?? throw new ArgumentNullException(nameof(door));
        }

        /// <summary>
        /// Kích hoạt chế độ Đi làm: tắt đèn, tắt quạt và khóa cửa.
        /// </summary>
        public void GoToWork()
        {
            Console.WriteLine($"[{HomeConfiguration.Instance.HomeName}] Activating 'Go To Work' mode...");
            light.TurnOff();
            fan.TurnOff();
            door.Lock();
        }

        /// <summary>
        /// Kích hoạt chế độ Đi ngủ: tắt quạt, khóa cửa, bật đèn ngủ và áp dụng mức sáng từ cấu hình chung.
        /// </summary>
        public void GoToSleep()
        {
            Console.WriteLine($"[{HomeConfiguration.Instance.HomeName}] Activating 'Go To Sleep' mode...");
            fan.TurnOff();
            door.Lock();
            light.TurnOn();

            int level = HomeConfiguration.Instance.NightLightLevel;
            Console.WriteLine($"Night light level: {level}%");
        }
    }
}