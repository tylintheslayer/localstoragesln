using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace localstorage
{
    public partial class MainPage : ContentPage
    {
        private string ProfileFilePath;

        private Profile profile;

        public MainPage()
        {
            InitializeComponent();
            ProfileFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "profile.json");
            LoadProfile();
        }

        private void LoadProfile()
        {
            if (File.Exists(ProfileFilePath))
            {
                string profileJson = File.ReadAllText(ProfileFilePath);
                profile = Profile.FromJson(profileJson);

                nameEntry.Text = profile.Name;
                surnameEntry.Text = profile.Surname;
                emailEntry.Text = profile.Email;
                bioEditor.Text = profile.Bio;
            }
            else
            {
                profile = new Profile();
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            profile.Name = nameEntry.Text;
            profile.Surname = surnameEntry.Text;
            profile.Email = emailEntry.Text;
            profile.Bio = bioEditor.Text;

            string profileJson = profile.ToJson();
            File.WriteAllText(ProfileFilePath, profileJson);

            DisplayAlert("Success", "Profile saved successfully.", "OK");
        }
    }

    public class Profile
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }

        public static Profile FromJson(string json)
        {
            string[] parts = json.Split(';');
            return new Profile
            {
                Name = parts[0],
                Surname = parts[1],
                Email = parts[2],
                Bio = parts[3]
            };
        }

        public string ToJson()
        {
            return $"{Name};{Surname};{Email};{Bio}";
        }
    }
}