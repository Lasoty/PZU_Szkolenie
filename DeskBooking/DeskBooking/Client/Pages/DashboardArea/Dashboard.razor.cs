using Blazorise.Charts;
using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.DashboardArea
{
    public partial class Dashboard
    {
        LineChart<int> lineChart;
        string[] Labels = Enumerable.Range(1, 30).Select(x => x.ToString()).ToArray();
        List<DeskReservationDto> data;

        [Inject]
        public HttpClient HttpClient { get; set; }

        LineChartOptions lineChartOptions = new()
        {
            Legend = new Legend { Display = false },
            Responsive = true,
            AspectRatio = 7
        };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                data = await HttpClient.
                    GetFromJsonAsync<List<DeskReservationDto>>("Statistics/ReservationsInLastMonth");
                await HandleRedraw();
            }
        }

        private async Task HandleRedraw()
        {
            await lineChart.Clear();

            await lineChart.AddLabelsDatasetsAndUpdate(Labels, GetLineChartDataset());
        }

        private LineChartDataset<int> GetLineChartDataset()
        {
            return new()
            {
                Label = "Zarezerwowanych biurek ",
                Data = GetLastMonthReservations(),
                BackgroundColor = ChartColor.FromRgba(255, 99, 132, 0.2f).ToJsRgba(), // line chart can only have one color
                BorderColor = ChartColor.FromRgba(255, 99, 132, 1f).ToJsRgba(),
                Fill = true,
                PointRadius = 3,
                BorderWidth = 1,
                PointBorderColor = Enumerable.Repeat(ChartColor.FromRgba(255, 99, 132, 1f).ToJsRgba(), 6).ToList()
            };
        }

        private List<int> RandomizeData()
        {
            var r = new Random(DateTime.Now.Millisecond);
            return Enumerable.Range(0, 100).Select(x => r.Next(0, 1000)).ToList()  ;
        }

        private List<int> GetLastMonthReservations()
        {
            var result = data.GroupBy(x => x.ReservationStartAt).Select(x => x.Count());
            return result.ToList();
        }
    }
}
