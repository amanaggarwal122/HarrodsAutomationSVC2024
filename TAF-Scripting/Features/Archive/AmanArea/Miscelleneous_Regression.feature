Feature: Miscelleneous_Regression


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

#_LoyaltyRewardsCustomer_DeleteDefaultAddress | TestDataSSCRegressionUpgrade | G01       |

@SVCRegression @G01 @096_EnrollToMiniHarrodsFromOnline
Scenario Outline: TC_096_EnrollToMiniHarrodsFromOnline
	Given I launch the "Harrods" website
	When I enroll "<UserName>" "<Email>" to mini harrods from Harrods.com
	Then I should validate enrolled "<UserName>" "<Email>" child is showing on Harrods.com
	And I close the browser window

	Examples:
		| UserName                          | Email                               |
		| FullRewardUserD DHYA | fullrewarduserdhya2024@gmail.com |
		#| FullRewardUserQSJLV LastNameFXIFN | FullRewardUserQSJLV222024@gmail.com |

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
		| FullRewardUserD DHYA | fullrewarduserdhya2024@gmail.com |
	#Examples:
	#	| UserCategory                                                       | ExcelFile                    | SheetName |
	#	| TC_100_Edit/remove_MiniHarrodsinterest_of_customer_through_Harrods | TestDataSSCRegressionUpgrade | G01       |


@SVCRegression @G01 @119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child
Scenario Outline: TC_119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	When I enroll "<UserName>" "<Email>" to mini harrods from Harrods.com
	And I click on MiniHarrods
	And I validate more than four child cannot be added in miniharrods from Harrods.com "<UserCategory>" "<ExcelFile>" "<SheetName>"
	Then I close the browser window
     

	Examples:
		| UserCategory                                                      | ExcelFile                    | SheetName |
		| TC_119_Existing_LoyaltyRewardsCustomer_allowedtoaddmorethan4child | TestDataSSCRegressionUpgrade | G01       |

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
	When I perform and validate existing Non rewards "<UserCategory>" customer register from Harrods.com by fetching data from "<ExcelFile>" and "<SheetName>"
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


@SVCRegression @G07 @226_CST_EnquiryTicket_GrantAdditional10Pct_Elite
Scenario Outline: TC_226_CST_EnquiryTicket_GrantAdditional10Pct_Elite
	Given I launch the "SSC" website
	#When I Navigate to SSC > Service > Tickets
	When I Navigate to SSC > Customers
	#And I create a new Service Ticket
	#And I enter all the mandatory details and create ticket for <UserCategory> <ExcelFile> <SheetName>
	And I create staff enquiry ticket for customer miscellaneous point addition <UserCategory> <ExcelFile> <SheetName>
	Then I change the Target Tier and Validate whether the status points are automatically calculated and save the upgrade <UserCategory> <ExcelFile> <SheetName>
	And I change the ticket status to Solved and closed
	#Then I validate the Customer Subject Details Category
	Then I validate the Customer Subject Details Category <UserCategory> <ExcelFile> <SheetName>
	And I close the browser window

	Examples:
		| UserCategory                                        | ExcelFile                    | SheetName |
		| TC_226_CST_EnquiryTicket_GrantAdditional10Pct_Elite | TestDataSSCRegressionUpgrade | G07       |


#249	Verify the Black tier customer is able to cancel the 2nd slot(Day 2) of  previously booked 10% discount day from Harrods.com
@SVCRegression @G15 @249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct
Scenario Outline: TC_249_BlackTierCustomer_Cancel_2_slot_of_prevBooked10pct
	Given I launch the "Harrods" website
	When I login to Harrods with a "<UserCategory>" user from "<ExcelFile>" "<SheetName>"
	Then I verify whether 10 percent discount is displayed to user <UserCategory> <ExcelFile> <SheetName>
	And I cancel Day 2 slot and check remaining count <UserCategory> <ExcelFile> <SheetName>
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