Feature: Customer_Service_Regression

@SVCRegression @G01 @148_CST_Register_FullAccountCustomer_for_MiniHarrods
Scenario Outline: TC_148_CST_Register_FullAccountCustomer_for_MiniHarrods
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add Child for the user <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window

	Examples:
		| UserCategory                                            | ExcelFile                    | SheetName |
		| TC_148_CST_Register_FullAccountCustomer_for_MiniHarrods | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @149_CST_Remove_LastChild_from_MiniHarrods
Scenario Outline: TC_149_CST_Remove_LastChild_from_MiniHarrods
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I remove added child of the user <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window

	Examples:
		| UserCategory                                 | ExcelFile                    | SheetName |
		| TC_149_CST_Remove_LastChild_from_MiniHarrods | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @150_CST_CreateFUllRewardsCustomer_NotinSVCDB
Scenario Outline: TC_150_CST_CreateFUllRewardsCustomer_NotinSVCDB
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new customer <UserCategory> <ExcelFile> <SheetName>
	And I validate whether the user created is a duplicate
	And I close the browser window

	Examples:
		| UserCategory                                    | ExcelFile                    | SheetName |
		| TC_150_CST_CreateFUllRewardsCustomer_NotinSVCDB | TestDataSSCRegressionUpgrade | G01       |
