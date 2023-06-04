@company @update-information
Feature: Update company information
  Background:
    Given the 'Company details page' is displayed 
      And the HR user selects 'Edit Company Information'
    When the HR user sees the 'Edit Company Information page'


  Scenario: Required info is entered and info entered is valid
      And enters a company name between 1 and 50 characters
      And enters a legal name
      And enters an employer identification number 
      And enters company website url
      And enters a mail address line 1
      And optionally enters a mail address line 2
      And enters a mail city
      And enters a mail state province code
      And enters a mail postal code
      And enters a delivery address line 1
      And optionally enters a delivery address line 2
      And enters a delivery city
      And enters a delivery state province code
      And enters a delivery postal code between 1 and 15 characters
      And enters a telephone number between 1 and 25 characters
      And enters a fax number between 1 and 25 characters
    When the HR user tells the system to save the information
    Then the HR user sees a message indicating that the information was successfully saved

  Scenario: Missing company name.
      And doesn't enters a company name
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid company name.
      And enters a company name greater than 50 characters
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid legal name.
      And enters a legal name greater than 50 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing employer identification number (EIN).
      And doesn't enters an EIN
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid employer identification number (EIN).
      And enters an EIN not formatted as 7 digits, a dash (-), followed by 2 digits (example: 1234567-89)
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Mal-formed company website url.
      And enters a mal-formed url
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid company website url.
      And enters a url greater than 50 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing mail address line1.
      And doesn't enters a mail address line1
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid mail address line1.
      And enters a mail address line1 greater than 60 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown. 

  Scenario: Invalid mail address line2.
      And enters a mail address line2 greater than 60 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing mail city.
      And doesn't enters a mail city
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid mail city.
      And enters a mail city greater than 30 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown. 

  Scenario: Missing mail state province code.
      And doesn't enters a mail state province code
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing mail postal code.
      And doesn't enters a mail postal code
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid mail postal code.
      And enters a mail postal code greater than 15 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing delivery address line1.
      And doesn't enters a delivery address line1
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid delivery address line1.
      And enters a delivery address line1 greater than 60 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown. 

  Scenario: Invalid delivery address line2.
      And enters a delivery address line2 greater than 60 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing mail city.
      And doesn't enters a mail city
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid delivery city.
      And enters a delivery city greater than 30 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown. 

  Scenario: Missing delivery state province code.
      And doesn't enters a delivery state province code
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Missing delivery postal code.
      And doesn't enters a delivery postal code
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid delivery postal code.
      And enters a delivery postal code greater than 15 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown. 

  Scenario: Missing telephone number.
      And doesn't enters a telephone number
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.

  Scenario: Invalid fax number.
      And enters a fax number greater than 25 characters
    When the HR user tells the system to save the information
    Then An error message detailing the errors and indicating that the information was not saved is shown.                                               