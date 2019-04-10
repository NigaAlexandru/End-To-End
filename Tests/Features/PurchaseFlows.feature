@End-to-End
Feature: PurchaseFlows
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Add product to basket
Given The user accessed a product page
When The user clicks on the buy button available
Then The product is successfully added to basket

Scenario: Delete product from basket
Given The user added a product to basket
And  The user clicks on see basket button
When The user clicks on the remove button
Then The product is successfully removed from the basket

Scenario: Clicking on "See basket" takes the user to basket page
Given The user added a product to basket
When The user clicks on see basket button
Then The user is redirected to basket page


