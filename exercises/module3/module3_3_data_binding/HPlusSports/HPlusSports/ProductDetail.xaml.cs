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
    }
}
