using System.Threading.Tasks;

namespace WpfApp1.Services
{
    /// <summary>
    /// Compares two image files for similarity and decides whether they are equal.
    /// </summary>
    public interface IPhotoComparisonService
    {
        Task<bool> CompareAsync(string filePathImageA, string filePathImageB);
    }
}
