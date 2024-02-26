//using System.ComponentModel;
//using System.Runtime.CompilerServices;

//public class Signing : INotifyPropertyChanged
//{
// Your properties here

//public event PropertyChangedEventHandler PropertyChanged;

//protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
//{
//    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//  }
//}
namespace localstorage
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
    }
}