namespace Themuser;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var name = NameEntry.Text;

        if (!string.IsNullOrWhiteSpace(name))
        {
            var newUser = new User { Name = name };
            using (var db = new AppDbContext())
            {
                db.Users.Add(newUser);
                await db.SaveChangesAsync();
            }

            await DisplayAlert("Thành Công", "Thêm User thành công", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Lỗi", "Thêm không đc", "OK");
        }
    }
}