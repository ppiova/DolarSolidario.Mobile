using System;
using Xamarin.Forms;

namespace SolidarityDollar.Controls
{
    public class VideoPlayer : View
    {
        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(
                nameof(Source),
                typeof(string),
                typeof(VideoPlayer), null);

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
    }
}
