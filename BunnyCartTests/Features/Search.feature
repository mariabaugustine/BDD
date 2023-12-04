Feature: Search


@Product_Search
Scenario Outline:Search For Products
	Given User will be on the homepage
	When  User will type the '<searchtext>' in the search input box
	#*     User clicks on search button
	Then  Search results are loaded in the same page with '<searchtext>'
Examples: 
    | searchtext |
    | water      |
    | java       |
    | hairgrass  |
