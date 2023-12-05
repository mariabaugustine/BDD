Feature: SearchAndAddToCart

A short summary of the feature

@E2E-Search_AddToCart
Scenario: Search
	Given User will be on the homepage
	When  User will type the '<searchtext>' in the search input box
	Then  Search results are loaded in the same page with '<searchtext>'
Examples: 
    | searchtext |
    | water      |