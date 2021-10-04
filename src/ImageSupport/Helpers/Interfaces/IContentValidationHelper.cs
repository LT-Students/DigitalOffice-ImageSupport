using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.ImageSupport.Helpers.Interfaces
{
  [AutoInject]
  public interface IContentValidationHelper
  {
    bool ContentCheck(string content, string extension);
  }
}
