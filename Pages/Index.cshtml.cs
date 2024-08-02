using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CampaignMediaPlanner.Models;

namespace CampaignMediaPlanner.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Total campaign budget is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total campaign budget must be greater than zero.")]
        public double TotalBudgetZ { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Agency fee percentage is required.")]
        [Range(0, 1, ErrorMessage = "Agency fee percentage must be between 0 and 1.")]
        public double AgencyFeeY1 { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Third-party tool fee percentage is required.")]
        [Range(0, 1, ErrorMessage = "Third-party tool fee percentage must be between 0 and 1.")]
        public double ThirdPartyFeeY2 { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Fixed agency hours cost is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Fixed agency hours cost must be a positive value.")]
        public double FixedHoursCost { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Budgets for other ads are required.")]
        [MinLength(1, ErrorMessage = "At least one budget for other ads is required.")]
        public double[] OtherAdsBudgets { get; set; } = new double[3]; // Assuming three other ads for simplicity

        public double MaxAdBudget { get; private set; }

        public string ErrorMessage { get; private set; }

        public void OnPost()
        {
            // Server-side validation
            if (!ModelState.IsValid)
            {
                return;
            }

            try
            {
                // Ensure that the budgets for other ads are valid
                if (OtherAdsBudgets.Any(b => b < 0))
                {
                    ModelState.AddModelError("", "Budgets for other ads must be non-negative values.");
                    return;
                }

                var optimizer = new BudgetOptimizer(TotalBudgetZ, AgencyFeeY1, ThirdPartyFeeY2, FixedHoursCost, OtherAdsBudgets);
                MaxAdBudget = optimizer.GoalSeek();

                // Check if the calculated max ad budget is valid
                if (MaxAdBudget < 0)
                {
                    ErrorMessage = "Unable to calculate a valid budget for the specific ad. Please check your input values.";
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                ErrorMessage = "An error occurred during the calculation: " + ex.Message;
            }
        }
    }
}
