Feature: Account_Merge_Regression


@SVCRegression @G01 @155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack
Scenario Outline: TC_155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack
	Given I launch the "SSC" website
	When I Navigate to SSC > Customer Merge
	And Search for two active users and merge <UserCategory> <ExcelFile> <SheetName>
	And I edit the Attributes of the Surviving Customer and save
	And I initiate merge for the customers
	Then I close the browser window

	#When I Navigate to SSC > Tickets
	#And I create ticket for reward points merge for user <UserCategory> <ExcelFile> <SheetName>
	#there is issue in SSC for updating merge ticket
	Examples:
		| UserCategory                                         | ExcelFile                    | SheetName |
		| TC_155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @156_Merge_TwoAccounts_AndRegisterDeemedUser
Scenario Outline: TC_156_Merge_TwoAccounts_AndRegisterDeemedUser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customer Merge
	And Search for two active users and merge <UserCategory> <ExcelFile> <SheetName>
	And I edit the Attributes of the Surviving Customer and save
	And I initiate merge for the customers
	Then I close the browser window

	