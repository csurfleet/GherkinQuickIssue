Feature: Alive Monitoring
	In order to report on when the Gateway is down
	As any monitor, human or automated
	I want to be able to ask the Gateway if it is alive

Scenario: Web request confirming system is alive
	Given the system is running
	When a web request is recieved to the root URL
	Then a response is returned with the HTTP status code 200