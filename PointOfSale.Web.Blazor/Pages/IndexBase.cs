using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointOfSale.Repository.Models;
using PointOfSale.Service;

namespace PointOfSale.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        private IDataService dataService { get; set; }
        public List<Applications> ApplicationList { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await InitializedApplicatioonRecordsAsync();
        }
        private async Task InitializedApplicatioonRecordsAsync()
        {
            ApplicationList = await dataService.GetApplications();
        }


    }
}
