Feature: Careers
	Check careers page

Scenario: Return Career Areas Count
	When user navigates to the products page
	And user clicks on buy NordVPN
	And user clicks login button
	Then email field is present
	When user goes back
	And user selects one year plan
	And store one year plan price
	And user clicks continue on payment
	Then the yearly price should match