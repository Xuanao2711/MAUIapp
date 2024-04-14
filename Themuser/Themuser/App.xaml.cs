namespace Themuser
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeDatabase();
            MainPage = new NavigationPage(new MainPage());
        }
        void InitializeDatabase()
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
