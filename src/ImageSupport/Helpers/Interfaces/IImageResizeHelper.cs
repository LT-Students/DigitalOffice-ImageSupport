using LT.DigitalOffice.Kernel.Attributes;

namespace ImageSupport.Helpers.Interfaces
{
  [AutoInject]
  public interface IImageResizeHelper
  {
    (bool isSuccess, string resizedContent, string extension) Resize(string inputBase64, string extension);
  }
}
