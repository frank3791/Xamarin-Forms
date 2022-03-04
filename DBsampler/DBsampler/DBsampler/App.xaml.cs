using System;
using Utilities;
using Xamarin.Forms;

namespace DBsampler
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            UpdateFontSize();
            MainPage = new DBsampler.MainPage();
        }

        public static void UpdateFontSize()
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                Current.Resources["btnFontSize"] = Device.GetNamedSize(NamedSize.Large, typeof(Style));
                Current.Resources["btnPadding"] = 4;
                Current.Resources["btnMargin"] = 4;
                Current.Resources["logoHeight"] = 50;
            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                Current.Resources["btnFontSize"] = 50;
                Current.Resources["btnPadding"] = 6;
                Current.Resources["btnMargin"] = 6;
                Current.Resources["logoHeight"] = 75;
            }
        }

        public static void UpdateThemeColors(ColorScheme scheme)
        {
            if (scheme == null)
            {
                throw new ArgumentNullException(nameof(scheme));
            }
            Current.Resources["mainColor"] = XFUtilities.GetColorFromInt(scheme.MainColor);
            Current.Resources["highlightColor"] = XFUtilities.GetColorFromInt(scheme.HighlightColor);
            Current.Resources["buttonColor"] = XFUtilities.GetColorFromInt(scheme.ButtonColor);
            Current.Resources["backgroundColor"] = XFUtilities.GetColorFromInt(scheme.BackgroundColor);
        }


        
    }
}