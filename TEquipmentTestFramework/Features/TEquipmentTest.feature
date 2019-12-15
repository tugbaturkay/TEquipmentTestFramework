Feature: TEquipmentTest

Scenario: TEquipment Search And Checkout
	Given User is on HomePage of application
	When User searches for "fluke"
	And selects item number 4 from results
	And User checks out as a guest
	Then User sees OrderConfirmationPage
