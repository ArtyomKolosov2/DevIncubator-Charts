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
            var validationResult = true;
            if (plotViewModel.RangeFrom >= plotViewModel.RangeTo)
            {
                ErrorMessage = "Range must be correct!";
                validationResult = false;
            }
            return validationResult;
        }
    }
}
