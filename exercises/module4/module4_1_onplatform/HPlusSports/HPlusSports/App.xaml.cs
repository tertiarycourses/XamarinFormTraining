using System;
using HPlusSports.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HPlusSports
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( 
                                          new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            ProductService.LoadWishList();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            ProductService.SaveWishList();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            ProductService.LoadWishList();
        }
    }
}
