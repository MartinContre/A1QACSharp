using System.Runtime.InteropServices;

namespace Userinyerface.Utilis
{
    public partial class ClipboardPaste
    {
        const int KEYEVENTF_KEYDOWN = 0x0000;
        const int KEYEVENTF_KEYUP = 0x0002;
        const int VK_CONTROL = 0x11;
        const int VK_V = 0x56;
        const int VK_ENTER = 0x0D;

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);

        public static void PasteAndHitEnter(int delayTime)
        {
            // Simulate Ctrl+V
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, IntPtr.Zero);
            keybd_event(VK_V, 0, KEYEVENTF_KEYDOWN, IntPtr.Zero);
            keybd_event(VK_V, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, IntPtr.Zero);

            // Wait time before simulate Enter
            Thread.Sleep(delayTime);

            // Simulate enter
            keybd_event(VK_ENTER, 0, KEYEVENTF_KEYDOWN, IntPtr.Zero);
            keybd_event(VK_ENTER, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        }
    }
}
