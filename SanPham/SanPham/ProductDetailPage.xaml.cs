
using Microsoft.Maui.Controls;
using SanPham;

namespace SanPham
{
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            BindingContext = product;
        }

    }
}
