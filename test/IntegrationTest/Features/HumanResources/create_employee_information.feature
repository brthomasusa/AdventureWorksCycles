@employee @create-information
Feature: Collect new employee details
  Background:
    Given the HR user is on the application start page 
      And the HR user selects 'Workers'
      And sees the Employee List page
      And selects 'Create new Employee'
    When the HR user sees the 'Create New Employee page'

    Scenario: Required info is entered and info entered is valid 
      And selects a name style and the name style is of type: 
      | name style | 
      | Western    | 
      | Eastern    | 
      And enters the employee title 
      And enters the employee first name 
      And enters the employee middle name 
      And enters the employee last name 
      And enters the employee suffix 
      And enters a national identification number 
      And enters a login id 
      And enters a job title 
      And enters a valid phone number for the employee 
      And selects a phone number type and the phone number type is of type: 
      | Phone number type | 
      | cell | 
      | home | 
      | work | 
      And enters a valid email address for the employee 
      And selects an email promotion preference and the email promotion preference is of type: 
      | email promotion preference                                                               | 
      | Contact does not wish to receive e-mail promotions                                       | 
      | Contact does wish to receive e-mail promotions from AdventureWorks                       | 
      | Contact does wish to receive e-mail promotions from AdventureWorks and selected partners | 
      And enters a first address line of between 1 and 60 characters 
      And enters a second address line of between 0 and 60 characters 
      And enters a city of between 1 and 30 characters 
      And selects a state name 
      And enters a postal code 
      And selects a country name     
      And enters a birth date  
      And enters a marital status code     
      And enters a gender status code 
      And enters a hire date 
      And enters a salaried flag 
      And enters zero for the employee's accumulated vacation hours 
      And enters zero for the employee's accumulated sick leave hours 
      And selects an employment status 
      And selects the employee's department  
      And selects the employee's manager 
      And enters the employee's salary 
    When the HR user tells the system to save the information 
    Then the HR user sees a message indicating that the information was successfully saved 

    Scenario: name style not selected 
      And does not select a name style 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved 

    Scenario: title has too many characters 
      And enters an employee title greater than 8 characters 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved

    Scenario: first name not entered 
      And does not enter a first name 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved   

    Scenario: Invalid first name entered 
      And enters an employee first name greater than 30 characters 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved 

    Scenario: Invalid middle name entered 
      And enters an employee middle name greater than 30 characters 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved

    Scenario: last name not entered 
      And does not enter a last name 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved   

    Scenario: Invalid last name entered 
      And enters an employee last name greater than 30 characters 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved

    Scenario: Invalid suffix entered 
      And enters a suffix greater than 10 characters 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved 

    Scenario: national identification number not entered 
      And does not enter a national identification number 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved   

    Scenario: Invalid national identification number entered 
      And enters an employee national identification number greater than 15 characters 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved 

    Scenario: login id not entered 
      And does not enter a login id 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved   

    Scenario: Invalid login id entered 
      And enters an employee login id greater than 256 characters 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved   

    Scenario: job title not entered 
      And does not enter a job title 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved   

    Scenario: Invalid job title entered 
      And enters an employee job title greater than 50 characters 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved

    Scenario: telephone number not entered 
      And does not enter a telephone number 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved   

    Scenario: Invalid telephone number entered 
      And enters an employee telephone number greater than 24 characters 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved  

    Scenario: telephone number type not selected 
      And does not select a telephone number type 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved

    Scenario: email address not entered 
      And does not enter an email address 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved   

    Scenario: mal-formed email address entered 
      And enters a mal-formed email address 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved

    Scenario: Invalid email address entered 
      And enters an email address greater than 50 characters 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved

    Scenario: email promotion preference not selected 
      And does not select an email promotion preference 
    When the HR user tells the system to save the information 
    Then the HR user sees an error message that details the errors and indicates that the information was not saved 

    Scenario: Missing address line1.
      And doesn't enters an address line1
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

    Scenario: Invalid address line1.
      And enters an address line1 greater than 60 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown. 

  Scenario: Invalid address line2.
      And enters a address line2 greater than 60 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing city.
      And doesn't enters a city
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid city.
      And enters a city greater than 30 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown. 

  Scenario: Missing state province code.
      And does not select a state province code
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing postal code.
      And doesn't enters a postal code
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid postal code.
      And enters a postal code greater than 15 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing country name
      And does not select a country name
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing birth date
      And does not select a birth date
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: birth date less than 1930-01-01 or greater than today minus 18 years
      And enters a birth date less than 1930-01-01 or greater than today minus 18 years
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing gender status (Male/Female)
      And does not select a gender status
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing marital status (Married/Single)
      And does not select a marital status
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing hire date
      And does not select a hire date
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: hire date less than 1996-07-01 or greater than today
      And enters a birth date less than 1996-07-01 or greater than today
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing pay status (Salaried/Hourly)
      And does not select a pay status
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid accumulated vacation hours
      And enter accumulated vacation hours greater then 240
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid accumulated sick leave hours
      And enter accumulated sick leave hours greater then 120
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.
    
  Scenario: Missing employment status (active/inactive)
      And does not select a gender status
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing department assignment
      And does not select a department
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing manager name
      And does not select a manager
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.
 
  Scenario: salary too low
      And enter salary less than $6.50/hour
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: salary too high
      And enter salary greater than $40.00/hour
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.                                                 