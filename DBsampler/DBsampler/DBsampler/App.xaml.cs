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

            //MainPage = new NavigationPage(new DBsampler.MainPage()); //org
            //MainPage = new ContentPage(new DBsampler.MainPage()); // test
            MainPage = new DBsampler.MainPage();
        }
        public static void UpdateThemeColors (ColorScheme scheme)
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
