using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.Intro.Calculator
{
    public partial class Calculator : ComponentBase
    {
        int liczbaA = 0;
        int liczbaB = 0;
        int result = 0;

        public void Sum()
        {
            result = liczbaA + liczbaB;
        }
    }
}
