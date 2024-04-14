namespace SanPham;

public partial class ProductListPage : ContentPage
{
    private List<Product> _products;

    public ProductListPage()
    {
        InitializeComponent();
        LoadProducts();
    }


    private void LoadProducts()
    {
        _products = new List<Product>
            {
                new Product {
                    Id = 1,
                    Title = "Điện thoại iPhone 15 Pro Max 256GB",
                    Description = "iPhone 15 Pro Max đã chính thức được ra mắt trong sự kiện Wonderlust tại nhà hát Steve Jobs, California (Mỹ) vào lúc 10h sáng 12/9 tức 0h ngày 13/9 (giờ Việt Nam). Chiếc iPhone mới trong series mới đem đến cho người dùng trải nghiệm ổn định hơn với thế hệ chip A17 Pro mới nhất, cùng công nghệ Wi-Fi 6E. Bộ camera của iPhone 15 Pro Max cũng được nâng cấp thêm với ống kính tele với khả năng zoom quang học 5x với thiết kế tetraprism hiện đại.",
                    Price = 26.990000,
                    Category = "Điện thoại",
                    Image = "phone1.jpg" },

                    new Product {
                    Id = 2,
                    Title = "Điện thoại iPhone 11 (128GB) - Chính hãng VN/A",
                    Description = "iPhone 11 - siêu phẩm được mong chờ nhất năm 2019 của Apple chuẩn bị ra mắt. Với những cải tiến vượt trội, phiên bản iPhone mới nhất hứa hẹn sẽ làm bùng nổ thị trường công nghệ.",
                    Price = 15.880000,
                    Category = "Điện Thoại",
                    Image = "phone2.jpg" },

                    new Product {
                    Id = 3,
                    Title = "Điện thoại iPhone 13 (128GB) - Chính hãng VN/A",
                    Description = "Với những cải tiến không ngừng nghỉ cho những sản phẩm điện thoại thông minh của mình, Apple là hãng smartphone luôn nhận được sự tin tưởng từ người tiêu dùng Việt Nam. Dòng sản phẩm iPhone 13 được ra mắt gần đây với màu sắc mới và nâng cấp đáng kể về phần cứng của điện thoại đang nhận được rất nhiều sự quan tâm từ người hâm mộ.   ",
                    Price = 18.970000,
                    Category = "Điện Thoại",
                    Image = "phone3.jpg" },
            };
        ProductListView.ItemsSource = _products;
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedProduct = (Product)e.SelectedItem;
        await Navigation.PushAsync(new ProductDetailPage(selectedProduct));
        ProductListView.SelectedItem = null;
    }

    private void SortByPriceClicked(object sender, EventArgs e)
    {
        _products = _products.OrderBy(p => p.Price).ToList();
        ProductListView.ItemsSource = _products;
    }

}