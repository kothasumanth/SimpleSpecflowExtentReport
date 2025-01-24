Feature: Calculate addition of two numbers
    We have to check if two numbers are numerical.
    If they are not numerical, then return an error message saying "Please enter valid numbers".
    If they are numerical, then return the sum of two numbers.

Scenario Outline: Validate addition of two numbers
    Given I have entered "<input1>" and "<input2>"
    When I press add
    Then the result should be "<expectedResult>"

    Examples:
      | input1 | input2 | expectedResult               |
      | 5      | 10     | 15                           |
      | -5     | -10    | -1                          |
      | -5     | 10     | 5                            |
      | 5      | -10    | -5                           |
      | abc    | 10     | Please enter valid numbers   |
      | 5      | xyz    | Please enter valid numbers   |
      | abc    | xyz    | Please enter valid numbers   |