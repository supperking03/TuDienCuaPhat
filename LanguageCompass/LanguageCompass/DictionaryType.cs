using System.IO;
using System.Collections.Generic;
using Xamarin.Forms;
using System;
using System.Text.RegularExpressions;
using System.Reflection;

namespace LanguageCompass
{
    class DictionaryType: ContentPage
    {
        private static string dataDict;
        public List<string> suggestKey = new List<string>();
        public Dictionary<string, string> hashDict = new Dictionary<string, string>();


        //Read Data
        public void ReadData(string link)
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(link);
            try
            {
                using (StreamReader read = new StreamReader(stream))
                {
                    dataDict = read.ReadToEnd();
                    dataDict = dataDict.Replace(@"\r\n\r\n", "~");
                    DisplayAlert("cac", dataDict, "a");
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        //Set up Words for Dictionary type (hashDict)
        public void SetUpForDictionary()
        {
            string[] fullWords = dataDict.Split(new string[] {  }, StringSplitOptions.RemoveEmptyEntries);
            Regex regex = new Regex("(?<=@)[\\S\\D ]+?(?= /)");
            foreach (string oneWord in fullWords)
            {
                try
                {
                    Match match;
                    string name;
                    match = regex.Match(oneWord);
                    if (match.Success == false)
                    {
                        continue;
                    }
                    name = match.Value;
                    suggestKey.Add(name);
                    if (hashDict.ContainsKey(name) == false)
                        hashDict.Add(name, oneWord);
                }
                catch { }
            }
            //Constructor
            


        }
        public DictionaryType(string datalink)
        {
            ReadData(datalink);
            SetUpForDictionary();
        }



    }
}
