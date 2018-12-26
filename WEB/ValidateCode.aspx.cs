using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;

namespace WEB
{
	public partial class ValidateCode : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GenerateCaptchaImage(110, 40, GenerateCaptchaCode());
		}

		private const string Letters = "2346789ABCDEFGHJKLMNPRTUVWXYZ";

		private static string GenerateCaptchaCode()
		{
			var rand = new Random();
			var maxRand = Letters.Length - 1;
			var sb = new StringBuilder();
			for (var i = 0; i < 4; i++)
			{
				var index = rand.Next(maxRand);
				sb.Append(Letters[index]);
			}

			HttpContext.Current.Session["VerificationCode"] = sb.ToString();
			return sb.ToString();
		}

		private static void GenerateCaptchaImage(int width, int height, string captchaCode)
		{
			using (var baseMap = new Bitmap(width, height))
			using (var graph = Graphics.FromImage(baseMap))
			{
				var rand = new Random();
				graph.Clear(GetRandomLightColor());
				DrawCaptchaCode();
				DrawDisorderLine();
				var random = new Random();
				for (var i = 0; i < 400; i++)
				{
					var x = random.Next(width);
					var y = random.Next(height);
					baseMap.SetPixel(x, y, Color.FromArgb(random.Next()));
				}
				using (var ms = new MemoryStream())
				{
					//图片格式指定为png
					baseMap.Save(ms, ImageFormat.Png);
					//清除缓冲区流中的所有输出
					HttpContext.Current.Response.ClearContent();
					//输出流的HTTP MIME类型设置为"image/Png"
					HttpContext.Current.Response.ContentType = "image/Jpeg";
					//输出图片的二进制流
					HttpContext.Current.Response.BinaryWrite(ms.ToArray());
				}

				int GetFontSize(int imageWidth, int captchCodeCount)
				{
					var averageSize = imageWidth / captchCodeCount;

					return Convert.ToInt32(averageSize);
				}

				Color GetRandomDeepColor()
				{
					int redlow = 160, greenLow = 100, blueLow = 160;
					return Color.FromArgb(rand.Next(redlow), rand.Next(greenLow), rand.Next(blueLow));
				}

				Color GetRandomLightColor()
				{
					int low = 180, high = 255;

					var nRend = rand.Next(high) % (high - low) + low;
					var nGreen = rand.Next(high) % (high - low) + low;
					var nBlue = rand.Next(high) % (high - low) + low;
					return Color.FromArgb(nRend, nGreen, nBlue);
				}

				void DrawCaptchaCode()
				{
					var fontBrush = new SolidBrush(Color.Black);
					var fontSize = GetFontSize(width, captchaCode.Length);
					var font = new Font(FontFamily.GenericSerif, fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
					for (var i = 0; i < captchaCode.Length; i++)
					{
						fontBrush.Color = GetRandomDeepColor();
						var shiftPx = fontSize / 6;
						float x = i * fontSize + rand.Next(-shiftPx, shiftPx) + rand.Next(-shiftPx, shiftPx);
						var maxY = height - fontSize;
						if (maxY < 0) maxY = 0;
						float y = rand.Next(0, maxY);

						graph.DrawString(captchaCode[i].ToString(), font, fontBrush, x, y);
					}
				}

				void DrawDisorderLine()
				{
					var linePen = new Pen(new SolidBrush(Color.Black), 1);
					for (var i = 0; i < rand.Next(3, 5); i++)
					{
						linePen.Color = GetRandomDeepColor();

						var startPoint = new Point(rand.Next(0, width), rand.Next(0, height));
						var endPoint = new Point(rand.Next(0, width), rand.Next(0, height));
						graph.DrawLine(linePen, startPoint, endPoint);
						var bezierPoint1 = new Point(rand.Next(0, width), rand.Next(0, height));
						var bezierPoint2 = new Point(rand.Next(0, width), rand.Next(0, height));
						graph.DrawBezier(linePen, startPoint, bezierPoint1, bezierPoint2, endPoint);
					}
				}

			}
		}
	}
}