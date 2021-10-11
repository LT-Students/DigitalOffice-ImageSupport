using LT.DigitalOffice.Kernel.Attributes;
using System.Threading.Tasks;

namespace LT.DigitalOffice.ImageSupport.Helpers.Interfaces
{
  [AutoInject]
  public interface IImageResizeHelper
  {
    Task<(bool isSuccess, string resizedContent, string extension)> Resize(string inputBase64, string extension, int resizeMinValue = 150);
  }
}
