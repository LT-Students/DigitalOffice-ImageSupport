using LT.DigitalOffice.Kernel.Attributes;

namespace ImageSupport.Helpers.Interfaces
{
  [AutoInject]
  public interface IContentValidationHelper
  {
    bool ContentCheck(string content, string extension);
  }
}
