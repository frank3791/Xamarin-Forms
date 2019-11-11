using Xamarin.Forms;

namespace DBsampler
{
    public partial class ColorSchemePage : ContentPage
    {
        public ColorSchemePage()
        {
            InitializeComponent();

            colorSchemesList.ItemsSource = ColorSchemes.Schemes;
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Preferences.Intstance.ColorScheme = colorSchemesList.SelectedItem as ColorScheme;

            Navigation.PopAsync();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Preferences.Intstance.ColorScheme = colorSchemesList.SelectedItem as ColorScheme;
        }
    }
}
