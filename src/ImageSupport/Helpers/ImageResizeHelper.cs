using ImageSupport.Constants;
using ImageSupport.Helpers.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Svg;
using System;
using Drawing = System.Drawing;
using System.IO;

namespace ImageSupport.Helpers
{
  public class ImageResizeHelper : IImageResizeHelper
  {
    #region private methods

    private (bool isSuccess, string resizedContent, string extension)  SvgResize(string inputBase64, string extension)
    {
      try
      {
        byte[] byteString = Convert.FromBase64String(inputBase64);

        using (var ms = new MemoryStream(byteString))
        {
          SvgDocument svgDocument = SvgDocument.Open<SvgDocument>(ms);
          Drawing.Bitmap image = svgDocument.Draw();

          if (image.Width > 150 || image.Height > 150)
          {
            double maxSize = Math.Max(image.Width, image.Height);

            int ratio = Convert.ToInt32(Math.Ceiling(maxSize / 150));

            Drawing.Bitmap newImage = new Drawing.Bitmap(image.Width / ratio, image.Height / ratio);
            Drawing.Graphics.FromImage(newImage).DrawImage(image, 0, 0, image.Width / ratio, image.Height / ratio);

            Drawing.ImageConverter converter = new Drawing.ImageConverter();

            byteString = (byte[])converter.ConvertTo(newImage, typeof(byte[]));
            extension = ".png";

            return (isSuccess: true,
              resizedContent: Convert.ToBase64String(byteString),
              extension: extension);
          }
          else
          {
            return (isSuccess: true, resizedContent: null, extension: extension);
          }
        }
      }
      catch
      {
        return (isSuccess: false, resizedContent: null, extension: extension);
      }
    }

    private (bool isSuccess, string resizedContent, string extension)  OtherFormatsResize(string inputBase64, string extension)
    {
      try
      {
        byte[] byteString = Convert.FromBase64String(inputBase64);
        Image image = Image.Load(byteString);

        if (image.Width > 150 || image.Height > 150)
        {
          double maxSize = Math.Max(image.Width, image.Height);

          int ratio = Convert.ToInt32(Math.Ceiling(maxSize / 150));

          image.Mutate(x => x.Resize(image.Width / ratio, image.Height / ratio));

          return (isSuccess: true,
            resizedContent: image.ToBase64String(ImageFormats.formatsInstances[extension]).Split(',')[1],
            extension: extension);
        }
        else
        {
          return (isSuccess: true, resizedContent: null, extension: extension);
        }
      }
      catch
      {
        return (isSuccess: false, resizedContent: null, extension: extension);
      }
    }

    #endregion

    public (bool isSuccess, string resizedContent, string extension) Resize(string inputBase64, string extension)
    {
      return extension == ".svg"
        ? SvgResize(inputBase64, extension)
        : OtherFormatsResize(inputBase64, extension);
    }
  }
}
