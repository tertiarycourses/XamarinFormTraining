using System;
using System.Collections.Generic;
using HPlusSports.Services;
using Xamarin.Forms;

namespace HPlusSports
{
    public partial class ProductDetail : ContentPage
    {
        public ProductDetail()
        {
            InitializeComponent();
        }
        public ProductDetail(Product target)
        {
            InitializeComponent();
            BindingContext = target;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var target = BindingContext as Product;

            Navigation.PushAsync(new OrderForm(
                new Order { ProductName = target.Name, Quantity = 1 }));
        }
    }
}
