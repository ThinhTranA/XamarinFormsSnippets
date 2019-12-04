using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.IO;
using System.Reflection;

namespace Onboarding.Controls
{
    public class SVGImage : ContentView
    {
        private readonly SKCanvasView canvasView = new SKCanvasView();

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
                                                           propertyName: nameof(Source), 
                                                           returnType: typeof(string), 
                                                           declaringType: typeof(SVGImage),
                                                           defaultValue: default(string), 
                                                           propertyChanged: RedrawCanvas);
        public string Source
        {
            get => (string) GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public SVGImage()
        {
            Padding = new Thickness(0);
            BackgroundColor = Color.Transparent;
            Content = canvasView;
            canvasView.PaintSurface += CanvasView_PaintSurface;
        }

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvas skCanvas = e.Surface.Canvas;
            skCanvas.Clear();

            if (string.IsNullOrEmpty(this.Source))
            {
                return;
            }

            // Get the assembly information to access the local image
            var assembly = typeof(SVGImage).GetTypeInfo().Assembly.GetName();

            // Update the canvas with the SVG image
            using (Stream stream = typeof(SVGImage).GetTypeInfo().Assembly.GetManifestResourceStream(assembly.Name + ".Images." + Source))
            {
                SkiaSharp.Extended.Svg.SKSvg skSVG = new SkiaSharp.Extended.Svg.SKSvg();
                skSVG.Load(stream);
                SKImageInfo imageInfo = e.Info;
                skCanvas.Translate(imageInfo.Width / 2f, imageInfo.Height / 2f);
                SKRect rectBounds = skSVG.ViewBox;
                float xRatio = imageInfo.Width / rectBounds.Width;
                float yRatio = imageInfo.Height / rectBounds.Height;
                float minRatio = Math.Min(xRatio, yRatio);
                skCanvas.Scale(minRatio);
                skCanvas.Translate(-rectBounds.MidX, -rectBounds.MidY);
                skCanvas.DrawPicture(skSVG.Picture);
            }
        }

        private static void RedrawCanvas(BindableObject bindable, object oldValue, object newValue)
        {
            SVGImage sVGImage = bindable as SVGImage;
            sVGImage?.canvasView.InvalidateSurface();
        }
    }
}
