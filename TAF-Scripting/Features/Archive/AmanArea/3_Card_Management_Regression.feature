Feature: Card_Management_Regression

   
@SVCRegression @G01 @151_CST_Replace_StolenCard
Scenario Outline: TC_151_CST_Replace_StolenCard
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Deactivate old card and activate new card for the customer <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                  | ExcelFile                    | SheetName |
		| TC_151_CST_Replace_StolenCard | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @152_CST_Deactivate_activecard_with_InvalidCardID
Scenario Outline: TC_152_CST_Deactivate_activecard_with_InvalidCardID
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Deactivate the card for the customer <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName |
		| TC_152_CST_Deactivate_activecard_with_InvalidCardID | TestDataSSCRegressionUpgrade | G01       |    