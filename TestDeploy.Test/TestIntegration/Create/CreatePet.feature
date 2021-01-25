
Feature: Create Pet

  Create Pet

  Scenario Outline: Request Successful
    Given A valid Post request with <Name>, <Dob> and <TempinC>
    When A Post on called on pets
    Then it should Resturn Created
    And Pet Id in Header

    Examples:
      | Name | Dob        | TempinC |
      | cat  | 02-01-2009 | 10      |
      | rat  | 12-02-2009 | 09      |