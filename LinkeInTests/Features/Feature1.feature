﻿Feature: Login

User logs in with valid credentials (username,password)
Home page will load after successful login

A short summary of the feature

Background: Given User will be on the login page

@positive
Scenario Outline: Login with valid credentials
	When User will enter '<UserName>'
	And  User will enter '<Password>'
	And  User will click on login button
	Then User will be redirected to home page
Examples:
     | UserName      | Password |
     | abc@gmail.com | 1234     |
     | xyz@gmail.com | 4567     |

@negative
Scenario Outline: Login with invalid credentials
	When User will enter '<UserName>'
	And  User will enter '<Password>'
	And  User will click on login button
	Then Error message for password length should be thrown
Examples: 
     | UserName      | Password |
     | abc@gmail.com | 12345    |
     | xyz@gmail.com | 45678    |

@regression
Scenario Outline: Check for Password Hidden Display
	When User will enter '<Password>'
	And  User will click on show button in the password text box
	Then The password characters should be shown
Examples: 
     | Password |
     | 6653     |

@regression
Scenario Outline: Check for Password Show Display
	When User will enter '<Password>'
	And  User will click on show button in the password text box
	And  User will click on hide button in the password text box
	Then The password characters should not be shown
Examples:
	 | Password |
	 | 6653     |