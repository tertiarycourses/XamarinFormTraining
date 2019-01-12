using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPlusSports.Services;
using Xamarin.Forms;

namespace HPlusSports
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //void Handle_Clicked(object sender, System.EventArgs e)
        //{
        //    Navigation.PushAsync(new ProductDetail());
        //}

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Product target = e.Item as Product;
            Navigation.PushAsync(new ProductDetail(target));
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            INetworkManager mgr = DependencyService.Get<INetworkManager>();
            if(mgr.IsNetworkConnected()){
                var products = await ProductService.GetProductsAsync();
                BindingContext = products;
            }
            else {
                await DisplayAlert("Not connected", "you are not connected to a network", "Ok");
            }

        }
    }
}
