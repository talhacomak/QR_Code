using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Newtonsoft.Json;
using System.Linq;

namespace App1
{
    public class Contact
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
    }

    public class ContactList
    {
        public List<Contact> contacts { get; set; }
    }
    public class NetworkCheck
    {
        public static bool IsInternet()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            {
                // write your code if there is no Internet available      
                return false;
            }
        }
    }
    class get_data_from_web
    {

        public async void GetJSON()
        {
            //Check network status   
            if (!NetworkCheck.IsInternet())
            {
                //await DisplayAlert("JSONParsing", "No network is available.", "Ok");
            }
            else
            {

                var client = new System.Net.Http.HttpClient();
                var response = await client.GetAsync("REPLACE YOUR JSON URL");
                string contactsJson = await response.Content.ReadAsStringAsync();
                ContactList ObjContactList = new ContactList();
                if (contactsJson != "")
                {
                    //Converting JSON Array Objects into generic list  
                    ObjContactList = JsonConvert.DeserializeObject<ContactList>(contactsJson);
                }
                //Binding listview with server response
                string[] ar = new string[ObjContactList.contacts.Count];
                for (int i=0; i<ObjContactList.contacts.Count; i++)
                {
                    ar[i] = ObjContactList.contacts.ToString();
                }
                
            }
            //Hide loader after server response    
            //ProgressLoader.IsVisible = false;
        }
    }
}