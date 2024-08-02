using System;
using System.Linq;

namespace CampaignMediaPlanner.Models
{
    public class BudgetOptimizer
    {
        private double TotalBudgetZ;
        private double AgencyFeePercentageY1;
        private double ThirdPartyToolFeePercentageY2;
        private double FixedAgencyHoursCost;
        private double[] OtherAdsBudgets;

        public BudgetOptimizer(double totalBudgetZ, double agencyFeeY1, double thirdPartyFeeY2, double fixedHoursCost, double[] otherAdsBudgets)
        {
            TotalBudgetZ = totalBudgetZ;
            AgencyFeePercentageY1 = agencyFeeY1;
            ThirdPartyToolFeePercentageY2 = thirdPartyFeeY2;
            FixedAgencyHoursCost = fixedHoursCost;
            OtherAdsBudgets = otherAdsBudgets;
        }

        public double GoalSeek(double tolerance = 0.01, double maxIterations = 1000)
        {
            // Validate inputs to prevent negative or nonsensical values
            if (TotalBudgetZ <= 0 || AgencyFeePercentageY1 < 0 || AgencyFeePercentageY1 > 1 ||
                ThirdPartyToolFeePercentageY2 < 0 || ThirdPartyToolFeePercentageY2 > 1 ||
                FixedAgencyHoursCost < 0 || OtherAdsBudgets == null || OtherAdsBudgets.Any(b => b < 0))
            {
                throw new ArgumentException("Invalid input values. Please ensure all inputs are within valid ranges.");
            }

            double specificAdBudget = 0.0;
            double low = 0.0;
            double high = TotalBudgetZ;
            int iterations = 0;

            while (iterations < maxIterations)
            {
                specificAdBudget = (low + high) / 2;
                double calculatedBudget = CalculateTotalBudget(specificAdBudget);

                if (Math.Abs(calculatedBudget - TotalBudgetZ) <= tolerance)
                {
                    break;
                }

                if (calculatedBudget > TotalBudgetZ)
                {
                    high = specificAdBudget;
                }
                else
                {
                    low = specificAdBudget;
                }

                iterations++;
            }

            // If specificAdBudget is negative, return a zero budget to indicate failure
            return specificAdBudget >= 0 ? specificAdBudget : 0;
        }

        private double CalculateTotalBudget(double specificAdBudget)
        {
            double totalAdSpend = specificAdBudget + OtherAdsBudgets.Sum();
            double totalBudget = totalAdSpend * (1 + AgencyFeePercentageY1) + ThirdPartyToolFeePercentageY2 * (OtherAdsBudgets[0] + OtherAdsBudgets[1] + specificAdBudget) + FixedAgencyHoursCost;
            return totalBudget;
        }
    }
}



