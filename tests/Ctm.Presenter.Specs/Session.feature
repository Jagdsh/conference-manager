Feature: Session
	In order fit my talks into my schedule
	As a conference coordinator 
	I want to have a my talks organized in sub groups

Scenario: Session types
	Given I have a new session
	When I add several talks as raw data
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
	Then there should be a morning session
	And there shold be an afternoon session

Scenario: Morning session start
	Given I have a new session
	When I add several talks as raw data
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
	Then the first morning talk should be at 9AM

Scenario: Morning session stop
	Given I have a new session
	When I add several talks as raw data
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
	Then the last morning talk should end before 12PM

Scenario: Afternoon session start
	Given I have a new session
	When I add several talks as raw data
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
	Then the first afternoon talk should be at 1PM

Scenario: Afternoon session stop
	Given I have a new session
	When I add several talks as raw data
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
	Then the last afternoon talk should end before 5PM