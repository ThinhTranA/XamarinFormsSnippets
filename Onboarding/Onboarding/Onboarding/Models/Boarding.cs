using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Onboarding.Models
{
    public class Boarding
    {
        public string ImagePath { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public View RotatorItem { get; set; }
    }
}
