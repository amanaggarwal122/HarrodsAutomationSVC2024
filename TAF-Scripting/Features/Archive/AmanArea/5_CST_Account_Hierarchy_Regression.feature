Feature: CST_Account_Hierarchy_Regression

#Verify that the CST is able to add only 1 Primary Member and 4 Secondary members to Loyalty Rewards group.
@SVCRegression @G07 @224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup @E2ERun
Scenario Outline: TC_224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I add the New Primary Member in <UserCategory> <ExcelFile> <SheetName>
	When I Navigate to SSC > Group Accounts
	And I create a new group account <UserCategory> <ExcelFile> <SheetName>
	#And I search for the group created and add a nonrewards member as primary member <UserCategory> <ExcelFile> <SheetName>
	When I add a valid rewards member as primary member and add 4 valid reward members as secondary members <UserCategory> <ExcelFile> <SheetName>
	Then I Validate whether the 5 members are added successfully for the customer <UserCategory> <ExcelFile> <SheetName>
	#And I validate whether user is unable to add additional members in relationships tab <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                     | ExcelFile                    | SheetName |
		| TC_224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup | TestDataSSCRegressionUpgrade | G07       |

#Verify that the CST is able to create a Complaint ticket for a Secondary Customer to Transfer Points to another Secondary Member
@SVCRegression @G07 @225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer
Scenario Outline: TC_225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer
	Given I launch the "SSC" website
	#When I Navigate to SSC > Service > Tickets
	When I Navigate to SSC > Customers
	#And I enter all the mandatory details and select the <UserCategory> <ExcelFile> <SheetName>
	And I create staff enquiry ticket for customer miscellaneous point addition <UserCategory> <ExcelFile> <SheetName>
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	Then I validate the Customer Tier <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

#234	Verify that the CST is able to Deactivate the Group Account
@SVCRegression @G07  @234_DeactivateGroupAccountValidateOnSSCSMCAC @E2ERun
Scenario Outline: TC_234_DeactivateGroupAccountValidateOnSSCSMCAC
	#Given I create 1 Full Reward User in Harrods.com
	Given I launch the "SSC" website
	When I Navigate to SSC > Group Accounts
	And I create new group account with PrimaryMember from SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I "DeActivate" given group account "" from SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I should validate is deactivated from SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                    | ExcelFile                    | SheetName |
		| TC_234_DeactivateGroupAccountValidateOnSSCSMCAC | TestDataSSCRegressionUpgrade | G07       |
