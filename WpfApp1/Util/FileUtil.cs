using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfApp1.Util
{
    public class FileUtil
    {
        public static readonly string directoryPath = Directory.GetCurrentDirectory() + "/pictures";

        public static void InitializeFolder()
        {
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Initial directory Exists!");
                return;
            }

            Console.WriteLine($"New Directory created at: {directoryPath}");
            Directory.CreateDirectory(directoryPath);
        }

        public static WriteableBitmap SelectImage(string path, int xWidth, int yHeight)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Image with path {path} not found!");
                return null;
            }

            WriteableBitmap bitmap = BitmapFactory.FromResource(directoryPath + path);
            bitmap.Resize(xWidth, yHeight, WriteableBitmapExtensions.Interpolation.Bilinear);
            return bitmap;
        }

        public static string GetPathFromFile(string fileName)
        {
            return $"{directoryPath}/{fileName}";
        }
    }
}
