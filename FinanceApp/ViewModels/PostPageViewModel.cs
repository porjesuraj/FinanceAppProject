using FinanceApp.Models;
using Microsoft.AppCenter.Crashes;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceApp.ViewModels
{
    public class PostPageViewModel : ViewModelBase
    {

        private string items;
        public string Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public INavigationService navigate { get; set; }

        public PostPageViewModel(INavigationService naigationService):base(naigationService)
        {
            navigate = naigationService;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
           // Item item = null;
            try
            {
               
               var item = parameters.GetValue<Item>("items");

                Items = item.ItemLink;
                throw (new Exception("Unable to load blogs"));

            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>
                {
                    { "Blog_Post", "item.Title" }
                };

                Crashes.TrackError(ex,properties);
            }

           
        }

    }
}
