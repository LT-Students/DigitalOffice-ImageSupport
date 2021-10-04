using ImageSupport.Constants;
using ImageSupport.Helpers.Interfaces;
using SixLabors.ImageSharp;
using Svg;
using System;
using System.IO;
using Drawing = System.Drawing;

namespace ImageSupport.Helpers
{
  public class ContentValidationHelper : IContentValidationHelper
  {
    #region private methods
    private bool SvgResizeCheck(string content)
    {
      try
      {
        byte[] byteString = Convert.FromBase64String(content);

        using (var ms = new MemoryStream(byteString))
        {
          SvgDocument svgDocument = SvgDocument.Open<SvgDocument>(ms);
          Drawing.Bitmap image = svgDocument.Draw();
        }

        return true;
      }
      catch
      {
        return false;
      }
    }

    private bool OtherFormatsResizeCheck(string content)
    {
      try
      {
        byte[] byteString = Convert.FromBase64String(content);
        Image image = Image.Load(byteString);

        return true;
      }
      catch
      {
        return false;
      }
    }
    #endregion

    public bool ContentCheck(string content, string extension)
    {
      if (extension == ".svg")
      {
        return SvgResizeCheck(content);
      }
      else
      {
        return ImageFormats.formats.Contains(extension)
          ? OtherFormatsResizeCheck(content)
          : false;
      }
    }
  }
}
