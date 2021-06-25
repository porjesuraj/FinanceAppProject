using FinanceApp.Models;
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

            var items = parameters.GetValue<Item>("items");

            Items = items.ItemLink;
        }

    }
}
