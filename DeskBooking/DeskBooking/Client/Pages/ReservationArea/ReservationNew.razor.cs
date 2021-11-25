using DeskBooking.Client.Services;
using DeskBooking.Client.ViewModels.Reservation;
using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.ReservationArea
{
    public partial class ReservationNew
    {
        private ReservationNewViewModel vm;

        [Inject]
        public IDeskDataProvider DeskProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            vm = new ReservationNewViewModel()
            {
                Start = DateTime.Today,
                End = DateTime.Today,
                DeskList = new Dictionary<int, string>()
            };
        }

        private async Task DateSelectionChanged()
        {
            Dictionary<int, string> data = (await DeskProvider.GetFreeDesks(vm.Start, vm.End))
                .Select(x => new { Id = x.Id, Number = x.Number.ToString() })
                .ToDictionary(x => x.Id, x => x.Number);

            vm.DeskList = data;
        }

        private Task Save()
        {
            return Task.CompletedTask;
        }

        private Task Cancel()
        {
            return Task.CompletedTask;
        }
    }
}
