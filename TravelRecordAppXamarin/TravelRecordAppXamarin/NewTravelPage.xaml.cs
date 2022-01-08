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
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = TxtExperience.Text
            };

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Post>();
            int rows = conn.Insert(post);
            conn.Close();

            if (rows > 0)
                DisplayAlert("Success", "Experience succesfully inserted", "OK");
            else
                DisplayAlert("Failure", "Experience not inserted", "OK");
        }
    }
}