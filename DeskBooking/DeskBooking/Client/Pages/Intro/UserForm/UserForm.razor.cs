using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.Intro.UserForm
{
    public partial class UserForm
    {
        string firstName = string.Empty;
        string lastName = string.Empty;
        int age = 0;

        bool isEditHidden = false;
        bool isCardHidden = true;

        public void ShowInfo()
        {
            isEditHidden = true;
            isCardHidden = false;
        }
    }
}
