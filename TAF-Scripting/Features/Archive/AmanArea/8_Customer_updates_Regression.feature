Feature: Customer_updates_Regression

@SVCRegression @G01 @162_CST_Customer_SetBillingAddress
Scenario Outline: TC_162_CST_Customer_SetBillingAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I select a non billing address and change it to Billing Address and save in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                          | ExcelFile                    | SheetName |
		| TC_162_CST_Customer_SetBillingAddress | TestDataSSCRegressionUpgrade | G01       |

		 