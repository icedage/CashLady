Feature: Apply for loand

@mytag
Scenario Outline: Add two numbers
	Given user applies for a loan
	And details are correct
	Then the system should create an account for the user
	And it should save user details
	And it should return a loan reference number
