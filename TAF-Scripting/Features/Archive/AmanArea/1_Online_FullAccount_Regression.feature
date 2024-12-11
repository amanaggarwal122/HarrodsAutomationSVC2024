Feature: Online_FullAccount_Regression

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
	And I perform "Opt-In" "<channel2>" and mixed interests consent from Harrods.com
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

