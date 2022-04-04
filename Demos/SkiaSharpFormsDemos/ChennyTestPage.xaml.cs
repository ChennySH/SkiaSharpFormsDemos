using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChennyTestPage : ContentPage
    {
        public ChennyTestPage()
        {
            InitializeComponent();
        }

        private void chennyTestCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            #region board
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    SKPath path = new SKPath();
                    path.MoveTo(j * 0.1f * info.Width, i * 0.1f * info.Height);
                    path.LineTo((0.1f + j * 0.1f) * info.Width, i * 0.1f * info.Height);
                    path.LineTo((0.1f + j * 0.1f) * info.Width, (0.1f + i * 0.1f) * info.Height);
                    path.LineTo(j * 0.1f * info.Width, (0.1f + i * 0.1f) * info.Height);
                    path.LineTo(j * 0.1f * info.Width, i * 0.1f * info.Height);
                    path.Close();
                    SKPaint fillPaint = new SKPaint
                    {
                        Style = SKPaintStyle.Fill,
                        Color = SKColors.Goldenrod,
                    };
                    if ((i + j) % 2 == 0)
                    {
                        fillPaint = new SKPaint
                        {
                            Style = SKPaintStyle.Fill,
                            Color = SKColors.LightGoldenrodYellow,
                        };
                    }

                    int posNum = 10 * (9 - i) + (9 - j) + 1;
                    if (i % 2 == 1)
                        posNum = 10 * (9 - i) + j + 1;
                    if (posNum == 100)
                    {
                        fillPaint = new SKPaint
                        {
                            Style = SKPaintStyle.Fill,
                            Color = SKColors.Pink,
                        };
                    }
                    canvas.DrawPath(path, fillPaint);

                    string text = posNum.ToString();
                    float textX = j * 0.1f * info.Width;
                    float textY = (0.1f + i * 0.1f) * info.Height;
                    SKPaint textPaint = new SKPaint
                    {
                        TextSize = 30,
                        Color = SKColors.Black,
                    };
                    canvas.DrawText(text, textX, textY, textPaint);

                }
            }
            #endregion
            float startX = 0.05f * info.Width;
            float startY = 0.95f * info.Height;
            float endX = 0.95f * info.Width;
            float endY = 0.55f * info.Height;
            SKPoint startPoint = new SKPoint
            {
                X = startX,
                Y = startY,
            };
            SKPoint endPoint = new SKPoint
            {
                X = endX,
                Y = endY,
            };
            SKPoint[] ladder = new SKPoint[2];
            ladder[0] = startPoint;
            ladder[1] = endPoint;
            SKPaint paint = new SKPaint
            {
                //Style = SKPaintStyle.Stroke,
                Color = SKColors.Blue,
                StrokeWidth = 10,
                StrokeCap = SKStrokeCap.Round,
            };
            SKPointMode pointMode = SKPointMode.Lines;
            canvas.DrawPoints(pointMode, ladder, paint);
        }
    }
}