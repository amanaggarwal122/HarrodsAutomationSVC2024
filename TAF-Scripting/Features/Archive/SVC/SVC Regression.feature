Feature: SVCRegression
	SVC Regression Test cases. 
	AUT : Harrods.com, SSC, SMC and AC
	Sub groups taken: G01,G02,G05,G07,G17, G21

#G01.01 - Lite Account
@SVCRegression @G01 @001_Lite_account_NewuserSignup
Scenario Outline: 001_Lite_account_NewuserSignup
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

@SVCRegression @G01 @002_ReguserNonrewardsSignup
Scenario Outline: 002_ReguserNonrewardsSignup
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	And I perform SignUp action with a reg user Non rewards from Harrods.com <UserCategory> <ExcelFile> <SheetName>
	#And I perform SignUp action with a new user from Harrods.com
	And I perform reg user email validation from yopmail
	Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate signed up with reguser email non rewards were saved on SMC
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate signed up with reguser email full rewards were saved on SSC
	Then I close the browser

	Examples:
		| UserCategory                | ExcelFile             | SheetName |
		| 002_ReguserNonrewardsSignup | TestDataSVCRegression | G01       |

@SVCRegression @G01 @003_ReguserFullrewardsSignup
Scenario Outline: 003_ReguserFullrewardsSignup
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	And I perform SignUp action with a reg user full rewards from Harrods.com <UserCategory> <ExcelFile> <SheetName>
	#When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	And I perform SignUp action with a new user from Harrods.com
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
		| UserCategory                 | ExcelFile             | SheetName |
		| 003_ReguserFullrewardsSignup | TestDataSVCRegression | G01       |

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
		| UserCategory                   | ExcelFile             | SheetName |
		| 004_UnsubscribeEmailfromFooter | TestDataSVCRegression | G01       |

@SVCRegression @G01 @005_NewNonReward_HarrodsReg_EmailConsentNo
Scenario Outline: 005_NewNonReward_HarrodsReg_EmailConsentNo
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
		| UserCategory                               | ExcelFile             | SheetName |
		| 005_NewNonReward_HarrodsReg_EmailConsentNo | TestDataSVCRegression | G01       |

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
		| UserCategory                                                | ExcelFile             | SheetName |
		| 006_ExistingNonLoyalityNonReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @007_MigratedNonLoyalityNonReward_HarrodsReg_EmailConsentNo
Scenario Outline: 007_MigratedNonLoyalityNonReward_HarrodsReg_EmailConsentNo
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
		| UserCategory                                               | ExcelFile             | SheetName |
		| 007_MigratedNonLoyalityNonReward_HarrodsReg_EmailConsentNo | TestDataSVCRegression | G01       |

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
		| UserCategory                                         | ExcelFile             | SheetName |
		| 008_ExistingLiteNonReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

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
		| UserCategory                                 | ExcelFile             | SheetName |
		| 009_NewFullReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @010_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes
Scenario Outline: 010_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentYes
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
Scenario Outline: 011_ExistingNonLoyalityFullReward_HarrodsReg_EmailConsentNo
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
		| UserCategory                                                         | ExcelFile             | SheetName |
		| 012_ExistingGoldRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @013_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 013_ExistingBlackRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
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

@SVCRegression @G01 @014_ExistingEliteRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 014_ExistingEliteRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes
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
		| 014_ExistingEliteRewardsCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

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
		| UserCategory                                                  | ExcelFile             | SheetName |
		| 015_ExistingLiteCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @016_ExistingStaffCustomer_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 016_ExistingStaffCustomer_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                   | ExcelFile             | SheetName |
		| 016_ExistingStaffCustomer_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

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
		| UserCategory                                            | ExcelFile             | SheetName |
		| 017_NewRewardsCard_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @018_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo
Scenario Outline: 018_ExistingNonLoyalityUnassignedCard_FullRewardHarrodsReg_EmailConsentNo
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

@SVCRegression @G01 @019_ExistingLiteUnassignedCard_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 019_ExistingLiteUnassignedCard_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                        | ExcelFile             | SheetName |
		| 019_ExistingLiteUnassignedCard_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @020_ExistingRewardsUnassignedCard_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 020_ExistingRewardsUnassignedCard_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                           | ExcelFile             | SheetName |
		| 020_ExistingRewardsUnassignedCard_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @021_ExistingStaffUnassignedCard_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 021_ExistingStaffUnassignedCard_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                         | ExcelFile             | SheetName |
		| 021_ExistingStaffUnassignedCard_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

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
		| UserCategory                                                          | ExcelFile             | SheetName |
		| 022_ExistingThinUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @023_ExistingGhostGreen2UserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 023_ExistingGhostGreen2UserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
	Given I launch the "Harrods" website
	When I perform and validate and register existing "<UserCategory>" customer from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	#When I perform and validate existing "<UserCategory>" customer from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
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
		| 023_ExistingGhostGreen2UserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @024_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 024_ExistingGhostGoldUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
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
Scenario Outline: 025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                                 | ExcelFile             | SheetName |
		| 025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @026_EmailFromNonReward_CardFromReward_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 026_EmailFromNonReward_CardFromReward_FullRewardHarrodsReg_EmailConsentYes
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
		| 026_EmailFromNonReward_CardFromReward_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G01 @027_EmailFromReward_CardFromGhost_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 027_EmailFromReward_CardFromGhost_FullRewardHarrodsReg_EmailConsentYes
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
		| UserCategory                                                           | ExcelFile             | SheetName |
		| 027_EmailFromReward_CardFromGhost_FullRewardHarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

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
		| UserCategory                                   | ExcelFile             | SheetName |
		| 028_NonReward_HarrodsJoinRewardWithoutCardData | TestDataSVCRegression | G01       |

@SVCRegression @G01 @029_NonReward_HarrodsJoinRewardWithGhostPremiumPointsCard
Scenario Outline: 029_NonReward_HarrodsJoinRewardWithGhostPremiumPointsCard
	Given I launch the "Harrods" website
	When I perform join rewards as "<UserCategory>" from Harrods.com with ghost rewards card data "<ExcelFile>" and "<SheetName>"
	Then I validate user "<UserCategory>" is able to join rewards from Harrods.com with rewards card data "<ExcelFile>" and "<SheetName>"
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
		| UserCategory                                              | ExcelFile             | SheetName |
		| 029_NonReward_HarrodsJoinRewardWithGhostPremiumPointsCard | TestDataSVCRegression | G01       |

@SVCRegression @G01 @030_FullRewardHarrodsCheckOutRegistrationWithNewEmail
Scenario Outline: 030_FullRewardHarrodsCheckOutRegistrationWithNewEmail
	Given I launch the browser to open the harrods website
	When I perform guest checkout from Harrods.com
	Then I validate the order and verify the payment details
	And I close the browser and save the order details
	And I should be able to see a confirmation email
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify join rewards users with ghost card is showing on SSC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify join rewards users with ghost card is showing on SMC
	And I close the browser

@SVCRegression @G01 @031_FullRewardHarrodsCheckOutRegistrationWithNonLoyalityUserEmail
Scenario Outline: 031_FullRewardHarrodsCheckOutRegistrationWithNonLoyalityUserEmail
	Given I launch the browser to open the harrods website
	When I perform guest "<UserCategory>" user checkout with NonLoyality Email from Harrods.com "<ExcelFile>" "<SheetName>"
	Then I validate the order and verify the payment details
	And I close the browser and save the order details
	And I should be able to see a confirmation email
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify join rewards users with ghost card is showing on SSC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify join rewards users with ghost card is showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                                      | ExcelFile             | SheetName |
		| 031_FullRewardHarrodsCheckOutRegistrationWithNonLoyalityUserEmail | TestDataSVCRegression | G01       |

@SVCRegression @G01 @032_ResetPasswordFromHarrods @E2ERun
Scenario Outline: 032_ResetPasswordFromHarrods
	Given I launch the browser to open the harrods website
	When I perform forgot password action for <UserEmail>
	Then I should verify user is able to reset <UserEmail> password from Harrods.com
	And I close the browser

	Examples:
		| UserEmail            |
		| SVCSmoke44@gmail.com |

@SVCRegression @G01 @033_Reg_NonRewardCustomer_EnableEmailConsent_Yes
Scenario Outline: 033_Reg_NonRewardCustomer_EnableEmailConsent_Yes
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-In" "<channel>" and interests consent from Harrods.com
	#Then I should validate "Opt-In All" channels and interests consent were saved on Harrods.com
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Non RewardCustomer Enable EmailConsent reflected in SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Non RewardCustomer Enable EmailConsent reflected in SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                    | ExcelFile             | SheetName | channel |
		| 33_Reg_NonRewardCustomer_EnableEmailConsent_Yes | TestDataSVCRegression | G01       | email   |

@SVCRegression @G01 @034_Reg_NonRewardCustomer_EnableSMSConsent_Yes
Scenario Outline: 034_Reg_NonRewardCustomer_EnableSMSConsent_Yes
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-In" "<channel>" and interests consent from Harrods.com
	#Then I should validate "Opt-In All" channels and interests consent were saved on Harrods.com
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Non RewardCustomer Enable SMSConsent reflected in SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Non RewardCustomer Enable SMSConsent reflected in SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                   | ExcelFile             | SheetName | channel |
		| 034_Reg_NonRewardCustomer_EnableSMSConsent_Yes | TestDataSVCRegression | G01       | sms     |

@SVCRegression @G01 @035_Reg_NonRewardCustomer_EnablePostalConsent_Yes
Scenario Outline: 035_Reg_NonRewardCustomer_EnablePostConsent_Yes
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-In" "<channel>" and interests consent from Harrods.com
	#Then I should validate "Opt-In All" channels and interests consent were saved on Harrods.com
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Non RewardCustomer Enable PostalConsent reflected in SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Non RewardCustomer Enable PostalConsent reflected in SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                      | ExcelFile             | SheetName | channel |
		| 035_Reg_NonRewardCustomer_EnablePostalConsent_Yes | TestDataSVCRegression | G01       | postal  |

@SVCRegression @G01 @036_Reg_NonRewardCustomer_EnablePhoneConsent_Yes
Scenario Outline: 036_Reg_NonRewardCustomer_EnablePhoneConsent_Yes
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-In" "<channel>" and interests consent from Harrods.com
	#Then I should validate "Opt-In All" channels and interests consent were saved on Harrods.com
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Non RewardCustomer Enable phoneConsent reflected in SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Non RewardCustomer Enable phoneConsent reflected in SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                     | ExcelFile             | SheetName | channel |
		| 036_Reg_NonRewardCustomer_EnablePhoneConsent_Yes | TestDataSVCRegression | G01       | phone   |

@SVCRegression @G01 @037_Reg_NonRewardCustomer_WithSMSConsent_RemoveInterest_partially
Scenario Outline: 037_Reg_NonRewardCustomer_WithSMSConsent_RemoveInterest_partially
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-In-All" "<channel>" and select partial interests consent from Harrods.com
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Non RewardCustomer Enable SMSConsent remove interest partially reflected in SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Non RewardCustomer Enable SMSConsent remove interest partially reflected in SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                      | ExcelFile             | SheetName | channel |
		| 037_Reg_NonRewardCustomer_WithSMSConsent_RemoveInterest_partially | TestDataSVCRegression | G01       | email   |

@SVCRegression @G01 @038_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests
Scenario Outline: @038_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-In-All" "<channel>" and mixed interests consent from Harrods.com
	#Then I should validate "Opt-In All" channels and interests consent were saved on Harrods.com
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Non RewardCustomer Enable phoneConsent reflected in SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Non RewardCustomer Enable phoneConsent reflected in SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                                   | ExcelFile             | SheetName | channel |
		| 038_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests | TestDataSVCRegression | G01       | phone   |

@SVCRegression @G01 @039_Reg_LoyaltyRewardCustomerG0/G1_EnableEmailConsentYes_JoinMiniHarrods
Scenario Outline: 039_Reg_LoyaltyRewardCustomerG0/G1_EnableEmailConsentYes_JoinMiniHarrods
	Given I launch the browser to open the harrods website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	#When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"	
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-In" "<channel>" and interests consent for Rewards Customer from Harrods.com
	And I enroll on miniharrods from Communication Preferences and save in Harrods "<ExcelFile>" "<SheetName>" "<UserCategory>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser

	Examples:
		| UserCategory                                                             | ExcelFile             | SheetName | channel |
		| 039_Reg_LoyaltyRewardCustomerG0/G1_EnableEmailConsentYes_JoinMiniHarrods | TestDataSVCRegression | G01       | email   |

@SVCRegression @G01 @040_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine
Scenario Outline: 040_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine
	Given I launch the browser to open the harrods website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	#When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-In" "<channel>" and interests consent for Rewards Customer from Harrods.com
	And I enroll on miniharrods from Communication Preferences and save in Harrods "<ExcelFile>" "<SheetName>" "<UserCategory>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser

	Examples:
		| UserCategory                                                       | ExcelFile             | SheetName | channel |
		| 040_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine | TestDataSVCRegression | G01       | postal  |

@SVCRegression @G01 @041_Loyaltyrewards_Goldcustomer_EmailConsent_Yes
Scenario Outline: 041_Loyaltyrewards_Goldcustomer_EmailConsent_Yes
	Given I launch the browser to open the harrods website
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	#When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-In-All" "<channel>" and mixed interests consent from Harrods.com
	Then I should validate "Opt-In-email" "<channel>" channels and interests updated in Harrods.com
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser

	Examples:
		| UserCategory                                     | ExcelFile             | SheetName | channel |
		| 041_Loyaltyrewards_Goldcustomer_EmailConsent_Yes | TestDataSVCRegression | G01       | email   |

@SVCRegression @G01 @042_Loyaltyrewards_Goldcustomer_PostalandMagazineConsent_Yes
Scenario Outline: 042_Loyaltyrewards_Goldcustomer_PostalandMagazineConsent_Yes
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	Then I should validate "Opt-In-postal" "<channel>" channels and interests updated in Harrods.com
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser

	Examples:
		| UserCategory                                                 | ExcelFile             | SheetName | channel |
		| 042_Loyaltyrewards_Goldcustomer_PostalandMagazineConsent_Yes | TestDataSVCRegression | G01       | postal  |

@SVCRegression @G01 @043_Loyaltyrewards_Goldcustomer_signedMiniHarrods_emailconsent_removesallinterests
Scenario Outline: 043_Loyaltyrewards_Goldcustomer_signedMiniHarrods_emailconsent_removesallinterests
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	Then I should validate "No consent" "<channel>" channels and interests updated in Harrods.com
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent remove all interest reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent remove all interest reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser

	Examples:
		| UserCategory                                                                       | ExcelFile             | SheetName | channel |
		| 043_Loyaltyrewards_Goldcustomer_signedMiniHarrods_emailconsent_removesallinterests | TestDataSVCRegression | G01       | email   |

@SVCRegression @G01 @044_Loyaltyrewards_Goldcustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent
Scenario Outline: 044_Loyaltyrewards_Goldcustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	Then I should validate "All consent" "<channel>" channels and interests updated in Harrods.com
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent remove all consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent remove all consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser

	Examples:
		| UserCategory                                                                                       | ExcelFile             | SheetName | channel |
		| 044_Loyaltyrewards_Goldcustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent | TestDataSVCRegression | G01       | postal  |

#G01.02 - Online - Full Account - Manage Personal Details
@SVCRegression @G01 @045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber
Scenario Outline: 045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add new "UK" phone number to the user born <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                                    | ExcelFile             | SheetName |
		| 045_Verify_existing_loyaltyrewardscustomer_addnewUKmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @046_Verify_existing_loyaltyrewardscustomer_addnewUSmobilenumber
Scenario Outline: 046_Verify_existing_loyaltyrewardscustomer_addnewUSmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add new "US" phone number to the user born <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "US" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                                    | ExcelFile             | SheetName |
		| 046_Verify_existing_loyaltyrewardscustomer_addnewUSmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @047_Verify_existing_loyaltyrewardscustomer_addnewChinamobilenumber
Scenario Outline: 047_Verify_existing_loyaltyrewardscustomer_addnewChinamobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add new "China" phone number to the user born <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "China" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "China" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                                       | ExcelFile             | SheetName |
		| 047_Verify_existing_loyaltyrewardscustomer_addnewChinamobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @048_Verify_existing_loyaltyrewardscustomer_addnewCanadamobilenumber
Scenario Outline: 048_Verify_existing_loyaltyrewardscustomer_addnewCanadamobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add new "Canada" phone number to the user born <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "Canada" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "Canada" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                                        | ExcelFile             | SheetName |
		| 048_Verify_existing_loyaltyrewardscustomer_addnewCanadamobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber
Scenario Outline: 049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I edit "UK" Phonenumber of the user <ExcelFile> <SheetName> <UserCategory>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                               | ExcelFile             | SheetName |
		| 049_Verify_existing_loyaltyrewardscustomer_editUKmobnumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @050_Verify_existing_loyaltyrewardscustomer_editUSmobnumber
Scenario Outline: 050_Verify_existing_loyaltyrewardscustomer_editUSmobnumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I edit "US" Phonenumber of the user <ExcelFile> <SheetName> <UserCategory>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "US" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                               | ExcelFile             | SheetName |
		| 050_Verify_existing_loyaltyrewardscustomer_editUSmobnumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @051_Verify_existing_loyaltyrewardscustomer_editCanadamobnumber
Scenario Outline: 051_Verify_existing_loyaltyrewardscustomer_editCanadamobnumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I edit "Canada" Phonenumber of the user <ExcelFile> <SheetName> <UserCategory>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "Canada" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "Canada" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                                   | ExcelFile             | SheetName |
		| 051_Verify_existing_loyaltyrewardscustomer_editCanadamobnumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber
Scenario Outline: 052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
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
		| UserCategory                                        | ExcelFile             | SheetName |
		| 052_Verify_loyaltyrewardscustomer_DeleteUKmobnumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @053_Verify_loyaltyrewardscustomer_DeleteUSmobnumber
Scenario Outline: 053_Verify_loyaltyrewardscustomer_DeleteUSmobnumber
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
		| UserCategory                                        | ExcelFile             | SheetName |
		| 053_Verify_loyaltyrewardscustomer_DeleteUSmobnumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @054_Verify_loyaltyrewardscustomer_DeleteCanadamobnumber
Scenario Outline: 054_Verify_loyaltyrewardscustomer_DeleteCanadamobnumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
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
		| UserCategory                                            | ExcelFile             | SheetName |
		| 054_Verify_loyaltyrewardscustomer_DeleteCanadamobnumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @055_Verify_existing_loyaltyrewardscustomer_AddDOB
Scenario Outline: 055_Verify_existing_loyaltyrewardscustomer_AddDOB
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add DOB for the user <ExcelFile> <SheetName> <UserCategory>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the user in SSC and validate whether the DOB is updated <ExcelFile> <SheetName> <UserCategory>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the DOB is updated <ExcelFile> <SheetName> <UserCategory>
	And I close the browser

	Examples:
		| UserCategory                                      | ExcelFile             | SheetName |
		| 055_Verify_existing_loyaltyrewardscustomer_AddDOB | TestDataSVCRegression | G01       |

@SVCRegression @G01 @056_Verify_existing_nonRewardscustomer_addnewUKmobilenumber
Scenario Outline: 056_Verify_existing_nonRewardscustomer_addnewUKmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I add new "UK" phone number to the user born <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                                | ExcelFile             | SheetName |
		| 056_Verify_existing_nonRewardscustomer_addnewUKmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @057_Verify_existing_nonRewardscustomer_editUKmobilenumber
Scenario Outline: 057_Verify_existing_nonRewardscustomer_editUKmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I edit "UK" Phonenumber of the user <ExcelFile> <SheetName> <UserCategory>
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the "UK" phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                              | ExcelFile             | SheetName |
		| 057_Verify_existing_nonRewardscustomer_editUKmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @058_Verify_existing_nonRewardscustomer_DeleteUKmobilenumber
Scenario Outline: 058_Verify_existing_nonRewardscustomer_DeleteUKmobilenumber
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
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
		| UserCategory                                                | ExcelFile             | SheetName |
		| 058_Verify_existing_nonRewardscustomer_DeleteUKmobilenumber | TestDataSVCRegression | G01       |

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
		| UserCategory                                           | ExcelFile             | SheetName |
		| 059_Verify_loyaltyrewardscustomer_addnewUKmobilenumber | TestDataSVCRegression | G01       |

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
		| UserCategory                                           | ExcelFile             | SheetName |
		| 060_Verify_loyaltyrewardscustomer_addnewUSmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @061_Verify_loyaltyrewardscustomer_addnewFrancemobilenumber
Scenario Outline: 061_Verify_loyaltyrewardscustomer_addnewFrancemobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add new "France" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for the customer in Harrods.com and validate the "France" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the Customer in SMC and validate the "France" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                               | ExcelFile             | SheetName |
		| 061_Verify_loyaltyrewardscustomer_addnewFrancemobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @062_Verify_loyaltyrewardscustomer_editUKmobilenumber
Scenario Outline: 062_Verify_loyaltyrewardscustomer_editUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I edit "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
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
		| UserCategory                                         | ExcelFile             | SheetName |
		| 062_Verify_loyaltyrewardscustomer_editUKmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @063_Verify_loyaltyrewardscustomer_editUSmobilenumber
Scenario Outline: 063_Verify_loyaltyrewardscustomer_editUSmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I edit "US" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
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
		| UserCategory                                         | ExcelFile             | SheetName |
		| 063_Verify_loyaltyrewardscustomer_editUSmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber
Scenario Outline: 064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I delete "UK" <Phonenumber> with <UserName>,<UserEmail> in SSC
	And I close the browser
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                           | ExcelFile             | SheetName |
		| 064_Verify_loyaltyrewardscustomer_DeleteUKmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @065_Verify_loyaltyrewardscustomer_DeleteUSmobilenumber
Scenario Outline: 065_Verify_loyaltyrewardscustomer_DeleteUSmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I delete "US" <Phonenumber> with <UserName>,<UserEmail> in SSC
	And I close the browser
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for the customer in Harrods.com and validate the "US" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                           | ExcelFile             | SheetName |
		| 065_Verify_loyaltyrewardscustomer_DeleteUSmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @066_Verify_loyaltyrewardscustomer_AddPersonalDetails
Scenario Outline: 066_Verify_loyaltyrewardscustomer_AddPersonalDetails
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add personal details for the customer in SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for Customer in Harrods.com and validate <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I Search for the customer in SMC and validate the personal details <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                         | ExcelFile             | SheetName |
		| 066_Verify_loyaltyrewardscustomer_AddPersonalDetails | TestDataSVCRegression | G01       |

#^^^ this test data should be newly created. So update for every iteration
@SVCRegression @G01 @067_Verify_nonrewardscustomer_addnewUKmobilenumber
Scenario Outline: 067_Verify_nonrewardscustomer_addnewUKmobilenumber
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
		| UserCategory                                       | ExcelFile             | SheetName |
		| 067_Verify_nonrewardscustomer_addnewUKmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @068_Verify_nonrewardscustomer_editUKmobilenumber
Scenario Outline: 068_Verify_nonrewardscustomer_editUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I edit "UK" Phonenumber for the user in SSC <UserCategory> <ExcelFile> <SheetName>
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
		| UserCategory                                     | ExcelFile             | SheetName |
		| 068_Verify_nonrewardscustomer_editUKmobilenumber | TestDataSVCRegression | G01       |

@SVCRegression @G01 @069_Verify_nonrewardscustomer_DeleteUKmobilenumber
Scenario Outline: 069_Verify_nonrewardscustomer_DeleteUKmobilenumber
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I delete "UK" <Phonenumber> with <UserName>,<UserEmail> in SSC
	And I close the browser
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I search for the customer in Harrods.com and validate the "UK" Phonenumber <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for the user in SMC and validate whether the Phonenumber is deleted <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                       | ExcelFile             | SheetName |
		| 069_Verify_nonrewardscustomer_DeleteUKmobilenumber | TestDataSVCRegression | G01       |

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
		| UserCategory                                    | ExcelFile             | SheetName |
		| 070_Existing_LoyaltyRewardCustomer_AddUKAddress | TestDataSVCRegression | G01       |

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
		| UserCategory                                                  | ExcelFile             | SheetName |
		| 071_Existing_LoyaltyRewardCustomer_AdddefaultUSContactAddress | TestDataSVCRegression | G01       |

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
		| UserCategory                                            | ExcelFile             | SheetName |
		| 072_Existing_LoyaltyRewardCustomer_EditDefaultUKAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress
Scenario Outline: 073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress
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
		| UserCategory                                             | ExcelFile             | SheetName |
		| 073_Existing_LoyaltyRewardsCustomer_DeleteDefaultAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @074_Existing_LoyaltyRewardsCustomer_SetDefaultContactAddress
Scenario Outline: 074_Existing_LoyaltyRewardsCustomer_SetDefaultContactAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I select address for "<UserCategory>" to be default contact address from "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate whether the selected address is marked as Default contact on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                 | ExcelFile             | SheetName |
		| 074_Existing_LoyaltyRewardsCustomer_SetDefaultContactAddress | TestDataSVCRegression | G01       |

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
		| UserCategory                                          | ExcelFile             | SheetName |
		| 075_Existing_LoyaltyRewardsCustomer_SetBillingAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @076_Existing_LoyaltyRewardsCustomer_SetDeliveryAddress
Scenario Outline: 076_Existing_LoyaltyRewardsCustomer_SetDeliveryAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I select address for "<UserCategory>" to be delivery address from "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate whether the selected address is marked as Delivery Address on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate edited address reflected on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                           | ExcelFile             | SheetName |
		| 076_Existing_LoyaltyRewardsCustomer_SetDeliveryAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @077_Existing_NonRewardCustomer_AddUKAddress
Scenario Outline: 077_Existing_NonRewardCustomer_AddUKAddress
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
		| UserCategory                                | ExcelFile             | SheetName |
		| 077_Existing_NonRewardCustomer_AddUKAddress | TestDataSVCRegression | G01       |

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
		| UserCategory                                              | ExcelFile             | SheetName |
		| 078_Existing_NonRewardCustomer_AdddefaultUSContactAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @079_Existing_NonRewardCustomer_AdddefaultFranceContactAddress
Scenario Outline: 079_Existing_NonRewardCustomer_AdddefaultFranceContactAddress
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
		| UserCategory                                                  | ExcelFile             | SheetName |
		| 079_Existing_NonRewardCustomer_AdddefaultFranceContactAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @080_Existing_NonRewardsCustomer_EditDefaultUKAddress
Scenario Outline: 080_Existing_NonRewardsCustomer_EditDefaultUKAddress
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
		| UserCategory                                         | ExcelFile             | SheetName |
		| 080_Existing_NonRewardsCustomer_EditDefaultUKAddress | TestDataSVCRegression | G01       |

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
		| UserCategory                                         | ExcelFile             | SheetName |
		| 081_Existing_NonRewardsCustomer_DeleteDefaultAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @082_AddUKAddressFromSSC
Scenario Outline: 082_AddUKAddressFromSSC
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
		| UK      | Autuserelci AutuserelciLname | autuserelci@gmail.com |

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

@SVCRegression @G01 @085_EditUKAddressFromSSC
Scenario Outline: 085_EditUKAddressFromSSC
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
Scenario Outline: 086_EditNonUKAddressFromSSC
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

@SVCRegression @G01 @087_Existing_LoyaltyRewardsCustomer_deleteDefaultContactAddress_fromSSC
Scenario Outline: 087_Existing_LoyaltyRewardsCustomer_deleteDefaultContactAddress_fromSSC
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
	#Then I should validate address gets deleted from SMC "<ExcelFile>" "<SheetName>"
	Then I should validate address is deleted from SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                            | ExcelFile             | SheetName |
		| 087_Existing_LoyaltyRewardsCustomer_deleteDefaultContactAddress_fromSSC | TestDataSVCRegression | G01       |

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
		| UserCategory                                                                | ExcelFile             | SheetName |
		| 088_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_DeliveryAddressSwap | TestDataSVCRegression | G01       |

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
		| UserCategory                                                               | ExcelFile             | SheetName |
		| 089_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_BillingAddressSwap | TestDataSVCRegression | G01       |

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
		| UserCategory                                                               | ExcelFile             | SheetName |
		| 090_Existing_LoyaltyRewardsCustomer_WithMultipleAddress_ContactAddressSwap | TestDataSVCRegression | G01       |

@SVCRegression @G01 @091_Create_new_Qatari_staffcustomer_SSC @E2ERun
Scenario: 091_Create_new_Qatari_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Qatari staff for "Bronze" bandgrade
	Then I validate the newly added Qatari staff
	And I close the browser

@SVCRegression @G01 @092_Create_new_AlFayad_staffcustomer_SSC @E2ERun
Scenario: 092_Create_new_AlFayad_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new AlFayad staff "Orange"
	Then I validate the newly added AlFayad staff
	And I close the browser

@SVCRegression @G01 @093_Create_new_Pressperson_staffcustomer_SSC @E2ERun
Scenario: 093_Create_new_Pressperson_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Press person staff
	Then I validate the newly added Press person staff
	And I close the browser

@SVCRegression @G01 @094_Create_new_InteriorDesignperson_staffcustomer_SSC @E2ERun
Scenario: 094_Create_new_InteriorDesignperson_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Interior Design person staff
	Then I validate the newly added Interior Design person staff
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
		| Vikram Raman |

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
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate enrolled "<UserName>" "<Email>" child is showing on SSC
	And I close the browser
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
		| UserCategory                                                          | ExcelFile             | SheetName |
		| 097_Existing_LoyaltyRewardsCustomer_AddMultipleChildToCustomerAccount | TestDataSVCRegression | G01       |

@SVCRegression @G01 @098_BlackTierCustomerMiniHarrodsOnlineValidation @E2ERun
Scenario Outline: 098_BlackTierCustomerMiniHarrodsOnlineValidation
	Given I launch the browser to open the harrods website
	When I enroll "<UserName>" "<Email>" to mini harrods from Harrods.com
	Then I should validate enrolled "<UserName>" "<Email>" child is showing on Harrods.com
	And I should validate mini harrods benefits, membership and Stay in touch communication preferance on Harrods.com
	And I close the browser

	Examples:
		| UserName | Email             |
		| MhBlack  | MhBlack@gmail.com |

@SVCRegression @G01 @099_EliteTierCustomerMiniHarrodsOnlineValidation @E2ERun
Scenario Outline: 099_EliteTierCustomerMiniHarrodsOnlineValidation
	Given I launch the browser to open the harrods website
	When I enroll "<UserName>" "<Email>" to mini harrods from Harrods.com
	Then I should validate enrolled "<UserName>" "<Email>" child is showing on Harrods.com
	And I should validate mini harrods benefits, membership and Stay in touch communication preferance on Harrods.com
	And I close the browser

	Examples:
		| UserName | Email             |
		| MhElite  | MhElite@gmail.com |

@SVCRegression @G01 @100_Edit/remove_MiniHarrodsinterest_of_customer_through_Harrods
Scenario Outline: 100_Edit/remove_MiniHarrodsinterest_of_customer_through_Harrods
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I click on MiniHarrods
	And I validate that remove miniharrods interest is updated in Harrods.com "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate remove miniharrods Interest updated on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate remove miniharrods Interest updated on SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                    | ExcelFile             | SheetName |
		| 100_Edit/remove_MiniHarrodsinterest_of_customer_through_Harrods | TestDataSVCRegression | G01       |

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
		| UserCategory                       | ExcelFile             | SheetName |
		| 101_RemoveLastChildFromMiniHarrods | TestDataSVCRegression | G01       |

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

@SVCRegression @G01 @103_FullRewardHarrodsReg_NewEmail_RewardCard_ExistingGhost_GDTier
Scenario Outline: 103_FullRewardHarrodsReg_NewEmail_RewardCard_ExistingGhost_GDTier
	Given I launch the "Harrods" website
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SSC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                                      | ExcelFile             | SheetName |
		| 103_FullRewardHarrodsReg_NewEmail_RewardCard_ExistingGhost_GDTier | TestDataSVCRegression | G01       |

@SVCRegression @G01 @104_NonReward_HarrodsJoinRewardWithGhostCard_Points_5000to9999 @E2ERun
Scenario Outline: 104_NonReward_HarrodsJoinRewardWithGhostCard_Points_5000to9999
	Given I launch the "Harrods" website
	When I perform join rewards as "<UserCategory>" from Harrods.com with ghost rewards card data "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" user from "<ExcelFile>" "<SheetName>" is showing as rewards on SSC
	And I close the browser

	Examples:
		| UserCategory                                                   | ExcelFile             | SheetName |
		| 104_NonReward_HarrodsJoinRewardWithGhostCard_Points_5000to9999 | TestDataSVCRegression | G01       |

@SVCRegression @G01 @105_Reg_LoyaltyRewardCustomer_EnableSMSconsentYes_MixedSelectionOnInterests
Scenario Outline: 105_Reg_LoyaltyRewardCustomer_EnableSMSconsentYes_MixedSelectionOnInterests
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	And I perform operation for "<channel>" and mixed selection of interest in Harrods
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Customer Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Customer Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser

	Examples:
		| UserCategory                                                                | ExcelFile             | SheetName | channel |
		| 105_Reg_LoyaltyRewardCustomer_EnableSMSconsentYes_MixedSelectionOnInterests | TestDataSVCRegression | G01       | SMS     |

@SVCRegression @G01 @106_Reg_LoyaltyRewardCustomer_removeAllConsent
Scenario Outline: 106_Reg_LoyaltyRewardCustomer_removeAllConsent
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	And I perform operation for "<channel>" remove all consent
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Customer Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Customer Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser

	Examples:
		| UserCategory                                   | ExcelFile             | SheetName | channel |
		| 106_Reg_LoyaltyRewardCustomer_removeAllConsent | TestDataSVCRegression | G01       | sms     |

@SVCRegression @G01 @107_Loyaltyrewards_Gold/black/Elitecustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent
Scenario Outline: 107_Loyaltyrewards_Gold/black/Elitecustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	Then I should validate "All consent" "<channel>" channels and interests updated in Harrods.com
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent remove all consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent remove all consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser

	Examples:
		| UserCategory                                                                                                   | ExcelFile             | SheetName | channel |
		| 107_Loyaltyrewards_Gold/black/Elitecustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent | TestDataSVCRegression | G01       | postal  |

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
		| UserCategory                                                                     | ExcelFile             | SheetName |
		| 108_Existing_LoyaltyRewardCustomer_EditCity_state_postal_inDefaultContactaddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @109_Loyaltyrewards_G0/G1customer_PostalandMagazineConsent_Yes
Scenario Outline: 109_Loyaltyrewards_G0/G1customer_PostalandMagazineConsent_Yes
	Given I launch the browser to open the harrods website
	When I login to Harrods with a Reg user from "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I Navigate to Harrods > Communication Preferences
	Then I should validate "Opt-In-postal" "<channel>" channels and interests for Rewards user updated in Harrods.com "<UserCategory>"
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SSC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate Loyaltyrewards Enable "<channel>" Consent reflected in SMC "<ExcelFile>" "<SheetName>" "<UserCategory>"
	And I close the browser

	Examples:
		| UserCategory                                                  | ExcelFile             | SheetName | channel |
		| 109_Loyaltyrewards_G0/G1customer_PostalandMagazineConsent_Yes | TestDataSVCRegression | G01       | postal  |

@SVCRegression @G01 @110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress
Scenario Outline: 110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress
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
		| UserCategory                                                   | ExcelFile             | SheetName |
		| 110_Existing_LoyaltyRewardsCustomer_swap_defaultDeliverAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @111_Existing_LoyaltyRewardsCustomer_swap_defaultBillingAddress @E2ERun
Scenario Outline: 111_Existing_LoyaltyRewardsCustomer_swap_defaultBillingAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I validate that the "BillingAddress" addresses can be swaped
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate swap "BillingAddress" address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	#No validation in SMC
	Examples:
		| UserCategory                                                   | ExcelFile             | SheetName |
		| 111_Existing_LoyaltyRewardsCustomer_swap_defaultBillingAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @112_Existing_LoyaltyRewardsCustomer_swap_defaultContactAddress @E2ERun
Scenario Outline: 112_Existing_LoyaltyRewardsCustomer_swap_defaultContactAddress
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I validate that the "DefaultContactAddress" addresses can be swaped
	Then I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate swap "DefaultContactAddress" address reflected on SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	#No validation in SMC
	Examples:
		| UserCategory                                                   | ExcelFile             | SheetName |
		| 112_Existing_LoyaltyRewardsCustomer_swap_defaultContactAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @113_CustomerInstoreBookingByHAndB
Scenario Outline: 113_CustomerInstoreBookingByHAndB
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
		| UserName | Email                | Phone      |
		| Bbooking | Bbooking@yopmail.com | 7837837839 |

@SVCRegression @G01 @114_VerifyBeautyBookingPerformedUser @E2ERun
Scenario Outline: 114_VerifyBeautyBookingPerformedUser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify given prespa "<UserName>" "<Email>" and "<Phone>" details were showing on SSC
	And I close the browser

	Examples:
		| UserName | Email                | Phone      |
		| Bbooking | Bbooking@yopmail.com | 7837837839 |

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
		| UserName    | Email                   | Phone      |
		| Bbblacktier | Bbblacktier@yopmail.com | 7837637830 |

@SVCRegression @G01 @118_IDSCustomerSearchWithActiveRewardCard
Scenario Outline: 118_IDSCustomerSearchWithActiveRewardCard
	Given I launch the browser to open IDS
	When I login to IDS with common User
	And I navigate to IDS > Create new project
	And I Perform customer search on IDS with "<RewardCard>"
	Then I should validate IDS populated with user details "<SapId>" "<UserName>" "<RewardCard>" "<Phone>"
	And I close the browser

	Examples:
		| SapId      | UserName     | RewardCard       | Phone      |
		| 0002127090 | Krisha Krish | 7042776500002175 | 7546534231 |

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
		| UserCategory                                                   | ExcelFile             | SheetName |
		| 119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child | TestDataSVCRegression | G01       |

@SVCRegression @G01 @120_LoyaltyRewardsCustomer_RemoveLastChildFromMiniHarrods
Scenario Outline: 120_LoyaltyRewardsCustomer_RemoveLastChildFromMiniHarrods
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
		| UserCategory                                              | ExcelFile             | SheetName |
		| 120_LoyaltyRewardsCustomer_RemoveLastChildFromMiniHarrods | TestDataSVCRegression | G01       |

@SVCRegression @G01 @121_OnlineRewardCustomer_CancelMiniHarrodsSubscription
Scenario Outline: 121_OnlineRewardCustomer_CancelMiniHarrodsSubscription
	Given I launch the browser to open the harrods website
	When I enroll <UserCategory> <ExcelFile> <SheetName> to mini harrods from Harrods.com
	And I cancel the mini harrods subscription
	Then I should validate mini harrods subscription is cancelled
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate <UserCategory> <ExcelFile> <SheetName> mini harrods subscription cancelled status is updated on SMC
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate removed child is not showing on SSC
	And I close the browser

	Examples:
		| UserCategory                                           | ExcelFile             | SheetName |
		| 121_OnlineRewardCustomer_CancelMiniHarrodsSubscription | TestDataSVCRegression | G01       |

@SVCRegression @G01 @147_CST_Resend_the_Verfication_Emails @E2ERun
Scenario Outline: 147_CST_Resend_the_Verfication_Emails
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Search and Send Verification Email to the user <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                          |
		| TestDataSVCRegression | G01       | 147_CST_Resend_the_Verfication_Emails |

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
		| UserCategory                                         | ExcelFile             | SheetName |
		| 148_CST_Register_FullAccountCustomer_for_MiniHarrods | TestDataSVCRegression | G01       |

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
		| UserCategory                              | ExcelFile             | SheetName |
		| 149_CST_Remove_LastChild_from_MiniHarrods | TestDataSVCRegression | G01       |

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
		| UserCategory                                 | ExcelFile             | SheetName |
		| 150_CST_CreateFUllRewardsCustomer_NotinSVCDB | TestDataSVCRegression | G01       |

@SVCRegression @G01 @151_CST_Replace_StolenCard
Scenario Outline: 151_CST_Replace_StolenCard
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Deactivate old card and activate new card for the customer <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for customer in SMC and validate the Reward Card <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory               | ExcelFile             | SheetName |
		| 151_CST_Replace_StolenCard | TestDataSVCRegression | G01       |

@SVCRegression @G01 @152_CST_Deactivate_activecard_with_InvalidCardID
Scenario Outline: 152_CST_Deactivate_activecard_with_InvalidCardID
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Deactivate the card for the customer <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I search for customer in SMC and validate Reward Card <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                     | ExcelFile             | SheetName |
		| 152_CST_Deactivate_activecard_with_InvalidCardID | TestDataSVCRegression | G01       |

@SVCRegression @G01 @153_CST_ChangeName_inCard_SSC_resendto_CustomerUKAddress @E2ERun
Scenario Outline: 153_CST_ChangeName_inCard_SSC_resendto_CustomerUKAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I edit the name in Card for the customer <UserCategory> <ExcelFile> <SheetName>
	And I verify whether the Name in Card is changed for the customer <UserCategory> <ExcelFile> <SheetName>
	Then I send the New card to the customer
	And I close the browser

	Examples:
		| UserCategory                                             | ExcelFile             | SheetName |
		| 153_CST_ChangeName_inCard_SSC_resendto_CustomerUKAddress | TestDataSVCRegression | G01       |

@SVCRegression @G01 @154_CST_CardReplenishment_Jobs @E2ERun
Scenario Outline: 154_CST_CardReplenishment_Jobs
	Given I launch the "SSC" website
	When I Navigate to SSC > CardManagement
	And I create a new Card Replenishment job with <UserCategory> <ExcelFile> <SheetName>
	Then I validate the status of the job <UserCategory> <ExcelFile> <SheetName>

	Examples:
		#| MassDataRunID | RunDescription         |
		#| AutomatedTest | JobcreatedbyAutomation |
		| UserCategory                   | ExcelFile             | SheetName |
		| 154_CST_CardReplenishment_Jobs | TestDataSVCRegression | G01       |

#155	Verify if the user is able to merge two accounts with deemed customer(G2 tier with rewards and status 4900 points) and
#surviving customer(Gold tier with rewards and status 5100) - need to be upgraded to BLACK tier
@SVCRegression @G01 @155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack
Scenario Outline: 155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack
	Given I launch the "SSC" website
	When I Navigate to SSC > Customer Merge
	And Search for two active users and merge <UserCategory> <ExcelFile> <SheetName>
	And I edit the Attributes of the Surviving Customer and save
	And I initiate merge for the customers
	When I Navigate to SSC > Customers
	And I Validate whether the deemed customer is not available in SSC <UserCategory> <ExcelFile> <SheetName>
	#When I Navigate to SSC > Tickets
	#And I create ticket for reward points merge for user <UserCategory> <ExcelFile> <SheetName>
	#there is issue in SSC for updating merge ticket
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate whether the deemed user is not found in SMC <UserCategory> <ExcelFile> <SheetName>

	Examples:
		| UserCategory                                      | ExcelFile             | SheetName |
		| 155_Merge_TwoAccounts_G2_G2AndGold_UpgradetoBlack | TestDataSVCRegression | G01       |

#156	"Verify if the user is able to merge two rewards account selecting Customer 2's email address and Customer 1's surviving record ID
#Customer 1 - Non - Online email address
#Customer 2 - Online email address"
@SVCRegression @G01 @156_Merge_TwoAccounts_AndRegisterDeemedUser
Scenario Outline: 156_Merge_TwoAccounts_AndRegisterDeemedUser
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

	Examples:
		| UserCategory                                | ExcelFile             | SheetName |
		| 156_Merge_TwoAccounts_AndRegisterDeemedUser | TestDataSVCRegression | G01       |

@SVCRegression @G01 @157_CSTMember_SearchExistCustomer_EmailAddress @E2ERun
Scenario Outline: 157_CSTMember_SearchExistCustomer_EmailAddress
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search the Customer email and validate in SSC <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| UserCategory                                   | ExcelFile             | SheetName |
		| 157_CSTMember_SearchExistCustomer_EmailAddress | TestDataSVCRegression | G01       |

#158	Verify that the CST Member is able to add a Customer as "Potential Reseller"
@SVCRegression @G01 @158_CSTMember_Add_Potential_Reseller @E2ERun
Scenario Outline: 158_CSTMember_Add_Potential_Reseller
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Add and validate Potential Reseller Attribute to Customer from <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| UserCategory                         | ExcelFile             | SheetName |
		| 158_CSTMember_Add_Potential_Reseller | TestDataSVCRegression | G01       |

#159	Verify that the CST Member is able to remove a Customer as "Potential private shopping"
@SVCRegression @G01 @159_CSTMember_Remove_Potential_PrivateShopping @E2ERun
Scenario Outline: 159_CSTMember_Remove_Potential_PrivateShopping
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I remove the Private Shopping Attribute of the Customer <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| UserCategory                                   | ExcelFile             | SheetName |
		| 159_CSTMember_Remove_Potential_PrivateShopping | TestDataSVCRegression | G01       |

@SVCRegression @G01 @160_CSTMember_UpdateDOBofCsutomer @E2ERun
Scenario Outline: 160_CSTMember_UpdateDOBofCsutomer
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I update DOB of the customer <UserCategory> <ExcelFile> <SheetName>
	Then I close the browser

	Examples:
		| UserCategory                      | ExcelFile             | SheetName |
		| 160_CSTMember_UpdateDOBofCsutomer | TestDataSVCRegression | G01       |

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
		| UserCategory                                  | ExcelFile             | SheetName |
		| 161_Verify_CST_is_ableto_DeleteUKmobilenumber | TestDataSVCRegression | G01       |

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
		| UserCategory                       | ExcelFile             | SheetName |
		| 162_CST_Customer_SetBillingAddress | TestDataSVCRegression | G01       |

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
		| UserCategory                                         | ExcelFile             | SheetName |
		| 163_CST_Customer_deleteDefaultContactAddress_fromSSC | TestDataSVCRegression | G01       |

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

@SVCRegression @G01 @165_liteUserRegistrationByNewsLetterSignup
Scenario: 165_liteUserRegistrationByNewsLetterSignup
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
Scenario Outline: 166_NonReward_HarrodsReg_EmailConsentYes
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
		| UserCategory                              | ExcelFile             | SheetName |
		| 167_FullReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G02       |

#168	Full Rewards registration from Harrods.com with an email address that belongs to existing non-loyalty customer (with email consent)
@SVCRegression @G01 @168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes
Scenario Outline: 168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes
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
		| 168_ExistingNonLoyalty_FullReward_HarrodsReg_EmailConsentYes | TestDataSVCRegression | G01       |

@SVCRegression @G02 @169_GoldTier10PBookingEmailValidation @E2ERun
Scenario Outline: 169_GoldTier10PBookingEmailValidation
	Given I launch the "Harrods" website
	When I Login to Harrods with <Email>
	Then I should validate remaining ten percentage count "<RemainingDays>" and booked date "<BookedDate>" from Harrods.com
	And I close the browser
	Given I launch the "Yopmail" website
	When I Login with "<Email>" from yopmail
	Then I should validate the Tenp email content "<UserName>" from yopmail
	And I close the browser

	Examples:
		| UserName | Email                | RemainingDays | BookedDate |
		| Tenpused | tenpused@yopmail.com | 1 Remaining   | 21st Jun   |

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
		| UserName       | Email                      |
		| Goldtenpdayone | Goldtenpdayone@yopmail.com |

@SVCRegression @G02 @173_EliteTenpDayTwoSSCSelectEmailCheck
Scenario Outline: 173_EliteTenpDayTwoSSCSelectEmailCheck
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create Tenp day booking ticket for "<UserName>" "<Email>" from SSC
	Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate selected Tenp discount second day "<UserName>" "<Email>" interaction is showing on SMC
	And I close the browser

	Examples:
		| UserName         | Email                        |
		| Elitetenpdaybook | Elitetenpdaybook@yopmail.com |

@SVCRegression @G02 @174_TenpNoEmailConsentOnlineBookingEmailCheck
Scenario Outline: 174_TenpNoEmailConsentOnlineBookingEmailCheck
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
		| UserName    | Email                   |
		| Tenpnoemail | Tenpnoemail@yopmail.com |

@SVCRegression @G02 @175_BrandMailerNonRewCustomerWithEmailConsent
Scenario Outline: 175_BrandMailerNonRewCustomerWithEmailConsent
	Given I launch the "Harrods" website
	#	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" with card and email consent were showing on SMC
	Then I should validate BrandMailer email for "<UserCategory>" from "<ExcelFile>" "<SheetName>" showing on SMC
	And I close the browser

	Examples:
		| UserCategory                                  | ExcelFile             | SheetName |
		| 175_BrandMailerNonRewCustomerWithEmailConsent | TestDataSVCRegression | G02       |

@SVCRegression @G02 @176_Existing_LoyaltyRewardsGroupAccountCustomer_AddMultipleChild_ValidateWelcomeEmail
Scenario Outline: 176_Existing_LoyaltyRewardsGroupAccountCustomer_AddMultipleChild_ValidateWelcomeEmail
	Given I launch the browser to open the harrods website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	And I click on MiniHarrods
	And I add multiple child in miniharrods from Harrods.com "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I validate Mini harrods Interest is selected in Communication prefernce page
	#And I perform Welcome email validation from yopmail "<UserCategory>" "<ExcelFile>" "<SheetName>"
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
		| UserCategory                                                                          | ExcelFile             | SheetName |
		| 176_Existing_LoyaltyRewardsGroupAccountCustomer_AddMultipleChild_ValidateWelcomeEmail | TestDataSVCRegression | G02       |

@SVCRegression @G02 @178_HarrodsRegistrationForFullRewardCustomerWithEmailConsentYes
Scenario Outline: 178_HarrodsRegistrationForFullRewardCustomerWithEmailConsentYes
	Given I launch the "Harrods" website
	#When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	#And I perform Welcome email validation from yopmail "<UserCategory>" "<ExcelFile>" "<SheetName>"
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
		| UserCategory                                                    | ExcelFile             | SheetName |
		| 178_HarrodsRegistrationForFullRewardCustomerWithEmailConsentYes | TestDataSVCRegression | G02       |

@SVCRegression @G02 @177_VerifyEmailTriggeredForNewlycreatedStaff
Scenario Outline: 177_VerifyEmailTriggeredForNewlycreatedStaff
	Given I create a new staff in Harrods
	And I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" employee updated in SSC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify "<UserCategory>" users from "<ExcelFile>" "<SheetName>" employee updated in SMC
	And I close the browser

	Examples:
		| UserCategory                                 | ExcelFile             | SheetName |
		| 177_VerifyEmailTriggeredForNewlycreatedStaff | TestDataSVCRegression | G02       |

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
		| UserCategory                                              | ExcelFile             | SheetName |
		| 179_HarrodsRegistrationForLiteCustomerWithEmailConsentYes | TestDataSVCRegression | G02       |

@SVCRegression @G02 @180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail
Scenario Outline: 180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail
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
		| UserCategory                                          | ExcelFile             | SheetName |
		| 180_HarrodsRegistrationForGhostG0CustomerWelcomeEmail | TestDataSVCRegression | G02       |

@SVCRegression @G02 @182_SearchAndInsertImagesfromCantoIntoSMCstudio
Scenario Outline: 182_SearchAndInsertImagesfromCantoIntoSMCstudio
	Given I launch the "SMC" website
	When  I Navigate to SMC > contentStudio
	Then I search and Insert Image from Canto to SMC studio
	And I close the browser

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
		| UserCategory                                                          | ExcelFile             | SheetName | BookingDate     |
		| 184_Goldcustomercancelled_slot_previouslybooked_tenpercentDiscountDay | TestDataSVCRegression | G02       | Fri Jun 24 2022 |

@SVCRegression @G02 @185_CSTCancelled_firstSlotfordiscount_bookedthrough_harrods
Scenario Outline: 185_CSTCancelled_firstSlotfordiscount_bookedthrough_harrods
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate CST cancelled discount booked through Harrods"<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate cancelled status is updated in SMC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                                | ExcelFile             | SheetName |
		| 185_CSTCancelled_firstSlotfordiscount_bookedthrough_harrods | TestDataSVCRegression | G02       |

@SVCRegression @G02 @187_OnlineFullReturnAndPointValidation
Scenario Outline: 187_OnlineFullReturnAndPointValidation
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
		| UserName    | Email                    | DocId  | PointDeduction |
		| Janet Brown | janetbrown6523@gmail.com | 8D3DTP | -1             |

@SVCRegression @G05 @188_OnlineFullCancelAndPointValidation
Scenario Outline: 188_OnlineFullCancelAndPointValidation
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify partial cancel "<UserName>" "<Email>" is showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Order Reports
	Then I should verify full cancelled entry for "<OrderId>" is showing on AC
	And I close the browser

	Examples:
		| UserName                             | Email                       | OrderId    |
		| Fullordercancel FullordercancelLname | Fullordercancel@yopmail.com | 1300014308 |

@SVCRegression @G05 @189_OnlinePartialCancelAndPointValidation
Scenario Outline: 189_OnlinePartialCancelAndPointValidation
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify partial cancel "<UserName>" "<Email>" is showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Order Reports
	Then I should verify partial cancelled entry for "<OrderId>" is showing on AC
	And I close the browser

	Examples:
		| UserName                               | Email                        | OrderId    |
		| Partialreturnchk PartialreturnchkLname | Partialreturnchk@yopmail.com | 1300014206 |

@SVCRegression @G05 @191_VerifyRewardspointsInternallyEarnedbyHarrodsAMEXcustomers @E2ERun
Scenario Outline: 191_VerifyRewardspointsInternallyEarnedbyHarrodsAMEXcustomers
	Given I add points to AMEX customer
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I validate rewardPoint updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > InteractionReports
	Then I should verify Amex rewardPoints are reflected in AC
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                                  |
		| TestDataSVCRegression | G05       | 191_VerifyRewardspointsInternallyEarnedbyHarrodsAMEXcustomers |

@SVCRegression @G05 @204_VerifyQNBLifeRewardsCustomersCanExchangeTheirPointsforHarrodsRewardsCard @E2ERun
Scenario Outline: 204_VerifyQNBLifeRewardsCustomersCanExchangeTheirPointsforHarrodsRewardsCard
	Given I add points to QNB Customer
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I validate rewardPoint updated in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > InteractionReports
	Then I should verify QNB rewardPoints are reflected in AC for the customer
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                                                 |
		| TestDataSVCRegression | G05       | 204_VerifyQNBLifeRewardsCustomersCanExchangeTheirPointsforHarrodsRewardsCard |

@SVCRegression @G05 @205_VerifyBonusPointsManuallyAddedinSSCisUpdatedInAC @E2ERun
Scenario Outline: 205_VerifyBonusPointsManuallyAddedinSSCisUpdatedInAC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	When I create ticket for customer bonus point addition from SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Point Reports
	Then I should verify bonuspoints are reflected in AC
	And I close the browser

	Examples:
		| ExcelFile             | SheetName | UserCategory                                         |
		| TestDataSVCRegression | G05       | 205_VerifyBonusPointsManuallyAddedinSSCisUpdatedInAC |

@SVCRegression @G05 @206_VerifyGreenTierEarnedRewardsStatusPointsForOnlineTransaction @E2ERun
Scenario Outline: 206_VerifyGreenTierEarnedRewardsStatusPointsForOnlineTransaction
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify online transaction rewards points for "<UserName>" "<UserEmail>" "<OrderId>" is showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Order Reports
	Then I should verify online transaction rewards points for "<DateRange>" "<OrderId>" is showing on AC
	And I close the browser

	Examples:
		| UserName    | UserEmail                | OrderId    | DateRange             |
		| Janet Brown | janetbrown6523@gmail.com | 1300014360 | 08/01/2022-08/02/2022 |

@SVCRegression @G05 @207_VerifyBlackTierEarnedRewardsStatusPointsForOnlineTransaction @E2ERun
Scenario Outline: 207_VerifyBlackTierEarnedRewardsStatusPointsForOnlineTransaction
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify online transaction rewards points for "<UserName>" "<UserEmail>" "<OrderId>" is showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Order Reports
	Then I should verify online transaction rewards points for "<DateRange>" "<OrderId>" is showing on AC
	And I close the browser

	Examples:
		| UserName          | UserEmail                                       | OrderId    | DateRange             |
		| Jingchao . Wisker | jingchao.wisker.1893081@harrods.proctortech.com | 1300014168 | 07/20/2022-07/26/2022 |

@SVCRegression @G05 @208_VerifyPartnerPointsManuallyaddedinSSCwithReosonAMEXHarrodsSpendGetsupdatedinAC @E2ERun
Scenario Outline: 208_VerifyPartnerPointsManuallyaddedinSSCwithReosonAMEXHarrodsSpendGetsupdatedinAC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	When I create ticket for partner points manually created in SSC "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Point Reports
	Then I should verify bonuspoints are reflected in AC
	And I close the browser

	Examples:
		| UserCategory                                                                       | ExcelFile             | SheetName |
		| 208_VerifyPartnerPointsManuallyaddedinSSCwithReosonAMEXHarrodsSpendGetsupdatedinAC | TestDataSVCRegression | G05       |

@SVCRegression @G02 @209_VerifyOnlineRewardsStatementForMiscellaneousPoints @E2ERun
Scenario Outline: 209_VerifyOnlineRewardsStatementForMiscellaneousPoints
	Given I launch the "Harrods" website
	When I Login to Harrods with <UserEmail>
	Then I validate "Miscellaneous" rewards statement were showing against "<UserName>" on harrods.com
	And I close the browser

	Examples:
		| UserName     | UserEmail                |
		| Miscpointchk | Miscpointchk@yopmail.com |

@SVCRegression @G02 @210_VerifyOnlineRewardsStatementForTransferPoints @E2ERun
Scenario Outline: 210_VerifyOnlineRewardsStatementForTransferPoints
	Given I launch the "Harrods" website
	When I Login to Harrods with <UserEmail>
	Then I validate "Transfers" rewards statement were showing against "<UserName>" on harrods.com
	And I close the browser

	Examples:
		| UserName      | UserEmail                 |
		| Transpointchk | Transpointchk@yopmail.com |

@SVCRegression @G02 @211_VerifyOnlineRewardsStatementForRedeemedPoints @E2ERun
Scenario Outline: 211_VerifyOnlineRewardsStatementForRedeemedPoints
	Given I launch the "Harrods" website
	When I Login to Harrods with <UserEmail>
	Then I validate "Redeemed" rewards statement were showing against "<UserName>" on harrods.com
	And I close the browser

	Examples:
		| UserName       | UserEmail                  |
		| Redeempointchk | Redeempointchk@yopmail.com |

@SVCRegression @G02 @212_VerifyOnlineRewardsStatementForRetrospectivePoints @E2ERun
Scenario Outline: 212_VerifyOnlineRewardsStatementForRetrospectivePoints
	Given I launch the "Harrods" website
	When I Login to Harrods with <UserEmail>
	Then I validate "Retrospective" rewards statement were showing against "<UserName>" on harrods.com
	And I close the browser

	Examples:
		| UserName         | UserEmail                   |
		| new releasestest | new.releasetest@yopmail.com |

@SVCRegression @G02 @213_VerifyOnlineRewardsStatementForPurchasePoints @E2ERun
Scenario Outline: 213_VerifyOnlineRewardsStatementForPurchasePoints
	Given I launch the "Harrods" website
	When I Login to Harrods with <UserEmail>
	Then I validate "Purchase" rewards statement were showing against "<UserName>" on harrods.com
	And I close the browser

	Examples:
		| UserName | UserEmail            |
		| POS TRVC | trvc.pos@yopmail.com |

#Verify that the CST is able to create a Enquiry ticket for a Customer to upgrade tier from Green 0 to Gold (Manual Tier Upgrade)
@SVCRegression @G07 @221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade
Scenario Outline: 221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	And I create a new Service Ticket
	And I enter all the mandatory details and create ticket for <UserCategory> <ExcelFile> <SheetName>
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
		| UserCategory                                                         | ExcelFile             | SheetName |
		| 221_CST_EnquiryTickettoUpgradeTier_SSC_GreentoGold_ManualTierUpgrade | TestDataSVCRegression | G07       |

#Verify that the CST is able to create a Complaint ticket for a Customer to upgrade tier from Black to Elite(Manual Tier Upgrade)
@SVCRegression @G07 @222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC
Scenario Outline: 222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC
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
		| UserCategory                                     | ExcelFile             | SheetName |
		| 222_StaffEnqTicketMiscPointsValidateOnSSC_SMC_AC | TestDataSVCRegression | G07       |

@SVCRegression @G07 @223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC
Scenario Outline: 223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I create complaint ticket for customer status point addition <UserCategory> <ExcelFile> <SheetName>
	When I Navigate to SSC > Customers
	Then I validate user is added with "Status Points" points on SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Point Reports
	Then I validate expected "Status Points" points is added on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate user is added with expected "Status Points" points in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "Harrods" website
	When I Login with to Harrods with <UserCategory> <ExcelFile> <SheetName>
	Then I validate expected "Status Points" points is added on Harrods.com
	And I close the browser

	Examples:
		| UserCategory                                        | ExcelFile             | SheetName |
		| 223_ComplaintTicketStatusPointsValidateOnSSC_SMC_AC | TestDataSVCRegression | G07       |

#Verify that the CST is able to add only 1 Primary Member and 4 Secondary members to Loyalty Rewards group.
@SVCRegression @G07 @224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup @E2ERun
Scenario Outline: 224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup
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
		| UserCategory                                                  | ExcelFile             | SheetName |
		| 224_CST_Add_1Primary_4Secondary_membersto_LoyaltyRewardsGroup | TestDataSVCRegression | G07       |

#Verify that the CST is able to create a Complaint ticket for a Secondary Customer to Transfer Points to another Secondary Member
@SVCRegression @G07 @225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer
Scenario Outline: 225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	#And I create a new Service Ticket
	#And I enter all the mandatory details and select the <UserCategory> <ExcelFile> <SheetName>
	And I create staff enquiry ticket for customer miscellaneous point addition <UserCategory> <ExcelFile> <SheetName>
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
		| UserCategory                                                               | ExcelFile             | SheetName |
		| 225_CST_EnquiryTicket_Transferpointsfrom_SecCustomer_to_anotherSecCustomer | TestDataSVCRegression | G07       |

@SVCRegression @G07 @226_CST_EnquiryTicket_GrantAdditional10Pct_Elite
Scenario Outline: 226_CST_EnquiryTicket_GrantAdditional10Pct_Elite
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	And I create a new Service Ticket
	And I enter all the mandatory details and select the <UserCategory> <ExcelFile> <SheetName>
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	Then I validate the Customer Subject Details Category
	And I close the browser

	#
	#	Given I launch the "SMC" website
	#	When I Navigate to SMC > Contacts
	#	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	#	And I close the browser
	#
	#	Given I launch the "AC" website
	#	When I Navigate to AC > Reports > Member Reports
	#	Then I search for the ticket created <UserCategory> <ExcelFile> <SheetName>
	#	And I close the browser
	Examples:
		| UserCategory                                     | ExcelFile             | SheetName |
		| 226_CST_EnquiryTicket_GrantAdditional10Pct_Elite | TestDataSVCRegression | G07       |

@SVCRegression @G07 @227_CST_EnquiryTicket_GrantAdditional10Pct_Green1 @E2ERun
Scenario Outline: 227_CST_EnquiryTicket_GrantAdditional10Pct_Green1
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	And I create a new Service Ticket
	And I enter all the mandatory details and select the <UserCategory> <ExcelFile> <SheetName>
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	Then I validate the Customer Subject Details Category
	And I close the browser

	#
	#	Given I launch the "SMC" website
	#	When I Navigate to SMC > Contacts
	#	Then I validate the tier of the Customer of <UserCategory> <ExcelFile> <SheetName>
	#	And I close the browser
	#
	#	Given I launch the "AC" website
	#	When I Navigate to AC > Reports > Member Reports
	#	Then I search for the ticket created <UserCategory> <ExcelFile> <SheetName>
	#	And I close the browser
	Examples:
		| UserCategory                                      | ExcelFile             | SheetName |
		| 227_CST_EnquiryTicket_GrantAdditional10Pct_Green1 | TestDataSVCRegression | G07       |

@SVCRegression @G07 @228_ValidateMiscActivityOnSSC @E2ERun
Scenario Outline: 228_ValidateMiscActivityOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate "Miscellaneous" activity against "<UserName>" "<UserEmail>" is showing on SSC
	And I close the browser

	Examples:
		| UserName                     | UserEmail               |
		| Addpointchk AddpointchkLname | Addpointchk@yopmail.com |

@SVCRegression @G07  @229_GreenOneToGoldTierUpgradeValidation @E2ERun
Scenario Outline: 229_GreenOneToGoldTierUpgradeValidation
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
		| UserCategory                            | ExcelFile             | SheetName |
		| 229_GreenOneToGoldTierUpgradeValidation | TestDataSVCRegression | G07       |

@SVCRegression @G07  @230_GreenZeroToGreenTwoTierUpgradeValidation @E2ERun
Scenario Outline: 230_GreenZeroToGreenTwoTierUpgradeValidation
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
		| UserCategory                                 | ExcelFile             | SheetName |
		| 230_GreenZeroToGreenTwoTierUpgradeValidation | TestDataSVCRegression | G07       |

@SVCRegression @G07 @231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC
Scenario Outline: 231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I create complaint ticket for customer extend point addition <UserCategory> <ExcelFile> <SheetName>
	When I Navigate to SSC > Customers
	Then I validate user is added with "Extend Points" points on SSC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I validate expected "Extend Points" points is added on AC
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate user is added with expected "Extend Points" points in SMC <UserCategory> <ExcelFile> <SheetName>
	And I close the browser
	Given I launch the "Harrods" website
	When I Login with to Harrods with "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I validate expected "Extend Points" points is added on Harrods.com
	And I close the browser

	Examples:
		| UserCategory                                        | ExcelFile             | SheetName |
		| 231_ComplaintTicketExtendPointsValidateOnSSC_SMC_AC | TestDataSVCRegression | G07       |

#232	Verify that the CST is able to create a Complaint ticket for a Customer to upgrade tier from Black to Elite(Manual Tier Upgrade)

@SVCRegression @G07 @232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade
Scenario Outline: 232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade
	Given I launch the "SSC" website
	When I Navigate to SSC > Service > Tickets
	And I create a new Service Ticket
	And I enter all the mandatory details and create ticket for <UserCategory> <ExcelFile> <SheetName>
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
		| UserCategory                                                          | ExcelFile             | SheetName |
		| 232_CST_EnquiryTickettoUpgradeTier_SSC_BlacktoElite_ManualTierUpgrade | TestDataSVCRegression | G07       |

#233	Verify that the CST is able to create a Enquiry ticket for a Primary Customer to Transfer Points to Secondary Members

@SVCRegression @G07  @233_PrimaryToSecondaryPointTransfer @E2ERun
Scenario Outline: 233_PrimaryToSecondaryPointTransfer
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for primary user to secondary user in <UserCategory> <ExcelFile> <SheetName> transfer
	And I Navigate to SSC > Customers
	Then I validate points were transfered from Primary to Secondary user
	And I close the browser

	Examples:
		| UserCategory                        | ExcelFile             | SheetName |
		| 233_PrimaryToSecondaryPointTransfer | TestDataSVCRegression | G07       |

#234	Verify that the CST is able to Deactivate the Group Account

@SVCRegression @G07  @234_DeactivateGroupAccountValidateOnSSCSMCAC @E2ERun
Scenario: 234_DeactivateGroupAccountValidateOnSSCSMCAC
	Given I create 1 Full Reward User in Harrods.com
	Given I launch the "SSC" website
	When I Navigate to SSC > Group Accounts
	And I create new group account with PrimaryMember from SSC
	And I "DeActivate" given group account "" from SSC
	Then I should validate is deactivated from SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Hierarchy Management
	Then I should validate is deactivated from AC
	And I close the browser

#235	Verify that the CST is able to Rewards Statement based on Rewards Point that are Redeemed

@SVCRegression @G07 @235_ValidateRedeemActivityOnSSC @E2ERun
Scenario Outline: 235_ValidateRedeemActivityOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate "RedeemPoints" activity against the user in <UserCategory> <ExcelFile> <SheetName> is showing on SSC
	And I close the browser

	Examples:
		| UserCategory                    | ExcelFile             | SheetName |
		| 235_ValidateRedeemActivityOnSSC | TestDataSVCRegression | G07       |

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
		| ExcelFile             | SheetName | UserCategory                                           |
		| TestDataSVCRegression | G15       | 249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct |

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
		| ExcelFile             | SheetName | UserCategory                                          |
		| TestDataSVCRegression | G15       | 250_BlackTierCustomer_Book_1st_slot_aftercancellation |

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
		| ExcelFile             | SheetName | UserCategory                                                       |
		| TestDataSVCRegression | G15       | 251_CST_Cancel2ndSlot_10Percent_FromSSC_onBlackTierCustomerRequest |

#252	Verify if the existing loyalty rewards (Elite) customer with a UK address gets free delivery by purchasing greater than £10.00
@SVCRegression @G15 @252_Existing_Elite_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
Scenario Outline: 252_Existing_Elite_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
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
Scenario Outline: 253_Existing_Green_LoyaltyRewards_UKAddress_FreeDelivery_PurchasegreaterThan10
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

#259	Verify the CST is able to resolve the complaint based on a specific event and provide Dining experience voucher as compensation/Goodwilll

@SVCRegression @G17 @259_ValidateComplaintBasedDiningCompensationOnSSC @E2ERun
Scenario Outline: 259_ValidateComplaintBasedDiningCompensationOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for dining compensation for <UserCategory> <ExcelFile> <SheetName>
	And I change the status of ticket to "Closed" from SSC
	Then I should validate dining compensation ticket gets closed without any approvals
	And I close the browser

	Examples:
		| UserCategory                                      | ExcelFile             | SheetName |
		| 259_ValidateComplaintBasedDiningCompensationOnSSC | TestDataSVCRegression | G17       |

#260	Verify the CST is able to resolve the complaint based on a specific event and provide flowers as compensation/Goodwilll

@SVCRegression @G17 @260_ValidateComplaintBasedFlowersAsCompensationOnSSC @E2ERun
Scenario Outline: 260_ValidateComplaintBasedFlowersAsCompensationOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for flower as compensation for <UserCategory> <ExcelFile> <SheetName>
	And I change the status of ticket to "Closed" from SSC
	Then I should validate dining compensation ticket gets closed without any approvals
	And I close the browser

	Examples:		
		| UserCategory                                         | ExcelFile             | SheetName |
		| 260_ValidateComplaintBasedFlowersAsCompensationOnSSC | TestDataSVCRegression | G17       |

#261	A customer requests assistance ordering a gift card online or over the phone.  
#Customer is provided with details on how to self-serve in templated response or Knowledge articles.  
#Where necessary, advisers will correspond with transaction services to complete request.
@SVCRegression @G17 @261_AssistanceForOnlineGiftCardCompleteRequestOnSSC @E2ERun
Scenario Outline: 261_AssistanceForOnlineGiftCardCompleteRequestOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online gift card <UserCategory> <ExcelFile> <SheetName>
	And I change the status of ticket to "Closed" from SSC
	Then I should validate online "Gift card" ticket gets closed without any approvals
	And I close the browser

	Examples:
		| UserCategory                                        | ExcelFile             | SheetName |
		| 261_AssistanceForOnlineGiftCardCompleteRequestOnSSC | TestDataSVCRegression | G17       |

#262		An employee will request assistance creating a digital rewards card for their employee account, 
#adviser will walk them through the process of registering their account for a digital rewards card.
@SVCRegression @G17 @262_AssistanceForOnlineDigitalRewardsCardForEmployeeOnSSC @E2ERun
Scenario Outline: 262_AssistanceForOnlineDigitalRewardsCardForEmployeeOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card <UserCategory> <ExcelFile> <SheetName>
	And I change the status of ticket to "Closed" from SSC
	Then I should validate online "Reward card" ticket gets closed without any approvals
	And I close the browser

	Examples:
		| UserCategory                                              | ExcelFile             | SheetName |
		| 262_AssistanceForOnlineDigitalRewardsCardForEmployeeOnSSC | TestDataSVCRegression | G17       |

#263	"For managers to monitor adviser performance, the below SLA’s will be configured in the system according to this table. 
#Below are the To Be conditions for active ticket SLA’s.
#Admin, Managers, Furniture, Procedural Complaint, Hampers, Digital, Social Media, Rewards / Store Support, 
#Post Transactional Adjustment, Business VAT Requests, Store CS, Personal Shopping, General Tickets, 
#Watch Repairs – Maintenance/Service, Watch Repairs – Full Service, Watch Repairs - Adjustments, Alterations, Transaction Support. 
#Create SLA for - Admin"

@SVCRegression @G17 @263_VerifySSCTicketTimelineDataIsAsperSLA @E2ERun
Scenario Outline: 263_VerifySSCTicketTimelineDataIsAsperSLA
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card <UserCategory> <ExcelFile> <SheetName>
	Then I should validate resolved and resolution date were showing as per SLA
	And I close the browser

	Examples:
		| UserCategory                              | ExcelFile             | SheetName |
		| 263_VerifySSCTicketTimelineDataIsAsperSLA | TestDataSVCRegression | G17       |

#264	Customer reaches out to customer service to access transcripts of tickets held in SSC.Transcripts are collated and password protected. 
#Transcripts are shared with the customer using external Secure Share site. Customer is notified of completion of request. (Chat Transcript)
@SVCRegression @G17 @264_VerifyChatTranscriptTicketSummaryAccess @E2ERun
Scenario Outline: 264_VerifyChatTranscriptTicketSummaryAccess
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card <UserCategory> <ExcelFile> <SheetName>
	Then I should verify "Chat transcript" ticket summary can be accessed by the customer
	And I close the browser

	Examples:
		| UserCategory                                | ExcelFile             | SheetName |
		| 264_VerifyChatTranscriptTicketSummaryAccess | TestDataSVCRegression | G17       |

#265	Customer reaches out to customer service to access transcripts of tickets held in SSC.Transcripts are collated and password protected. 
#Transcripts are shared with the customer using external Secure Share site. Customer is notified of completion of request. (Individual call Transcript)
@SVCRegression @G17 @265_VerifyCallTranscriptTicketSummaryAccess @E2ERun
Scenario Outline: 265_VerifyCallTranscriptTicketSummaryAccess
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket for assistance for online digital rewards card <UserCategory> <ExcelFile> <SheetName>
	Then I should verify "Call transcript" ticket summary can be accessed by the customer
	And I close the browser

	Examples:
		| UserCategory                                | ExcelFile             | SheetName |
		| 265_VerifyCallTranscriptTicketSummaryAccess | TestDataSVCRegression | G17       |

#269	Verify if the CST  is able to resolve complaint about a Brand at Harrods  raised by customer,with an Apology and Goodwill.
@SVCRegression @G17 @269_ValidateResolveComplaintByApologyOnSSC
Scenario Outline: 269_ValidateResolveComplaintByApologyOnSSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create SSC ticket to resolve complaint by apology for <UserCategory> <ExcelFile> <SheetName>
	And I change the status of ticket to "Closed" from SSC
	Then I should validate ticket gets closed and approvers names were added
	And I close the browser

	Examples:
		| UserCategory                               | ExcelFile             | SheetName |
		| 269_ValidateResolveComplaintByApologyOnSSC | TestDataSVCRegression | G17       |

#270	Create Qatari staff customer(Qatari Board VIP) via SC with new payroll number and verify the details in SAP CDC
@SVCRegression @G01 @270_Create_new_QatariVIP_staffcustomer_SSC @E2ERun
Scenario: 270_Create_new_QatariVIP_staffcustomer_SSC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I add a new Qatari staff for "Gold" bandgrade
	And I validate the newly added Qatari staff
	And I close the browser

#273	Ensure that customers are limited to one award per day for currency exchange(i.e 250 points)
@SVCRegression @G05 @273_VerifyCustomerLmtToOneRewardForCurrencyExchange
Scenario Outline: 273_VerifyCustomerLmtToOneRewardForCurrencyExchange
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I should fetch CdcId of the user in <UserCategory> <ExcelFile> <SheetName> from SSC
	Then I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate currency interaction type for <UserCategory> <ExcelFile> <SheetName> is showing on SMC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > InteractionReports
	Then I should verify currency interaction type and bonus points against <UserCategory> <ExcelFile> <SheetName> is showing on AC
	And I close the browser

	Examples:
		| UserCategory                                        | ExcelFile             | SheetName |
		| 273_VerifyCustomerLmtToOneRewardForCurrencyExchange | TestDataSVCRegression | G05       |

#274	Verify for Gold tier customer, CST is able to Postpone birthday promotion week as per request (Limited to the current year only)
@SVCRegression @G07 @274_CST_Postpone_BdayPromo_OneWeek_CurrentYear
Scenario Outline: 274_CST_Postpone_BdayPromo_OneWeek_CurrentYear
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I navigate to the Birthday Campaign section of the user <UserCategory> <ExcelFile> <SheetName>
	Then I validate whether error message is thrown for incorrect birthday week selection
	And I Validate whether the Birthday week is changed and saved for the user
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate whether the Birthday is moved in SMc for <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                   | ExcelFile             | SheetName |
		| 274_CST_Postpone_BdayPromo_OneWeek_CurrentYear | TestDataSVCRegression | G07       |

#275	Verify for Gold tier customer, CST is able to Prepone birthday promotion week as per customer request. Verify customer is getting confirmation email for this.
@SVCRegression @G07 @275_CST_Postpone_BdayPromo_OneWeek
Scenario Outline: 275_CST_Postpone_BdayPromo_OneWeek
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I navigate to the Birthday Campaign section of the user <UserCategory> <ExcelFile> <SheetName>
	Then I validate whether error message is thrown for incorrect birthday week selection
	And I Validate whether the Birthday week is changed and saved for the user
	And I close the browser
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate whether the Birthday is moved in SMc for <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                       | ExcelFile             | SheetName |
		| 275_CST_Postpone_BdayPromo_OneWeek | TestDataSVCRegression | G07       |

#276	Verify CST is able to Prepone mini Harrods birthday promotion week for first child
@SVCRegression @G07 @276_CST_Prepone_MiniHarrods_BdayPromo_OneWeek
Scenario Outline: 276_CST_Prepone_MiniHarrods_BdayPromo_OneWeek
	Given I launch the "SMC" website
	When I Navigate to SMC > Campaigns
	And I search for adhoc campaigns and open the latest
	And I Select the MiniHarrods Bday week adhoc
	And I insert email in Chain Segment <UserCategory> <ExcelFile> <SheetName>
	And I copy the campaign and create new campaign
	Then I validate whether the emails are delivered for the new campaign
	And I close the browser
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I validate whether the miniharrods campaign is updated in SSC for user <UserCategory> <ExcelFile> <SheetName>
	And I close the browser

	Examples:
		| UserCategory                                  | ExcelFile             | SheetName |
		| 276_CST_Prepone_MiniHarrods_BdayPromo_OneWeek | TestDataSVCRegression | G07       |

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
		| UserCategory                         | ExcelFile             | SheetName |
		| 277_VerifyCSTObsoleteCustomerFromSSC | TestDataSVCRegression | G10       |

#278	Verify that customer cannot earn points while redeeming rewards points against cash rewards during a POS transaction
@SVCRegression @G05 @278_ValidateNoRewardsPointForRedeemingCashRewardsForPOS @E2ERun
Scenario Outline: 278_ValidateNoRewardsPointForRedeemingCashRewardsForPOS
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Order Reports
	Then I should verify "<UserCategory>" no rewards points gets added against redeem cash rewards action "<ExcelFile>" and "<SheetName>"
	And I close the browser

	Examples:
		| UserCategory                                            | ExcelFile             | SheetName |
		| 278_ValidateNoRewardsPointForRedeemingCashRewardsForPOS | TestDataSVCRegression | G05       |

#279	Verify that miscellaneous points manually deducted in SSC with reason-Loyalty testing  gets updated in AC
@SVCRegression @G05 @279_MiscPointManualDeductionLoyalityCheckAC @E2ERun
Scenario Outline: 279_MiscPointManualDeductionLoyalityCheckAC
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	And I create enquiry ticket for customer misc point deduction <UserCategory> <ExcelFile> <SheetName>
	When I Navigate to SSC > Customers
	Then I validate user from file <UserCategory> <ExcelFile> <SheetName> is added with points on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I validate expected "Miscellaneous" points is added on AC
	And I close the browser

	Examples:
		| UserCategory                                | ExcelFile             | SheetName |
		| 279_MiscPointManualDeductionLoyalityCheckAC | TestDataSVCRegression | G05       |

#283 Verify the retrospective points(Rewards and status points) awarded  if the customer not presented rewards card during sales transaction and sales document not sent to AC
@SVCRegression @G05 @283_VerifyRetrospectivePointsForSalesTransaction @E2ERun
Scenario Outline: 283_VerifyRetrospectivePointsForSalesTransaction
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify retrospective points for the user in <UserCategory> <ExcelFile> <SheetName> is showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Order Reports
	Then I should verify retrospective points for the user is showing on AC
	And I close the browser

	Examples:
		| UserCategory                                     | ExcelFile             | SheetName |
		| 283_VerifyRetrospectivePointsForSalesTransaction | TestDataSVCRegression | G05       |

#285	Verify the retrospective points(Base Rewards/Status ) awarded  if the customer not presented rewards card during sales transaction
@SVCRegression @G05 @285_VerifyBaseRewardsStatusPointsForSalesTransaction @E2ERun
Scenario Outline: 285_VerifyBaseRewardsStatusPointsForSalesTransaction
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify base rewards points for the user in <UserCategory> <ExcelFile> <SheetName> is showing on SSC
	And I close the browser
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Order Reports
	Then I should verify base rewards points for the user is showing on AC
	And I close the browser

	Examples:
		| UserCategory                                         | ExcelFile             | SheetName |
		| 285_VerifyBaseRewardsStatusPointsForSalesTransaction | TestDataSVCRegression | G05       |

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
		| UserCategory                                | ExcelFile             | SheetName |
		| 286_GoldTierCustomerTenpOnlineDayOneBooking | TestDataSVCRegression | G15       |

#289	Verify that the contact would be flagged as “end of purpose” and a deletion job which runs nightly would then delete this contact in SMC
@SVCRegression @G10 @289_VerifyStatusOfObsoleteCustomerFromSMC
Scenario Outline: 289_VerifyStatusOfObsoleteCustomerFromSMC
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate obsolete customers in <UserCategory> <ExcelFile> <SheetName> were deleted from SMC
	And I close the browser

	Examples:
		| UserCategory                              | ExcelFile             | SheetName |
		| 289_VerifyStatusOfObsoleteCustomerFromSMC | TestDataSVCRegression | G10       |

#290	Verify that the contact would be flagged as “Inactive”. The contact object will not get deleted in AC only flagged as “Inactive”
@SVCRegression @G10 @290_VerifyStatusOfObsoleteCustomerFromAC @E2ERun
Scenario Outline: 290_VerifyStatusOfObsoleteCustomerFromAC
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I validate obsolete customers in <UserCategory> <ExcelFile> <SheetName> were showing as inactive on AC
	And I close the browser

	Examples:
		| UserCategory                             | ExcelFile             | SheetName |
		| 290_VerifyStatusOfObsoleteCustomerFromAC | TestDataSVCRegression | G10       |