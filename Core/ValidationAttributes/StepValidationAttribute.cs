using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ValidationAttributes
{
    public class StepValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var plotViewModel = value as PlotViewModel;
            var validationResult = true;
            if (plotViewModel.Step < 0)
            {
                ErrorMessage = "Step must be positive for this range!";
                validationResult = false;
            }
            else if (plotViewModel.Step == 0)
            {
                ErrorMessage = "Step must not be 0!";
                validationResult = false;
            }
            return validationResult;
        }
    }
}
