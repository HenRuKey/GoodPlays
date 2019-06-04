using GoodPlaysLib.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoodPlays
{
    public class SearchPageViewModel
    {
        public ObservableCollection<Game> Games { get; private set; }
        public ICommand SearchCommand { get; private set; }
        
        //Add search index client

        public SearchPageViewModel()
        {
            SearchCommand = new Command<string>(async (text) => await DatabaseSearch(text));
            Games = new ObservableCollection<Game>();
            //EF client
        }

        async Task DatabaseSearch(string text)
        {
            Games.Clear();

            /*
             var search_results
             foreach(SearchResult<Game> result in search_results.Results)
                Games.Add(new Game
                {
                    data fields
                }
             */
        }
    }
}
