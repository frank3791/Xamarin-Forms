using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Utilities;
using System.Diagnostics;

namespace DBsampler
{
    public enum DrumType
    {
        acesHigh,
        agentsOfSteel,
        breakingTheLaw,
        fastAsAShark,
        heartOfSteel,
        stalingrad,
        theNumberOfTheBeast,
        Bass1,
        Stop,
        count
    }

    public partial class MainPage : ContentPage
    {
        ISimpleAudioPlayer[] players = new ISimpleAudioPlayer[(int)DrumType.count];
        Animation[] animations = new Animation[(int)DrumType.count];

        List<Note> recording = new List<Note>();

        public MainPage()
        {
            //force color scheme for now
            Preferences.Intstance.ColorScheme = ColorSchemes.Schemes[1];

            var player = CrossSimpleAudioPlayer.Current;

            for (int i = 0; i < (int)DrumType.count; i++)
            {
                players[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                players[i].Loop = false;
            }

            LoadSamples(1);


            InitializeComponent();

            int j = 0;
            foreach (Button button in gridButtons.Children)
            {
                DrumType drum = (DrumType)j;
                button.Clicked += (s, e) => OnDrumButton(drum);
                j++;
            }

            btnSettings.Clicked += (s, e) => Navigation.PushAsync(new ColorSchemePage());
            btnAbout.Clicked += (s, e) => DisplayAlert("DIRTBAG sampler", "v0.0.1", "OK");

            Preferences.Intstance.ColorSchemeUpdated += ColorSchemeUpdated;

            //to set the animations
            ColorSchemeUpdated(this, Preferences.Intstance.ColorScheme.SchemeType);
        }

        void ColorSchemeUpdated(object sender, ColorSchemeType e)
        {
            Color colorButton = XFUtilities.GetColorFromInt(Preferences.Intstance.ColorScheme.ButtonColor);
            Color colorMain = XFUtilities.GetColorFromInt(Preferences.Intstance.ColorScheme.MainColor);
            Color colorHighlight = XFUtilities.GetColorFromInt(Preferences.Intstance.ColorScheme.HighlightColor);

            int j = 0;
            foreach (Button button in gridButtons.Children)
            {
                button.BackgroundColor = colorButton;
                button.TextColor = colorHighlight;
                animations[j++] = new Animation(v => button.BackgroundColor = GetBlendedColor(colorButton, colorMain, v), 0, 1);
                
            }

            imgLogo.Source = ImageSource.FromResource("DrumPad.Images." + Preferences.Intstance.ColorScheme.Logo);
        }


        void OnDrumButton(DrumType drumType)
            {
            //players[(int)drumType]?.Play();

            foreach (DrumType i in (DrumType[])Enum.GetValues(typeof(DrumType)))
            {
                if (i != DrumType.count)
                {
                    players[(int)i]?.Stop();
                    //players[(int)i].Volume = 0.0;
                    //Debug.WriteLine((int)i);
                }
            }
            //players[(int)drumType].Volume = 1.0;
            players[(int)drumType]?.Play();
            animations[(int)drumType]?.Commit(this, drumType.ToString());
            }

        void LoadSamples(int index)
        {
            if (index < 1 || index > 2)
                return;

            //_ = players[(int)DrumType.Bass1].Load($"DrumPad.Audio.bd1.wav");
            _ = players[(int)DrumType.Bass1].Load(GetStreamFromFile($"Audio.bd1.wav"));
            _ = players[(int)DrumType.Stop].Load(GetStreamFromFile($"Audio.bd2.wav"));
            _ = players[(int)DrumType.theNumberOfTheBeast].Load(GetStreamFromFile($"Audio.theNumberOfTheBeast.mp3"));
            _ = players[(int)DrumType.stalingrad].Load(GetStreamFromFile($"Audio.stalingrad.mp3"));
            _ = players[(int)DrumType.heartOfSteel].Load(GetStreamFromFile($"Audio.heartOfSteel.mp3"));
            _ = players[(int)DrumType.fastAsAShark].Load(GetStreamFromFile($"Audio.fastAsAShark.mp3"));
            _ = players[(int)DrumType.breakingTheLaw].Load(GetStreamFromFile($"Audio.breakingTheLaw.mp3"));
            _ = players[(int)DrumType.agentsOfSteel].Load(GetStreamFromFile($"Audio.agentsOfSteel.mp3"));
            _ = players[(int)DrumType.acesHigh].Load(GetStreamFromFile($"Audio.acesHigh.mp3"));
        }

    //object GetStreamFromFile(string v)
    //{
    //    throw new NotImplementedException();
    //}

    Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("DrumPad." + filename);

            return stream;
        }

        Color GetBlendedColor(Color color1, Color color2, double percentage)
        {
            return new Color(percentage * color1.R + (1 - percentage) * color2.R,
                             percentage * color1.G + (1 - percentage) * color2.G,
                             percentage * color1.B + (1 - percentage) * color2.B);
        }
    }
}