using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Themuser
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public MainPage()
        {
            InitializeComponent();
            UsersListView.ItemsSource = Users;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadUsers();
        }

        async void LoadUsers()
        {
            Users.Clear();
            using (var db = new AppDbContext())
            {
                var users = await db.Users.ToListAsync();
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
        }

        async void OnAddUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserPage());
        }

        async void OnSortClicked(object sender, EventArgs e)
        {
            var sortedUsers = Users.OrderBy(u => u.Name).ToList();
            Users.Clear();
            foreach (var user in sortedUsers)
            {
                Users.Add(user);
            }
        }

        async void OnDeleteAllClicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Confirmation", "Bạn có chắc chắn muốn xóa hết ?", "đúng", "không");
            if (result)
            {
                using (var db = new AppDbContext())
                {
                    db.Users.RemoveRange(db.Users);
                    await db.SaveChangesAsync();
                }
                Users.Clear();
            }
        }
    }
}
