using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace xamarin1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=b67aa439-bb4b-4292-b83c-44f2bf6b1af5;"
                + "ios=78dd993c-a711-47b2-b741-b5665200d070;" 
                + "uwp=b393e627-7e88-4571-a1ac-d69a65cbe71f", 
                typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
