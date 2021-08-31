using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Controller
{
    class Class1
    {
        [DllImport("user32.dll")]

        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public enum MouseActionAdresses
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            SCROLL = 0x00000800
        }

        public static void LeftClickDown(int x, int y)
    {
        mouse_event((int)(MouseActionAdresses.LEFTDOWN), 0, 0, 0, 0);
    }
        public static void LeftClickUp(int x, int y)
        {
            mouse_event((int)(MouseActionAdresses.LEFTUP), 0, 0, 0, 0);
        }
        public static void RightClickDown(int x, int y)
        {
            mouse_event((int)(MouseActionAdresses.RIGHTDOWN), 0, 0, 0, 0);
        }
        public static void RightClickUp(int x, int y)
        {
            mouse_event((int)(MouseActionAdresses.RIGHTUP), 0, 0, 0, 0);
        }
        public static void Scroll(int x, int y, float value)
        {
            mouse_event((int)(MouseActionAdresses.SCROLL), 0, 0, Convert.ToInt16(value), 0);
        }
    }
}
