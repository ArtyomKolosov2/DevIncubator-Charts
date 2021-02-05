using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModels
{
    [RangeValidation]
    [StepValidation]
    public class PlotViewModel
    {
        [Required(ErrorMessage = "Start range required!")]
        public int RangeFrom { get; set; }
        [Required(ErrorMessage = "End range required!")]
        public int RangeTo { get; set; }
        [Required(ErrorMessage = "Step required!")]
        public float Step { get; set; }
        [Required]
        public int A { get; set; }
        [Required]
        public int B { get; set; }
        [Required]
        public int C { get; set; }
    }
}
