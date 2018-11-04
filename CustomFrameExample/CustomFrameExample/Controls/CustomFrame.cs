using Xamarin.Forms;

namespace CustomFrameExample.Controls
{
	public class CustomFrame : Frame
	{
		public static readonly BindableProperty CustomRadiusProperty =
			BindableProperty.Create(nameof(CustomRadius), typeof(Thickness),
									typeof(CustomFrame), new Thickness(0, 0, 0, 0));

		public Thickness CustomRadius
		{
			get => (Thickness)GetValue(CustomRadiusProperty);
			set => SetValue(CustomRadiusProperty, value);
		}
	}
}