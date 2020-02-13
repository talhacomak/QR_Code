using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class giris : ContentPage
    {
        
        public giris()
        {
            InitializeComponent();
            if(SelectLang.SelectedItem != null) SelectLang.SelectedItem.ToString(); // seçilen dil
        }

        public void baslat(object sender, EventArgs e)
        {
            MessagingCenter.Send<giris, string>(this, "EntryValue", "ok");
            this.Navigation.PopAsync(); // işe yaramazsa PushAsync dene
        }

        protected override bool OnBackButtonPressed()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            return true;
        }
    
    }

}
