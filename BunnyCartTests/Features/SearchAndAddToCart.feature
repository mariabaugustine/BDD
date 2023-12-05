Feature: SearchAndAddToCart

A short summary of the feature

@E2E-Search_AddToCart
Scenario: 01 Search
	Given User will be on the homepage
	When  User will type the '<searchtext>' in the search input box
	Then  Search results are loaded in the same page with '<searchtext>'
	Then The heading should have '<searchtext>'
	* Title should have '<searchtext>'
Examples: 
    | searchtext |
    | water      |

@E2E-Search_AddToCart
Scenario Outline: 02 Select a particular product
	Given  Search page is loaded
	When User selects a '<productnumber>'
	Then Product page is loaded
Examples: 
    | productnumber |
    | 1             |
