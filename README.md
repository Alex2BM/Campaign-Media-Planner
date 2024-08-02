--------------------------------------------------------Installation----------------------------------------------
To set up the application locally, follow these steps:

1.Clone the Repository: Open your terminal or command prompt and run:
  
  -git clone git@github.com:Alex2BM/Campaign-Media-Planner.git
  
  -cd campaign-media-planner

2.Open the Project: Launch Visual Studio or Visual Studio Code and open the CampaignMediaPlanner.sln file.

3.Restore Packages: In Visual Studio, navigate to Build > Restore NuGet Packages to install the necessary dependencies.



------------------------------------------------------Running the Application-------------------------------------
                  Follow these steps to run the application:

1.Build the Project:

  -In Visual Studio, click on Build > Build Solution.

  -Alternatively, you can use the terminal to navigate to the project directory and run:
       dotnet build
2.Run the Application:

   -Press F5 or click on Debug > Start Debugging in Visual Studio to start the application.

    -Or, use the terminal to run the application with:
     dotnet run

3.Access the Application:

   -Open your web browser and navigate to http://localhost:5000 or http://localhost:<PORT>,
   where <PORT> is the port number displayed in the terminal or output window.
--------------------------------------Usage------------------------------------------------------------------------
Once the application is running, follow these steps to use the Campaign Media Planner:

1.Enter Campaign Details: Fill in the required fields:

Total Campaign Budget (Z): The total budget for the campaign.
Agency Fee Percentage (Y1): The agency's fee as a percentage of the ad spend.
Third-Party Tool Fee Percentage (Y2): The fee for third-party tools as a percentage of certain ad spends.
Fixed Agency Hours Cost: The fixed cost for agency hours.
Other Ads Budgets: The budgets allocated for other ads.
Calculate Max Ad Budget: Click the Calculate Max Ad Budget button to compute the optimal budget for a specific ad.

View Results: The application will display the maximum budget for the specific ad or an error message if the calculation fails.


