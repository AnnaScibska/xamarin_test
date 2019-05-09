using System;

using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;

namespace xamarin1
{

    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public partial class MainPage : ContentPage
    {

        public int id { get; set; }
        public string title { get; set; }
        public ObservableCollection<Post> Data { get; set; } = new ObservableCollection<Post>();


        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            this.Data = Data;
            request(Data);
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            var p = new Post { id = 5, title = title };
            Data.Add(p);
        }

        public async static void request(ObservableCollection<Post> Data)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://my-json-server.typicode.com/typicode/demo/posts");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Post>>(json);
                foreach(Post d in data)
                {
                    Data.Add(d);
                }
            }
        }
    }
















        //    // public string Text { get; set; } = "dupa"; // solution 1

        //    public List<string> Data { get; set; }
        //    public ObservableCollection<List<string>> List { get; set; }

        //    private string _text = "text to change"; // solution 2 beginning
        //    public string Text
        //    {
        //        get => _text;
        //        set
        //        {
        //            if(_text != value)
        //            {
        //                _text = value;
        //                OnPropertyChanged(nameof(Text));
        //            }
        //        }
        //    } // solution 2 end

        //    public MainPage()
        //    {
        //        InitializeComponent();
        //        Data = new List<String>
        //        {
        //            "I",
        //            "hate",
        //            "C#"
        //        };
        //        List = new ObservableCollection<List<string>>
        //        {
        //            Data
        //        };
        //        List.CollectionChanged += OnListChanged;
        //        BindingContext = this; // one to the whole Page 
        //    }

        //    private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
        //    {
        //        DisplayAlert("Info", "List changed", "OK");
        //    }

        //    private void Button_Clicked(object sender, EventArgs e)
        //    {
        //        Debug.WriteLine("click");
        //        Text = "Don't touch that!";
        //        // OnPropertyChanged("Text");  //  OnPropertyChanged(nameOf(Text)); // pierwsze stare, drugie nowe // Solution 1
        //        Data.RemoveAt(0);
        //    }

        //    private void Say_Hello_Clicked(object sender, EventArgs e)
        //    {
        //        DisplayAlert("Hello", "Anula's App", "OK");
        //    }
        //}
    }
