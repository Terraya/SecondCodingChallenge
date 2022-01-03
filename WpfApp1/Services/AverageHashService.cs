using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WpfApp1.Util;

namespace WpfApp1.Services
{
    public class AverageHashService : IPhotoComparisonService
    {
        public AverageHashService() { }

        public Task<bool> CompareAsync(string filePathImageA, string filePathImageB)
        {
            WriteableBitmap firstImage = FileUtil.SelectImage(filePathImageA, 8 ,8);
            WriteableBitmap secondImage = FileUtil.SelectImage(filePathImageB, 8, 8);

            if(firstImage == null|| secondImage == null)
                return null;

            var firstGrayscaledImage = ImageUtil.ConvertToGrayScale(firstImage);
            var secondGrayscaledImage = ImageUtil.ConvertToGrayScale(secondImage);


            return ImageUtil.CompareSimilarity(firstGrayscaledImage.averagePixel, secondGrayscaledImage.averagePixel);
        }
    }
}
