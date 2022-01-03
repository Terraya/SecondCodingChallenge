using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp1.Util
{
    public class ImageUtil
    {
        public struct GrayScaleComparison
        {
            public WriteableBitmap bitmap;
            public List<int> averagePixel;

            public GrayScaleComparison(WriteableBitmap bitmap, List<int> averagePixel)
            {
                this.bitmap = bitmap;
                this.averagePixel = averagePixel;
            }
        }

        public static GrayScaleComparison ConvertToGrayScale(WriteableBitmap wb)
        {
            List<int> pixelHash = new List<int>();

            for (int h = 0; h < wb.PixelHeight; h++)
            {
                for (int i = 0; i < wb.PixelWidth; i++)
                {
                    int pixel = wb.GetPixeli(i, h);

                    int red = (pixel & 0x00FF0000) >> 16;
                    int blue = (pixel & 0x0000FF00) >> 8;
                    int green = (pixel & 0x000000FF);

                    int average = (byte)((red + blue + green) / 3);
                    pixelHash.Add(average);

                    // Check if its the right place to convert pixels to grayscale
                    wb.SetPixeli(pixel, ((int)(pixel & 0xFF000000) | average << 16 | average << 8 | average));
                }
            }

            return new GrayScaleComparison(wb, pixelHash);
        }

        /// <summary>
        /// Compares the grayscale pixels, taking from each row, the first 8 pixels, compared to their neightbour to the right
        /// </summary>
        /// <returns></returns>
        public static Task<bool> CompareSimilarityByDifferenceHash(List<int> averageColImageA, List<int> averageColImageB)
        {
            int certain = 0;

            for (int i = 0; i < averageColImageA.Count; i++)
            {
                certain = averageColImageA[i] == averageColImageB[i + 1]
                 ? certain + 1
                 : certain - 1;
            }

            return Task.FromResult(certain > 0);
        }

        public static Task<bool> CompareSimilarity(List<int> averageColImageA, List<int> averageColImageB)
        {
            int certain = 0;

            for (int i = 0; i < averageColImageA.Count; i++)
            {
                certain = averageColImageA[i] == averageColImageB[i]
                    ? certain + 1
                    : certain - 1;
            }

            return Task.FromResult(certain > 0);
        }
    }
}
