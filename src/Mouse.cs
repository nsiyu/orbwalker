using System.Runtime.InteropServices;

public class Mouse
{
    //Mouse actions
    private const int SCREEN_WIDTH = 2560;
    private const int SCREEN_HEIGHT = 1440;
    private const double PIXELS_PER_UNIT_LEAGUE = 480.0 / 525;

    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;

    public Mouse()
    { }

    public void HoverCenter()
    {
        int w = Screen.PrimaryScreen.Bounds.Width;
        int h = Screen.PrimaryScreen.Bounds.Height;

        int X = (SCREEN_WIDTH)/2;
        int Y = (SCREEN_HEIGHT)/2;

        double new_X = (((double)X / SCREEN_WIDTH) * (double)w);
        double new_Y = (((double)Y / SCREEN_HEIGHT) * (double)h);

        double attack_range = 525;
        NativeImport.SetCursorPos((int)(new_X), (int)(new_Y + attack_range * PIXELS_PER_UNIT_LEAGUE));
    }


    public void LeftClick()
    {
        uint X = (uint)Cursor.Position.X;
        uint Y = (uint)Cursor.Position.Y;
        NativeImport.mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
        NativeImport.mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
    }

    public void LeftClick(uint X, uint Y)
    {
        int w = Screen.PrimaryScreen.Bounds.Width;
        int h = Screen.PrimaryScreen.Bounds.Height;

        uint old_X = (uint)Cursor.Position.X;
        uint old_Y = (uint)Cursor.Position.Y;

        double new_X = (((double)X / SCREEN_WIDTH) * (double) w);
        double new_Y = (((double)Y / SCREEN_HEIGHT) * (double) h);

        NativeImport.SetCursorPos((int)new_X, (int)new_Y);
        NativeImport.SetCursorPos((int)new_X, (int)new_Y);

        Thread.Sleep(5);
        Keyboard.a_Click();
        Keyboard.a_Click();
        Thread.Sleep(5);

        NativeImport.SetCursorPos((int)old_X, (int)old_Y);
        NativeImport.SetCursorPos((int)old_X, (int)old_Y);
    }

    public void RightClick(uint X, uint Y)
    {
        NativeImport.mouse_event(MOUSEEVENTF_RIGHTDOWN, X, Y, 0, 0);
        NativeImport.mouse_event(MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
    }

    public void RightClick()
    {
        uint X = (uint)Cursor.Position.X;
        uint Y = (uint)Cursor.Position.Y;
        NativeImport.mouse_event(MOUSEEVENTF_RIGHTDOWN, X, Y, 0, 0);
        NativeImport.mouse_event(MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);

    }
}