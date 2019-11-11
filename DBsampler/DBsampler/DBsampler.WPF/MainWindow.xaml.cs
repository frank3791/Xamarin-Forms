using Xamarin.Forms.Platform.WPF;
using System.Windows;


namespace DBsampler.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
            Xamarin.Forms.Forms.Init();
            LoadApplication(new DBsampler.App());
        }
    }
}
