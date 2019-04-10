Feature: LoginFlows
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Error message received on incorrect login
Given The user accessed the login page
When the user enters wrong credentials
Then An error message is displayed

Scenario: Clicking on the back button takes the user back to email input step
Given The user accessed the login page
When The user clicks on the back button after inputing an email
Then The user is redirected back to email input step

Scenario: Login form displayed at the end of the purchase flow
Given The user accessed a product page
When The unlogged user tries to complete the purchase flow
Then The login form is displayed