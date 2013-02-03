Feature: Talks
	In order fit my talks into my schedule
	As a conference coordinator 
	I want to organize my talks

Scenario: Bulk Talks 
	Given I have a new schedule
	When I enter several talks as raw data
	"""
	Writing Fast Tests Against Enterprise Rails 60min
	Overdoing it in Python 45min
	Lua for the Masses 30min
	Ruby Errors from Mismatched Gem Versions 45min
	Common Ruby Errors 45min
	Rails for Python Developers lightning
	Communicating Over Distance 60min
	Accounting-Driven Development 45min
	Woah 30min
	Sit Down and Write 30min
	Pair Programming vs Noise 45min
	Rails Magic 60min
	Ruby on Rails: Why We Should Move On 60min
	Clojure Ate Scala (on my project) 45min
	Programming in the Boondocks of Seattle 30min
	Ruby vs. Clojure for Back-End Development 30min
	Ruby on Rails Legacy App Maintenance 60min
	A World Without HackerNews 30min
	User Interface CSS in Rails Apps 30min	
	"""
	Then I should receive 19 talks returned

Scenario: Talk numbers
	Given I have a new schedule
	 When I add a talk that has a number at the end of the raw data
	"""
	User Interface CSS in Rails Apps 30min
	"""
	Then the talk duration should be 30 minutes

Scenario: Talk lightning 
	Given I have a new schedule
	When I add a talk that has the lightning keywork in the raw data
	"""
	Rails for Python Developers lightning
	"""
	Then the talk duration should be 5 minutes

Scenario: Talk title 
	Given I have a new schedule
	When I add talk title that has numbers not at the end of the raw data 
	"""
	Rails for 99 Python Developers lightning
	"""
	Then the talk will not be added

Scenario: Talk title double number
	Given I have a new schedule
	When I add talk title that has numbers not at the end of the raw data 
	"""
	Rails for 99 Python Developers 30min 
	"""
	Then the talk will not be added

Scenario: Talk gaps
	Given I have a new schedule
	And there exists room for it on the schedule
	When the talk is added to the schedule
	Then there should be no gaps
