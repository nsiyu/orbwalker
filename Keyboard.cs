using System.Runtime.InteropServices;
using WindowsInput;
class Keyboard
{
    public static bool IsKeyPressed(System.Windows.Forms.Keys keys)
    {
        return 0 != (NativeImport.GetAsyncKeyState((int)keys) & 0x8000);
    }
    public static void a_Click()
    {
        InputSimulator sim = new InputSimulator();
        sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_A);
    }

    public static void v_Click()
    {
        InputSimulator sim = new InputSimulator();
        sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_V);
    }

    public static void targetChampionsKeyDown()
    {
        InputSimulator sim = new InputSimulator();
        sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.OEM_3);
    }
    public static void targetChampionsKeyUp()
    {
        InputSimulator sim = new InputSimulator();
        sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.OEM_3);
    }

}