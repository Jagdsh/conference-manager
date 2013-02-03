Feature: Tracks
	In order fit my talks into my schedule
	As a conference coordinator 
	I want to automate my schedule creation

Scenario: Track
	Given I have a new track
	When I enter talks
	Then my schedule should have at least one track

Scenario: Track sessions 
	Given I have a new track
	When I enter talks
	Then my track should have at least one session

Scenario: Session talks
	Given I have a new track
	When I enter talks
	Then my session should have at least one talk

Scenario: Lunch
	Given I have a new track
	When I enter talks
	Then I want to see a lunch for each track
	And lunch should start at 12PM
	And lunch should end by 1PM

Scenario: Network event
	Given I have a new track
	When I enter talks
	Then my track should have one network event 
	And it should start no earlier than 4PM
	And it should end no later than 5PM

Scenario: Schedule time
	Given I have a new track
	When I enter talks
	Then each talk should be assigned a time