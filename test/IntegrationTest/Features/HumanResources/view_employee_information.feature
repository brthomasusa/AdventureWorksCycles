@employee @view_information
Feature: View employee information

  Scenario: It just works.
    Given the HR user is on the application start page
    When the HR user selects 'Workers'
      And then selects any employee on the Employee List page
    Then the HR user sees the 'Employee Details' page for that employee