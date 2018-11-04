using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using CustomFrameExample.Controls;
using CustomFrameExample.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FrameRenderer = Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace CustomFrameExample.Droid.Renderers
{
    public class CustomFrameRenderer : FrameRenderer
    {
        CustomFrame customFrame;

        public CustomFrameRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomFrame.CustomRadiusProperty.PropertyName ||
                e.PropertyName == Frame.BorderColorProperty.PropertyName ||
                e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                ApplyCornerRadius();
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            customFrame = Element as CustomFrame;

            if (e.NewElement != null)
            {
                ApplyCornerRadius();
            }
        }

        void ApplyCornerRadius()
        {
            if (customFrame == null)
            {
                return;
            }

            ClipToOutline = true;
            Background.Mutate();

            Background.SetColorFilter(Element.BackgroundColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
            var customFrameDrawable = ((GradientDrawable)Background);

            // TopLeft, TopRight, BottomRight, BottomLeft
            customFrameDrawable.SetCornerRadii(new[]
            {   Context.ToPixels(customFrame.CustomRadius.Top),
                Context.ToPixels(customFrame.CustomRadius.Top),
                Context.ToPixels(customFrame.CustomRadius.Right),
                Context.ToPixels(customFrame.CustomRadius.Right),
                Context.ToPixels(customFrame.CustomRadius.Bottom),
                Context.ToPixels(customFrame.CustomRadius.Bottom),
                Context.ToPixels(customFrame.CustomRadius.Left),
                Context.ToPixels(customFrame.CustomRadius.Left)
            });
        }
    }
}