Feature: SSC Regression Creation cases

#Test for SCAYLE login
@SVCRegression @G01 @005_NewNonReward_HarrodsReg_EmailConsentNo
Scenario Outline: TC_001_LOGIN_SCAYLE
	Given I launch the "SCAYLE" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                    | ExcelFile                    | SheetName |
		| TC_009_NewFullReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full non rewards registration from Harrods.com using an email address that does not exist in CDC(with email consent)
@SVCRegression @G01 @005_NewNonReward_HarrodsReg_EmailConsentNo
Scenario Outline: TC_005_NewNonReward_HarrodsReg_EmailConsentNo
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                  | ExcelFile                    | SheetName |
		| TC_005_NewNonReward_HarrodsReg_EmailConsentNo | TestDataSSCRegressionUpgrade | G01       |

#Full non rewards registration from Harrods.com using an email address that belongs to existing non-loyalty customer (with email consent)
@SVCRegression @G01 @006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	Then I create Non Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <UserCategory>
	When I perform join rewards as "<UserCategory>" from Harrods.com with ghost rewards card data "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                   | ExcelFile                    | SheetName |
		| TC_006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com with an email address that does not exist in CDC (with email consent)
@SVCRegression @G01 @009_NewFullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_009_NewFullReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                    | ExcelFile                    | SheetName |
		| TC_009_NewFullReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com with an email address that belongs to existing non-loyalty customer (with email consent)
@SVCRegression @G01 @010_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_010_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	Then I create Non Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <UserCategory>
	Then I close the browser window

	Examples:
		| UserCategory                                                    | ExcelFile                    | SheetName |
		| TC_010_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com with an email address that belongs to existing rewards customer with BL tier
@SVCRegression @G01 @013_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_013_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
	#Create user from SSC and upgrade to Black and email address should be available in Excel
	#Given I launch the "SSC" website
	#When I Navigate to SSC > Customers
	#When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	#Then I upgrade the user to "Black" tier and write to Input Excelsheet <ExcelFile> <SheetName> for <UserCategory>
	#And I close the browser
	Given I launch the "Harrods" website
	When I perform and validate existing "<UserCategory>" customer from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                             | ExcelFile                    | SheetName |
		| TC_013_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com with an email address that belongs to existing lite account customer (with email consent)
@SVCRegression @G01 @015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	And I Perform SignUp action with new user From Harrods.com and write to Input Excelsheet "<ExcelFile>" "<SheetName>" for "<UserCategory>"
	And I perform email validation from yopmail
	When I perform and validate existing "<UserCategory>" customer from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                     | ExcelFile                    | SheetName |
		| TC_015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com by providing rewards card and email address that does not exist in CDC
@SVCRegression @G01 @017_NewRewardsCard_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_017_NewRewardsCard_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                               | ExcelFile                    | SheetName |
		| TC_017_NewRewardsCard_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com by providing :-
#•valid rewards card that does not exist in CDC
#•email address that belongs to existing non-loyalty customer(without email consent)
@SVCRegression @G01 @018_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo
Scenario Outline: TC_018_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                                 | ExcelFile                    | SheetName |
		| TC_018_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com by providing :-
#•email address that does not exist in CDC
#•rewards card that belongs to existing thin account(GD tier)
@SVCRegression @G01 @022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                             | ExcelFile                    | SheetName |
		| TC_022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com by providing :-
#•email address that does not exist in CDC
#•rewards card that belongs to existing ghost account with G2 tier points
@SVCRegression @G01 @023_ExistingGhostGreen2UserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_023_ExistingGhostGreen2UserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                                    | ExcelFile                    | SheetName |
		| TC_023_ExistingGhostGreen2UserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#Full rewards registration from Harrods.com by providing :-
#•email address that does not exist in CDC
#•rewards card that belongs to existing ghost account with GD tier points
@SVCRegression @G01 @024_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_024_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                                  | ExcelFile                    | SheetName |
		| TC_024_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

#
#Full rewards registration from Harrods.com by providing :-
#•email address that does not exist in CDC
#•rewards card that belongs to another full registered customer
@SVCRegression @G01 @025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                                    | ExcelFile                    | SheetName |
		| TC_025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @028_NonReward_HarrodsJoinRewardWithoutCardData
Scenario Outline: TC_028_NonReward_HarrodsJoinRewardWithoutCardData
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	When I perform join rewards as "<UserCategory>" from Harrods.com without rewards card data "<ExcelFile>" and "<SheetName>"
	Then I validate user "<UserCategory>" is able to join rewards from Harrods.com without rewards card data "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                      | ExcelFile                    | SheetName |
		| TC_028_NonReward_HarrodsJoinRewardWithoutCardData | TestDataSSCRegressionUpgrade | G01       |

#Verify existing non rewards customer is able to join rewards from Harrods.com using a ghost card with enough transactions to get rewards points >10000
#Fill data in test data sheet
@SVCRegression @G01 @029_NonReward_HarrodsJoinRewardWithGhostPremiumPointsCard
Scenario Outline: TC_029_NonReward_HarrodsJoinRewardWithGhostPremiumPointsCard
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	When I perform join rewards as "<UserCategory>" from Harrods.com with ghost rewards card data "<ExcelFile>" and "<SheetName>"
	Then I validate user "<UserCategory>" is able to join rewards from Harrods.com with rewards card data "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                 | ExcelFile                    | SheetName |
		| TC_029_NonReward_HarrodsJoinRewardWithGhostPremiumPointsCard | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to add a default UK contact address as a first address for a loyalty rewards customer in CDC
@SVCRegression @G01 @082_AddUKAddressFromSSC
Scenario Outline: TC_082_AddUKAddressFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I add "UK" default contact address for user in <UserCategory> <ExcelFile> <SheetName> from SSC
	Then I should validate added "UK" address for <UserCategory> <ExcelFile> <SheetName> successfully updated on SSC
	And I close the browser window

	Examples:
		| UserCategory               | ExcelFile                    | SheetName |
		| TC_082_AddUKAddressFromSSC | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to add new UK mobile number for a loyalty rewards customer
@SVCRegression @G01 @059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber
Scenario Outline: TC_059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                              | ExcelFile                    | SheetName |
		| TC_059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to add new US mobile number for a loyalty rewards customer
@SVCRegression @G01 @060_Verify_loyaltyrewardscustomer_addnewUSmobilenumber
Scenario Outline: TC_060_Verify_loyaltyrewardscustomer_addnewUSmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new "US" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                              | ExcelFile                    | SheetName |
		| TC_060_Verify_loyaltyrewardscustomer_addnewUSmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to edit UK mobile number for a loyalty rewards customer
@SVCRegression @G01 @062_Verify_loyaltyrewardscustomer_editUKmobilenumber
Scenario Outline: TC_062_Verify_loyaltyrewardscustomer_editUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I edit "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                            | ExcelFile                    | SheetName |
		| TC_062_Verify_loyaltyrewardscustomer_editUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to edit non UK mobile number for a loyalty rewards customer
@SVCRegression @G01 @063_Verify_loyaltyrewardscustomer_editUSmobilenumber
Scenario Outline: TC_063_Verify_loyaltyrewardscustomer_editUSmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I edit "US" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                            | ExcelFile                    | SheetName |
		| TC_063_Verify_loyaltyrewardscustomer_editUSmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to delete UK mobile number for a loyalty rewards customer
@SVCRegression @G01 @064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber
Scenario Outline: TC_064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I delete "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                              | ExcelFile                    | SheetName |
		| TC_064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to add new UK mobile number for a non rewards customer
@SVCRegression @G01 @067_Verify_nonrewardscustomer_addnewUKmobilenumber
Scenario Outline: TC_067_Verify_nonrewardscustomer_addnewUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                          | ExcelFile                    | SheetName |
		| TC_067_Verify_nonrewardscustomer_addnewUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to edit UK mobile number for a non rewards customer
@SVCRegression @G01 @068_Verify_nonrewardscustomer_editUKmobilenumber
Scenario Outline: TC_068_Verify_nonrewardscustomer_editUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I edit "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName |
		| TC_068_Verify_nonrewardscustomer_editUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to delete UK mobile number for a non rewards customer
@SVCRegression @G01 @069_Verify_nonrewardscustomer_DeleteUKmobilenumber
Scenario Outline: TC_069_Verify_nonrewardscustomer_DeleteUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I delete "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                          | ExcelFile                    | SheetName |
		| TC_069_Verify_nonrewardscustomer_DeleteUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to add default Canada contact address for a loyalty rewards customer in CDC
@SVCRegression @G01 @084_AddCanadaAddressFromSSC
Scenario Outline: TC_084_AddCanadaAddressFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I add "Canada" default contact address for user in <UserCategory> <ExcelFile> <SheetName> from SSC
	Then I should validate added "Canada" address for <UserCategory> <ExcelFile> <SheetName> successfully updated on SSC
	And I close the browser window

	Examples:
		| UserCategory                   | ExcelFile                    | SheetName |
		| TC_084_AddCanadaAddressFromSSC | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to edit a UK Contact address for a loyalty rewards customer
@SVCRegression @G01 @085_EditUKAddressFromSSC
Scenario Outline: TC_085_EditUKAddressFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I edit "UK" default contact address for user in <UserCategory> <ExcelFile> <SheetName> from SSC
	Then I should validate edited "UK" address for <UserCategory> <ExcelFile> <SheetName> successfully updated on SSC
	And I close the browser window

	Examples:
		| UserCategory                | ExcelFile                    | SheetName |
		| TC_085_EditUKAddressFromSSC | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to edit a non UK Contact address for a loyalty rewards customer
@SVCRegression @G01 @086_EditNonUKAddressFromSSC
Scenario Outline: TC_086_EditNonUKAddressFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I edit "Canada" default contact address for user in <UserCategory> <ExcelFile> <SheetName> from SSC
	Then I should validate edited "Canada" address for <UserCategory> <ExcelFile> <SheetName> successfully updated on SSC
	And I close the browser window

	Examples:
		| UserCategory                   | ExcelFile                    | SheetName |
		| TC_086_EditNonUKAddressFromSSC | TestDataSSCRegressionUpgrade | G01       |

#Verify if the user is able to swap contact address from address 1 to address 2 for a loyalty rewards customer
@SVCRegression @G01 @090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap
Scenario Outline: TC_090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate delivery address can be swaped in SSC from "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                                  | ExcelFile                    | SheetName |
		| TC_090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap | TestDataSSCRegressionUpgrade | G01       |

#Non rewards customer signs in to Harrods.com and provides consent for Post channel (Customer doesn't have contact address added)
@SVCRegression @G01 @035_Reg_NonRewardCustomer_EnablePostalConsent_Yes
Scenario Outline: TC_035_Reg_NonRewardCustomer_EnablePostalConsent_Yes
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	And I perform "Opt-In" "<channel>" and interests consent for the user from Harrods.com
	#Then I should validate "Opt-In All" channels and interests consent were saved on Harrods.com
	Then I close the browser window

	Examples:
		| UserCategory                                         | ExcelFile                    | SheetName | channel |
		| TC_035_Reg_NonRewardCustomer_EnablePostalConsent_Yes | TestDataSSCRegressionUpgrade | G01       | postal  |

#Non rewards customer signs in to Harrods.com updates the channel consent from Email to SMS and makes a mixed selection on interests
@SVCRegression @G01 @038_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests
Scenario Outline: TC_038_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	And I perform "Opt-In-All" "<channel>" and mixed interests consent from Harrods.com
	#Then I should validate "Opt-In All" channels and interests consent were saved on Harrods.com
	Then I close the browser window

	Examples:
		| UserCategory                                                                      | ExcelFile                    | SheetName | channel |
		| TC_038_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests | TestDataSSCRegressionUpgrade | G01       | phone   |

#Loyalty rewards(G0/G1) customer provides consent for Post channel and Harrods magazine
@SVCRegression @G01 @040_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine
Scenario Outline: TC_040_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	And I perform "Opt-In" "<channel1>" and mixed interests consent from Harrods.com
	#And I perform "Opt-In" "<channel2>" and mixed interests consent from Harrods.com
	#And I enroll on miniharrods from Communication Preferences and save in Harrods "<ExcelFile>" "<SheetName>" "<UserCategory>"
	Then I close the browser window

	Examples:
		| UserCategory                                                          | ExcelFile                    | SheetName | channel1 | channel2     |
		| TC_040_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine | TestDataSSCRegressionUpgrade | G01       | postal   | publications |

#Loyalty rewards(Gold/Black/Elite)  customer provides consent for Email channel
@SVCRegression @G01 @041_Loyaltyrewards_Goldcustomer_EmailConsent_Yes
Scenario Outline: TC_041_Loyaltyrewards_Goldcustomer_EmailConsent_Yes
	Given I launch the "Harrods" website
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	And I perform "Opt-In-All" "<channel>" and mixed interests consent from Harrods.com
	Then I should validate "Opt-In-email" "<channel>" channels and interests updated in Harrods.com
	Then I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName | channel |
		| TC_041_Loyaltyrewards_Goldcustomer_EmailConsent_Yes | TestDataSSCRegressionUpgrade | G01       | email   |

#Verify if existing loyalty rewards customer is able to add new UK mobile number
 @SVCRegression @G01 @045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber
Scenario Outline: TC_045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add new "UK" phone number to the user born <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                       | ExcelFile                    | SheetName |
		| TC_045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty rewards customer is able to edit UK mobile number
 @SVCRegression @G01 @049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber
Scenario Outline: TC_049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I edit "UK" Phonenumber of the user <ExcelFile> <SheetName> <UserCategory>
	And I close the browser window

	Examples:
		| UserCategory                                                  | ExcelFile                    | SheetName |
		| TC_049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty rewards customer is able to delete UK mobile number
 @SVCRegression @G01 @052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber
Scenario Outline: TC_052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I delete the phone number <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                           | ExcelFile                    | SheetName |
		| TC_052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty rewards customer is able to add DOB
 @SVCRegression @G01 @055_Verify_existing_loyaltyrewardscustomer_AddDOB
Scenario Outline: TC_055_Verify_existing_loyaltyrewardscustomer_AddDOB
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add DOB for the user <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                         | ExcelFile                    | SheetName |
		| TC_055_Verify_existing_loyaltyrewardscustomer_AddDOB | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty rewards customer is able to add UK address
@SVCRegression @070_Existing_LoyaltyRewardCustomer_AddUKAddress
Scenario Outline: TC_070_Existing_LoyaltyRewardCustomer_AddUKAddress
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I add a new address for "<UserCategory>" in Harrods.com "<ExcelFile>" "<SheetName>"
	Then I should validate added address "<UserCategory>" is reflected in Harrods.com "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                       | ExcelFile                    | SheetName |
		| TC_070_Existing_LoyaltyRewardCustomer_AddUKAddress | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing Loyalty rewards customer is able to delete default contact address
@SVCRegression @G01 @073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress
Scenario Outline: TC_073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I delete address and validate for "<UserCategory>" in Harrods.com "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                                | ExcelFile                    | SheetName |
		| TC_073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress | TestDataSSCRegressionUpgrade | G01       |

 @SVCRegression @G01 @096_EnrollToMiniHarrodsFromOnline
Scenario Outline: TC_096_EnrollToMiniHarrodsFromOnline
	Given I launch the "Harrods" website
	When I enroll "<UserName>" "<Email>" to mini harrods from Harrods.com
	Then I should validate enrolled "<UserName>" "<Email>" child is showing on Harrods.com
	And I close the browser window

	Examples:
		| UserName | Email |
		|  Auto-TC-ninetysix MiniHarrods | Auto-TC-ninetysixMini@gmail.com|
		#| AT-TwofactorUsertwo twofactortwo| at-twofactortcusertwo@gmail.com |

 @SVCRegression @G01 @100_Edit/remove_MiniHarrodsinterest_of_customer_through_Harrods
Scenario Outline: TC_100_Edit/remove_MiniHarrodsinterest_of_customer_through_Harrods
	Given I launch the "Harrods" website
	#When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	When I enroll "<UserName>" "<Email>" to mini harrods from Harrods.com
	And I click on MiniHarrods
	And I validate that remove miniharrods interest is updated in Harrods.com "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser window
	Examples:
		| UserName                          | Email                               |
		| AT-TwofactorUsertwo twofactortwo| at-twofactortcusertwo@gmail.com |
	#Examples:
	#	| UserCategory                                                       | ExcelFile                    | SheetName |
	#	| TC_100_Edit/remove_MiniHarrodsinterest_of_customer_through_Harrods | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty rewards(G2) customer signs in and changes the preference channel from Email to SMS and makes a mixed selection of interests  (Customer has mobile number)
@SVCRegression @G01 @105_Reg_LoyaltyRewardCustomer_EnableSMSconsentYes_MixedSelectionOnInterests
Scenario Outline: TC_105_Reg_LoyaltyRewardCustomer_EnableSMSconsentYes_MixedSelectionOnInterests
	#Given I launch the "Harrods" website
	#When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	#Then I close the browser window
	Given I launch the "Harrods" website
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	And I perform the operation for "<channel>" and mixed selection of interest in Harrods
	Then I close the browser window

	Examples:
		| UserCategory                                                                   | ExcelFile                    | SheetName | channel |
		| TC_105_Reg_LoyaltyRewardCustomer_EnableSMSconsentYes_MixedSelectionOnInterests | TestDataSSCRegressionUpgrade | G01       | sms     |

 @SVCRegression @G01 @119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child
Scenario Outline: TC_119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	#When I enroll "<UserName>" "<Email>" to mini harrods from Harrods.com
	And I click on MiniHarrods
	And I validate more than four child cannot be added in miniharrods from Harrods.com "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser window
  #   Examples:
		#| UserName                          | Email                               |
		#| Miniallowedtoaddmorethanfourchild Harrods| miniallowedtoaddmorethanfourchild@gmail.com |

	Examples:
		| UserCategory                                                      | ExcelFile                    | SheetName |
		| TC_119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child | TestDataSSCRegressionUpgrade | G01       |

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
#Descoped as per Bug 152374
@Ignore @SVCRegression @G01 @155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack
Scenario Outline: TC_155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack
    #Registering new User1 for Merge Two Accounts
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Given I launch the "SSC" website
	#Registering new User2 for Merge Two Accounts
	When I Navigate to SSC > Customers
	Then I create new customer in SSC
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

#Descoped as per Bug 152374
@Ignore
@SVCRegression @G01 @156_Merge_TwoAccounts_AndRegisterDeemedUser
Scenario Outline: TC_156_Merge_TwoAccounts_AndRegisterDeemedUser
	#Registering new User1 for Merge Two Accounts
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Given I launch the "SSC" website
	#Registering new User2 for Merge Two Accounts
	When I Navigate to SSC > Customers
	Then I create new customer in SSC
	When I Navigate to SSC > Customer Merge
	And Search for two active users and merge <UserCategory> <ExcelFile> <SheetName>
	And I edit the Attributes of the Surviving Customer and save
	And I initiate merge for the customers
	Then I close the browser window

	#When I Navigate to SSC > Tickets
	#And I create ticket for reward points merge for user <UserCategory> <ExcelFile> <SheetName>
	#there is issue in SSC for updating merge ticket
	Examples:
		| UserCategory                                   | ExcelFile                    | SheetName |
		| TC_156_Merge_TwoAccounts_AndRegisterDeemedUser | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing Loyalty rewards(Gold/black/elite) customer signed up for Mini Harrods and selected Harrods magazine subscription channel is able to remove all the channel consent
@SVCRegression @G01 @107_Loyaltyrewards_Gold/black/Elitecustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent
Scenario Outline: TC_107_Loyaltyrewards_Gold/black/Elitecustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent
	Given I launch the "Harrods" website
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	Then I should validate "All consent" "<channel>" channels and interests updated in Harrods.com
	And I close the browser window

	Examples:
		| UserCategory                                                                                                      | ExcelFile                    | SheetName | channel |
		| TC_107_Loyaltyrewards_Gold/black/Elitecustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent | TestDataSSCRegressionUpgrade | G01       | postal  |

#Verify if existing loyalty customer is able to edit City,State,Postal code in the default contact address
@SVCRegression @G01 @108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress
Scenario Outline: TC_108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I edit address for "<UserCategory>" in Harrods.com "<ExcelFile>" "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                                        | ExcelFile                    | SheetName |
		| TC_108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress | TestDataSSCRegressionUpgrade | G01       |

#Verify if existing loyalty(G0/G1) rewards customer is able to provide consent for post channel and Harrods magazine
@SVCRegression @G01 @109_Loyaltyrewards_G0/G1customer_PostalandMagazineConsent_Yes
Scenario Outline: TC_109_Loyaltyrewards_G0/G1customer_PostalandMagazineConsent_Yes
	Given I launch the "Harrods" website
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	Then I should validate "Opt-In-postal" "<channel>" channels and interests for Rewards user updated in Harrods.com "<UserCategory>"
	Then I close the browser window

	Examples:
		| UserCategory                                                     | ExcelFile                    | SheetName | channel |
		| TC_109_Loyaltyrewards_G0/G1customer_PostalandMagazineConsent_Yes | TestDataSSCRegressionUpgrade | G01       | postal  |

#Verify if existing Loyalty rewards customer is able to swap the default delivery address from one address to another
@SVCRegression @G01 @110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress
Scenario Outline: TC_110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I validate that the "DeliveryAddress" addresses can be swaped <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window

	Examples:
		| UserCategory                                                      | ExcelFile                    | SheetName |
		| TC_110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress | TestDataSSCRegressionUpgrade | G01       |


@SVCRegression @G01 @162_CST_Customer_SetBillingAddress
Scenario Outline: TC_162_CST_Customer_SetBillingAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I select a non billing address and change it to Billing Address and save in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                          | ExcelFile                    | SheetName |
		| TC_162_CST_Customer_SetBillingAddress | TestDataSSCRegressionUpgrade | G01       |

#Full non rewards registration from Harrods.com using an email address that does not exist in CDC(with email consent)
@SVCRegression @G02 @166_NonReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_166_NonReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	#When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                | ExcelFile                    | SheetName |
		| TC_166_NonReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G02       |

#Full Rewards registration from Harrods.com with an email address that does not exist in CDC (with email consent)
@SVCRegression @G02 @167_FullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_167_FullReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                 | ExcelFile                    | SheetName |
		| TC_167_FullReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G02       |

#Full Rewards registration from Harrods.com with an email address that belongs to existing non-loyalty customer (with email consent)
@SVCRegression @G01 @168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	#When I perform and validate existing Non rewards "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	#Full Rewards registration from Harrods.com
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser window

	Examples:
		| UserCategory                                                    | ExcelFile                    | SheetName |
		| TC_168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes | TestDataSSCRegressionUpgrade | G02       |

@SVCRegression @G02 @180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail
Scenario Outline: TC_180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	And I perform SignUp action with a new user from Harrods.com <UserCategory> <ExcelFile> <SheetName>
	And I perform email validation from yopmail
	Then I close the browser window
	Given I launch the "Harrods" website
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I perform the Welcome email validation from yopmail "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                             | ExcelFile                    | SheetName |
		| TC_180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail | TestDataSSCRegressionUpgrade | G02       |

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
	Then I validate user is added with "Status Points Balance" points on SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                           | ExcelFile                    | SheetName |
		| TC_223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC | TestDataSSCRegressionUpgrade | G07       |

#Verify that the CST is able to add only 1 Primary Member and 4 Secondary members to Loyalty Rewards group.
@SVCRegression @G07 @224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup @E2ERun
Scenario Outline: TC_224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup
	
	#When I Navigate to SSC > Customers
	#And I add the New Primary Member in <UserCategory> <ExcelFile> <SheetName>
	Given I launch the "Harrods" website
	When I perform new  primary user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Given I launch the "SSC" website
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
	Then I change the Target Tier and Validate the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	Then I validate the Customer Tier <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                                  | ExcelFile                    | SheetName |
		| TC_225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer | TestDataSSCRegressionUpgrade | G07       |

 @SVCRegression @G07 @226_CST_EnquiryTicket_GrantAdditional10Pct_Elite
Scenario Outline: TC_226_CST_EnquiryTicket_GrantAdditional10Pct_Elite
	Given I launch the "SSC" website
	#When I Navigate to SSC > Service > Tickets
	When I Navigate to SSC > Customers
	#And I create a new Service Ticket
	#And I enter all the mandatory details and create ticket for <UserCategory> <ExcelFile> <SheetName>
	And I create staff enquiry ticket for customer miscellaneous point addition <UserCategory> <ExcelFile> <SheetName>
	Then I change the Target Tier and Validate the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	#Then I validate the Customer Subject Details Category
	Then I validate the Customer Subject Details Category <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName |
		| TC_226_CST_EnquiryTicket_GrantAdditional10Pct_Elite | TestDataSSCRegressionUpgrade | G07       |

@SVCRegression @G07  @229_GreenOneToGoldTierUpgradeValidation @E2ERun
Scenario Outline: TC_229_GreenOneToGoldTierUpgradeValidation
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create ticket for "Green-Gold" tier upgrade from file "<UserCategory>" "<ExcelFile>" "<SheetName>"
	#And I Navigate to SSC > Customers
	#Then I validate user tier gets upgraded to "Gold" on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                               | ExcelFile                    | SheetName |
		| TC_229_GreenOneToGoldTierUpgradeValidation | TestDataSSCRegressionUpgrade | G07       |

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

@SVCRegression @G07 @231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC
Scenario Outline: TC_231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I create complaint ticket for customer extend point addition <UserCategory> <ExcelFile> <SheetName>
	When I Navigate to SSC > Customers
	Then I validate user is added with "Points to Next Tier" points on SSC <UserCategory> <ExcelFile> <SheetName>
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
	#Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	Then I change Ticket to Upgrade Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	#Then I validate the Customer Tier
	#Then I validate the Customer Tier <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                             | ExcelFile                    | SheetName |
		| TC_232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade | TestDataSSCRegressionUpgrade | G07       |

#234	Verify that the CST is able to Deactivate the Group Account
@SVCRegression @G07  @234_DeactivateGroupAccountValidateOnSSCSMCAC @E2ERun
Scenario Outline: TC_234_DeactivateGroupAccountValidateOnSSCSMCAC
	#Given I create 1 Full Reward User in Harrods.com
	Given I launch the "SSC" website
	#Registering new User for Group Deactivation
	When I Navigate to SSC > Customers
	Then I create new customer in SSC
	When I Navigate to SSC > Group Accounts
	And I create new group account with PrimaryMember from SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I "DeActivate" given group account "" from SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I should validate is deactivated from SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser window

	Examples:
		| UserCategory                                    | ExcelFile                    | SheetName |
		| TC_234_DeactivateGroupAccountValidateOnSSCSMCAC | TestDataSSCRegressionUpgrade | G07       |

#249	Verify the Black tier customer is able to cancel the 2nd slot(Day 2) of  previously booked 10% discount day from Harrods.com
@SVCRegression @G15 @249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct
Scenario Outline: TC_249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I verify whether 10 percent discount is displayed to user <UserCategory> <ExcelFile> <SheetName>
	And I cancel Day 2 slot and check remaining count <UserCategory> <ExcelFile> <SheetName>
	#And I cancel the existing slots
	And I close the browser window

	Examples:
		| UserCategory                                              | ExcelFile                    | SheetName |
		| TC_249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct | TestDataSSCRegressionUpgrade | G15       |

#250	Verify the Black tier customer is able to book 1st slot(Day 1)of 10% discount day again from Harrods.com, after cancellation of the same date.
@SVCRegression @G15 @250_BlackTierCustomer_Book_1st_slot_aftercancellation
Scenario Outline: TC_250_BlackTierCustomer_Book_1st_slot_aftercancellation
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I verify whether 10 percent discount is displayed to user <UserCategory> <ExcelFile> <SheetName>
	And I cancel Day 2 slot and check remaining count <UserCategory> <ExcelFile> <SheetName>
	And I reselect the Ten percent discount for the user <UserCategory> <ExcelFile> <SheetName>
	And I cancel the existing slots
	And I close the browser window

	Examples:
		| UserCategory                                             | ExcelFile                    | SheetName |
		| TC_250_BlackTierCustomer_Book_1st_slot_aftercancellation | TestDataSSCRegressionUpgrade | G15       |

#251	Verify CST advisor is able cancel the  second slot of 10% discount day date booked from SSC on Black tier customer request.
@SVCRegression @G15 @251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest
Scenario Outline: TC_251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate the count of Ten percent discount days in SSC <UserCategory> <ExcelFile> <SheetName>
	And I create a Cancellation Request Ticket of SlotTwo for the Customer <UserCategory> <ExcelFile> <SheetName> and validate the remaining slots
	And I close the browser window

	Examples:
		| UserCategory                                                          | ExcelFile                    | SheetName |
		| TC_251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest | TestDataSSCRegressionUpgrade | G15       |

@SVCRegression @G01 @291_CSTMember_Optin_Post_Phone_Email_SMS @E2ERun
Scenario Outline: TC_291_CSTMember_Optin_Post_Phone_Email_SMS
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I "Opt-In" for "Telephone,Letter,SMS,E-Mail" for the user in <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window
	Given I launch the "Harrods" website
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	And I validate the Marketing consent "Opt-In" for "phone,postal,sms,email" for the user in <UserCategory> <ExcelFile> <SheetName> as per selection in SSC
	Then I close the browser window

	Examples:
		| UserCategory                                | ExcelFile                    | SheetName |
		| TC_291_CSTMember_Optin_Post_Phone_Email_SMS | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @292_CSTMember_Optout_AllChannels @E2ERun
Scenario Outline: TC_292_CSTMember_Optout_AllChannels
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I "Opt-Out" for "Telephone,Letter,SMS,E-Mail,Publications" for the user in <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window
	Given I launch the "Harrods" website
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	And I validate the Marketing consent "Opt-Out" for "phone,postal,sms,email,publications" for the user in <UserCategory> <ExcelFile> <SheetName> as per selection in SSC
	Then I close the browser window

	Examples:
		| UserCategory                        | ExcelFile                    | SheetName |
		| TC_292_CSTMember_Optout_AllChannels | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @293_CSTMember_Optin_AllChannels @E2ERun
Scenario Outline: TC_293_CSTMember_Optin_AllChannels
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I "Opt-In" for "Telephone,Letter,SMS,E-Mail,Publications" for the user in <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window
	Given I launch the "Harrods" website
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	And I validate the Marketing consent "Opt-In" for "phone,postal,sms,email" for the user in <UserCategory> <ExcelFile> <SheetName> as per selection in SSC
	Then I close the browser window

	Examples:
		| UserCategory                       | ExcelFile                    | SheetName |
		| TC_293_CSTMember_Optin_AllChannels | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @294_CSTMember_Optout_AllInterests @E2ERun
Scenario Outline: TC_294_CSTMember_Optout_AllInterests
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I "Opt-Out" All Interests for the user in <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser window
	Given I launch the "Harrods" website
	When I login to Harrods with a Registered user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to the Harrods > Communication Preferences
	And I validate whether all Interests are opted out for customer
	Then I close the browser window

	Examples:
		| UserCategory                         | ExcelFile                    | SheetName |
		| TC_294_CSTMember_Optout_AllInterests | TestDataSSCRegressionUpgrade | G01       |

#New Test Scenarios for Mobile Number validation
#Verify that phone number field accepts only numeric values
 @SVCRegression @G01 @295_PhoneNumber_Accept_NumericValues
Scenario Outline: TC_295_PhoneNumber_Accept_NumericValues
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new customer and validate phone number field "GB - +44" "RRTT336621" <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                            | ExcelFile                    | SheetName |
		| TC_295_PhoneNumber_Accept_NumericValues | TestDataSSCRegressionUpgrade | G01       |

#Verify that phone number field doesn’t not allow special characters and spaces
 @SVCRegression @G01 @296_PhoneNumber_NotAllow_SpecialcharacterandSpace
Scenario Outline: TC_296_PhoneNumber_NotAllow_SpecialcharacterandSpace
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new customer and validate phone number field "GB - +44" "'@#'TT  662'" <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                         | ExcelFile                    | SheetName |
		| TC_296_PhoneNumber_NotAllow_SpecialcharacterandSpace | TestDataSSCRegressionUpgrade | G01       |

 @SVCRegression @G01 @297_UKPhonenumber_Startswith7
Scenario Outline: TC_297_UKPhonenumber_Startswith7
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new customer and validate phone number field "GB - +44" "9966225511" <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                     | ExcelFile                    | SheetName |
		| TC_297_UKPhonenumber_Startswith7 | TestDataSSCRegressionUpgrade | G01       |

 @SVCRegression @G01 @298_UKPhonenumber_Length_is_10
Scenario Outline: TC_298_UKPhonenumber_Length_is_10
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new customer and validate phone number field "GB - +44" "99662211" <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                      | ExcelFile                    | SheetName |
		| TC_298_UKPhonenumber_Length_is_10 | TestDataSSCRegressionUpgrade | G01       |

 @SVCRegression @G01 @299_InternationalPhonenumber
Scenario Outline: TC_299_InternationalPhonenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new customer and validate phone number field "US - +1" "9966221144" <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                    | ExcelFile                    | SheetName |
		| TC_299_InternationalPhonenumber | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @300_NonUKPhonenumber_Length_min7
Scenario Outline: TC_300_NonUKPhonenumber_Length_min7
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new customer and validate phone number field "US - +1" "996622" <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                        | ExcelFile                    | SheetName |
		| TC_300_NonUKPhonenumber_Length_min7 | TestDataSSCRegressionUpgrade | G01       |

 @SVCRegression @G01 @301_IncorrectFormat_Phonenumber
Scenario Outline: TC_301_IncorrectFormat_Phonenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new customer and validate phone number field "GB - +44" "1231231234" <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                       | ExcelFile                    | SheetName |
		| TC_301_IncorrectFormat_Phonenumber | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @302_Phonenumber_inclDialcode_Length_Max_13
Scenario Outline: TC_302_Phonenumber_inclDialcode_Length_Max_13
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new customer and validate phone number field "GB - +44" "996622114421" <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                  | ExcelFile                    | SheetName |
		| TC_302_Phonenumber_inclDialcode_Length_Max_13 | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @303_AddPhonenumber_CustomersFirstnumber
Scenario Outline: TC_303_AddPhonenumber_CustomersFirstnumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                               | ExcelFile                    | SheetName |
		| TC_303_AddPhonenumber_CustomersFirstnumber | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @304_DeletePhonenumber
Scenario Outline: TC_304_DeletePhonenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I delete "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory             | ExcelFile                    | SheetName |
		| TC_304_DeletePhonenumber | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @305_CreateNewCustomer_withMobilenumber_Updated_to_othersystems
Scenario Outline: TC_305_CreateNewCustomer_withMobilenumber_Updated_to_othersystems
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new customer <UserCategory> <ExcelFile> <SheetName>
	And I validate whether the user created is a duplicate
	Then I add new "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                                      | ExcelFile                    | SheetName |
		| TC_305_CreateNewCustomer_withMobilenumber_Updated_to_othersystems | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @306_AddMobilenumber_fromHarrods_Updated_to_othersystems
Scenario Outline: TC_306_AddMobilenumber_fromHarrods_Updated_to_othersystems
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add new "UK" phone number to the user born <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                               | ExcelFile                    | SheetName |
		| TC_306_AddMobilenumber_fromHarrods_Updated_to_othersystems | TestDataSSCRegressionUpgrade | G01       |

 @SVCRegression @G01 @307_UpdateMobilenumber_fromHarrods_Updated_to_othersystems
Scenario Outline: TC_307_UpdateMobilenumber_fromHarrods_Updated_to_othersystems
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I edit "UK" Phonenumber of the user <ExcelFile> <SheetName> <UserCategory>
	And I close the browser window

	Examples:
		| UserCategory                                                  | ExcelFile                    | SheetName |
		| TC_307_UpdateMobilenumber_fromHarrods_Updated_to_othersystems | TestDataSSCRegressionUpgrade | G01       |