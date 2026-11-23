/****************/
// 202418929
// Hoàng Chí Kiệt
/****************/

using System;
using SmartHomeMini.Devices;
using SmartHomeMini.Interfaces;
using SmartHomeMini.Patterns;

namespace SmartHomeMini
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== SMART HOME MINI - DEMO ===");

            // 1. Cấu hình chung qua Singleton
            HomeConfiguration config = HomeConfiguration.Instance;
            config.HomeName = "Smart Home Mini";
            config.NightLightLevel = 30;

            // 2. Tạo thiết bị qua Factory
            IDevice light = DeviceFactory.Create("light", "Living room light");
            IDevice fan = DeviceFactory.Create("FAN", "Living room fan"); // Kiểm tra không phân biệt hoa thường
            IDevice door = DeviceFactory.Create("Door", "Main door");

            // 3. Điều khiển thiết bị riêng lẻ (Facade không thay thế điều khiển trực tiếp)
            light.TurnOn();
            fan.TurnOn();
            ((ILockable)door).Unlock();

            Console.WriteLine();

            // 4. Sử dụng Facade cho các chế độ mức cao
            var facade = new SmartHomeFacade(light, fan, (ILockable)door);
            facade.GoToWork();
            Console.WriteLine();
            facade.GoToSleep();

            Console.WriteLine("\n=== RUNNING AUTOMATED TESTS (T1 - T5) ===");
            RunTests();
        }

        /// <summary>
        /// Thực thi 5 kịch bản kiểm thử bắt buộc (T1 - T5) cho Factory, Singleton và Facade.
        /// </summary>
        private static void RunTests()
        {
            // T1: Tạo light, fan, door -> Factory trả đúng kiểu đối tượng
            IDevice tLight = DeviceFactory.Create("light", "Living room light");
            IDevice tFan = DeviceFactory.Create("fan", "Living room fan");
            IDevice tDoor = DeviceFactory.Create("door", "Main door");

            bool t1Pass = tLight is SmartLight && tFan is SmartFan && tDoor is SmartDoor;
            PrintTestResult("T1", "Factory tao dung kieu SmartLight, SmartFan, SmartDoor", t1Pass);

            // T2: Tạo loại camera chưa hỗ trợ -> Phát sinh ArgumentException
            bool t2Pass = false;
            try
            {
                DeviceFactory.Create("camera", "Gate camera");
            }
            catch (ArgumentException ex)
            {
                t2Pass = ex.Message.Contains("Unsupported device type");
            }
            PrintTestResult("T2", "Factory nem ArgumentException voi loai 'camera'", t2Pass);

            // T3: Lấy HomeConfiguration.Instance hai lần -> cùng tham chiếu một đối tượng
            HomeConfiguration c1 = HomeConfiguration.Instance;
            HomeConfiguration c2 = HomeConfiguration.Instance;
            if (!ReferenceEquals(c1, c2))
            {
                throw new Exception("Singleton implementation is incorrect.");
            }
            PrintTestResult("T3", "HomeConfiguration.Instance tra ve cung mot tham chieu", ReferenceEquals(c1, c2));

            // T4: Gọi GoToWork() -> Đèn tắt, quạt tắt, cửa khóa
            var testDoor = (SmartDoor)tDoor;
            tLight.TurnOn();
            tFan.TurnOn();
            testDoor.Unlock();

            var testFacade = new SmartHomeFacade(tLight, tFan, testDoor);
            testFacade.GoToWork();

            bool t4Pass = !tLight.IsOn && !tFan.IsOn && testDoor.IsLocked;
            PrintTestResult("T4", "GoToWork(): Den tat, quat tat, cua khoa", t4Pass);

            // T5: Gọi GoToSleep() -> Quạt tắt, cửa khóa, đèn bật, áp dụng NightLightLevel
            tFan.TurnOn();
            testDoor.Unlock();
            tLight.TurnOff();
            HomeConfiguration.Instance.NightLightLevel = 25;

            testFacade.GoToSleep();

            bool t5Pass = !tFan.IsOn && testDoor.IsLocked && tLight.IsOn
                          && HomeConfiguration.Instance.NightLightLevel == 25;
            PrintTestResult("T5", "GoToSleep(): Quat tat, cua khoa, den bat, ap dung muc sang ban dem", t5Pass);
        }

        private static void PrintTestResult(string testId, string description, bool passed)
        {
            Console.WriteLine($"[{testId}] {(passed ? "PASS" : "FAIL")} - {description}");
        }
    }
}