using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeptemberUIChallenge
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}