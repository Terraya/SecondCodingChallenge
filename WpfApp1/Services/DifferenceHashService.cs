using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WpfApp1.Util;

namespace WpfApp1.Services
{
    public class DifferenceHashService : IPhotoComparisonService
    {
        public DifferenceHashService() { }
        public Task<bool> CompareAsync(string filePathImageA, string filePathImageB)
        {
            WriteableBitmap firstImage = FileUtil.SelectImage(filePathImageA, 9, 8);
            WriteableBitmap secondImage = FileUtil.SelectImage(filePathImageB, 9, 8);

            if (firstImage == null || secondImage == null)
                return null;

            var firstGrayscaledImage = ImageUtil.ConvertToGrayScale(firstImage);
            var secondGrayscaledImage = ImageUtil.ConvertToGrayScale(secondImage);

            return ImageUtil.CompareSimilarityByDifferenceHash(firstGrayscaledImage.averagePixel, secondGrayscaledImage.averagePixel);
        }
    }
}
