Feature: Euronews
Want to get basic practical skills for Aquality framework. 
Work with http-requests


@tag1
Scenario: Euronwes Gmail API
    Given the main page of Euronews is opened
    When I follow the link "Newsletters" in the header
    Then the page "Newsletters" is opened
    
    When I Choose A Random Newsletter Subscription Plan
    And an email form has appeared at the bottom of the page

