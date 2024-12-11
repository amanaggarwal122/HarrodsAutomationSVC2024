Feature: SSC Regression Validation cases

#Full non rewards registration from Harrods.com using an email address that does not exist in CDC(with email consent)
@SVCRegression @G01 @005A_NewNonReward_HarrodsReg_EmailConsentNo
Scenario Outline: TC_005A_NewNonReward_HarrodsReg_EmailConsentNo
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                  | ExcelFile                    | SheetName |
		| TC_005_NewNonReward_HarrodsReg_EmailConsentNo | TestDataSSCRegressionUpgrade | G01       |

#Full non rewards registration from Harrods.com using an email address that belongs to existing non-loyalty customer (with email consent)
@SVCRegression @G01 @006A_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_006A_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                   | ExcelFile                    | SheetName |
		| TC_006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com with an email address that does not exist in CDC (with email consent)
@SVCRegression @G01 @009A_NewFullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_009A_NewFullReward_HarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                    | ExcelFile                    | SheetName |
		| TC_009_NewFullReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com with an email address that belongs to existing non-loyalty customer (with email consent)
@SVCRegression @G01 @010A_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_010A_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                    | ExcelFile                    | SheetName |
		| TC_010_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com with an email address that belongs to existing rewards customer with BL tier
@SVCRegression @G01 @013A_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_013A_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                             | ExcelFile                    | SheetName |
		| TC_013_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com with an email address that belongs to existing lite account customer (with email consent)
@SVCRegression @G01 @015A_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_015A_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes
	#Lite Use willnot display in SSC and AC as per latest functionality so commenting SSC ,AC the validation
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	#And I close the browser window
	#Given I launch the "AC" website
	#When I Navigate to AC > Reports > Member Reports
	#Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	#And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                     | ExcelFile                    | SheetName |
		| TC_015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com by providing rewards card and email address that does not exist in CDC
@SVCRegression @G01 @017A_NewRewardsCard_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_017A_NewRewardsCard_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                               | ExcelFile                    | SheetName |
		| TC_017_NewRewardsCard_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com by providing :-
#•email address that does not exist in CDC
#•rewards card that belongs to existing ghost account with G2 tier points
@SVCRegression @G01 @023A_ExistingGhostGreen2UserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_023A_ExistingGhostGreen2UserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                                    | ExcelFile                    | SheetName |
		| TC_023_ExistingGhostGreen2UserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @028_NonReward_HarrodsJoinRewardWithoutCardData
Scenario Outline: TC_028A_NonReward_HarrodsJoinRewardWithoutCardData
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" user from "<ExcelFile>" "<SheetName>" is showing as rewards on SSC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" user from "<ExcelFile>" "<SheetName>" is showing as rewards on SMC
	And I close the browser window

	Examples:
		| UserCategory                                      | ExcelFile                    | SheetName |
		| TC_028_NonReward_HarrodsJoinRewardWithoutCardData | TestDataSSCRegressionUpgrade | G01       |

#Verify existing non rewards customer is able to join rewards from Harrods.com using a ghost card with enough transactions to get rewards points >10000
#Fill data in test data sheet
@SVCRegression @G01 @029_NonReward_HarrodsJoinRewardWithGhostPremiumPointsCard
Scenario Outline: TC_029A_NonReward_HarrodsJoinRewardWithGhostPremiumPointsCard
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" user from "<ExcelFile>" "<SheetName>" is showing as rewards on SSC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" user from "<ExcelFile>" "<SheetName>" is showing as rewards on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                 | ExcelFile                    | SheetName |
		| TC_029_NonReward_HarrodsJoinRewardWithGhostPremiumPointsCard | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty rewards(G2) customer signs in and changes the preference channel from Email to SMS and makes a mixed selection of interests  (Customer has mobile number)
@SVCRegression @G01 @105_Reg_LoyaltyRewardCustomer_EnableSMSconsentYes_MixedSelectionOnInterests
Scenario Outline: TC_105A_Reg_LoyaltyRewardCustomer_EnableSMSconsentYes_MixedSelectionOnInterests
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Customer Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Customer Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser window

	Examples:
		| UserCategory                                                                   | ExcelFile                    | SheetName | channel |
		| TC_105_Reg_LoyaltyRewardCustomer_EnableSMSconsentYes_MixedSelectionOnInterests | TestDataSSCRegressionUpgrade | G01       | SMS     |

#Verify if the user is able to add a default UK contact address as a first address for a loyalty rewards customer in CDC
@SVCRegression @G01 @082_AddUKAddressFromSSC
Scenario Outline: TC_082A_AddUKAddressFromSSC
	Given I launch the "Harrods" website
	Then I should validate added "<Country>" address for <UserCategory> <ExcelFile> <SheetName> is showing on Harrods.com
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added "<Country>" address for <UserCategory> <ExcelFile> <SheetName> is showing on SMC
	And I close the browser window

	Examples:
		| UserCategory               | ExcelFile                    | SheetName | Country |
		| TC_082_AddUKAddressFromSSC | TestDataSSCRegressionUpgrade | G01       | UK      |

#| Country | UserName | Email              |
#| UK      | LoyalUsr | LoyalUsr@gmail.com |
#Verify if the user is able to add new UK mobile number for a loyalty rewards customer
@SVCRegression @G01 @059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber
Scenario Outline: TC_059A_Verify_loyaltyrewardscustomer_addnewUKmobilenumber
	#Given I launch the "Harrods" website
	#When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	#Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	#And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                              | ExcelFile                    | SheetName |
		| TC_059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to add new US mobile number for a loyalty rewards customer
@SVCRegression @G01 @060_Verify_loyaltyrewardscustomer_addnewUSmobilenumber
Scenario Outline: TC_060A_Verify_loyaltyrewardscustomer_addnewUSmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for the customer in Harrods.com and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                              | ExcelFile                    | SheetName |
		| TC_060_Verify_loyaltyrewardscustomer_addnewUSmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to edit UK mobile number for a loyalty rewards customer
@SVCRegression @G01 @062_Verify_loyaltyrewardscustomer_editUKmobilenumber
Scenario Outline: TC_062A_Verify_loyaltyrewardscustomer_editUKmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                            | ExcelFile                    | SheetName |
		| TC_062_Verify_loyaltyrewardscustomer_editUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to edit non UK mobile number for a loyalty rewards customer
@SVCRegression @G01 @063_Verify_loyaltyrewardscustomer_editUSmobilenumber
Scenario Outline: TC_063A_Verify_loyaltyrewardscustomer_editUSmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for the customer in Harrods.com and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                            | ExcelFile                    | SheetName |
		| TC_063_Verify_loyaltyrewardscustomer_editUSmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to delete UK mobile number for a loyalty rewards customer
@SVCRegression @G01 @064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber
Scenario Outline: TC_064A_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                              | ExcelFile                    | SheetName |
		| TC_064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to add new UK mobile number for a non rewards customer
@SVCRegression @G01 @067_Verify_nonrewardscustomer_addnewUKmobilenumber
Scenario Outline: TC_067A_Verify_nonrewardscustomer_addnewUKmobilenumber
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                          | ExcelFile                    | SheetName |
		| TC_067_Verify_nonrewardscustomer_addnewUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to edit UK mobile number for a non rewards customer
@SVCRegression @G01 @068_Verify_nonrewardscustomer_editUKmobilenumber
Scenario Outline: TC_068A_Verify_nonrewardscustomer_editUKmobilenumber
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName |
		| TC_068_Verify_nonrewardscustomer_editUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to delete UK mobile number for a non rewards customer
@SVCRegression @G01 @069_Verify_nonrewardscustomer_DeleteUKmobilenumber
Scenario Outline: TC_069A_Verify_nonrewardscustomer_DeleteUKmobilenumber
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                          | ExcelFile                    | SheetName |
		| TC_069_Verify_nonrewardscustomer_DeleteUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to add default Canada contact address for a loyalty rewards customer in CDC
@SVCRegression @G01 @084_AddCanadaAddressFromSSC
Scenario Outline: TC_084A_AddCanadaAddressFromSSC
	Given I launch the "Harrods" website
	Then I should validate added "<Country>" address for <UserCategory> <ExcelFile> <SheetName> is showing on Harrods.com
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added "<Country>" address for <UserCategory> <ExcelFile> <SheetName> is showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                   | ExcelFile                    | SheetName | Country |
		| TC_084_AddCanadaAddressFromSSC | TestDataSSCRegressionUpgrade | G01       | Canada  |

#Verify if the user is able to edit a UK Contact address for a loyalty rewards customer
@SVCRegression @G01 @085_EditUKAddressFromSSC
Scenario Outline: TC_085A_EditUKAddressFromSSC
	Given I launch the "Harrods" website
	Then I should validate edited "<Country>" address for <UserCategory> <ExcelFile> <SheetName> is showing on Harrods.com
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited "<Country>" address for <UserCategory> <ExcelFile> <SheetName> is showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                | ExcelFile                    | SheetName | Country |
		| TC_085_EditUKAddressFromSSC | TestDataSSCRegressionUpgrade | G01       | UK      |

#Verify if the user is able to edit a non UK Contact address for a loyalty rewards customer
@SVCRegression @G01 @086_EditNonUKAddressFromSSC
Scenario Outline: TC_086A_EditNonUKAddressFromSSC
	Given I launch the "Harrods" website
	Then I should validate edited "<Country>" address for <UserCategory> <ExcelFile> <SheetName> is showing on Harrods.com
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited "<Country>" address for <UserCategory> <ExcelFile> <SheetName> is showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                   | ExcelFile                    | SheetName | Country |
		| TC_086_EditNonUKAddressFromSSC | TestDataSSCRegressionUpgrade | G01       | Canada    |

#Verify if the user is able to swap contact address from address 1 to address 2 for a loyalty rewards customer
@SVCRegression @G01 @090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap
Scenario Outline: TC_090A_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I validate that the "ContactAddress" addresses can be swaped <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                                  | ExcelFile                    | SheetName |
		| TC_090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com by providing :-
#•valid rewards card that does not exist in CDC
#•email address that belongs to existing non-loyalty customer(without email consent)
@SVCRegression @G01 @018_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo
Scenario Outline: TC_018A_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                                 | ExcelFile                    | SheetName |
		| TC_018_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com by providing :-
#•email address that does not exist in CDC
#•rewards card that belongs to existing thin account(GD tier)
@SVCRegression @G01 @022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_022A_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                             | ExcelFile                    | SheetName |
		| TC_022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com by providing :-
#•email address that does not exist in CDC
#•rewards card that belongs to existing ghost account with GD tier points
@SVCRegression @G01 @024_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_024A_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                                  | ExcelFile                    | SheetName |
		| TC_024_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#
#Full rewards registration from Harrods.com by providing :-
#•email address that does not exist in CDC
#•rewards card that belongs to another full registered customer
@SVCRegression @G01 @025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_025A_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                                    | ExcelFile                    | SheetName |
		| TC_025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Non rewards customer signs in to Harrods.com and provides consent for Post channel (Customer doesn't have contact address added)
@SVCRegression @G01 @035_Reg_NonRewardCustomer_EnablePostalConsent_Yes
Scenario Outline: TC_035A_Reg_NonRewardCustomer_EnablePostConsent_Yes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Non RewardCustomer Enable PostalConsent reflected in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Non RewardCustomer Enable PostalConsent reflected in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                         | ExcelFile                    | SheetName | channel |
		| TC_035_Reg_NonRewardCustomer_EnablePostalConsent_Yes | TestDataSSCRegressionUpgrade | G01       | postal  |

#Non rewards customer signs in to Harrods.com updates the channel consent from Email to SMS and makes a mixed selection on interests
@SVCRegression @G01 @038_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests
Scenario Outline: TC_038A_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Non RewardCustomer Enable phoneConsent reflected in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Non RewardCustomer Enable phoneConsent reflected in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                                      | ExcelFile                    | SheetName | channel |
		| TC_038_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests | TestDataSSCRegressionUpgrade | G01       | phone   |

#Loyalty rewards(G0/G1) customer provides consent for Post channel and Harrods magazine
@SVCRegression @G01 @040_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine
Scenario Outline: TC_040A_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser window

	Examples:
		| UserCategory                                                          | ExcelFile                    | SheetName | channel |
		| TC_040_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine | TestDataSSCRegressionUpgrade | G01       | postal  |

#Loyalty rewards(Gold/Black/Elite)  customer provides consent for Email channel
@SVCRegression @G01 @041_Loyaltyrewards_Goldcustomer_EmailConsent_Yes
Scenario Outline: TC_041A_Loyaltyrewards_Goldcustomer_EmailConsent_Yes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName | channel |
		| TC_041_Loyaltyrewards_Goldcustomer_EmailConsent_Yes | TestDataSSCRegressionUpgrade | G01       | email   |

#Verify if existing loyalty rewards customer is able to add new UK mobile number
@SVCRegression @G01 @045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber
Scenario Outline: TC_045A_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                       | ExcelFile                    | SheetName |
		| TC_045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty rewards customer is able to edit UK mobile number
@SVCRegression @G01 @049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber
Scenario Outline: TC_049A_Verify_existing_loyaltyrewardscustomer_editUKmobnumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                  | ExcelFile                    | SheetName |
		| TC_049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber | TestDataSSCRegressionUpgrade | G01       |

	
#Verify if existing loyalty rewards customer is able to delete UK mobile number
#05-August-2024 : We need to change script to validate phone number deletion on SMC -Phone number will not get deleted on SMC
@SVCRegression @G01 @052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber
Scenario Outline: TC_052A_Verify_loyaltyrewardscustomer_DeleteUKmobnumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the user in SSC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                           | ExcelFile                    | SheetName |
		| TC_052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty rewards customer is able to add DOB
@SVCRegression @G01 @055_Verify_existing_loyaltyrewardscustomer_AddDOB
Scenario Outline: TC_055A_Verify_existing_loyaltyrewardscustomer_AddDOB
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the user in SSC and validate whether the DOB is updated <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the DOB is updated <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                         | ExcelFile                    | SheetName |
		| TC_055_Verify_existing_loyaltyrewardscustomer_AddDOB | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty rewards customer is able to add UK address
@SVCRegression @070_Existing_LoyaltyRewardCustomer_AddUKAddress
Scenario Outline: TC_070A_Existing_LoyaltyRewardCustomer_AddUKAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate added "UK" address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                       | ExcelFile                    | SheetName |
		| TC_070_Existing_LoyaltyRewardCustomer_AddUKAddress | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing Loyalty rewards customer is able to delete default contact address
@SVCRegression @G01 @073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress
Scenario Outline: TC_073A_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate deleted address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate deleted address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                | ExcelFile                    | SheetName |
		| TC_073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing Loyalty rewards(Gold/black/elite) customer signed up for Mini Harrods and selected Harrods magazine subscription channel is able to remove all the channel consent
@SVCRegression @G01 @107_Loyaltyrewards_Gold/black/Elitecustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent
Scenario Outline: TC_107A_Loyaltyrewards_Gold/black/Elitecustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent remove all consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent remove all consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser window

	Examples:
		| UserCategory                                                                                                      | ExcelFile                    | SheetName | channel |
		| TC_107_Loyaltyrewards_Gold/black/Elitecustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent | TestDataSSCRegressionUpgrade | G01       | postal  |

#Verify if existing loyalty customer is able to edit City,State,Postal code in the default contact address
@SVCRegression @G01 @108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress
Scenario Outline: TC_108A_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate edited address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                                        | ExcelFile                    | SheetName |
		| TC_108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty(G0/G1) rewards customer is able to provide consent for post channel and Harrods magazine
@SVCRegression @G01 @109_Loyaltyrewards_G0/G1customer_PostalandMagazineConsent_Yes
Scenario Outline: TC_109A_Loyaltyrewards_G0/G1customer_PostalandMagazineConsent_Yes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser window

	Examples:
		| UserCategory                                                     | ExcelFile                    | SheetName | channel |
		| TC_109_Loyaltyrewards_G0/G1customer_PostalandMagazineConsent_Yes | TestDataSSCRegressionUpgrade | G01       | postal  |

#Verify if existing Loyalty rewards customer is able to swap the default delivery address from one address to another
@SVCRegression @G01 @110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress
Scenario Outline: TC_110A_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate swap "DeliveryAddress" address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate swap address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                      | ExcelFile                    | SheetName |
		| TC_110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress | TestDataSSCRegressionUpgrade | G01       |

#Create Qatari staff customer(Qatari Holdings) via SC with new payroll number and verify the details in SAP CDC
@SVCRegression @G01 @091_Create_new_Qatari_staffcustomer_SSC @E2ERun
Scenario: TC_091_Create_new_Qatari_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Qatari staff for "Bronze" bandgrade
	Then I validate the newly added Qatari staff
	And I close the browser window

#Create Al Fayed customer via SC with new payroll number and verify the details in SAP CDC
@SVCRegression @G01 @092_Create_new_AlFayad_staffcustomer_SSC @E2ERun
Scenario: TC_092_Create_new_AlFayad_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new AlFayad staff "Orange"
	Then I validate the newly added AlFayad staff
	And I close the browser window

#Create new press person from SC and validate the details in CDC
@SVCRegression @G01 @093_Create_new_Pressperson_staffcustomer_SSC @E2ERun
Scenario: TC_093_Create_new_Pressperson_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Press person staff
	Then I validate the newly added Press person staff
	And I close the browser window

#Create new Interior Design person from SC and validate the details in CDC
@SVCRegression @G01 @094_Create_new_InteriorDesignperson_staffcustomer_SSC @E2ERun
Scenario: TC_094_Create_new_InteriorDesignperson_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Interior Design person staff
	Then I validate the newly added Interior Design person staff
	And I close the browser window

#Add New Spouse/Civil Partner to a staff account from SAP SC
@SVCRegression @G01 @095_Add_Spouse_Civil_Partner_to_staff_SSC @E2ERun
Scenario Outline: TC_095_Add_Spouse_Civil_Partner_to_staff_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a spouse to the user to staff <spousename>
	Then I validate the spouse added to staff
	And I close the browser window

	Examples:
		| spousename |
		| VIKRAM Aljaberi |

#Create Qatari staff customer(Qatari Board VIP) via SC with new payroll number and verify the details in SAP CDC
@SVCRegression @G01 @270_Create_new_QatariVIP_staffcustomer_SSC @E2ERun
Scenario: TC_270_Create_new_QatariVIP_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Qatari staff for "Gold" bandgrade
	And I validate the newly added Qatari staff
	And I close the browser window

#Create new Privileged discount customer from SC and validate the details in CDC
@SVCRegression @G01 @271_Create_new_PrivilegedDiscount_staffcustomer_SSC @E2ERun
Scenario: TC_271_Create_new_PrivilegedDiscount_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new Privileged Discount customer
	And I validate the newly added Privileged Discount staff
	And I close the browser window

@SVCRegression @G01 @151A_CST_Replace_StolenCard
Scenario Outline: TC_151A_CST_Replace_StolenCard
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for customer in SMC and validate the Reward Card <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                  | ExcelFile                    | SheetName |
		| TC_151_CST_Replace_StolenCard | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @152A_CST_Deactivate_activecard_with_InvalidCardID
Scenario Outline: TC_152A_CST_Deactivate_activecard_with_InvalidCardID
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for customer in SMC and validate Reward Card <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName |
		| TC_152_CST_Deactivate_activecard_with_InvalidCardID | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @153_CST_ChangeName_inCard_SSC_resendto_CustomerUKAddress @E2ERun
Scenario Outline: TC_153_CST_ChangeName_inCard_SSC_resendto_CustomerUKAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I edit the name in Card for the customer <UserCategory> <ExcelFile> <SheetName>
	And I verify whether the Name in Card is changed for the customer <UserCategory> <ExcelFile> <SheetName>
	Then I send the New card to the customer
	And I close the browser window

	Examples:
		| UserCategory                                                | ExcelFile                    | SheetName |
		| TC_153_CST_ChangeName_inCard_SSC_resendto_CustomerUKAddress | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @154_CST_CardReplenishment_Jobs @E2ERun
Scenario Outline: TC_154_CST_CardReplenishment_Jobs
	Given I launch the "SSC" website
	When I Navigate to SSC > CardManagement  > Replenishment
	And I create a new Card Replenishment job with <UserCategory> <ExcelFile> <SheetName>
	Then I validate the status of the job <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                      | ExcelFile                    | SheetName |
		| TC_154_CST_CardReplenishment_Jobs | TestDataSSCRegressionUpgrade | G01       |

#Descoped as per Bug 152374
@Ignore @SVCRegression @G01 @155A_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack
Scenario Outline: TC_155A_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I Validate whether the deemed customer is not available in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate whether the deemed user is not found in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                         | ExcelFile                    | SheetName |
		| TC_155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack | TestDataSSCRegressionUpgrade | G01       |
#Descoped as per Bug 152374
@ignore @SVCRegression @G01 @156A_Merge_TwoAccounts_AndRegisterDeemedUser
Scenario Outline: TC_156A_Merge_TwoAccounts_AndRegisterDeemedUser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I Validate whether the deemed customer is not available in SSC <UserCategory> <ExcelFile> <SheetName>
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate whether the deemed user is not found in SMC <UserCategory> <ExcelFile> <SheetName>
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	And I perform SignUp action with a reg user full rewards from Harrods.com <UserCategory> <ExcelFile> <SheetName>
	And I perform reg user email validation from yopmail
	Then I close the browser window

	Examples:
		| UserCategory                                   | ExcelFile                    | SheetName |
		| TC_156_Merge_TwoAccounts_AndRegisterDeemedUser | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @157_CSTMember_SearchExistCustomer_EmailAddress @E2ERun
Scenario Outline: TC_157_CSTMember_SearchExistCustomer_EmailAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search the Customer email and validate in SSC <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window

	Examples:
		| UserCategory                                      | ExcelFile                    | SheetName |
		| TC_157_CSTMember_SearchExistCustomer_EmailAddress | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @158_CSTMember_Add_Potential_Reseller @E2ERun
Scenario Outline: TC_158_CSTMember_Add_Potential_Reseller
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Add and validate Potential Reseller Attribute to Customer from <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window

	Examples:
		| UserCategory                            | ExcelFile                    | SheetName |
		| TC_158_CSTMember_Add_Potential_Reseller | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @159_CSTMember_Remove_Potential_PrivateShopping @E2ERun
Scenario Outline: TC_159_CSTMember_Remove_Potential_PrivateShopping
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I remove the Private Shopping Attribute of the Customer <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window

	Examples:
		| UserCategory                                      | ExcelFile                    | SheetName |
		| TC_159_CSTMember_Remove_Potential_PrivateShopping | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @160_CSTMember_UpdateDOBofCsutomer @E2ERun
Scenario Outline: TC_160_CSTMember_UpdateDOBofCsutomer
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I update the <DOB> of the customer <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window

	Examples:
		| UserCategory                         | ExcelFile                    | SheetName | DOB        |
		| TC_160_CSTMember_UpdateDOBofCsutomer | TestDataSSCRegressionUpgrade | G01       | 01.07.1994 |

@SVCRegression @G01 @162A_CST_Customer_SetBillingAddress
Scenario Outline: TC_162A_CST_Customer_SetBillingAddress
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                          | ExcelFile                    | SheetName |
		| TC_162_CST_Customer_SetBillingAddress | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @116_NewUserPrespaRegistrationBookingAndSVCValidation
Scenario Outline: TC_116_NewUserPrespaRegistrationBookingAndSVCValidation
	Given I launch the "BeautyBooking" website
	When I perform booking for "dior_dior_dazzling-eye-treatment" from Harrods Beauty Booking
	Then I should validate user booking details were showing on Harrods Beauty Booking
	And I close the browser window
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate beauty booking customer is showing as verified on SSC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate beauty booking customer is showing as verified on SMC
	And I close the browser window

@SVCRegression @G01 @113_CustomerInstoreBookingByHAndB
Scenario Outline: TC_113_CustomerInstoreBookingByHAndB
	Given I launch the "BeautyBooking" website
	When I login to Harrods Beauty Booking application with "<Email>"
	Then I should validate future beauty booking were showing for "<Email>"
	And I should verify user personal details from Harrods Beauty Booking "<UserName>" "<Phone>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify marketing interaction and email for "<UserName>" "<Email>" is generated on SMC
	And I close the browser window

	Examples:
		| UserName   | Email                 | Phone     |
		| ATbeautybooking User | ATBeautybooking_SSC@yopmail.com | 7363042708 |

@SVCRegression @G01 @114_VerifyBeautyBookingPerformedUser @E2ERun
Scenario Outline: TC_114_VerifyBeautyBookingPerformedUser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify given prespa "<UserName>" "<Email>" and "<Phone>" details were showing on SSC
	And I close the browser window

	Examples:
		| UserName      | Email                 | Phone      |
		| TestBb UserBb | bbqauser1@yopmail.com | 8787673647 |

@SVCRegression @G01 @117_BlackTierCustomerPrespaBooking
Scenario Outline: TC_117_BlackTierCustomerPrespaBooking
	Given I launch the "BeautyBooking" website
	When I login to Harrods Beauty Booking application with "<Email>"
	Then I should validate future beauty booking were showing for "<Email>"
	And I should verify user personal details from Harrods Beauty Booking "<UserName>" "<Phone>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify marketing interaction and email for "<UserName>" "<Email>" is generated on SMC
	And I close the browser window

	Examples:
		| UserName   | Email                 | Phone     |
		| tanson her | tansonher@yopmail.com | 899999999 |

@SVCRegression @G01 @096A_EnrollToMiniHarrodsFromOnline
Scenario Outline: TC_096A_EnrollToMiniHarrodsFromOnline
	##Given I launch the "SMC" website
	##When I Navigate to SMC > Contacts
	##Then I should validate enrolled "<UserName>" "<Email>" child is showing on SMC
	##And I close the browser window
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate enrolled "<UserName>" "<Email>" child is showing on SSC
	And I close the browser window
	Given I launch the "Harrods" website
	When I remove enrolled child for "<UserName>" "<Email>" from Harrods.com
	Then I close the browser window

	Examples:
		| UserName | Email       |
		#        | enroll mini | enrollmini@gmail.com |
	   |  Auto-TC-ninetysix MiniHarrods | Auto-TC-ninetysixMini@gmail.com| 

@SVCRegression @G01 @100A_Edit/remove_MiniHarrodsinterest_of_customer_through_Harrods
Scenario Outline: TC_100A_Edit/remove_MiniHarrodsinterest_of_customer_through_Harrods
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate remove miniharrods Interest updated on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate remove miniharrods Interest updated on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                       | ExcelFile                    | SheetName |
		| TC_100_Edit/remove_MiniHarrodsinterest_of_customer_through_Harrods | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @102_CancelMiniHarrodsSubscription
Scenario Outline: TC_102_CancelMiniHarrodsSubscription
	Given I launch the "Harrods" website
	When I enroll "<UserName>" "<Email>" to mini harrods from Harrods.com
	And I cancel the mini harrods subscription
	Then I should validate mini harrods subscription is cancelled
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate "<UserName>" "<Email>" mini harrods subscription cancelled status updated on SMC
	And I close the browser window
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate removed child "<UserName>" is not showing on SSC
	And I close the browser window

	Examples:
		#| UserName     | Email                           |
		#| mini harrods | miniharrodstestcancel@gmail.com |
		| UserName     | Email                           |
		| SubCancel MiniHarrods | subcancelminiharrods@gmail.com |

@SVCRegression @G01 @119A_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child
Scenario Outline: TC_119A_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate added multiple child is showing on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added child details are updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                      | ExcelFile                    | SheetName |
		| TC_119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @120_LoyaltyRewardsCustomer_RemoveLastChildFromMiniHarrods
Scenario Outline: TC_120_LoyaltyRewardsCustomer_RemoveLastChildFromMiniHarrods
	Given I launch the "Harrods" website
	When I add another child "<UserName>" "<Email>" to mini harrods from Harrods.com
	And I remove last child from Harrods.com
	Then I should validate removed child is not showing on Harrods.com
	And I close the browser window
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate removed child "<UserName>" is not showing on SSC
	And I close the browser window

	Examples:
		#| UserName                   | Email                |
		#| Multichild MultichildLname | Multichild@gmail.com |
		| UserName                   | Email                |
		| abin john | abhinjohn11@yopmail.com |

@SVCRegression @G01 @147_CST_Resend_the_Verfication_Emails @E2ERun
Scenario Outline: TC_147_CST_Resend_the_Verfication_Emails
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Search and Send Verification Email to the user <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window

	Examples:
		| UserCategory                             | ExcelFile                    | SheetName |
		| TC_147_CST_Resend_the_Verfication_Emails | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @148A_CST_Register_FullAccountCustomer_for_MiniHarrods
Scenario Outline: TC_148A_CST_Register_FullAccountCustomer_for_MiniHarrods
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate the added child details are updated in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                            | ExcelFile                    | SheetName |
		| TC_148_CST_Register_FullAccountCustomer_for_MiniHarrods | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @149A_CST_Remove_LastChild_from_MiniHarrods
Scenario Outline: TC_149A_CST_Remove_LastChild_from_MiniHarrods
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate the removed child is not showing on SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                 | ExcelFile                    | SheetName |
		| TC_149_CST_Remove_LastChild_from_MiniHarrods | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @150A_CST_CreateFUllRewardsCustomer_NotinSVCDB
Scenario Outline: TC_150A_CST_CreateFUllRewardsCustomer_NotinSVCDB
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the customer in SMC and validate the Rewards status <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                    | ExcelFile                    | SheetName |
		| TC_150_CST_CreateFUllRewardsCustomer_NotinSVCDB | TestDataSSCRegressionUpgrade | G01       |

#Lite account registration through newsletter sign up from Harrods.com using an email which does not exist in SVC
#@SVCRegression @G01 @165_liteUserRegistrationByNewsLetterSignup
#Scenario Outline: TC_165A_liteUserRegistrationByNewsLetterSignup
#	Given I launch the "SSC" website
#	When I Navigate to SSC > Customers
#	Then I should validate signed up new user is reflecting on SSC
#	And I close the browser window
#	Given I launch the "SMC" website
#	When I Navigate to SMC > Contacts
#	Then I should validate signed up new user is reflecting on SMC
#	And I should validate the welcome interaction email against signup user on SMC
#	And I close the browser window
#Full Rewards registration from Harrods.com using an email address that does not exist in CDC(without email consent)
#@SVCRegression @G01 @TC_165A_liteUserRegistrationByNewsLetterSignup
#Scenario Outline: TC_165A_liteUserRegistrationByNewsLetterSignup
#	Given I launch the "SSC" website
#	When I Navigate to SSC > Customers
#	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
#	And I close the browser window
#	Given I launch the "AC" website
#	When I Navigate to AC > Reports > Member Reports
#	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
#	And I close the browser window
#	Given I launch the "SMC" website
#	When I Navigate to SMC > Contacts
#	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
#	And I close the browser window
#
#	Examples:
#		| UserCategory                                  | ExcelFile                    | SheetName |
#		| TC_165_liteUserRegistrationByNewsLetterSignup | TestDataSSCRegressionUpgrade | G01       |
#Full non rewards registration from Harrods.com using an email address that does not exist in CDC(with email consent)
@SVCRegression @G02 @166_NonReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_166A_NonReward_HarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	#Non rewards customer will not be there in AC,only rewards customer will be there on AC, so removing the AC Validation
	#Given I launch the "AC" website
	#When I Navigate to AC > Reports > Member Reports
	#Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	#And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                | ExcelFile                    | SheetName |
		| TC_166_NonReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G02       |

#Full Rewards registration from Harrods.com with an email address that does not exist in CDC (with email consent)
@SVCRegression @G02 @167_FullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_167A_FullReward_HarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                 | ExcelFile                    | SheetName |
		| TC_167_FullReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G02       |

#Full Rewards registration from Harrods.com with an email address that belongs to existing non-loyalty customer (with email consent)
@SVCRegression @G01 @168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_168A_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                                    | ExcelFile                    | SheetName |
		| TC_168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G02       |

@SVCRegression @G02 @180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail
Scenario Outline: TC_180A_HarrodsRegistrationForGhostG0CustomerWelcomeEmail
	#Lite Use willnot display in SSC and AC as per latest functionality so commenting SSC ,AC the validation
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	#And I close the browser window
	#Given I launch the "AC" website
	#When I Navigate to AC > Reports > Member Reports
	#Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" were showing on AC
	#And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	#Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser window

	Examples:
		| UserCategory                                             | ExcelFile                    | SheetName |
		| TC_180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail | TestDataSSCRegressionUpgrade | G02       |

@SVCRegression @G02 @187_OnlineFullReturnAndPointValidation
Scenario Outline: TC_187_OnlineFullReturnAndPointValidation
	#Given I launch the "SMC" website
	#When I Navigate to SMC > Contacts
	#Then I should verify sales interaction against full return "<UserName>" "<Email>" "<DocId>"showing on SMC
	#And I close the browser window
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify full return for "<UserName>" "<Email>" is showing on SSC
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Point Reports
	Then I should verify deduction full return "<PointDeduction>" is showing on AC
	And I close the browser window

	Examples:
		| UserName   | Email                  | DocId  | PointDeduction |
		| Pen Monkey | monkey.pen@harrods.com | 5MGBAK | -1             |

#Verify that the CST is able to create a Enquiry ticket for a Customer to upgrade tier from Green 0 to Gold (Manual Tier Upgrade)
@SVCRegression @G07 @221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade
Scenario Outline: TC_221A_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I search for the ticket created "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                            | ExcelFile                    | SheetName |
		| TC_221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade | TestDataSSCRegressionUpgrade | G07       |

#Verify that the CST is able to create a Complaint ticket for a Customer to upgrade tier from Black to Elite(Manual Tier Upgrade)
@SVCRegression @G07 @222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC
Scenario Outline: TC_222A_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I validate expected "Miscellaneous" points is added on AC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate user is added with expected "Miscellaneous" points in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I validate expected "Miscellaneous" points is added on Harrods.com "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName |
		| TC_222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC | TestDataSSCRegressionUpgrade | G07       |

#Verify that the CST is able to create a Complaint ticket for a Customer (Status Points)
@SVCRegression @G07 @223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC
Scenario Outline: TC_223A_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Point Reports
	Then I validate expected "Status Points" points is added on AC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate user is added with expected "Status Points" points in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I validate expected "Status Points" points is added on Harrods.com "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                           | ExcelFile                    | SheetName |
		| TC_223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC | TestDataSSCRegressionUpgrade | G07       |

#Verify that the CST is able to add only 1 Primary Member and 4 Secondary members to Loyalty Rewards group.
@SVCRegression @G07 @224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup @E2ERun
Scenario Outline: TC_224A_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Hierarchy Management
	Then I validate whether the added 5 members are displayed correctly <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                     | ExcelFile                    | SheetName |
		| TC_224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup | TestDataSSCRegressionUpgrade | G07       |

#Verify that the CST is able to create a Complaint ticket for a Secondary Customer to Transfer Points to another Secondary Member
@SVCRegression @G07 @225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer
Scenario Outline: TC_225A_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I search for the ticket created "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                                  | ExcelFile                    | SheetName |
		| TC_225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer | TestDataSSCRegressionUpgrade | G07       |

@SVCRegression @G07 @226_CST_EnquiryTicket_GrantAdditional10Pct_Elite
Scenario Outline: TC_226A_CST_EnquiryTicket_GrantAdditional10Pct_Elite
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I search for the ticket created "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName |
		| TC_226_CST_EnquiryTicket_GrantAdditional10Pct_Elite | TestDataSSCRegressionUpgrade | G07       |

@SVCRegression @G07 @227_CST_EnquiryTicket_GrantAdditional10Pct_Green1 @E2ERun
Scenario Outline: TC_227_CST_EnquiryTicket_GrantAdditional10Pct_Green1
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	#When I Navigate to SSC > Service > Tickets
	#And I create a new Service Ticket
	#And I enter all the mandatory details and select the <UserCategory> <ExcelFile> <SheetName>
	And I create staff enquiry ticket for customer miscellaneous point addition <UserCategory> <ExcelFile> <SheetName>
	#Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	#Then I change the ticket status to Solved and closed
	#Then I validate the Customer Subject Details Category <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	#
	#	Given I launch the "SMC" website
	#	When I Navigate to SMC > Contacts
	#	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	#	And I close the browser window
	#
	#	Given I launch the "AC" website
	#	When I Navigate to AC > Reports > Member Reports
	#	Then I search for the ticket created <UserCategory> <ExcelFile> <SheetName>
	#	And I close the browser window
	Examples:
		| UserCategory                                         | ExcelFile                    | SheetName |
		| TC_227_CST_EnquiryTicket_GrantAdditional10Pct_Green1 | TestDataSSCRegressionUpgrade | G07       |

@SVCRegression @G07 @228_ValidateMiscActivityOnSSC @E2ERun
Scenario Outline: TC_228_ValidateMiscActivityOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate "Miscellaneous" activity against the user in <UserCategory> <ExcelFile> <SheetName> is showing on SSC
	And I close the browser window

	Examples:
		| UserCategory                     | ExcelFile                    | SheetName |
		| TC_228_ValidateMiscActivityOnSSC | TestDataSSCRegressionUpgrade | G07       |

#| UserName                     | UserEmail               |
#| Addpointchk AddpointchkLname | Addpointchk@yopmail.com |
@SVCRegression @G07  @229_GreenOneToGoldTierUpgradeValidation @E2ERun
Scenario Outline: TC_229A_GreenOneToGoldTierUpgradeValidation
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	#Then I should validate user points and tier is upgraded to "Gold" on AC
	Then I should validate user points and tier is upgraded to "Black" on AC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                               | ExcelFile                    | SheetName |
		| TC_229_GreenOneToGoldTierUpgradeValidation | TestDataSSCRegressionUpgrade | G07       |

@SVCRegression @G07  @230_GreenZeroToGreenTwoTierUpgradeValidation @E2ERun
Scenario Outline: TC_230A_GreenZeroToGreenTwoTierUpgradeValidation
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	#Then I should validate user points and tier is upgraded to "Green 2" on AC
	Then I should validate user points and tier is upgraded to "Black" on AC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                    | ExcelFile                    | SheetName |
		| TC_230_GreenZeroToGreenTwoTierUpgradeValidation | TestDataSSCRegressionUpgrade | G07       |

@SVCRegression @G07 @231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC
Scenario Outline: TC_231A_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	#Then I validate expected "Extend Points" points is added on AC
	Then I validate expected "Extend Points" points is added on AC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate user is added with expected "Extend Points" points in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	#Then I validate expected "Extend Points" points is added on Harrods.com
	Then I validate expected "Extend Points" points is added on Harrods.com "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                           | ExcelFile                    | SheetName |
		| TC_231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC | TestDataSSCRegressionUpgrade | G07       |

#232	Verify that the CST is able to create a Complaint ticket for a Customer to upgrade tier from Black to Elite(Manual Tier Upgrade)
#Cannot upgrade tier to Elite (Can be descoped)
@ignore @SVCRegression @G07 @232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade
Scenario Outline: TC_232A_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I search for the ticket created <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                             | ExcelFile                    | SheetName |
		| TC_232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade | TestDataSSCRegressionUpgrade | G07       |

#233	Verify that the CST is able to create a Enquiry ticket for a Primary Customer to Transfer Points to Secondary Members
@SVCRegression @G07  @233_PrimaryToSecondaryPointTransfer @E2ERun
Scenario Outline: TC_233_PrimaryToSecondaryPointTransfer
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for primary user to secondary user in <UserCategory> <ExcelFile> <SheetName> transfer
	And I Navigate to SSC > Customers
	Then I validate points were transfered from Primary to Secondary user
	And I close the browser window

	Examples:
		| UserCategory                           | ExcelFile                    | SheetName |
		| TC_233_PrimaryToSecondaryPointTransfer | TestDataSSCRegressionUpgrade | G07       |


#Bug id : 139580 this is a functionality is disabled in PRD as there were issues with it. therefore it is descoped for this project
#234	Verify that the CST is able to Deactivate the Group Account
@SVCRegression @G07  @234_DeactivateGroupAccountValidateOnSSCSMCAC @E2ERun
@Ignore
Scenario Outline: TC_234A_DeactivateGroupAccountValidateOnSSCSMCAC
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Hierarchy Management
	Then I should validate is deactivated from AC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                    | ExcelFile                    | SheetName |
		| TC_234_DeactivateGroupAccountValidateOnSSCSMCAC | TestDataSSCRegressionUpgrade | G07       |

#235	Verify that the CST is able to Rewards Statement based on Rewards Point that are Redeemed
@SVCRegression @G07 @235_ValidateRedeemActivityOnSSC @E2ERun
Scenario Outline: TC_235_ValidateRedeemActivityOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate "RedeemPoints" activity against the user in <UserCategory> <ExcelFile> <SheetName> is showing on SSC
	And I close the browser window

	Examples:
		| UserCategory                       | ExcelFile                    | SheetName |
		| TC_235_ValidateRedeemActivityOnSSC | TestDataSSCRegressionUpgrade | G07       |

#277	Verify that the CST is able to Obsolete the Customer's record in SSC based on GDPR
@SVCRegression @G10 @277_VerifyCSTObsoleteCustomerFromSSC @E2ERun
Scenario Outline: TC_277_VerifyCSTObsoleteCustomerFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I update the given user in the <UserCategory> <ExcelFile> <SheetName> to "Set As Obsolete" from SSC
	Then I should verify obsolete status on SSC is "Yes"
	When I update the given user in the <UserCategory> <ExcelFile> <SheetName> to "Set As Active" from SSC
	Then I close the browser window

	Examples:
		| UserCategory                            | ExcelFile                    | SheetName |
		| TC_277_VerifyCSTObsoleteCustomerFromSSC | TestDataSSCRegressionUpgrade | G10       |

#249	Verify the Black tier customer is able to cancel the 2nd slot(Day 2) of  previously booked 10% discount day from Harrods.com
@SVCRegression @G15 @249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct
Scenario Outline: TC_249A_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate cancelled status is updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate cancelled status is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                              | ExcelFile                    | SheetName |
		| TC_249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct | TestDataSSCRegressionUpgrade | G15       |

#250	Verify the Black tier customer is able to book 1st slot(Day 1)of 10% discount day again from Harrods.com, after cancellation of the same date.
@SVCRegression @G15 @250_BlackTierCustomer_Book_1st_slot_aftercancellation
Scenario Outline: TC_250A_BlackTierCustomer_Book_1st_slot_aftercancellation
    Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate cancelled status is updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I validate whether the 10 percent discount is updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate cancelled status is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I should whether the 10 percent discount is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                             | ExcelFile                    | SheetName |
		| TC_250_BlackTierCustomer_Book_1st_slot_aftercancellation | TestDataSSCRegressionUpgrade | G15       |

#251	Verify CST advisor is able cancel the  second slot of 10% discount day date booked from SSC on Black tier customer request.
@SVCRegression @G15 @251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest
Scenario Outline: TC_251A_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate cancelled status is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I verify the cancellation is updated in harrods website for the customer "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                          | ExcelFile                    | SheetName |
		| TC_251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest | TestDataSSCRegressionUpgrade | G15       |

#252	Verify if the existing loyalty rewards (Elite) customer with a UK address gets free delivery by purchasing greater than £10.00
#Elite Customer (Can be descoped)
@Ignore @SVCRegression @G15 @252_Existing_Elite_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
Scenario Outline: TC_252_Existing_Elite_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
	Given I launch the "SSC" website
	When I navigate to SSC > Sales > Purchases
	Then I enter the Purchase order number and search for <UserCategory> <ExcelFile> <SheetName>
	And I verify whether the free delivery is applied for the corresponding order <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the Purchase Order Value in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Order Reports
	Then I validate the Purchase Order Value in AC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                                      | ExcelFile                    | SheetName |
		| TC_252_Existing_Elite_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10 | TestDataSSCRegressionUpgrade | G15       |

#253	Verify if the existing loyalty rewards (GD) customer with a UK address gets free delivery by purchasing (Products from the inclusion and exclusion list) products greater than £10.00
@SVCRegression @G15 @253_Existing_Green_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
Scenario Outline: TC_253_Existing_Green_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
	#Given I launch the "Harrods" website
	#	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	#	And I add products greater than 10 Pounds and place order
	#	Then I Verify free delivery is applied for the order in Bag, Invoice and Order History
	#	And I close the browser window
	#Given I launch the "SSC" website
	##When I navigate to SSC > Sales > Purchases
	#When I Navigate to SSC > Customers
	#Then I navigate to Purchase tab of Customer <UserCategory> <ExcelFile> <SheetName>
	#Then I enter the Purchase order number and search for <UserCategory> <ExcelFile> <SheetName>
	#And I verify whether the free delivery is applied for the corresponding order <UserCategory> <ExcelFile> <SheetName>
	#And I close the browser window
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the Purchase Order Value in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Order Reports
	Then I validate the Purchase Order Value in AC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                                      | ExcelFile                    | SheetName |
		| TC_253_Existing_Green_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10 | TestDataSSCRegressionUpgrade | G15       |

#259	Verify the CST is able to resolve the complaint based on a specific event and provide Dining experience voucher as compensation/Goodwilll
@SVCRegression @G17 @259_ValidateComplaintBasedDiningCompensationOnSSC @E2ERun
Scenario Outline: TC_259_ValidateComplaintBasedDiningCompensationOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for dining compensation for <UserCategory> <ExcelFile> <SheetName>
	And I change the status of ticket to "Closed" from SSC
	Then I should validate dining compensation ticket gets closed without any approvals
	And I close the browser window

	Examples:
		| UserCategory                                         | ExcelFile                    | SheetName |
		| TC_259_ValidateComplaintBasedDiningCompensationOnSSC | TestDataSSCRegressionUpgrade | G17       |

#260	Verify the CST is able to resolve the complaint based on a specific event and provide flowers as compensation/Goodwilll
@SVCRegression @G17 @260_ValidateComplaintBasedFlowersAsCompensationOnSSC @E2ERun
Scenario Outline: TC_260_ValidateComplaintBasedFlowersAsCompensationOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for flower as compensation for <UserCategory> <ExcelFile> <SheetName>
	And I change the status of ticket to "Closed" from SSC
	Then I should validate dining compensation ticket gets closed without any approvals
	And I close the browser window

	Examples:
		| UserCategory                                            | ExcelFile                    | SheetName |
		| TC_260_ValidateComplaintBasedFlowersAsCompensationOnSSC | TestDataSSCRegressionUpgrade | G17       |

#261	A customer requests assistance ordering a gift card online or over the phone.
#Customer is provided with details on how to self-serve in templated response or Knowledge articles.
#Where necessary, advisers will correspond with transaction services to complete request.
@SVCRegression @G17 @261_AssistanceForOnlineGiftCardCompleteRequestOnSSC @E2ERun
Scenario Outline: TC_261_AssistanceForOnlineGiftCardCompleteRequestOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online gift card <UserCategory> <ExcelFile> <SheetName>
	And I change the status of ticket to "Closed" from SSC
	Then I should validate online "Gift card" ticket gets closed without any approvals
	And I close the browser window

	Examples:
		| UserCategory                                           | ExcelFile                    | SheetName |
		| TC_261_AssistanceForOnlineGiftCardCompleteRequestOnSSC | TestDataSSCRegressionUpgrade | G17       |

#262		An employee will request assistance creating a digital rewards card for their employee account,
#adviser will walk them through the process of registering their account for a digital rewards card.
@SVCRegression @G17 @262_AssistanceForOnlineDigitalRewardsCardForEmployeeOnSSC @E2ERun
Scenario Outline: TC_262_AssistanceForOnlineDigitalRewardsCardForEmployeeOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card <UserCategory> <ExcelFile> <SheetName>
	And I change the status of ticket to "Closed" from SSC
	Then I should validate online "Reward card" ticket gets closed without any approvals
	And I close the browser window

	Examples:
		| UserCategory                                                 | ExcelFile                    | SheetName |
		| TC_262_AssistanceForOnlineDigitalRewardsCardForEmployeeOnSSC | TestDataSSCRegressionUpgrade | G17       |

#263	"For managers to monitor adviser performance, the below SLA’s will be configured in the system according to this table.
#Below are the To Be conditions for active ticket SLA’s.
#Admin, Managers, Furniture, Procedural Complaint, Hampers, Digital, Social Media, Rewards / Store Support,
#Post Transactional Adjustment, Business VAT Requests, Store CS, Personal Shopping, General Tickets,
#Watch Repairs – Maintenance/Service, Watch Repairs – Full Service, Watch Repairs - Adjustments, Alterations, Transaction Support.
#Create SLA for - Admin"
@SVCRegression @G17 @263_VerifySSCTicketTimelineDataIsAsperSLA @E2ERun
Scenario Outline: TC_263_VerifySSCTicketTimelineDataIsAsperSLA
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card <UserCategory> <ExcelFile> <SheetName>
	Then I should validate resolved and resolution date were showing as per SLA
	And I close the browser window

	Examples:
		| UserCategory                                 | ExcelFile                    | SheetName |
		| TC_263_VerifySSCTicketTimelineDataIsAsperSLA | TestDataSSCRegressionUpgrade | G17       |

#264	Customer reaches out to customer service to access transcripts of tickets held in SSC.Transcripts are collated and password protected.
#Transcripts are shared with the customer using external Secure Share site. Customer is notified of completion of request. (Chat Transcript)
@SVCRegression @G17 @264_VerifyChatTranscriptTicketSummaryAccess @E2ERun
Scenario Outline: TC_264_VerifyChatTranscriptTicketSummaryAccess
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card <UserCategory> <ExcelFile> <SheetName>
	Then I should verify "Chat transcript" ticket summary can be accessed by the customer
	And I close the browser window

	Examples:
		| UserCategory                                   | ExcelFile                    | SheetName |
		| TC_264_VerifyChatTranscriptTicketSummaryAccess | TestDataSSCRegressionUpgrade | G17       |

#265	Customer reaches out to customer service to access transcripts of tickets held in SSC.Transcripts are collated and password protected.
#Transcripts are shared with the customer using external Secure Share site. Customer is notified of completion of request. (Individual call Transcript)
@SVCRegression @G17 @265_VerifyCallTranscriptTicketSummaryAccess @E2ERun
Scenario Outline: TC_265_VerifyCallTranscriptTicketSummaryAccess
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card <UserCategory> <ExcelFile> <SheetName>
	Then I should verify "Call transcript" ticket summary can be accessed by the customer
	And I close the browser window

	Examples:
		| UserCategory                                   | ExcelFile                    | SheetName |
		| TC_265_VerifyCallTranscriptTicketSummaryAccess | TestDataSSCRegressionUpgrade | G17       |

#269	Verify if the CST  is able to resolve complaint about a Brand at Harrods  raised by customer,with an Apology and Goodwill.
@SVCRegression @G17 @269_ValidateResolveComplaintByApologyOnSSC
Scenario Outline: TC_269_ValidateResolveComplaintByApologyOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket to resolve complaint by apology for <UserCategory> <ExcelFile> <SheetName>
	And I change the status of ticket to "Closed" from SSC
	Then I should validate ticket gets closed and approvers names were added
	And I close the browser window

	Examples:
		| UserCategory                                  | ExcelFile                    | SheetName |
		| TC_269_ValidateResolveComplaintByApologyOnSSC | TestDataSSCRegressionUpgrade | G17       |