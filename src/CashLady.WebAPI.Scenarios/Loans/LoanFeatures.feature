Feature: LoanFeatures

@mytag
Scenario: Apply for loan
	Given a user applies for a loan
	Then the system should return a reference number

	Given I am a borroweer user
	When I request to view my loan details
	Then System should return information regarding my Loan

	Given I am an underwtiter
	And a user applies for a loan 
	When I cancel the loan
	Then the loan Status should appear as Canceled

	Given I am an underwriter
	When I request to view all loans
	Then the system should return all available laons


