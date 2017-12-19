using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        
        // Main search routine
        private void  SearchForSongs(string mood)
        {
            // Initialize API using my private key 
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyBupBiyT9BAdC_txINLPjJn9jBH8Iujb94",
                ApplicationName = "bart-189220"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.SafeSearch =  SearchResource.ListRequest.SafeSearchEnum.Moderate;
            // Set the search terms
            searchListRequest.Q = mood;
            searchListRequest.Type = "video";
            searchListRequest.VideoEmbeddable = SearchResource.ListRequest.VideoEmbeddableEnum.True__;
;
            // Restrict the number of search results to return
            searchListRequest.MaxResults = 50;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse =  searchListRequest.Execute();

            // Choose a random video from the result set
            int itemToPlay = new Random().Next(searchListResponse.Items.Count);
            SearchResult myVideo = searchListResponse.Items[itemToPlay];
            string videoID = "";

            // Set the ID of the video depending on which list it belongs to
            switch (myVideo.Id.Kind)
            {
                case "youtube#video":
                    videoID=myVideo.Id.VideoId;
                    break;

                case "youtube#channel":
                    videoID = myVideo.Id.ChannelId;
                    break;

                case "youtube#playlist":
                    videoID = myVideo.Id.PlaylistId;
                    break;
            }

            // Show the song title in the title bar
            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = string.Format("Now playing {0}", myVideo.Snippet.Title);

            Debug.WriteLine(string.Format("{0} : {1}", myVideo.Snippet.Title, videoID));
            // Set the source of the webview to the address of the chosen video
            webview.Source = new Uri(string.Format("https://www.youtube.com/embed/{0}?rel=0&autoplay=1;html5=True;", videoID));
            
           
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // List of possible moods
            string[] moods = { "Happy" ,"Sad","Lonely","Excited","Festive","Lucky"};
            // Add them to the list for display
            for (int i = 0; i < moods.Length; i++)
            {
                MoodList.Items.Add(moods[i]);
            }

        }

        private string RetrieveUserDetails()
        {
            Windows.Storage.ApplicationDataContainer localSettings =
                Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            var userName =localSettings.Values["username"];
            return userName == null ? "" : userName.ToString();
        }



        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine(e.AddedItems[0]);
            string SearchTerms = string.Format("Songs with {0} lyrics", e.AddedItems[0]);
            SearchForSongs(SearchTerms);
        }
    }
}
