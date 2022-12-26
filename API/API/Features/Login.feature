Feature: Login
	Check Login functionality


Scenario: Get user name and password
	When User retrieves credentials
	Then response should contain credentials
	
Scenario: Check Get user name status code	
	When User retrieves credentials
	Then response code should be OK
	
Scenario: Login with correct user credentials
	When User retrieves credentials
	When User tries to login
	Then response code should be OK
	
Scenario: Login with wrong credentials
	Given wrong user credentials
	When User tries to login
	Then the response code should be Unautohorized
			