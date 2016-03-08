Feature: LoanFeatures

@mytag
Scenario: Apply for loan
	Given a user applies for a loan
	Then the system should return a reference number

Scenario: Get all loans
	Given I am an underwtiter
	When I request to view all loans
	Then System should return a list of loans


