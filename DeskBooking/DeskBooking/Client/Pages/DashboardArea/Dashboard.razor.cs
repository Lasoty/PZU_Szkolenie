using Blazorise.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.DashboardArea
{
    public partial class Dashboard
    {
        LineChart<int> lineChart;

        string[] Labels = { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" };

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
                Data = RandomizeData(),
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
    }
}
