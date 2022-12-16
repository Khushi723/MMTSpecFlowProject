Feature: MMT Automation

Scenario: Perform round trip booking and select lowest fare flights from MMT
	
	Given User is on the Home page of the MMT website
	And User selects the roundtrip
	When User select "New Delhi" and "Bangaluru"
	And User select the Departure after 15 days from Today's date
	And User selects the Return 5 days after the departure Date
	And Select 2 "Adults"
	And Select 1 "children"
	Then Click Search
	And Select Filter "Morning Departure"
	And Select "Lowest Fares"


	