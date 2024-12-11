Feature: CST_CustomerAndPoints_Regression


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

@SVCRegression @G07 @222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC
Scenario Outline: TC_222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I create staff enquiry ticket for customer miscellaneous point addition <UserCategory> <ExcelFile> <SheetName>
	When I Navigate to SSC > Customers
	Then I validate user is added with "Miscellaneous" points on SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName |
		| TC_222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC | TestDataSSCRegressionUpgrade | G07       |

#Verify that the CST is able to create a Complaint ticket for a Customer (Status Points)
@SVCRegression @G07 @223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC
Scenario Outline: TC_223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I create complaint ticket for customer status point addition <UserCategory> <ExcelFile> <SheetName>
	When I Navigate to SSC > Customers
	Then I validate user is added with "Status Points" points on SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                           | ExcelFile                    | SheetName |
		| TC_223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC | TestDataSSCRegressionUpgrade | G07       |



@SVCRegression @G07 @231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC
Scenario Outline: TC_231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I create complaint ticket for customer extend point addition <UserCategory> <ExcelFile> <SheetName>
	When I Navigate to SSC > Customers
	Then I validate user is added with "Extend Points" points on SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                           | ExcelFile                    | SheetName |
		| TC_231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC | TestDataSSCRegressionUpgrade | G07       |

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
