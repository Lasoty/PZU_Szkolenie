using Blazorise;
using Blazorise.Components;
using DeskBooking.Client.Services;
using DeskBooking.Client.ViewModels.Reservation;
using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.ReservationArea
{
    public partial class ReservationNew
    {
        private ReservationNewViewModel vm;
        private bool hasChanged;
        
        [Inject]
        public IDeskDataProvider DeskProvider { get; set; }

        [Inject]
        public IReservationsProvider ReservationProvider { get; set; }

        [Inject]
        public INotificationService Notification { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IMessageService MessageService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            vm = new ReservationNewViewModel()
            {
                Start = DateTime.Today,
                End = DateTime.Today,
                DeskList = new ObservableCollection<DeskDto>()
            };
            await UpdateFreeDesks();
        }

        private async Task DateSelectionChanged()
        {
            await UpdateFreeDesks();
        }

        private async Task UpdateFreeDesks()
        {
            vm.DeskList.Clear();
            foreach (DeskDto item in await DeskProvider.GetFreeDesks(vm.Start, vm.End))
            {
                vm.DeskList.Add(item);
            }
            StateHasChanged();
        }

        private async Task Save()
        {
            ReservationDto reservation = new()
            {
                DeskId = vm.SelectedDesk,
                UserId = 1, //TODO: Pobrać id użytkownika z sesji
                Start = vm.Start,
                End = vm.End
            };

            if (await ReservationProvider.SaveReservation(reservation))
            {
                await Notification.Success("Rezerwacja została utworzona.", "Sukces");
            }
            else
            {
                await Notification.Error("Nie udało się utworzyć rezerwacji.", "Błąd");
            }

            NavigationManager.NavigateTo("/");
        }

        private async Task Cancel()
        {
            if (hasChanged)
            {
                if (await MessageService.Confirm("Czy na pewno chcesz porzucić zmiany?", "Porzucanie zmian"))
                {
                    NavigationManager.NavigateTo("/");
                }
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }

        }
    }
}
