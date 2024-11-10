Feature: UserInterfaceTests


Background: 
	Given I make the window the maximum size
	When I go to the site "userinyerface.com"
	Then The home page is opened
	When In home page i click button "HERE"
	Then Login form is opened


@tag1
Scenario: TestCase1
	When I clear the input fields and enter the password 'A1сatrasas', email 'tractor', lower domain 'gmail' and high domain '.com'
		And I accept the user agreement, uncheck the box and click "Next"
	Then User form is opened
	When I uncheck all interests and check three interests
		And Click button "Daowland image"
	Then The download file has loaded
	When I delete the downloaded file
	Then The file was deleted
		

Scenario: TestCase2
	Then Help form is opened
    When I click button "Send"
    Then The help form is missing
		

Scenario: TestCase3
	When I Click accept coockie
	Then Field cookie is missed
		

Scenario: TestCase4
	Then Timer strarts wirh '00:00:00'
		
