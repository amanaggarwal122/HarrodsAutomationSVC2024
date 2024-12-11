Feature: SVCOptimizationRegression
	SVC Optimization Test cases. 
	AUT : Harrods.com, SSC, SMC, PreSpa and AC

#G01.01 - Lite Account
@SVCRegression @G01 @001_Lite_account_NewuserSignup
Scenario Outline: 001_Lite_account_NewuserSignup
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	#And I perform SignUp action with a new user from Harrods.com
	And I Perform SignUp action with new user From Harrods.com and write to Input Excelsheet "<ExcelFile>" "<SheetName>" for "<UserCategory>"
	And I perform email validation from yopmail
	Then I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I should validate signed up new user is reflecting on SSC
	#And I close the browser
	#Given I launch the "SMC" website
	#When I Navigate to SMC > Contacts
	#Then I should validate signed up new user is reflecting on SMC
	#And I close the browser

Examples:
		| UserCategory                   | ExcelFile                   | SheetName | TestCase |
		| 001_Lite_account_NewuserSignup | TestDataSVCOptimizationRegn | G01       | TC001    |

@SVCRegression @G01 @003_ReguserFullrewardsSignup
Scenario Outline: 003_ReguserFullrewardsSignup
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	And I perform SignUp action with a reg user full rewards from Harrods.com <UserCategory> <ExcelFile> <SheetName>
	#When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	#And I perform SignUp action with a new user from Harrods.com
	And I perform reg user email validation from yopmail
	Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate signed up with reguser email full rewards were saved on SMC
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate signed up with reguser email full rewards were saved on SSC
	Then I close the browser

	Examples:
		| UserCategory                 | ExcelFile                   | SheetName |
		| 003_ReguserFullrewardsSignup | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @004_UnsubscribeEmailfromFooter
Scenario Outline: 004_UnsubscribeEmailfromFooter
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	And I perform SignUp action with a new user from Harrods.com
	And I click on unsubscribe from email footer
	Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate signed up with new email were saved on SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I should search the Lite customer signed up with new mail in SSC from <UserCategory> <ExcelFile> <SheetName>
	And I validate the lite Account emailid <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| UserCategory                   | ExcelFile                   | SheetName |
		| 004_UnsubscribeEmailfromFooter | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @005_NewNonReward_HarrodsReg_EmailConsentNo
Scenario Outline: 005_NewNonReward_HarrodsReg_EmailConsentNo
	Given I launch the "Harrods" website	
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	#And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                               | ExcelFile                   | SheetName |
		| 005_NewNonReward_HarrodsReg_EmailConsentNo | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes
Scenario Outline: 006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                                | ExcelFile                   | SheetName |
		| 006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @008_ExistingLiteNonReward_HarrodsReg_EmailConsentYes
Scenario Outline: 008_ExistingLiteNonReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                         | ExcelFile                   | SheetName |
		| 008_ExistingLiteNonReward_HarrodsReg_EmailConsentYes | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @009_NewFullReward_HarrodsReg_EmailConsentYes
Scenario Outline: 009_NewFullReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                 | ExcelFile                   | SheetName |
		| 009_NewFullReward_HarrodsReg_EmailConsentYes | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @012_ExistingGoldRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 012_ExistingGoldRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                                         | ExcelFile                   | SheetName |
		| 012_ExistingGoldRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform and validate existing "<UserCategory>" customer from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                                  | ExcelFile                   | SheetName |
		| 015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @017_NewRewardsCard_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 017_NewRewardsCard_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website	
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                            | ExcelFile                   | SheetName |
		| 017_NewRewardsCard_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform and validate existing "<UserCategory>" customer from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                                          | ExcelFile                   | SheetName |
		| 022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @028_NonReward_HarrodsJoinRewardWithoutCardData
Scenario Outline: 028_NonReward_HarrodsJoinRewardWithoutCardData
	Given I launch the "Harrods" website
	When I perform join rewards as "<UserCategory>" from Harrods.com without rewards card data "<ExcelFile>" and "<SheetName>"
	Then I validate user "<UserCategory>" is able to join rewards from Harrods.com without rewards card data "<ExcelFile>" and "<SheetName>"
	And I close the browser
	
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" user from "<ExcelFile>" "<SheetName>" is showing as rewards on SSC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" user from "<ExcelFile>" "<SheetName>" is showing as rewards on SMC
	And I close the browser

	Examples:
		| UserCategory                                   | ExcelFile                   | SheetName |
		| 028_NonReward_HarrodsJoinRewardWithoutCardData | TestDataSVCOptimizationRegn | G01       |
			   
#G01.02 - Online - Full Account - Manage Personal Details
@SVCRegression @G01 @045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber
Scenario Outline: 045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add new "UK" phone number to the user born <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I search for the Customer in SSC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	#And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                                    | ExcelFile                   | SheetName |
		| 045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @046_Verify_existing_loyaltyrewardscustomer_addnewUSmobilenumber
Scenario Outline: 046_Verify_existing_loyaltyrewardscustomer_addnewUSmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add new "US" phone number to the user born <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I search for the Customer in SSC and validate the "US" phonenumber <UserCategory> <ExcelFile> <SheetName>
	#And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                                    | ExcelFile                   | SheetName |
		| 046_Verify_existing_loyaltyrewardscustomer_addnewUSmobilenumber | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber
Scenario Outline: 049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I edit "UK" Phonenumber of the user <ExcelFile> <SheetName> <UserCategory>
	And I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I search for the Customer in SSC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	#And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                               | ExcelFile                   | SheetName |
		| 049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @050_Verify_existing_loyaltyrewardscustomer_editUSmobnumber
Scenario Outline: 050_Verify_existing_loyaltyrewardscustomer_editUSmobnumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I edit "US" Phonenumber of the user <ExcelFile> <SheetName> <UserCategory>
	And I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I search for the Customer in SSC and validate the "US" phonenumber <UserCategory> <ExcelFile> <SheetName>
	#And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                               | ExcelFile                   | SheetName |
		| 050_Verify_existing_loyaltyrewardscustomer_editUSmobnumber | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber
Scenario Outline: 052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I delete the phone number
	And I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I search for the user in SSC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	#And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                        | ExcelFile                   | SheetName |
		| 052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @053_Verify_loyaltyrewardscustomer_DeleteUSmobnumber
Scenario Outline: 053_Verify_loyaltyrewardscustomer_DeleteUSmobnumber
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I delete the phone number
	And I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I search for the user in SSC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	#And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                        | ExcelFile                   | SheetName |
		| 053_Verify_loyaltyrewardscustomer_DeleteUSmobnumber | TestDataSVCOptimizationRegn | G01       |


@SVCRegression @G01 @055_Verify_existing_loyaltyrewardscustomer_AddDOB
Scenario Outline: 055_Verify_existing_loyaltyrewardscustomer_AddDOB
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add DOB for the user <UserCategory> <ExcelFile> <SheetName> 
	And I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I search for the user in SSC and validate whether the DOB is updated <ExcelFile> <SheetName> <UserCategory>
	#And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the DOB is updated <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                      | ExcelFile                   | SheetName |
		| 055_Verify_existing_loyaltyrewardscustomer_AddDOB | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber
Scenario Outline: 059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                           | ExcelFile                   | SheetName |
		| 059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @060_Verify_loyaltyrewardscustomer_addnewUSmobilenumber
Scenario Outline: 060_Verify_loyaltyrewardscustomer_addnewUSmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new "US" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for the customer in Harrods.com and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                           | ExcelFile                   | SheetName |
		| 060_Verify_loyaltyrewardscustomer_addnewUSmobilenumber | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @070_Existing_LoyaltyRewardCustomer_AddUKAddress
Scenario Outline: 070_Existing_LoyaltyRewardCustomer_AddUKAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I add a new address for "<UserCategory>" in Harrods.com "<ExcelFile>" "<SheetName>"
	Then I should validate added address "<UserCategory>" is reflected in Harrods.com "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate added address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                    | ExcelFile                   | SheetName |
		| 070_Existing_LoyaltyRewardCustomer_AddUKAddress | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @071_Existing_LoyaltyRewardCustomer_AdddefaultUSContactAddress
Scenario Outline: 071_Existing_LoyaltyRewardCustomer_AdddefaultUSContactAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I add a new address for "<UserCategory>" in Harrods.com "<ExcelFile>" "<SheetName>"
	Then I should validate added address "<UserCategory>" is reflected in Harrods.com "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate added address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                  | ExcelFile                   | SheetName |
		| 071_Existing_LoyaltyRewardCustomer_AdddefaultUSContactAddress | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @072_Existing_LoyaltyRewardCustomer_EditDefaultUKAddress
Scenario Outline: 072_Existing_LoyaltyRewardCustomer_EditDefaultUKAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I edit address for "<UserCategory>" in Harrods.com "<ExcelFile>" "<SheetName>"
	Then I should validate edited address "<UserCategory>" is reflected in Harrods.com "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate edited address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                            | ExcelFile                   | SheetName |
		| 072_Existing_LoyaltyRewardCustomer_EditDefaultUKAddress | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @075_Existing_LoyaltyRewardsCustomer_SetBillingAddress
Scenario Outline: 075_Existing_LoyaltyRewardsCustomer_SetBillingAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I select address for "<UserCategory>" to be billing address from "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate whether the selected address is marked as Billing Address on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                          | ExcelFile                   | SheetName |
		| 075_Existing_LoyaltyRewardsCustomer_SetBillingAddress | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @078_Existing_NonRewardCustomer_AdddefaultUSContactAddress
Scenario Outline: 078_Existing_NonRewardCustomer_AdddefaultUSContactAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I add a new address for "<UserCategory>" in Harrods.com "<ExcelFile>" "<SheetName>"
	Then I should validate added address "<UserCategory>" is reflected in Harrods.com "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate added address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                              | ExcelFile                   | SheetName |
		| 078_Existing_NonRewardCustomer_AdddefaultUSContactAddress | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @081_Existing_NonRewardsCustomer_DeleteDefaultAddress
Scenario Outline: 081_Existing_NonRewardsCustomer_DeleteDefaultAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I delete address and validate for "<UserCategory>" in Harrods.com "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate deleted address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate deleted address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                         | ExcelFile                   | SheetName |
		| 081_Existing_NonRewardsCustomer_DeleteDefaultAddress | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @083_AddUSAddressFromSSC
Scenario Outline: 083_AddUSAddressFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I add "<Country>" default contact address for "<UserName>" and "<Email>" from SSC
	Then I should validate added "<Country>" address for "<UserName>" and "<Email>" successfully updated on SSC
	And I close the browser
	Given I launch the browser to open the harrods website
	Then I should validate added "<Country>" address for "<UserName>" "<Email>" is showing on Harrods.com
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added "<Country>" address for "<UserName>" "<Email>" is showing on SMC
	And I close the browser

	Examples:
		| Country | UserName                     | Email                 |
		| US      | Autusertbea AutusertbeaLname | autusertbea@gmail.com |

@SVCRegression @G01 @084_AddCanadaAddressFromSSC
Scenario Outline: 084_AddCanadaAddressFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I add "<Country>" default contact address for "<UserName>" and "<Email>" from SSC
	Then I should validate added "<Country>" address for "<UserName>" and "<Email>" successfully updated on SSC
	And I close the browser
	Given I launch the browser to open the harrods website
	Then I should validate added "<Country>" address for "<UserName>" "<Email>" is showing on Harrods.com
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added "<Country>" address for "<UserName>" "<Email>" is showing on SMC
	And I close the browser

	Examples:
		| Country | UserName                     | Email                 |
		| Canada  | Autusergqgw AutusergqgwLname | autusergqgw@gmail.com |


@SVCRegression @G01 @088_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_DeliveryAddressSwap
Scenario Outline: 088_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_DeliveryAddressSwap
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate delivery address can be swaped in SSC from "<UserCategory>" "<ExcelFile>" "<SheetName>"
	#Then I should validate swap address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	#Given I launch the browser to open the harrods website
	#When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	#And I validate that the "DeliveryAddress" addresses can be swaped
	#Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate swap address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                                | ExcelFile                   | SheetName |
		| 088_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_DeliveryAddressSwap | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @089_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_BillingAddressSwap
Scenario Outline: 089_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_BillingAddressSwap
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate delivery address can be swaped in SSC from "<UserCategory>" "<ExcelFile>" "<SheetName>"
	#Then I should validate added address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	#Given I launch the browser to open the harrods website
	#When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	#And I validate that the "BillingAddress" addresses can be swaped
	#Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                               | ExcelFile                   | SheetName |
		| 089_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_BillingAddressSwap | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap
Scenario Outline: 090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate delivery address can be swaped in SSC from "<UserCategory>" "<ExcelFile>" "<SheetName>"
	#Then I should validate added address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	#Given I launch the browser to open the harrods website
	#When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	#And I validate that the "ContactAddress" addresses can be swaped
	#Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                               | ExcelFile                   | SheetName |
		| 090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @091_Create_new_Qatari_staffcustomer_SSC @E2ERun
Scenario: 091_Create_new_Qatari_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Qatari staff for "Bronze" bandgrade
	Then I validate the newly added Qatari staff
	And I close the browser

@SVCRegression @G01 @093_Create_new_Pressperson_staffcustomer_SSC @E2ERun
Scenario: 093_Create_new_Pressperson_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Press person staff
	Then I validate the newly added Press person staff
	And I close the browser

@SVCRegression @G01 @095_Add_Spouse_Civil_Partner_to_staff_SSC @E2ERun
Scenario Outline: 095_Add_Spouse_Civil_Partner_to_staff_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a spouse to the user to staff <spousename>
	Then I validate the spouse added to staff
	And I close the browser

	Examples:
		| spousename   |
		| anand sharma |

@SVCRegression @G01 @096_EnrollToMiniHarrodsFromOnline
Scenario Outline: 096_EnrollToMiniHarrodsFromOnline
	Given I launch the browser to open the harrods website
	When I enroll "<UserName>" "<Email>" to mini harrods from Harrods.com
	Then I should validate enrolled "<UserName>" "<Email>" child is showing on Harrods.com
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate enrolled "<UserName>" "<Email>" child is showing on SMC
	And I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I should validate enrolled "<UserName>" "<Email>" child is showing on SSC
	#And I close the browser
	Given I launch the browser to open the harrods website
	When I remove enrolled child for "<UserName>" "<Email>" from Harrods.com
	Then I close the browser

	Examples:
		| UserName           | Email            |
		| MhUser MhUserLname | MhUser@gmail.com |

@SVCRegression @G01 @097_Existing_LoyaltyRewardsCustomer_AddMultipleChildToCustomerAccount
Scenario Outline: 097_Existing_LoyaltyRewardsCustomer_AddMultipleChildToCustomerAccount
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I click on MiniHarrods
	And I add multiple child in miniharrods from Harrods.com "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should search the customer in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I should validate added multiple child is showing on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added child details are updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                          | ExcelFile                   | SheetName |
		| 097_Existing_LoyaltyRewardsCustomer_AddMultipleChildToCustomerAccount | TestDataSVCOptimizationRegn | G01       |


@SVCRegression @G01 @101_RemoveLastChildFromMiniHarrods
Scenario Outline: 101_RemoveLastChildFromMiniHarrods
	Given I launch the browser to open the harrods website
	When I add another child <UserCategory> <ExcelFile> <SheetName> to mini harrods from Harrods.com
	And I remove last child from Harrods.com
	Then I should validate removed child is not showing on Harrods.com
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate the removed child is not showing on SMC
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate removed child is not showing on SSC
	And I close the browser

	Examples:
		| UserCategory                       | ExcelFile                   | SheetName |
		| 101_RemoveLastChildFromMiniHarrods | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @102_CancelMiniHarrodsSubscription
Scenario Outline: 102_CancelMiniHarrodsSubscription
	Given I launch the browser to open the harrods website
	When I enroll "<UserName>" "<Email>" to mini harrods from Harrods.com
	And I cancel the mini harrods subscription
	Then I should validate mini harrods subscription is cancelled
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate "<UserName>" "<Email>" mini harrods subscription cancelled status is updated on SMC
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate removed child is not showing on SSC
	And I close the browser

	Examples:
		| UserName   | Email                |
		| Minisubscr | Minisubscr@gmail.com |

@SVCRegression @G01 @108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress
Scenario Outline: 108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I edit address for "<UserCategory>" in Harrods.com "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate edited address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                                     | ExcelFile                   | SheetName |
		| 108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress | TestDataSVCOptimizationRegn | G01       |


@SVCRegression @G01 @116_NewUserPrespaRegistrationBookingAndSVCValidation
Scenario Outline: 116_NewUserPrespaRegistrationBookingAndSVCValidation
	Given I launch the browser to open Harrods Beauty Booking
	When I perform booking for "dior_dior_dazzling-eye-treatment" from Harrods Beauty Booking
	Then I should validate user booking details were showing on Harrods Beauty Booking
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate beauty booking customer is showing as verified on SSC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate beauty booking customer is showing as verified on SMC
	And I close the browser

@SVCRegression @G01 @117_BlackTierCustomerPrespaBooking
Scenario Outline: 117_BlackTierCustomerPrespaBooking
	Given I launch the browser to open Harrods Beauty Booking
	When I login to Harrods Beauty Booking application with "<Email>"
	Then I should validate future beauty booking were showing for "<Email>"
	And I should verify user personal details from Harrods Beauty Booking "<UserName>" "<Phone>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify marketing interaction and email for "<UserName>" "<Email>" is generated on SMC
	And I close the browser

	Examples:
		| UserName     | Email                   | Phone      |
		| anand sharma | anandsharma@yopmail.com | 7186417510 |

@SVCRegression @G01 @119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child
Scenario Outline: 119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I click on MiniHarrods
	And I validate more than four child cannot be added in miniharrods from Harrods.com "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate added multiple child is showing on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added child details are updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                   | ExcelFile                   | SheetName |
		| 119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child | TestDataSVCOptimizationRegn | G01       |
			   
@SVCRegression @G01 @147_CST_Resend_the_Verfication_Emails @E2ERun
Scenario Outline: 147_CST_Resend_the_Verfication_Emails
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Search and Send Verification Email to the user <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| ExcelFile                   | SheetName | UserCategory                          |
		| TestDataSVCOptimizationRegn | G01       | 147_CST_Resend_the_Verfication_Emails |

@SVCRegression @G01 @148_CST_Register_FullAccountCustomer_for_MiniHarrods
Scenario Outline: 148_CST_Register_FullAccountCustomer_for_MiniHarrods
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add Child for the user <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate the added child details are updated in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                         | ExcelFile                   | SheetName |
		| 148_CST_Register_FullAccountCustomer_for_MiniHarrods | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @149_CST_Remove_LastChild_from_MiniHarrods
Scenario Outline: 149_CST_Remove_LastChild_from_MiniHarrods
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I remove added child of the user <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate the removed child is not showing on SMC
	And I close the browser

	Examples:
		| UserCategory                              | ExcelFile                   | SheetName |
		| 149_CST_Remove_LastChild_from_MiniHarrods | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @150_CST_CreateFUllRewardsCustomer_NotinSVCDB
Scenario Outline: 150_CST_CreateFUllRewardsCustomer_NotinSVCDB
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new customer <UserCategory> <ExcelFile> <SheetName>
	And I validate whether the user created is a duplicate
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the customer in SMC and validate the Rewards status <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                 | ExcelFile                   | SheetName |
		| 150_CST_CreateFUllRewardsCustomer_NotinSVCDB | TestDataSVCOptimizationRegn | G01       |

#158	Verify that the CST Member is able to add a Customer as "Potential Reseller"
@SVCRegression @G01 @158_CSTMember_Add_Potential_Reseller @E2ERun
Scenario Outline: 158_CSTMember_Add_Potential_Reseller
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Add and validate Potential Reseller Attribute to Customer from <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| UserCategory                         | ExcelFile                   | SheetName |
		| 158_CSTMember_Add_Potential_Reseller | TestDataSVCOptimizationRegn | G01       |

#159	Verify that the CST Member is able to remove a Customer as "Potential private shopping"
@SVCRegression @G01 @159_CSTMember_Remove_Potential_PrivateShopping @E2ERun
Scenario Outline: 159_CSTMember_Remove_Potential_PrivateShopping
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I remove the Private Shopping Attribute of the Customer <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| UserCategory                                   | ExcelFile                   | SheetName |
		| 159_CSTMember_Remove_Potential_PrivateShopping | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @160_CSTMember_UpdateDOBofCsutomer @E2ERun
Scenario Outline: 160_CSTMember_UpdateDOBofCsutomer
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I update DOB of the customer <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| UserCategory                      | ExcelFile                   | SheetName |
		| 160_CSTMember_UpdateDOBofCsutomer | TestDataSVCOptimizationRegn | G01       |

@SVCRegression @G01 @161_Verify_CST_is_ableto_DeleteUKmobilenumber
Scenario Outline: 161_Verify_CST_is_ableto_DeleteUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I delete Phonenumber with <UserCategory> <ExcelFile> <SheetName> in SSC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the phonenumber is removed <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                  | ExcelFile                   | SheetName |
		| 161_Verify_CST_is_ableto_DeleteUKmobilenumber | TestDataSVCOptimizationRegn | G01       |

#162 Verify that the CST Member is able to add the UK Billing Address to the Customer
@SVCRegression @G01 @162_CST_Customer_SetBillingAddress
Scenario Outline: 162_CST_Customer_SetBillingAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I select a non billing address and change it to Billing Address and save in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                       | ExcelFile                   | SheetName |
		| 162_CST_Customer_SetBillingAddress | TestDataSVCOptimizationRegn | G01       |

#163 Verify that the CST Member is able to Delete the Default Contact Address of the Customer
@SVCRegression @G01 @163_CST_Customer_deleteDefaultContactAddress_fromSSC
Scenario Outline: 163_CST_Customer_deleteDefaultContactAddress_fromSSC
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I add a new address for "<UserCategory>" in Harrods.com "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate delete default address from SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I should validate address is deleting "<UserCategory>" "<ExcelFile>" "<SheetName>" on Harrods.com
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate address is deleted from SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                         | ExcelFile                   | SheetName |
		| 163_CST_Customer_deleteDefaultContactAddress_fromSSC | TestDataSVCOptimizationRegn | G01       |

#164 Verify that the CST Member is able to set an address to default billing address
@SVCRegression @G01 @164_CST_Customer_AddDefaultBillingAddress_fromSSC
Scenario Outline: 164_CST_Customer_AddDefaultBillingAddress_fromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I add "<Country>" default contact address for "<UserName>" and "<Email>" from SSC
	Then I should validate added "<Country>" address for "<UserName>" and "<Email>" successfully updated on SSC
	And I close the browser
	Given I launch the browser to open the harrods website
	Then I should validate added "<Country>" address for "<UserName>" "<Email>" is showing on Harrods.com
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added "<Country>" address for "<UserName>" "<Email>" is showing on SMC
	And I close the browser

	Examples:
		| Country | UserName               | Email              |
		| UK      | LoyalUsr LoyalUsrLname | LoyalUsr@gmail.com |

#166	Full non rewards registration from Harrods.com using an email address that does not exist in CDC(with email consent)
@SVCRegression @G02 @166_NonReward_HarrodsReg_EmailConsentYes
Scenario Outline: 166_NonReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	#And I close the browser
	#Given I launch the "AC" website
	#When I Navigate to AC > Reports > Member Reports
	#Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	#And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                             | ExcelFile                   | SheetName |
		| 166_NonReward_HarrodsReg_EmailConsentYes | TestDataSVCOptimizationRegn | G02       |

#167	Full Rewards registration from Harrods.com with an email address that does not exist in CDC (with email consent)
@SVCRegression @G02 @167_FullReward_HarrodsReg_EmailConsentYes
Scenario Outline: 167_FullReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                              | ExcelFile                   | SheetName |
		| 167_FullReward_HarrodsReg_EmailConsentYes | TestDataSVCOptimizationRegn | G02       |

#@SVCRegression @G02 @169_GoldTier10PBookingEmailValidation @E2ERun
#Scenario Outline: 169_GoldTier10PBookingEmailValidation
#	Given I launch the "Harrods" website
#	When I Login to Harrods with <Email>
#	Then I should validate remaining ten percentage count "<RemainingDays>" and booked date "<BookedDate>" from Harrods.com
#	And I close the browser
#	Given I launch the "Yopmail" website
#	When I Login with "<Email>" from yopmail
#	Then I should validate the Tenp email content "<UserName>" from yopmail
#	And I close the browser
#
#	Examples:
#		| UserName | Email                | RemainingDays | BookedDate |
#		| Tenpused | tenpused@yopmail.com | 1 Remaining   | 21st Jun   |

@SVCRegression @G02 @170_MultiMiniHarrodsBirthdayEmailValidation
Scenario Outline: 170_MultiMiniHarrodsBirthdayEmailValidation
	Given I launch the "Harrods" website
	When I Login to Harrods with <Email>
	Then I should validate expected child were showing on mini harrods gris on Harrods.com
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify mini harrods birthday email for "<UserName>" "<Email>" from SMC
	And I close the browser

	Examples:
		| UserName     | Email                    |
		| Hbdmultimini | Hbdmultimini@yopmail.com |

@SVCRegression @G02 @172_GoldTenpDayTwoOnlineSelectEmailCheck
Scenario Outline: 172_GoldTenpDayTwoOnlineSelectEmailCheck
	Given I launch the "Harrods" website
	When I Login to Harrods with <Email>
	And I select a date for Tenp discount second day from Harrods.com
	Then I validate selected Tenp discount second day is showing on Harrods.com
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate selected Tenp discount second day "<UserName>" "<Email>" interaction is showing on SMC
	And I close the browser
	Given I launch the "Harrods" website
	When I Login to Harrods with <Email>
	And I cancel the selected Tenp discount second day from Harrods.com
	Then I close the browser

	Examples:
		| UserName              | Email                           |
		| PrimaryUsrhtm LNXRXNW | PrimaryUsrhtm11292022@gmail.com |

@SVCRegression @G02 @179_HarrodsRegistrationForLiteCustomerWithEmailConsentYes
Scenario Outline: 179_HarrodsRegistrationForLiteCustomerWithEmailConsentYes
	Given I launch the "Harrods" website
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	And I perform Welcome email validation from yopmail "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                              | ExcelFile                   | SheetName |
		| 179_HarrodsRegistrationForLiteCustomerWithEmailConsentYes | TestDataSVCOptimizationRegn | G02       |

@SVCRegression @G02 @183_HarrodsBirthdayEmailValidation
Scenario Outline: 183_HarrodsBirthdayEmailValidation
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify happy birthday email for "<UserName>" "<Email>" from SMC
	And I close the browser

	Examples:
		| UserName                     | Email                   |
		| Hbdcampaign HbdcampaignLname | Hbdcampaign@yopmail.com |

#| ZORANA YOUNG   | zorana.young.1330940@harrods.proctortech.com |
#| Hbdgreentierchk HbdgreentierchkLname | Hbdgreentierchk@yopmail.com |
@SVCRegression @G02 @184_Goldcustomercancelled_slot_previouslybooked_tenpercentDiscountDay
Scenario Outline: 184_Goldcustomercancelled_slot_previouslybooked_tenpercentDiscountDay
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I validate ten percent discount"<BookingDate>" can be cancelled for previously booked discount day "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate cancelled status is updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate cancelled status is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                          | ExcelFile                   | SheetName | BookingDate     |
		| 184_Goldcustomercancelled_slot_previouslybooked_tenpercentDiscountDay | TestDataSVCOptimizationRegn | G02       | Fri Jun 24 2022 |


#249	Verify the Black tier customer is able to cancel the 2nd slot(Day 2) of  previously booked 10% discount day from Harrods.com
@SVCRegression @G15 @249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct
Scenario Outline: 249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I verify whether 10 percent discount is displayed to user
	And I cancel Day 2 slot and check remaining count
	And I close the browser
	#Given I launch the "AC" website
	#When I Navigate to AC > Reports > Member Reports
	#Then I validate whether 10 percent discount is displayed in the Recent activities
	#And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate cancelled status is updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate cancelled status is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| ExcelFile                   | SheetName | UserCategory                                           |
		| TestDataSVCOptimizationRegn | G15       | 249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct |

#250	Verify the Black tier customer is able to book 1st slot(Day 1)of 10% discount day again from Harrods.com, after cancellation of the same date.
@SVCRegression @G15 @250_BlackTierCustomer_Book_1st_slot_aftercancellation
Scenario Outline: 250_BlackTierCustomer_Book_1st_slot_aftercancellation
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I verify whether 10 percent discount is displayed to user
	And I cancel Day 2 slot and check remaining count
	And I reselect the Ten percent discount for the user
	And I close the browser
	#Given I launch the "AC" website
	#When I Navigate to AC > Reports > Member Reports
	#Then I validate the discount booking date in AC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	#And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate cancelled status is updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I validate whether the 10 percent discount is updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate cancelled status is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I should whether the 10 percent discount is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| ExcelFile                   | SheetName | UserCategory                                          |
		| TestDataSVCOptimizationRegn | G15       | 250_BlackTierCustomer_Book_1st_slot_aftercancellation |

#251	Verify CST advisor is able cancel the  second slot of 10% discount day date booked from SSC on Black tier customer request.
@SVCRegression @G15 @251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest
Scenario Outline: 251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate the count of Ten percent discount days in SSC <UserCategory> <ExcelFile> <SheetName>
	And I create a Cancellation Request Ticket of SlotTwo for the Customer <UserCategory> <ExcelFile> <SheetName> and validate the remaining slots
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate cancelled status is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	#Given I launch the "AC" website
	#When I Navigate to AC > Reports > Member Reports
	#Then I validate the cancellation status in AC <UserCategory> <ExcelFile> <SheetName>
	#And I close the browser
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I verify the cancellation is updated in harrods website for the customer
	And I close the browser

	Examples:
		| ExcelFile                   | SheetName | UserCategory                                                       |
		| TestDataSVCOptimizationRegn | G15       | 251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest |


#277	Verify that the CST is able to Obsolete the Customer's record in SSC based on GDPR
@SVCRegression @G10 @277_VerifyCSTObsoleteCustomerFromSSC @E2ERun
Scenario Outline: 277_VerifyCSTObsoleteCustomerFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I update the given user in the <UserCategory> <ExcelFile> <SheetName> to "Set As Obsolete" from SSC
	Then I should verify obsolete status on SSC is "Yes"
	When I update the given user in the <UserCategory> <ExcelFile> <SheetName> to "Set As Active" from SSC
	Then I close the browser

	Examples:		
		| UserCategory                         | ExcelFile                   | SheetName |
		| 277_VerifyCSTObsoleteCustomerFromSSC | TestDataSVCOptimizationRegn | G10       |

#286	Verify the Gold tier customer is able to book the 1st slot(Day 1) of 10% discount day from Harrods.com.
@SVCRegression @G15 @286_GoldTierCustomerTenpOnlineDayOneBooking
Scenario Outline: 286_GoldTierCustomerTenpOnlineDayOneBooking
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	And I select a date for Tenp discount for day one from Harrods.com
	Then I validate selected Tenp discount for day one is showing on Harrods.com
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate selected Tenp discount for day one <UserCategory> <ExcelFile> <SheetName> interaction is showing on SMC
	And I close the browser
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	And I cancel the selected Tenp discount for day one from Harrods.com
	Then I close the browser

	Examples:
		| UserCategory                                | ExcelFile                   | SheetName |
		| 286_GoldTierCustomerTenpOnlineDayOneBooking | TestDataSVCOptimizationRegn | G15       |


@SVCRegression @G15 @287_EliteTierCustomerTenpOnlineDayOneBooking
Scenario Outline: 287_EliteTierCustomerTenpOnlineDayOneBooking
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	And I select a date for Tenp discount for day one from Harrods.com
	Then I validate selected Tenp discount for day one is showing on Harrods.com
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate selected Tenp discount for day one <UserCategory> <ExcelFile> <SheetName> interaction is showing on SMC
	And I close the browser
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	And I cancel the selected Tenp discount for day one from Harrods.com
	Then I close the browser

	Examples:
		| UserCategory                                 | ExcelFile                   | SheetName |
		| 287_EliteTierCustomerTenpOnlineDayOneBooking | TestDataSVCOptimizationRegn | G15       |
