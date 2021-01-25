
Feature: Get Pet

  Get Pet

  Scenario: Request Successful
    Given A valid Get request
    When A Get is called on pets
    Then it should Resturn OK
    And Pet in response