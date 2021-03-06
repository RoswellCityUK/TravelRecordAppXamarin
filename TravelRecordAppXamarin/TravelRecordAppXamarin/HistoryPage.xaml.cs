using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordAppXamarin.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var post = conn.Table<Post>().ToList();

                postsListView.ItemsSource = post;
            }
        }
    }
}