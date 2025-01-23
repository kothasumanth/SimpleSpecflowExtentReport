Feature: SampleFeature
  This is a sample feature to test the ExtentReport functionality.

  Scenario: SampleScenario
    Given I have initialized the ExtentReport
    When I create a feature named "Sample Feature"
    And I create a scenario named "Sample Scenario"
    And I create a step named "Sample Step"
    And I log step info "This is a sample step info"
    Then the report should be generated successfully

     Scenario: SampleScenario1
    Given I have initialized the ExtentReport
    When I create a feature named "Sample Feature"
    And I create a scenario named "Sample Scenario"
    And I create a step named "Sample Step"
    And I log step info "This is a sample step info"
    Then the report should be generated successfully