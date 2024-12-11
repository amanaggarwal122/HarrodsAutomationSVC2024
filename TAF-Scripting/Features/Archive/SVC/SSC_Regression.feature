Feature: SSC Regression cases

#User creation in Other systems
#G01.01 - Lite Account
@SVCRegression @G01 @001_Lite_account_NewuserSignup
Scenario Outline: TC_001_Lite_account_NewuserSignup
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	And I perform SignUp action with a new user from Harrods.com
	And I perform email validation from yopmail
	Then I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate signed up new user is reflecting on SSC
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate signed up new user is reflecting on SMC
	And I close the browser

@SVCRegression @G01 @004_UnsubscribeEmailfromFooter
Scenario Outline: TC_004_UnsubscribeEmailfromFooter
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
		| ExcelFileName         | SheetName | UserCategory                   |
		| TestDataSVCRegression | G01       | 004_UnsubscribeEmailfromFooter |

@SVCRegression @G01 @005_NewNonReward_HarrodsReg_EmailConsentNo
Scenario Outline: TC_005_NewNonReward_HarrodsReg_EmailConsentNo
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
		| UserCategory                               | ExcelFile             | SheetName |
		| 005_NewNonReward_HarrodsReg_EmailConsentNo | TestDataSVCRegression | G01       |

@SVCRegression @G01 @006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes
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
		| UserCategory                                                | ExcelFile             | SheetName |
		| 006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |


@SVCRegression @G01 @009_NewFullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_009_NewFullReward_HarrodsReg_EmailConsentYes
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
		| UserCategory                                 | ExcelFile             | SheetName |
		| 009_NewFullReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @010_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_010_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website	
	When I perform and validate existing "<UserCategory>" customer from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I should verify existing "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
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
		| UserCategory                                                 | ExcelFile             | SheetName |
		| 010_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @011_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentNo
Scenario Outline: TC_011_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentNo
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
		| UserCategory                                                | ExcelFile             | SheetName |
		| 011_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentNo | TestDataSVCRegression | G01       |

@SVCRegression @G01 @013_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_013_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                          | ExcelFile             | SheetName |
		| 013_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |


@SVCRegression @G01 @015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                  | ExcelFile             | SheetName |
		| 015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |


@SVCRegression @G01 @018_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo
Scenario Outline: TC_018_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo
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
		| UserCategory                                                              | ExcelFile             | SheetName |
		| 018_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo | TestDataSVCRegression | G01       |

@SVCRegression @G01 @022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                          | ExcelFile             | SheetName |
		| 022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @024_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_024_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                               | ExcelFile             | SheetName |
		| 024_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: TC_025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                                 | ExcelFile             | SheetName |
		| 025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @028_NonReward_HarrodsJoinRewardWithoutCardData
Scenario Outline: TC_028_NonReward_HarrodsJoinRewardWithoutCardData
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
		| UserCategory                                   | ExcelFile             | SheetName |
		| 028_NonReward_HarrodsJoinRewardWithoutCardData | TestDataSVCRegression | G01       |

#G01.02 - Online - Full Account - Manage Personal Details
@SVCRegression @G01 @045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber
Scenario Outline: TC_045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I add new "UK" phone number to the user born <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                                    |
		| TestDataSVCRegression | G01       | 045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber |

@SVCRegression @G01 @049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber
Scenario Outline: TC_049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>	
	Then I edit "UK" Phonenumber of the user <ExcelFile> <SheetName> <UserCategory>
	And I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I search for the Customer in SSC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                               |
		| TestDataSVCRegression | G01       | 049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber |


@SVCRegression @G01 @052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber
Scenario Outline: TC_052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I delete the phone number
	And I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I search for the user in SSC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName> 
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts	
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName> 
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                        |
		| TestDataSVCRegression | G01       | 052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber |

@SVCRegression @G01 @055_Verify_existing_loyaltyrewardscustomer_AddDOB
Scenario Outline: TC_055_Verify_existing_loyaltyrewardscustomer_AddDOB
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I add DOB for the user <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the user in SSC and validate whether the DOB is updated <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts	
	Then I search for the user in SMC and validate whether the DOB is updated <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                      |
		| TestDataSVCRegression | G01       | 055_Verify_existing_loyaltyrewardscustomer_AddDOB |

@SVCRegression @070_Existing_LoyaltyRewardCustomer_AddUKAddress
Scenario Outline: TC_070_Existing_LoyaltyRewardCustomer_AddUKAddress
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
		| ExcelFile             | SheetName | UserCategory                                   |
		| TestDataSVCRegression | G01       | 070_Existing_LoyaltyRewardCustomer_AddUKAddress |

@SVCRegression @G01 @073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress
Scenario Outline: TC_073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress
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
		| ExcelFile             | SheetName | UserCategory                                           |
		| TestDataSVCRegression | G01       | 073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress |

@SVCRegression @G01 @108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress
Scenario Outline: TC_108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress
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
		| ExcelFile             | SheetName | UserCategory                                                                     |
		| TestDataSVCRegression | G01       | 108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress |


@SVCRegression @G01 @110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress
Scenario Outline: TC_110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I validate that the "DeliveryAddress" addresses can be swaped
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate swap "DeliveryAddress" address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate swap address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                                   |
		| TestDataSVCRegression | G01       | 110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress |

@SVCRegression @G01 @116_NewUserPrespaRegistrationBookingAndSVCValidation
Scenario Outline: TC_116_NewUserPrespaRegistrationBookingAndSVCValidation
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

@SVCRegression @G01 @119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child
Scenario Outline: TC_119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child
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
		| ExcelFile             | SheetName | UserCategory                                                   |
		| TestDataSVCRegression | G01       | 119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child |

@SVCRegression @G01 @120_LoyaltyRewardsCustomer_RemoveLastChildFromMiniHarrods
Scenario Outline: TC_120_LoyaltyRewardsCustomer_RemoveLastChildFromMiniHarrods
	Given I launch the browser to open the harrods website
	When I add another child "<UserName>" "<Email>" to mini harrods from Harrods.com
	And I remove last child of "<UserName>" from Harrods.com
	Then I should validate removed "<UserName>" child is not showing on Harrods.com
	And I close the browser
	
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate removed "<UserName>" "<Email>" child is not showing on SSC
	And I close the browser

	Examples:
		| UserName   | Email                |
		| Multichild | Multichild@gmail.com |

@SVCRegression @G01 @121_OnlineRewardCustomer_CancelMiniHarrodsSubscription
Scenario Outline: TC_121_OnlineRewardCustomer_CancelMiniHarrodsSubscription
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
	Then I should validate removed "<UserName>" "<Email>" child is not showing on SSC
	And I close the browser

	Examples:
		| UserName   | Email                |
		| Minisubscr | Minisubscr@gmail.com |

@SVCRegression @G01 @165_liteUserRegistrationByNewsLetterSignup
Scenario Outline: TC_165_liteUserRegistrationByNewsLetterSignup
	Given I launch the "Harrods" website
	When I perform news letter signup with new user fromn Harrods.com
	And I perform email validation from yopmail
	Then I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate signed up new user is reflecting on SSC
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate signed up new user is reflecting on SMC
	And I should validate the welcome interaction email against signup user on SMC
	And I close the browser

	#166	Full non rewards registration from Harrods.com using an email address that does not exist in CDC(with email consent)
@SVCRegression @G02 @166_NonReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_166_NonReward_HarrodsReg_EmailConsentYes
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
		| UserCategory                             | ExcelFile             | SheetName |
		| 166_NonReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G02       |

#167	Full Rewards registration from Harrods.com with an email address that does not exist in CDC (with email consent)
@SVCRegression @G02 @167_FullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_167_FullReward_HarrodsReg_EmailConsentYes
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
		| UserCategory                              | ExcelFile             | SheetName |
		| 167_FullReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G02       |

#168	Full Rewards registration from Harrods.com with an email address that belongs to existing non-loyalty customer (with email consent)
@SVCRegression @G01 @168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes
Scenario Outline: TC_168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes
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
		| UserCategory                                                 | ExcelFile             | SheetName |
		| 168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G02       |


@SVCRegression @G02 @178_HarrodsRegistrationForFullRewardCustomerWithEmailConsentYes
Scenario Outline: TC_178_HarrodsRegistrationForFullRewardCustomerWithEmailConsentYes
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
		| UserCategory                                                   | ExcelFile             | SheetName |
		| 178_HarrodsRegistrationForFullRewardCustomerWithEmailConsentYes | TestDataSVCRegression | G02       |


@SVCRegression @G02 @179_HarrodsRegistrationForLiteCustomerWithEmailConsentYes
Scenario Outline: TC_179_HarrodsRegistrationForLiteCustomerWithEmailConsentYes
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
		| UserCategory                                             | ExcelFile             | SheetName |
		| 179_HarrodsRegistrationForLiteCustomerWithEmailConsentYes | TestDataSVCRegression | G02       |

@SVCRegression @G02 @180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail
Scenario Outline: TC_180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail
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
		| UserCategory                                         | ExcelFile             | SheetName |
		| 180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail | TestDataSVCRegression | G02       |

@SVCRegression @G02 @187_OnlineFullReturnAndPointValidation
Scenario Outline: TC_187_OnlineFullReturnAndPointValidation
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify sales interaction against full return "<UserName>" "<Email>" "<DocId>"showing on SMC
	And I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify full return for "<UserName>" "<Email>" is showing on SSC
	And I close the browser

	Given I launch the "AC" website
	When I Navigate to AC > Reports > Point Reports
	Then I should verify deduction full return "<PointDeduction>" is showing on AC
	And I close the browser

	Examples:
		| UserName   | Email                                      | DocId  | PointDeduction |
		| Ahmed Ryan | Ahmed.Ryan.2669375@Harrods.ProctorTech.com | QAGQ3M | -1             |



	#249	Verify the Black tier customer is able to cancel the 2nd slot(Day 2) of  previously booked 10% discount day from Harrods.com
@SVCRegression @G15 @249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct
Scenario Outline: TC_249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct
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
	| ExcelFile             | SheetName | UserCategory                                           |
	| TestDataSVCRegression | G15       | 249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct |

#250	Verify the Black tier customer is able to book 1st slot(Day 1)of 10% discount day again from Harrods.com, after cancellation of the same date.
@SVCRegression @G15 @250_BlackTierCustomer_Book_1st_slot_aftercancellation
Scenario Outline: TC_250_BlackTierCustomer_Book_1st_slot_aftercancellation
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"	
	#Then I verify whether 10 percent discount is displayed to user
	Then I cancel Day 2 slot and check remaining count
	And I reselect the Ten percent discount for the user
	And I close the browser

	#Given I launch the "AC" website	
	#When I Navigate to AC > Reports > Member Reports
	#Then I validate the discount booking date in AC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	#And I close the browser
	
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	#Then I should validate cancelled status is updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I validate whether the 10 percent discount is updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	#Then I should validate cancelled status is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I should whether the 10 percent discount is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

Examples:
	| ExcelFile             | SheetName | UserCategory                                          |
	| TestDataSVCRegression | G15       | 250_BlackTierCustomer_Book_1st_slot_aftercancellation |


## Creation in SSC Website

@SVCRegression @G01 @082_AddUKAddressFromSSC
Scenario Outline: TC_082_AddUKAddressFromSSC
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
		| Country | UserName | Email              |
		| UK      | LoyalUsr | LoyalUsr@gmail.com |

@SVCRegression @G01 @059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber
Scenario Outline: TC_059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I add new "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>	
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts	
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                           |
		| TestDataSVCRegression | G01       | 059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber |


@SVCRegression @G01 @062_Verify_loyaltyrewardscustomer_editUKmobilenumber
Scenario Outline: TC_062_Verify_loyaltyrewardscustomer_editUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I edit "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>		
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts	
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                         |
		| TestDataSVCRegression | G01       | 062_Verify_loyaltyrewardscustomer_editUKmobilenumber |

@SVCRegression @G01 @064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber
Scenario Outline: TC_064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I delete "UK" <Phonenumber> with <UserName>,<UserEmail> in SSC
	And I close the browser

	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>	
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName> 
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                           |
		| TestDataSVCRegression | G01       | 064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber |

@SVCRegression @G01 @067_Verify_nonrewardscustomer_addnewUKmobilenumber
Scenario Outline: TC_067_Verify_nonrewardscustomer_addnewUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I add new "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>	
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts	
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                       |
		| TestDataSVCRegression | G01       | 067_Verify_nonrewardscustomer_addnewUKmobilenumber |

@SVCRegression @G01 @068_Verify_nonrewardscustomer_editUKmobilenumber
Scenario Outline: TC_068_Verify_nonrewardscustomer_editUKmobilenumber
Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I edit "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>		
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts	
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                     |
		| TestDataSVCRegression | G01       | 068_Verify_nonrewardscustomer_editUKmobilenumber |
		

@SVCRegression @G01 @069_Verify_nonrewardscustomer_DeleteUKmobilenumber
Scenario Outline: TC_069_Verify_nonrewardscustomer_DeleteUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I delete "UK" <Phonenumber> with <UserName>,<UserEmail> in SSC
	And I close the browser

	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>	
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName> 
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                       |
		| TestDataSVCRegression | G01       | 069_Verify_nonrewardscustomer_DeleteUKmobilenumber |


@SVCRegression @G01 @085_EditUKAddressFromSSC
Scenario Outline: TC_085_EditUKAddressFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I edit "<Country>" default contact address for "<UserName>" and "<Email>" from SSC
	Then I should validate edited "<Country>" address for "<UserName>" and "<Email>" successfully updated on SSC
	And I close the browser

	Given I launch the browser to open the harrods website
	Then I should validate edited "<Country>" address for "<UserName>" "<Email>" is showing on Harrods.com
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited "<Country>" address for "<UserName>" "<Email>" is showing on SMC
	And I close the browser

	Examples:
		| Country | UserName | Email              |
		| UK      | LoyalUsr | LoyalUsr@gmail.com |

@SVCRegression @G01 @086_EditNonUKAddressFromSSC
Scenario Outline: TC_086_EditNonUKAddressFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I edit "<Country>" default contact address for "<UserName>" and "<Email>" from SSC
	Then I should validate edited "<Country>" address for "<UserName>" and "<Email>" successfully updated on SSC
	And I close the browser

	Given I launch the browser to open the harrods website
	Then I should validate edited "<Country>" address for "<UserName>" "<Email>" is showing on Harrods.com
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited "<Country>" address for "<UserName>" "<Email>" is showing on SMC
	And I close the browser

	Examples:
		| Country | UserName | Email              |
		| US      | LoyalUsr | LoyalUsr@gmail.com |

@SVCRegression @G01 @090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap
Scenario Outline: TC_090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap
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
		| ExcelFile             | SheetName | UserCategory                                                              |
		| TestDataSVCRegression | G01       | 090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap |

@SVCRegression @G01 @091_Create_new_Qatari_staffcustomer_SSC @E2ERun
Scenario Outline: TC_091_Create_new_Qatari_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Qatari staff <UserCategory> <ExcelFile> <SheetName>
	Then I validate the newly added Qatari staff <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                            |
		| TestDataSVCRegression | G01       | 091_Create_new_Qatari_staffcustomer_SSC |

@SVCRegression @G01 @092_Create_new_AlFayad_staffcustomer_SSC @E2ERun
Scenario Outline: TC_092_Create_new_AlFayad_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I add a new AlFayad staff <UserCategory> <ExcelFile> <SheetName>	
	Then I validate the newly added AlFayad staff <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                             |
		| TestDataSVCRegression | G01       | 092_Create_new_AlFayad_staffcustomer_SSC |
		
@SVCRegression @G01 @093_Create_new_Pressperson_staffcustomer_SSC @E2ERun
Scenario Outline: TC_093_Create_new_Pressperson_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I add a new Press person staff <UserCategory> <ExcelFile> <SheetName>		
	Then I validate the newly added Press person staff <UserCategory> <ExcelFile> <SheetName>	
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                 |
		| TestDataSVCRegression | G01       | 093_Create_new_Pressperson_staffcustomer_SSC |

@SVCRegression @G01 @094_Create_new_InteriorDesignperson_staffcustomer_SSC @E2ERun
Scenario Outline: TC_094_Create_new_InteriorDesignperson_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I add a new Interior Design person staff <UserCategory> <ExcelFile> <SheetName>	
	Then I validate the newly added Interior Design person staff <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                          |
		| TestDataSVCRegression | G01       | 094_Create_new_InteriorDesignperson_staffcustomer_SSC |

@SVCRegression @G01 @095_Add_Spouse_Civil_Partner_to_staff_SSC @E2ERun
Scenario Outline: TC_095_Add_Spouse_Civil_Partner_to_staff_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a spouse to the user to staff <UserCategory> <ExcelFile> <SheetName>	
	Then I validate the spouse added to staff <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                              |
		| TestDataSVCRegression | G01       | 095_Add_Spouse_Civil_Partner_to_staff_SSC |

@SVCRegression @G01 @114_VerifyBeautyBookingPerformedUser @E2ERun
Scenario Outline: TC_114_VerifyBeautyBookingPerformedUser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify given prespa "<UserName>" "<Email>" and "<Phone>" details were showing on SSC
	And I close the browser

	Examples:
		| UserName | Email                | Phone      |
		| Bbooking | Bbooking@yopmail.com | 7837837839 |

@SVCRegression @G01 @147_CST_Resend_the_Verfication_Emails @E2ERun
Scenario Outline: TC_147_CST_Resend_the_Verfication_Emails
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I Search and Send Verification Email to the user <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                          |
		| TestDataSVCRegression | G01       | 147_CST_Resend_the_Verfication_Emails |

@SVCRegression @G01 @148_CST_Register_FullAccountCustomer_for_MiniHarrods
Scenario Outline: TC_148_CST_Register_FullAccountCustomer_for_MiniHarrods
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I add Child for the user <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts	
	Then I should validate the added child details are updated in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                         |
		| TestDataSVCRegression | G01       | 148_CST_Register_FullAccountCustomer_for_MiniHarrods |

@SVCRegression @G01 @149_CST_Remove_LastChild_from_MiniHarrods
Scenario Outline: TC_149_CST_Remove_LastChild_from_MiniHarrods
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I remove added child of the user <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts	
	Then I should validate the removed child is not showing on SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                              |
		| TestDataSVCRegression | G01       | 149_CST_Remove_LastChild_from_MiniHarrods |

@SVCRegression @G01 @150_CST_CreateFUllRewardsCustomer_NotinSVCDB
Scenario Outline: TC_150_CST_CreateFUllRewardsCustomer_NotinSVCDB
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
		| ExcelFile             | SheetName | UserCategory                                 |
		| TestDataSVCRegression | G01       | 150_CST_CreateFUllRewardsCustomer_NotinSVCDB |

@SVCRegression @G01 @151_CST_Replace_StolenCard
Scenario Outline: TC_151_CST_Replace_StolenCard
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Deactivate old card and activate new card for the customer <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for customer in SMC and validate the Reward Card <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory               |
		| TestDataSVCRegression | G01       | 151_CST_Replace_StolenCard |

@SVCRegression @G01 @152_CST_Deactivate_activecard_with_InvalidCardID
Scenario Outline: TC_152_CST_Deactivate_activecard_with_InvalidCardID
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I Deactivate the card for the customer <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts	
	Then I search for customer in SMC and validate Reward Card <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                     |
		| TestDataSVCRegression | G01       | 152_CST_Deactivate_activecard_with_InvalidCardID |

@SVCRegression @G01 @153_CST_ChangeName_inCard_SSC_resendto_CustomerUKAddress @E2ERun
Scenario Outline: TC_153_CST_ChangeName_inCard_SSC_resendto_CustomerUKAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I edit the name in Card for the customer <UserCategory> <ExcelFile> <SheetName>
	And I verify whether the Name in Card is changed for the customer <UserCategory> <ExcelFile> <SheetName>
	Then I send the New card to the customer
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                             |
		| TestDataSVCRegression | G01       | 153_CST_ChangeName_inCard_SSC_resendto_CustomerUKAddress |

@SVCRegression @G01 @154_CST_CardReplenishment_Jobs @E2ERun
Scenario Outline: TC_154_CST_CardReplenishment_Jobs
	Given I launch the "SSC" website
	When I Navigate to SSC > CardManagement	
	And I create a new Card Replenishment job with <UserCategory> <ExcelFile> <SheetName>	
	Then I validate the status of the job <UserCategory> <ExcelFile> <SheetName>

	Examples:
		| ExcelFile             | SheetName | UserCategory                   |
		| TestDataSVCRegression | G01       | 154_CST_CardReplenishment_Jobs |

		#155	Verify if the user is able to merge two accounts with deemed customer(G2 tier with rewards and status 4900 points) and 
#surviving customer(Gold tier with rewards and status 5100) - need to be upgraded to BLACK tier
		
@SVCRegression @G01 @155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack
Scenario Outline: TC_155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack
	Given I launch the "SSC" website
	When I Navigate to SSC > Customer Merge
	And Search for two active users and merge <UserCategory> <ExcelFile> <SheetName>
	And I edit the Attributes of the Surviving Customer and save	
	When I Navigate to SSC > Customers
	And I Validate whether the deemed customer is not available in SSC <UserCategory> <ExcelFile> <SheetName>
	#When I Navigate to SSC > Tickets
	#And I create ticket for reward points merge for user <UserCategory> <ExcelFile> <SheetName>
	#there is issue in SSC for updating merge ticket

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate whether the deemed user is not found in SMC <UserCategory> <ExcelFile> <SheetName>

Examples:
	| ExcelFile             | SheetName | UserCategory                                      |
	| TestDataSVCRegression | G01       | 155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack |

#156	"Verify if the user is able to merge two rewards account selecting Customer 2's email address and Customer 1's surviving record ID
#Customer 1 - Non - Online email address
#Customer 2 - Online email address"
@SVCRegression @G01 @156_Merge_TwoAccounts_AndRegisterDeemedUser
Scenario Outline: TC_156_Merge_TwoAccounts_AndRegisterDeemedUser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customer Merge
	And Search for two active users and merge <UserCategory> <ExcelFile> <SheetName>
	And I edit the Attributes of the Surviving Customer and save	
	When I Navigate to SSC > Customers
	And I Validate whether the deemed customer is not available in SSC <UserCategory> <ExcelFile> <SheetName>
	#When I Navigate to SSC > Tickets
	#And I create ticket for reward points merge for user <UserCategory> <ExcelFile> <SheetName>
	#there is issue in SSC for updating merge ticket

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate whether the deemed user is not found in SMC <UserCategory> <ExcelFile> <SheetName>

	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com	
	And I perform SignUp action with a reg user full rewards from Harrods.com <UserCategory> <ExcelFile> <SheetName>
	And I perform reg user email validation from yopmail
	Then I close the browser

	| UserCategory                                | ExcelFile             | SheetName |
	| 156_Merge_TwoAccounts_AndRegisterDeemedUser | TestDataSVCRegression | G01       |

@SVCRegression @G01 @157_CSTMember_SearchExistCustomer_EmailAddress @E2ERun
Scenario Outline: TC_157_CSTMember_SearchExistCustomer_EmailAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search the Customer email and validate in SSC <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| UserCategory                                   | ExcelFile             | SheetName |
		| 157_CSTMember_SearchExistCustomer_EmailAddress | TestDataSVCRegression | G01       |

#158	Verify that the CST Member is able to add a Customer as "Potential Reseller"
@SVCRegression @G01 @158_CSTMember_Add_Potential_Reseller @E2ERun
Scenario Outline: TC_158_CSTMember_Add_Potential_Reseller
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I Add and validate Potential Reseller Attribute to Customer from <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| UserCategory                         | ExcelFile             | SheetName |
		| 158_CSTMember_Add_Potential_Reseller | TestDataSVCRegression | G01       |

#159	Verify that the CST Member is able to remove a Customer as "Potential private shopping"
@SVCRegression @G01 @159_CSTMember_Remove_Potential_PrivateShopping @E2ERun
Scenario Outline: TC_159_CSTMember_Remove_Potential_PrivateShopping
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I remove the Private Shopping Attribute of the Customer <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| ExcelFile             | SheetName                                      |
		| TestDataSVCRegression | 159_CSTMember_Remove_Potential_PrivateShopping |

@SVCRegression @G01 @160_CSTMember_UpdateDOBofCsutomer @E2ERun
Scenario Outline: TC_160_CSTMember_UpdateDOBofCsutomer
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I update the <DOB> of the customer <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| ExcelFile             | SheetName                         | DOB        |
		| TestDataSVCRegression | 160_CSTMember_UpdateDOBofCsutomer | 01.07.1994 |

#Verify that the CST is able to create a Enquiry ticket for a Customer to upgrade tier from Green 0 to Gold (Manual Tier Upgrade)
@SVCRegression @G07 @221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade
Scenario Outline: TC_221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	And I create a new Service Ticket
	And I enter all the mandatory details and select the <UserCategory> <ExcelFile> <SheetName>	
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	Then I validate the Customer Tier
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I search for the ticket created <UserCategory> <ExcelFile> <SheetName>	
	And I close the browser

	 Examples:
	| ExcelFile             | SheetName | UserCategory                                                         |
	| TestDataSVCRegression | G07       | 221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade |

#Verify that the CST is able to create a Complaint ticket for a Customer to upgrade tier from Black to Elite(Manual Tier Upgrade)

@SVCRegression @G07 @222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC
Scenario Outline: TC_222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	And I create staff enquiry ticket for customer miscellaneous point addition <UserCategory> <ExcelFile> <SheetName>
	When I Navigate to SSC > Customers	
	Then I validate user is added with "Miscellaneous" points on SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I validate expected "Miscellaneous" points is added on AC
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts	
	Then I validate user is added with expected "Miscellaneous" points in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I validate expected "Miscellaneous" points is added on Harrods.com
	And I close the browser
	
Examples:	
	| ExcelFile             | SheetName | UserCategory                                     |
	| TestDataSVCRegression | G07       | 222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC |

@SVCRegression @G07 @223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC
Scenario Outline: TC_223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I create complaint ticket for customer status point addition "<UserName>" "<UserEmail>"
	When I Navigate to SSC > Customers
	Then I validate "<UserName>" "<UserEmail>" is added with "Status Points" points on SSC
	And I close the browser
	
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Point Reports
	Then I validate expected "Status Points" points is added on AC
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate "<UserName>" "<UserEmail>" expected "Status Points" points is added on SMC
	And I close the browser

	Given I launch the "Harrods" website 
	When I Login with to Harrods with <UserEmail>
	Then I validate expected "Status Points" points is added on Harrods.com
	And I close the browser
	
Examples:
	| UserName                           | UserEmail                  |
	| Addstatuspoint AddstatuspointLname | Addstatuspoint@yopmail.com |

#Verify that the CST is able to add only 1 Primary Member and 4 Secondary members to Loyalty Rewards group. 	
@SVCRegression @G07 @224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup @E2ERun
Scenario Outline: TC_224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup
	Given I launch the "SSC" website	
	When I Navigate to SSC > Group Accounts
	And I create a new group account <UserCategory> <ExcelFile> <SheetName>	
	And I search for the group created and add a nonrewards member as primary member <UserCategory> <ExcelFile> <SheetName>	
	When I add a valid rewards member as primary member and add 4 valid reward members as secondary members <UserCategory> <ExcelFile> <SheetName>
	Then I Validate whether the 5 members are added successfully for the customer <UserCategory> <ExcelFile> <SheetName>
	And I validate whether user is unable to add additional members in relationships tab <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "AC" website	
	When I Navigate to AC > Reports > Hierarchy Management
	Then I validate whether the added 5 members are displayed correctly <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	
Examples:
	| ExcelFile             | SheetName | UserCategory                                                  |
	| TestDataSVCRegression | G07       | 224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup |

#Verify that the CST is able to create a Complaint ticket for a Secondary Customer to Transfer Points to another Secondary Member
@SVCRegression @G07 @225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer
Scenario Outline: TC_225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	And I create a new Service Ticket
	And I enter all the mandatory details and select the <UserCategory> <ExcelFile> <SheetName>	
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	Then I validate the Customer Tier
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I search for the ticket created <UserCategory> <ExcelFile> <SheetName>	
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                                               |
		| TestDataSVCRegression | G07       | 225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer |


@SVCRegression @G07 @226_CST_EnquiryTicket_GrantAdditional10Pct_Elite
Scenario Outline: TC_226_CST_EnquiryTicket_GrantAdditional10Pct_Elite
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	And I create a new Service Ticket
	And I enter all the mandatory details and select the <UserCategory> <ExcelFile> <SheetName>	
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed	
	Then I validate the Customer Subject Details Category
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I search for the ticket created <UserCategory> <ExcelFile> <SheetName>	
	And I close the browser

	 Examples:
	| ExcelFile             | SheetName | UserCategory                                     |
	| TestDataSVCRegression | G07       | 226_CST_EnquiryTicket_GrantAdditional10Pct_Elite |

@SVCRegression @G07 @227_CST_EnquiryTicket_GrantAdditional10Pct_Green1 @E2ERun
Scenario Outline: TC_227_CST_EnquiryTicket_GrantAdditional10Pct_Green1
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	And I create a new Service Ticket
	And I enter all the mandatory details and select the <UserCategory> <ExcelFile> <SheetName>	
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed	
	Then I validate the Customer Subject Details Category
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I search for the ticket created <UserCategory> <ExcelFile> <SheetName>	
	And I close the browser

	 Examples:
	| ExcelFile             | SheetName | UserCategory                                      |
	| TestDataSVCRegression | G07       | 227_CST_EnquiryTicket_GrantAdditional10Pct_Green1 |

@SVCRegression @G07 @228_ValidateMiscActivityOnSSC @E2ERun
Scenario Outline: TC_228_ValidateMiscActivityOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate "Miscellaneous" activity against "<UserName>" "<UserEmail>" is showing on SSC
	And I close the browser
	
Examples:
	| UserName                     | UserEmail               |
	| Addpointchk AddpointchkLname | Addpointchk@yopmail.com |

@SVCRegression @G07  @229_GreenOneToGoldTierUpgradeValidation @E2ERun
Scenario Outline: TC_229_GreenOneToGoldTierUpgradeValidation
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create ticket for "Green1-Gold" tier upgrade from file "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I Navigate to SSC > Customers
	Then I validate user tier gets upgraded to "Gold" on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should validate user points and tier is upgraded to "Gold" on AC
	And I close the browser

	 Examples:
	| ExcelFile             | SheetName | UserCategory                            |
	| TestDataSVCRegression | G07       | 229_GreenOneToGoldTierUpgradeValidation | 

@SVCRegression @G07  @230_GreenZeroToGreenTwoTierUpgradeValidation @E2ERun
Scenario Outline: TC_230_GreenZeroToGreenTwoTierUpgradeValidation
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create ticket for "Green0-Green2" tier upgrade from file "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I Navigate to SSC > Customers
	Then I validate user tier gets upgraded to "Green 2" on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I should validate user points and tier is upgraded to "Green 2" on AC
	And I close the browser

	 Examples:
	| ExcelFile             | SheetName | UserCategory                                |
	| TestDataSVCRegression | G07       | 230_GreenZeroToGreenTwoTierUpgradeValidation | 

@SVCRegression @G07 @231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC
Scenario Outline: TC_231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I create complaint ticket for customer extend point addition "<UserName>" "<UserEmail>"
	When I Navigate to SSC > Customers
	Then I validate "<UserName>" "<UserEmail>" is added with "Extend Points" points on SSC
	And I close the browser
	
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I validate expected "Extend Points" points is added on AC
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate "<UserName>" "<UserEmail>" expected "Extend Points" points is added on SMC
	And I close the browser

	Given I launch the "Harrods" website 
	When I login to Harrods Beauty Booking application with "<UserName>"
	Then I validate expected "Extend Points" points is added on Harrods.com
	And I close the browser
	
Examples:
	| UserName                           | UserEmail                  |
	| Addextendpoint AddextendpointLname | Addextendpoint@yopmail.com |

@SVCRegression @G07 @232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade
Scenario Outline: TC_232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	And I create a new Service Ticket
	And I enter all the mandatory details and select the <UserCategory> <ExcelFile> <SheetName>
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	Then I validate the Customer Tier
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I search for the ticket created <UserCategory> <ExcelFile> <SheetName>	
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                                         |
		| TestDataSVCRegression | G07       | 232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade|

@SVCRegression @G07  @233_PrimaryToSecondaryPointTransfer @E2ERun
Scenario Outline: TC_233_PrimaryToSecondaryPointTransfer
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for primary "<PrimaryMember>" to secondary "<SecondaryMember>" transfer
	And I Navigate to SSC > Customers
	Then I validate points were transfered from "<PrimaryMember>" "<PrimaryEmail>" to secondary
	And I close the browser

	Examples:
		| PrimaryMember        | PrimaryEmail        | SecondaryMember      |
		| Priuser PriuserLname | Priuser@yopmail.com | Secuser SecuserLname |
 
@SVCRegression @G07  @234_DeactivateGroupAccountValidateOnSSCSMCAC @E2ERun
Scenario Outline: TC_234_DeactivateGroupAccountValidateOnSSCSMCAC
	Given I launch the "SSC" website
	When I Navigate to SSC > Group Accounts
	And I create new group account with "<PrimaryMember>" from SSC
	And I "DeActivate" given group account "" from SSC
	Then I should validate "" is deactivated from SSC
	And I close the browser

	Given I launch the "AC" website	
	When I Navigate to AC > Reports > Hierarchy Management
	Then I should validate  "" is deactivated from AC
	And I close the browser

	 Examples:
	| PrimaryMember              |
	| Janet, Brown |

@SVCRegression @G07 @235_ValidateRedeemActivityOnSSC @E2ERun
Scenario Outline: TC_235_ValidateRedeemActivityOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate "RedeemPoints" activity against "<UserName>" "<UserEmail>" is showing on SSC
	And I close the browser
	
Examples:
	| UserName                           | UserEmail                  |
	| Redeempointchk RedeempointchkLname | Redeempointchk@yopmail.com |

#251	Verify CST advisor is able cancel the  second slot of 10% discount day date booked from SSC on Black tier customer request.
@SVCRegression @G15 @251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest
Scenario Outline: TC_251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest
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
	#Then I validate the cancellation status in AC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	#And I close the browser

	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I verify the cancellation is updated in harrods website for the customer <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                                       |
		| TestDataSVCRegression | G15       | 251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest |

#252	Verify if the existing loyalty rewards (Elite) customer with a UK address gets free delivery by purchasing greater than £10.00
@SVCRegression @G15 @252_Existing_Elite_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
Scenario Outline: TC_252_Existing_Elite_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
#Given I launch the "Harrods" website
#	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"	
#	And I add products greater than 10 Pounds and place order
#	Then I Verify free delivery is applied for the order in Bag, Invoice and Order History	
#	And I close the browser
	Given I launch the "SSC" website
	When I navigate to SSC > Sales > Purchases
	Then I enter the Purchase order number and search for <UserCategory> <ExcelFile> <SheetName>
	And I verify whether the free delivery is applied for the corresponding order <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the Purchase Order Value in SMC <UserCategory> <ExcelFile> <SheetName>	
	And I close the browser

	Given I launch the "AC" website	
	When I Navigate to AC > Reports > Order Reports
	Then I validate the Purchase Order Value in AC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                                                   |
		| TestDataSVCRegression | G15       | 252_Existing_Elite_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10 |

#253	Verify if the existing loyalty rewards (GD) customer with a UK address gets free delivery by purchasing (Products from the inclusion and exclusion list) products greater than £10.00
@SVCRegression @G15 @253_Existing_Green_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
Scenario Outline: TC_253_Existing_Green_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
#Given I launch the "Harrods" website
#	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"	
#	And I add products greater than 10 Pounds and place order
#	Then I Verify free delivery is applied for the order in Bag, Invoice and Order History	
#	And I close the browser
	Given I launch the "SSC" website
	When I navigate to SSC > Sales > Purchases
	Then I enter the Purchase order number and search for <UserCategory> <ExcelFile> <SheetName>
	And I verify whether the free delivery is applied for the corresponding order <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate the Purchase Order Value in SMC <UserCategory> <ExcelFile> <SheetName>	
	And I close the browser

	Given I launch the "AC" website	
	When I Navigate to AC > Reports > Order Reports
	Then I validate the Purchase Order Value in AC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                                                   |
		| TestDataSVCRegression | G15       | 253_Existing_Green_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10 |

@SVCRegression @G17 @259_ValidateComplaintBasedDiningCompensationOnSSC @E2ERun
Scenario Outline: TC_259_ValidateComplaintBasedDiningCompensationOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for dining compensation for "<UserName>" "<UserEmail>"
	And I change the status of ticket to "Closed" from SSC
	Then I should validate dining compensation ticket gets closed without any approvals
	And I close the browser
	
Examples:
	| UserName                   | UserEmail              |
	| Dininguser DininguserLname | Dininguser@yopmail.com |

@SVCRegression @G17 @260_ValidateComplaintBasedFlowersAsCompensationOnSSC @E2ERun
Scenario Outline: TC_260_ValidateComplaintBasedFlowersAsCompensationOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for flower as compensation for "<UserName>" "<UserEmail>"
	And I change the status of ticket to "Closed" from SSC
	Then I should validate dining compensation ticket gets closed without any approvals
	And I close the browser
	
Examples:
	| UserName                   | UserEmail              |
	| Floweruser FloweruserLname | Floweruser@yopmail.com |
	
@SVCRegression @G17 @261_AssistanceForOnlineGiftCardCompleteRequestOnSSC @E2ERun
Scenario Outline: TC_261_AssistanceForOnlineGiftCardCompleteRequestOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online gift card "<UserName>" "<UserEmail>"
	And I change the status of ticket to "Closed" from SSC
	Then I should validate online "Gift card" ticket gets closed without any approvals
	And I close the browser
	
Examples:
	| UserName                           | UserEmail                  |
	| Giftcardassist GiftcardassistLname | Giftcardassist@yopmail.com |
	
@SVCRegression @G17 @262_AssistanceForOnlineDigitalRewardsCardForEmployeeOnSSC @E2ERun
Scenario Outline: TC_262_AssistanceForOnlineDigitalRewardsCardForEmployeeOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card "<UserName>" "<UserEmail>"
	And I change the status of ticket to "Closed" from SSC
	Then I should validate online "Reward card" ticket gets closed without any approvals
	And I close the browser
	
Examples:
	| UserName                               | UserEmail                    |
	| Rewardcardassist RewardcardassistLname | Rewardcardassist@yopmail.com |
	
@SVCRegression @G17 @263_VerifySSCTicketTimelineDataIsAsperSLA @E2ERun
Scenario Outline: TC_263_VerifySSCTicketTimelineDataIsAsperSLA
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card "<UserName>" "<UserEmail>"
	Then I should validate resolved and resolution date were showing as per SLA
	And I close the browser
	
Examples:
	| UserName                   | UserEmail              |
	| Slauserchk SlauserchkLname | Slauserchk@yopmail.com |
		
@SVCRegression @G17 @264_VerifyChatTranscriptTicketSummaryAccess @E2ERun
Scenario Outline: TC_264_VerifyChatTranscriptTicketSummaryAccess
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card "<UserName>" "<UserEmail>"
	#Then I should verify "Chat transcript" ticket summary can be accessed by the customer
	Then I close the browser
	
Examples:
	| UserName                     | UserEmail               |
	| Chatxnuser ChatxnuserLname   | Chatxnuser@yopmail.com  |
		
@SVCRegression @G17 @265_VerifyCallTranscriptTicketSummaryAccess @E2ERun
Scenario Outline: TC_265_VerifyCallTranscriptTicketSummaryAccess
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card "<UserName>" "<UserEmail>"
	Then I should verify "Call transcript" ticket summary can be accessed by the customer
	And I close the browser
	
Examples:
	| UserName                     | UserEmail               |
	| Calltxnuser CalltxnuserLname | Calltxnuser@yopmail.com |

@SVCRegression @G17 @269_ValidateResolveComplaintByApologyOnSSC
Scenario Outline: TC_269_ValidateResolveComplaintByApologyOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket to resolve complaint by apology for "<UserName>" "<UserEmail>"
	And I change the status of ticket to "Closed" from SSC
	Then I should validate ticket gets closed and approvers names were added
	And I close the browser
	
Examples:
	| UserName                     | UserEmail               |
	| Apologyuser ApologyuserLname | Apologyuser@yopmail.com |

@SVCRegression @G01 @270_Create_new_QatariVIP_staffcustomer_SSC @E2ERun
Scenario Outline: TC_270_Create_new_QatariVIP_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Qatari staff <UserCategory> <ExcelFile> <SheetName>
	And I validate the newly added Qatari staff <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                               | ExcelFile             | SheetName |
		| 270_Create_new_QatariVIP_staffcustomer_SSC | TestDataSVCRegression | G01       |


@SVCRegression @G10 @277_VerifyCSTObsoleteCustomerFromSSC @E2ERun
Scenario Outline: TC_277_VerifyCSTObsoleteCustomerFromSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I update the given user "<UserName>" "<UserEmail>" to "Set As Obsolete" from SSC
	Then I should verify obsolete status on SSC is "Yes"
	When I update the given user "<UserName>" "<UserEmail>" to "Set As Active" from SSC
	Then I close the browser
	
Examples:
	| UserName                       | UserEmail                |
	| Obsoluteuser ObsoluteuserLname | Obsoluteuser@yopmail.com |
