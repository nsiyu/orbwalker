using System.Drawing.Imaging;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Windows;

class Render
{
    private static int ScreenWidth = 2560;
    private static int ScreenHeight = 1440;

    Bitmap bmpScreenshot;
    Graphics gfxScreenshot;

    public Render()
    {
        this.bmpScreenshot = new Bitmap(ScreenWidth, ScreenHeight, PixelFormat.Format32bppArgb);

        // Create a graphics object from the bitmap.
        this.gfxScreenshot = Graphics.FromImage(this.bmpScreenshot);

        // Take the screenshot from the upper left corner to the right bottom corner.
        gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                Screen.PrimaryScreen.Bounds.Y,
                                0,
                                0,
                                new Size(ScreenWidth, ScreenHeight),
                                CopyPixelOperation.SourceCopy);
    }
    public List<Coordinate> PixelSearch()
    {
        List<Coordinate> champions = new List<Coordinate>();

        for (int x = 0; x < this.bmpScreenshot.Width; x += 5)
        {
            for (int y = 0; y < this.bmpScreenshot.Height; y += 5)
            {
                Color pixelColor = this.bmpScreenshot.GetPixel(x, y);
                int Blue = pixelColor.B;
                int Green = pixelColor.G;
                int Red = pixelColor.R;

                if (Red <= 53 + 1 && Red >= 53 - 1&& Green <= 3 + 1 && Green >= 3 - 1 && Blue <= 0 + 1 && Blue >= 0 - 1)
                {
                    champions.Add(new Coordinate(x, y));
                    y += 15;
                    x += 15;
                }

            }
        }
        bmpScreenshot.Dispose();

        return champions;
    }

}