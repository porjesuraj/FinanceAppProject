using FinanceApp.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace FinanceApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IPageLifecycleAware
    {
        private Posts blog;
        public Posts Blog
        {
            get { return blog; }
            set { SetProperty(ref blog, value); }
        }

        private DelegateCommand listItemSelectedCommand;
        public DelegateCommand ListItemSelectedCommand =>
            listItemSelectedCommand ?? (listItemSelectedCommand = new DelegateCommand(ExecuteListItemSelectedCommand));


        public INavigationService navigate { get; set; }


        private Item items;
        public Item Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public IPageDialogService pageService { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogueService)
            : base(navigationService)
        {
            Title = "Main Page";

            navigate = navigationService;
            pageService = pageDialogueService;
         // ReadRss();
        }

        void ExecuteListItemSelectedCommand()
        {
            var navParams = new NavigationParameters
            {
                {"items",Items }
            };

            navigate.NavigateAsync("PostPage",navParams);
        }

        public void ReadRss()
        {
            try
            {
                // ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

               // ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                XmlSerializer serializer = new XmlSerializer(typeof(Posts));

                using (WebClient client = new WebClient())
                {
                    string xml = Encoding.Default.GetString(client.DownloadData("https://www.nasa.gov/rss/dyn/shuttle_station.rss"));
                    using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                    {
                        Blog = (Posts)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                pageService.DisplayAlertAsync("Error", ex.Message, "OK");
                
            }
           
        }

        public void OnAppearing()
        {
            ReadRss();
        }

        public void OnDisappearing()
        {
            
        }
    }
}
