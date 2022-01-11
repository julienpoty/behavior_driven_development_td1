Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowCalculator.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@sum
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@multiplication
Scenario: Multiply two numbers
	Given the first number is 3
	And the second number is 5
	When the two numbers are multiplied
	Then the result should be 15

@division
Scenario: Divide two numbers
	Given the first number is 10
	And the second number is 2
	When the two numbers are divided
	Then the result should be 5

@divisionByZero
Scenario: Divide by zero
	Given the first number is 10
	And the second number is 0
	When the two numbers are divided
	Then the user is presented with an error message

@calculation
Scenario Outline: Calculation
	Given the calculation <calculation>
	When the calculation is solved
	Then the result should be <result>

Examples: 
| calculation     | result |
| 10 + 10 * 5 / 2 | 50     |
| 40 - 10 * 2 -3  | 57     |
	