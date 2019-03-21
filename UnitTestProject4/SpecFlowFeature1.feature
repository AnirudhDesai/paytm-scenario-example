Feature: Paytm Scenario
	

@mytag
Scenario: Open Paytm website 
	Given I have entered Paytm website
	When fields like Mobile,Electricity,DTH,Metro should be pesent
	Then check all the corresponding fields are present

@mytag
Scenario: Validate Mobile Recharge 
	Given I have entered Paytm website
	And I click on Mobile option
	Then Page should navigate to Url https://paytm.com/recharge


@mytag
Scenario: Paytm Recharge
	Given I have entered Paytm website
	And I click on Mobile option
	And also I have entered Mobile number and Amount
	When I click on Proceed Recharge Button
	Then Page should Navigate to Proceed to Pay and Url should be https://paytm.com/coupons
