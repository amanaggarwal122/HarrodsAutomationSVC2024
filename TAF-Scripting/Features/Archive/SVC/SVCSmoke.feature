Feature: SVCSmoke
	SVC Smoke Test cases. 
	AUT : Harrods.com, SSC, SMC and AC

@SVCSmoke @01HarrodsRegistrationForRewardCustomerWithEmailConsentNo  @HT-72336
Scenario Outline: 01HarrodsRegistrationForRewardCustomerWithEmailConsentNo
	Given I launch the "Harrods" website 
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from smoke "<ExcelFile>" and "<SheetName>"
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
	| UserCategory                 | ExcelFile        | SheetName        |
	| RewardCustomerEmailConsentNo | TestDataSVCSmoke | UserRegistration |

@SVCSmoke @02HarrodsRegistrationForRewardCustomerWithEmailConsentYes @HT-72342
Scenario Outline: 02HarrodsRegistrationForRewardCustomerWithEmailConsentYes
	Given I launch the "Harrods" website 
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from smoke "<ExcelFile>" and "<SheetName>"
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
	| UserCategory                  | ExcelFile        | SheetName        |
	| RewardCustomerEmailConsentYes | TestDataSVCSmoke | UserRegistration |

@SVCSmoke @03HarrodsRegistrationForNonRewardCustomerWithEmailConsentNo @HT-72343
Scenario Outline: 03HarrodsRegistrationForNonRewardCustomerWithEmailConsentNo
	Given I launch the "Harrods" website 
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from smoke "<ExcelFile>" and "<SheetName>"
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
	| UserCategory                    | ExcelFile        | SheetName        |
	| NonRewardCustomerEmailConsentNo | TestDataSVCSmoke | UserRegistration |

@SVCSmoke @04HarrodsRegistrationForNonRewardCustomerWithEmailConsentYes @HT-72344
Scenario Outline: 04HarrodsRegistrationForNonRewardCustomerWithEmailConsentYes
	Given I launch the "Harrods" website 
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from smoke "<ExcelFile>" and "<SheetName>"
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
	| UserCategory                     | ExcelFile        | SheetName        |
	| NonRewardCustomerEmailConsentYes | TestDataSVCSmoke | UserRegistration |

@SVCSmoke @05HarrodsRegistrationForExistingCustomerWithEmailConsentYes @HT-72345
Scenario Outline: 05HarrodsRegistrationForExistingCustomerWithEmailConsentYes
	Given I launch the "Harrods" website 
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from smoke "<ExcelFile>" and "<SheetName>"
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
	| UserCategory                    | ExcelFile        | SheetName        |
	| ExistingCustomerEmailConsentYes | TestDataSVCSmoke | UserRegistration |

@SVCSmoke @06HarrodsRegistrationForExistingCustomerWithEmailConsentNo @HT-72346
Scenario Outline: 06HarrodsRegistrationForExistingCustomerWithEmailConsentNo
	Given I launch the "Harrods" website 
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from smoke "<ExcelFile>" and "<SheetName>"
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
	| UserCategory                   | ExcelFile        | SheetName        |
	| ExistingCustomerEmailConsentNo | TestDataSVCSmoke | UserRegistration |

@SVCSmoke @07HarrodsRegistrationForGhostCustomerWithEmailConsentYes @HT-72347
Scenario Outline: 07HarrodsRegistrationForGhostCustomerWithEmailConsentYes
	Given I launch the "Harrods" website 
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from smoke "<ExcelFile>" and "<SheetName>"
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
	| UserCategory                 | ExcelFile        | SheetName        |
	| GhostCustomerEmailConsentYes | TestDataSVCSmoke | UserRegistration |

@SVCSmoke @08HarrodsRegistrationForGhostCustomerWithEmailConsentNo @HT-72348
Scenario Outline: 08HarrodsRegistrationForGhostCustomerWithEmailConsentNo
	Given I launch the "Harrods" website 
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from smoke "<ExcelFile>" and "<SheetName>"
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
	| UserCategory                | ExcelFile        | SheetName        |
	| GhostCustomerEmailConsentNo | TestDataSVCSmoke | UserRegistration |

@SVCSmoke @09HarrodsRegistrationForLiteCustomerWithEmailConsentYes @HT-72349
Scenario Outline: 09HarrodsRegistrationForLiteCustomerWithEmailConsentYes
	Given I launch the "Harrods" website 
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from smoke "<ExcelFile>" and "<SheetName>"
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
	| UserCategory                | ExcelFile        | SheetName        |
	| LiteCustomerEmailConsentYes | TestDataSVCSmoke | UserRegistration |

@SVCSmoke @10HarrodsRegistrationForLiteCustomerWithEmailConsentNo @HT-72350
Scenario Outline: 10HarrodsRegistrationForLiteCustomerWithEmailConsentNo
	Given I launch the "Harrods" website 
	When I perform and validate "<UserCategory>" customer register from Harrods.com by fetching data from smoke "<ExcelFile>" and "<SheetName>"
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
	| UserCategory               | ExcelFile        | SheetName        |
	| LiteCustomerEmailConsentNo | TestDataSVCSmoke | UserRegistration |

@SVCSmoke @11AddAddressFromOnlineValidateOnSSC_SMC @HT-72374
Scenario Outline: 11AddAddressFromOnlineValidateOnSSC_SMC
	Given I launch the browser to open the harrods website
	When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
	And I add a new address to user from Harrods.com "<ExcelFile>" "<SheetName>"
	Then I should validate added address is showing on Harrods.com "<ExcelFile>" "<SheetName>"
	And I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate added address is showing on SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added address is showing on SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
	| ExcelFile        | SheetName     |
	| TestDataSVCSmoke | ProfileUpdate |

@SVCSmoke @12EditAddressFromOnlineValidateOnSSC_SMC @HT-72375
Scenario Outline: 12EditAddressFromOnlineValidateOnSSC_SMC
	Given I launch the browser to open the harrods website
	When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
	And I edit existing address of user from Harrods.com "<ExcelFile>" "<SheetName>"
	Then I should validate updated address is showing on Harrods.com "<ExcelFile>" "<SheetName>"
	And I close the browser
	
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate updated address is showing on SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate updated address is showing on SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
	| ExcelFile        | SheetName     |
	| TestDataSVCSmoke | ProfileUpdate |

@SVCSmoke @13DeleteAddressFromOnlineValidateOnSSC_SMC @HT-72376
Scenario Outline: 13DeleteAddressFromOnlineValidateOnSSC_SMC
	Given I launch the browser to open the harrods website
	When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
	Then I delete the contact details of customer and validate "<ExcelFile>" "<SheetName>"
	And I close the browser
	
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate address gets deleted from SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate address gets deleted from SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
	| ExcelFile        | SheetName     |
	| TestDataSVCSmoke | ProfileUpdate |

@SVCSmoke @14AddUKphone_validatein_SSC_SMC_CDC @HT-72377
Scenario Outline: 14AddUKphone_validatein_SSC_SMC_CDC
	Given I launch the browser to open the harrods website
	When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
	Then I add UK Phone in harrods website from "<ExcelFile>" "<SheetName>"
	And I close the browser
	
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I search for the Customer in SSC and validate the phone number from "<ExcelFile>" "<SheetName>"
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate added phonenumber is showing on SMC "<ExcelFile>" ""<SheetName>"
	And I close the browser


	Examples:
	| ExcelFile        | SheetName     |
	| TestDataSVCSmoke | ProfileUpdate |

@SVCSmoke @15AddchildMiniHarrodsOnlineValidateOnSSC_SMC @HT-72378
    Scenario Outline: 15AddchildMiniHarrodsOnlineValidateOnSSC_SMC
    Given I launch the browser to open the harrods website
    When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
    And I click on MiniHarrods
    And I add a new child in miniharrods from Harrods.com "<ExcelFile>" "<SheetName>"
    Then I should validate added child is showing on Harrods.com "<ExcelFile>" "<SheetName>"
    And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate child details are updated in SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	 Given I launch the "SSC" website
    When I Navigate to SSC > Customers
	Then I should search the customer from SSC "<ExcelFile>" "<SheetName>"
    Then I should validate added child is showing on SSC "<ExcelFile>" "<SheetName>"
    And I close the browser
	
	Examples:
     | ExcelFile        | SheetName     |
     | TestDataSVCSmoke | ProfileUpdate |
   
@SVCSmoke @16RemovechildMiniHarrodsOnlineValidate @HT-72379
    Scenario Outline: 16RemovechildMiniHarrodsOnlineValidate
    Given I launch the browser to open the harrods website
    When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
    And I click on MiniHarrods
    And I click on remove button to remove child
    Then I should validate added child is removed from Harrods.com
    And I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should validate child gets deleted from SSC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate child details are removed from SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	
	Examples:
     | ExcelFile | SheetName |
     | TestDataSVCSmoke | ProfileUpdate |

@SVCSmoke @17OptInAllConsentInterestFromHarrodsValidateOnSSC_SMC @HT-72380
Scenario Outline: 17OptInAllConsentInterestFromHarrodsValidateOnSSC_SMC
	Given I launch the browser to open the harrods website
	When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-In All" channels and interests consent from Harrods.com
	Then I should validate "Opt-In All" channels and interests consent were saved on Harrods.com
	And I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I search for Customer Consent and Interests and validate on SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate "Opt-In All" channels and interests consent were saved on SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
	| ExcelFile        | SheetName     |
	| TestDataSVCSmoke | ProfileUpdate |

@SVCSmoke @18OptOutAllConsentInterestFromHarrodsValidateOnSSC_SMC @HT-72381
Scenario Outline: 18OptOutAllConsentInterestFromHarrodsValidateOnSSC_SMC
	Given I launch the browser to open the harrods website
	When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-Out All" channels and interests consent from Harrods.com
	Then I should validate "Opt-Out All" channels and interests consent were saved on Harrods.com
	And I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I search for Customer Consent and Interests and validate on SSC "<ExcelFile>" "<SheetName>"
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate "Opt-Out All" channels and interests consent were saved on SMC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Examples:
	| ExcelFile        | SheetName     |
	| TestDataSVCSmoke | ProfileUpdate |

@SVCSmoke @19OptInandOptoutconsentandinterests_validateOn_SSC_SMC_CDC @HT-72382
Scenario Outline: 19OptInandOptoutconsentandinterests_validateOn_SSC_SMC_CDC
Given I launch the browser to open the harrods website
	When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
	And I Navigate to Harrods > Communication Preferences
	And I perform "Opt-Some" channels and interests consent from Harrods.com
	Then I should validate "Opt-Some" channels and interests consent were saved on Harrods.com
	And I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Customers	
	Then I search for Customer Consent and Interests and validate on SSC "<ExcelFile>" "<SheetName>"
	And I close the browser

	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should validate "Opt-Some" channels and interests consent were saved on SMC "<ExcelFile>" "<SheetName>"
	And I close the browser
		

	Examples:
	| ExcelFile        | SheetName     |
	| TestDataSVCSmoke | ProfileUpdate |
	
@SVCSmoke @20OrderPlacingFromHarrodsValidateOnSSC_SMC_AC @HT-72383
Scenario Outline: 20OrderPlacingFromHarrodsValidateOnSSC_SMC_AC
### OTP asking while product purchasing during, Since validating with old order details
	#Given I launch the browser to open the harrods website
	#When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
	#Then I clear the cart before adding the products to bag	
	#When I Add product for Ordering by provide address and payment details from "<ExcelFile>" "<SheetName>"
	#Then I validate the order and verify the payment details
	#And I close the browser and save the order details
		
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify users from <ExcelFile> <SheetName> were showing on SSC
	And I close the browser

	Given I launch the "AC" website
	When I Navigate to AC > Reports > Order Reports
	Then I should verify orders against user from "<ExcelFile>" "<SheetName>" were showing on AC
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I should verify orders against user from "<ExcelFile>" "<SheetName>" were showing on SMC
	And I close the browser
	
	Given I launch the "SSC" website
	When I Navigate to SSC > Customers
	Then I should verify orders against user from "<ExcelFile>" "<SheetName>" were showing on SSC
	And I close the browser

	Examples:
	| ExcelFile        | SheetName       |
	| TestDataSVCSmoke | OrderManagement |

@SVCSmoke @21CustomerTierUpgradeTicketValidateOnSSC_SMC_AC @HT-72384
Scenario Outline: 21CustomerTierUpgradeTicketValidateOnSSC_SMC_AC
	Given I launch the "Harrods" website 
	When I perform new user registration for "<UserCategory>" and update details to excel "<ExcelFile>" and "<SheetName>"
	Then I close the browser

	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create ticket for customer tier upgrade from file "<ExcelFile>" "<SheetName>" 
	And I Navigate to SSC > Customers
	Then I validate user tier from file "<ExcelFile>" "<SheetName>" is upgraded on SSC
	And I close the browser

	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I validate user tier is upgraded on AC
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate user tier from file "<ExcelFile>" "<SheetName>" is upgraded on SMC
	And I close the browser

	Given I launch the browser to open the harrods website
	When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
	Then I validate user tier is upgraded on Harrods.com
	And I close the browser

	Examples:
	| UserCategory                 | ExcelFile        | SheetName |
	| TierUpgradePlusPointAddition | TestDataSVCSmoke | Tickets   |

##Execute above tier upgrade scenarion as a precondition for below test case
@SVCSmoke @22CustomerRewardsPointAdditionTicketValidateOnSSC_SMC_AC @HT-72385
Scenario Outline: 22CustomerRewardsPointAdditionTicketValidateOnSSC_SMC_AC
	Given I launch the "SSC" website
	When I Navigate to SSC > Tickets
	And I create ticket for customer rewards point addition from file "<ExcelFile>" "<SheetName>" 
	And I Navigate to SSC > Customers
	Then I validate user from file "<ExcelFile>" "<SheetName>" is added with points on SSC
	And I close the browser
	
	Given I launch the "AC" website
	When I Navigate to AC > Reports > Member Reports
	Then I validate user rewards points is added on AC
	And I close the browser
	
	Given I launch the "SMC" website
	When I Navigate to SMC > Contacts
	Then I validate user from file "<ExcelFile>" "<SheetName>" is added with points on SMC
	And I close the browser

	Given I launch the browser to open the harrods website
	When I login to Harrods with a user from "<ExcelFile>" "<SheetName>"
	Then I validate user rewards point is added on Harrods.com
	And I close the browser

	Examples:
	| UserCategory                 | ExcelFile        | SheetName |
	| TierUpgradePlusPointAddition | TestDataSVCSmoke | Tickets   |
