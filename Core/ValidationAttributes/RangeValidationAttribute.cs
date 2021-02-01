using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    public class RangeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var plotViewModel = value as PlotViewModel;
            if (plotViewModel.RangeFrom >= plotViewModel.RangeTo)
            {
                ErrorMessage = "Start range must be lower than end range!";
                return false;
            }
            return true;
        }
    }
}
