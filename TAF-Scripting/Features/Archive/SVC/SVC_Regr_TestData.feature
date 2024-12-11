Feature: SVCRegressionTestDataCreation

@Testdata @TestDataCreation @006_TestdataCreation_RegNonRewardsUserEmailConsentYes_In_SSC
Scenario Outline: 006_TestdataCreation_RegNonRewardsUserEmailConsentYes_In_SSC
    Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Perform Non Reward User Registration in SSC and write to Input Excelsheet "<ExcelFile>" "<SheetName>" for "<TestCase>"	
	Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC006    |

@TestDataCreation  @008_Lite_account_NewuserSignup
Scenario Outline: 008_Lite_account_NewuserSignup
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	And I Perform SignUp action with new user From Harrods.com and write to Input Excelsheet "<ExcelFile>" "<SheetName>" for "<TestCase>"
	And I perform email validation from yopmail
	Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC008    |


@TestDataCreation @010_TestdataCreation_RegNonRewardsUserEmailConsentNo_In_SSC
Scenario Outline: 010_TestdataCreation_RegNonRewardsUserEmailConsentNo_In_SSC
    Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Perform Non Reward User Registration in SSC and write to Input Excelsheet "<ExcelFile>" "<SheetName>" for "<TestCase>"	
	Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC010    |

@TestDataCreation @012_TestdataCreation_RegNonRewardsUserEmailConsentAndTierUpgradeGoldYes_In_SSC
Scenario Outline: 012_TestdataCreation_RegNonRewardsUserEmailConsentYesAndTierUpgradeGold_In_SSC
    Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Perform Non Reward User Registration in SSC
	Then I upgrade the user to "Gold" tier and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
	Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase | EmailConsent |
| SVCTestDataCreation | G01       | TC012    | yes          |

@TestDataCreation @013_TestdataCreation_RegNonRewardsUserEmailConsentYesAndTierUpgradeBlack_In_SSC
Scenario Outline: 013_TestdataCreation_RegNonRewardsUserEmailConsentYesAndTierUpgradeBlack_In_SSC
    Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Perform Non Reward User Registration in SSC	
	Then I upgrade the user to "Black" tier and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
	Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase | EmailConsent |
| SVCTestDataCreation | G01       | TC013    | yes          |

@TestDataCreation @014_TestdataCreation_RegNonRewardsUserEmailConsentYesAndTierUpgradeElite_In_SSC
Scenario Outline: 014_TestdataCreation_RegNonRewardsUserEmailConsentYesAndTierUpgradeElite_In_SSC
    Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I Perform Non Reward User Registration in SSC
	Then I upgrade the user to "Elite" tier and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
	Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase | EmailConsent |
| SVCTestDataCreation | G01       | TC014    | yes          |

@TestDataCreation  @015_Lite_account_NewuserSignup
Scenario Outline: 015_Lite_account_NewuserSignup
	Given I launch the "Harrods" website
	When I click on  signup to email button under footer of Harrods.com
	And I Perform SignUp action with new user From Harrods.com and write to Input Excelsheet "<ExcelFile>" "<SheetName>" for "<TestCase>"
	And I perform email validation from yopmail
	Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC015    |

@TestDataCreation @025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 025_ExistingFullRewardsUserCardNewEmail_FullRewardHarrodsReg_EmailConsentYes
Given I create Rewards customer in SSC and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC025    |

@TestDataCreation @026_EmailFromNonReward_CardFromReward_FullRewardHarrodsReg_EmailConsentYes
Scenario Outline: 026_EmailFromNonReward_CardFromReward_FullRewardHarrodsReg_EmailConsentYes
Given I create Non Rewards customer in SSC and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I create Rewards customer in SSC and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC026    |

@TestDataCreation @028_NonReward_HarrodsJoinRewardWithoutCardData
Scenario Outline: 028_NonReward_HarrodsJoinRewardWithoutCardData
Given I create Non Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC028    |

@TestDataCreation @031_FullRewardHarrodsCheckOutRegistrationWithNonLoyalityUserEmail
Scenario Outline: 031_FullRewardHarrodsCheckOutRegistrationWithNonLoyalityUserEmail
Given I create Non Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC031    |

@TestDataCreation @033_Reg_NonRewardCustomer_EnableEmailConsent_Yes
Scenario Outline: 033_Reg_NonRewardCustomer_EnableEmailConsent_Yes
Given I create Non Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC033    |

@TestDataCreation @034_Reg_NonRewardCustomer_EnableSMSConsent_Yes
Scenario Outline: 034_Reg_NonRewardCustomer_EnableSMSConsent_Yes
Given I create Non Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC034    |

@TestDataCreation @035_Reg_NonRewardCustomer_EnablePostalConsent_Yes
Scenario Outline: 035_Reg_NonRewardCustomer_EnablePostalConsent_Yes
Given I create Non Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC035    |

@TestDataCreation @036_Reg_NonRewardCustomer_EnablePhoneConsent_Yes
Scenario Outline: 036_Reg_NonRewardCustomer_EnablePhoneConsent_Yes
Given I create Non Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC036    |

@TestDataCreation @037_Reg_NonRewardCustomer_WithSMSConsent_RemoveInterest_partially
Scenario Outline: 037_Reg_NonRewardCustomer_WithSMSConsent_RemoveInterest_partially
Given I create Non Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC037    |

@TestDataCreation @038_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests
Scenario Outline: 038_Reg_NonRewardCustomer_EnableAllChannelConsentYes_MixedSelectionOnInterests
Given I create Non Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC038    |


@TestDataCreation @039_Reg_LoyaltyRewardCustomerG0/G1_EnableEmailConsentYes_JoinMiniHarrods
Scenario Outline: 039_Reg_LoyaltyRewardCustomerG0/G1_EnableEmailConsentYes_JoinMiniHarrods
Given I create Loyalty Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC039    |

@TestDataCreation @040_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine
Scenario Outline: 040_Reg_LoyaltyRewardCustomerG0/G1_consentPost_and_Harrodsmagazine
Given I create Loyalty Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
When I add UK address for the user created
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC040    |

@TestDataCreation @041_Loyaltyrewards_Goldcustomer_EmailConsent_Yes
Scenario Outline: 041_Loyaltyrewards_Goldcustomer_EmailConsent_Yes
Given I create Loyalty Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
When I mark Consent as "Yes" for Email
Then I upgrade the user to "Gold" tier and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC041    |

@TestDataCreation @042_Loyaltyrewards_Goldcustomer_PostalandMagazineConsent_Yes
Scenario Outline: 042_Loyaltyrewards_Goldcustomer_PostalandMagazineConsent_Yes
Given I create Loyalty Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
When I mark Consent as "Yes" for Postal, Magazine
Then I upgrade the user to "Gold" tier and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC042    |

@TestDataCreation @043_Loyaltyrewards_Goldcustomer_signedMiniHarrods_emailconsent_removesallinterests
Scenario Outline: 043_Loyaltyrewards_Goldcustomer_signedMiniHarrods_emailconsent_removesallinterests
Given I create Loyalty Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
When I mark Consent as "Yes" for Email
Then I upgrade the user to "Gold" tier and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC043    |

@TestDataCreation @044_Loyaltyrewards_Goldcustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent
Scenario Outline: 044_Loyaltyrewards_Goldcustomer_signedMiniHarrods_selectedHarrodsmagazine_removesAllchannelconsent
Given I create Loyalty Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
When I add UK address for the user created
And I mark Consent as "Yes" for Email,SMS,POST
Then I upgrade the user to "Gold" tier and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC044   |

@TestDataCreation @097_Existing_LoyaltyRewardsCustomer_AddMultipleChildToCustomerAccount
Scenario Outline: 097_Existing_LoyaltyRewardsCustomer_AddMultipleChildToCustomerAccount
Given I create Loyalty Rewards customer and write to Input Excelsheet <ExcelFile> <SheetName> for <TestCase>
Then I close the browser

Examples:
| ExcelFile           | SheetName | TestCase |
| SVCTestDataCreation | G01       | TC097   |
