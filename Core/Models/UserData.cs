using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Core.Models
{
    public class UserData
    {
        public UserData()
        {   
        }

        public UserData(PlotViewModel plotViewModel)
        {
            A = plotViewModel.A;
            B = plotViewModel.B;
            C = plotViewModel.C;
            Step = plotViewModel.Step;
            RangeFrom = plotViewModel.RangeFrom;
            RangeTo = plotViewModel.RangeTo;
        }
        public int UserDataId { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public float Step { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

    }
}
