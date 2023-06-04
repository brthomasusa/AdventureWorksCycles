@employee @view_list
Feature: View employee list

  Scenario: It just works.
    Given the HR user is on the application start page
     When the HR user selects 'Workers'
     Then the HR user sees the 'Employee List' page