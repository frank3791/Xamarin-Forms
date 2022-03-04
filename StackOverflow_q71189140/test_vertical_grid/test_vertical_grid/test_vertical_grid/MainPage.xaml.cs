using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace test_vertical_grid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (Height > Width)
            {
                viewModel.LoadPortraitData();
            }
            else
            {
                viewModel.LoadLandscapeData();
            }
        }
    }

}
