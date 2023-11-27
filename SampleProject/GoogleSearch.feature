Feature: GoogleSearch

To perform search operation on google home page

@tag1
Scenario: To perform search with google search button
	Given Google homepage should be loaded
	When Type "hp laptop" in the search text box
	And click on the google search button
	Then the results should be displayed on the next page with title "hp laptop - Google Search"


Scenario: To perform search IMFL button
	Given Google homepage should be loaded
	When Type "hp laptop" in the search text box
	And click on the IMFL button
	Then the results should be redirected to a page with title "HP Laptops"