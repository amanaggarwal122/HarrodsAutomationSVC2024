Feature: Customer upgradeDowngrade_Regression


#Verify that the CST is able to create a Enquiry ticket for a Customer to upgrade tier from Green 0 to Gold (Manual Tier Upgrade)
@SVCRegression @G07 @221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade
Scenario Outline: TC_221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	#And I create a new Service Ticket
	And I enter all the mandatory details and create ticket for <UserCategory> <ExcelFile> <SheetName>
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	#Then I validate the Customer Tier <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                            | ExcelFile                    | SheetName |
		| TC_221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade | TestDataSSCRegressionUpgrade | G07       |


@SVCRegression @G07  @230_GreenZeroToGreenTwoTierUpgradeValidation @E2ERun
Scenario Outline: TC_230_GreenZeroToGreenTwoTierUpgradeValidation
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create ticket for "Green0-Bronze" tier upgrade from file "<UserCategory>" "<ExcelFile>" "<SheetName>"
	#And I Navigate to SSC > Customers
	#Then I validate user tier gets upgraded to "Green 2" on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                    | ExcelFile                    | SheetName |
		| TC_230_GreenZeroToGreenTwoTierUpgradeValidation | TestDataSSCRegressionUpgrade | G07       |


#232	Verify that the CST is able to create a Complaint ticket for a Customer to upgrade tier from Black to Elite(Manual Tier Upgrade)
@SVCRegression @G07 @232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade
Scenario Outline: TC_232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	#And I create a new Service Ticket
	And I enter all the mandatory details and create ticket for <UserCategory> <ExcelFile> <SheetName>
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	#Then I validate the Customer Tier
	#Then I validate the Customer Tier <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                             | ExcelFile                    | SheetName |
		| TC_232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade | TestDataSSCRegressionUpgrade | G07       |