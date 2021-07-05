
Feature: Bunning Search
	Simple Search on bunnings

@Search
Scenario: Search bar has a difault placeholder
	Given User Navigates to  https://www.bunnings.com.au/
	Then difault search value is What can we help you find today?

@Search
Scenario: Search bar has 8 popular searches
	Given User Navigates to  https://www.bunnings.com.au/
	When click on search bar 
	Then There are 8 result on popular searchses 

@Search
Scenario: Search bar has 4 popular rightnow
	Given User Navigates to  https://www.bunnings.com.au/
	When click on search bar 
	Then There are 4 result on popular right now 
