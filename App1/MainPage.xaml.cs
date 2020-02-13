using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]


    public partial class MainPage : ContentPage
    {

        public static string result;

        public static String message;
        public static Button scanner;
        public static String GUID;

        public string guid;
        public MainPage()
        {
            
            InitializeComponent();
            result = "123";
            Guid id;
            guid = "";
            string returnedvalue = "";
            MessagingCenter.Subscribe<giris, string>(this, "Entry value", (sender, value) => {
                returnedvalue = value;
                MessagingCenter.Unsubscribe<giris, string>(this, "Entry value");
            });
            if (returnedvalue != "")
            {
                id = Guid.NewGuid();
                using (StreamWriter writetext = new StreamWriter("write.txt"))
                {
                    writetext.WriteLine(id.ToString());
                }
            }

            if (!File.Exists("write.txt")){
                MessagingCenter.Send<MainPage, string> (this, "Entry value", null);
                Navigation.PushAsync(new giris());
            }
            else
            {
                using (StreamReader readtext = new StreamReader("write.txt"))
                {
                    guid = readtext.ReadLine();
                }
            }
        }


        // SCANNING
        private async void btn_scanClick(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<Interface1>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    lbl2.Text = result;
                    string url = "https://web.bilist.com.tr:1512/dv_test_qr/tr_TR/";
                    posting(url);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void posting(string url)
        {
            string myXMLstring2 = "";
            String str = "";
            Task task2 = new Task(() => {

                str = lbl2.Text;
                string[] strAr = str.Split(',');
                string[] post = new String[strAr.Length+1];
                string[] post_name = new String[strAr.Length+1];
                string[] temp;
                for (int i = 0; i < strAr.Length; i++)
                {
                    temp = strAr[i].Split(':');
                    post_name[i] = temp[0].Substring(3, temp[0].Length - 1);
                    post[i] = temp[1].Substring(0, temp[1].Length - 1);
                }
                post_name[0] = post_name[0].Substring(1, post_name[0].Length);
                post[post.Length - 2] = post[post.Length - 2].Substring(0, post[post.Length - 2].Length - 3);
                post[post.Length-1] = guid;
                post_name[post_name.Length-1] = "GUID";
                string top = "";
                for(int i=0; i<post.Length; i++)
                {
                    top += post[i];
                }
                l1.Text = top;
                Post_request pr = new Post_request();
                myXMLstring2 = pr.AccessTheWebAsync(url, post_name, post).Result;
            });
            if (str != "")
            {
                task2.Start();
                task2.Wait();
                lbl.Text = myXMLstring2;
            }
        }

    }
}
