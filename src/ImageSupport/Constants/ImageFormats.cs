using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Tga;
using System.Collections.Generic;

namespace ImageSupport.Constants
{
  public static class ImageFormats
  {
    public static readonly Dictionary<string, IImageFormat> formatsInstances = new()
    {
      { ".jpg", JpegFormat.Instance },
      { ".jpeg", JpegFormat.Instance },
      { ".png", PngFormat.Instance },
      { ".bmp", BmpFormat.Instance },
      { ".gif", GifFormat.Instance },
      { ".tga", TgaFormat.Instance }
    };

    public static readonly List<string> formats = new()
    { ".jpg", ".jpeg", ".png", ".bmp", ".gif", "tga", ".svg" };
  }
}
