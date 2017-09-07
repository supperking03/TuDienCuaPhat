using Xamarin.Forms;
using System.IO;


namespace LanguageCompass
{
    public partial class MainPage : ContentPage
    {
        //latest searched word for history function
        string lastSearchedWord = "";

        //Datapath link
        private static string historyPath;
        

        //language pair : en|vi, vi|en
        private static string languagePair;
        //Current using dictionary 
        private static DictionaryType ev;
        public MainPage()
        {
            InitializeComponent();
            ev = new DictionaryType(@"LanguageCompass.EngtoVie.txt");
        }

        async private void Btn_search_Clicked(object sender, System.EventArgs e)
        {
            if (ev.hashDict.ContainsKey(entry_word.Text))
                lb_content.Text = ev.hashDict[entry_word.Text];
            else await DisplayAlert("Oops..", "404", "OK");
        }
    }

}
