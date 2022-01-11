using FluentAssertions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        private readonly Calculator _calculator = new();

        private int _result;

        private Queue<int> _operands = new();

        private Queue<char> _operators = new();

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _calculator.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculator.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _result.Should().Be(result);
        }

        [Then("the user is presented with an error message")]
        public void ThenTheUserIsPresentedWithAnErrorMessage()
        {
            var exception = _scenarioContext.Get<Exception>("Error");
            exception.Should().NotBeNull();
        }

        [When("the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            _result = _calculator.Multiply();
        }

        [When("the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            try
            {
                _result = _calculator.Divide();
            }
            catch(ArgumentException e)
            {
                _scenarioContext.Add("Error", e);
            }            
        }

        [Given("the calculation (.*)")]
        public void GivenTheCalculation(string calculation)
        {            
            char[] characters = calculation.ToCharArray();
            string currentOperand = "";
            string digits = "0123456789";

            foreach(char character in characters)
            {
                if(digits.Contains(character))
                {
                    currentOperand += character;
                }
                else
                {
                    switch(character)
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            _operands.Enqueue(int.Parse(currentOperand));
                            currentOperand = "";
                            _operators.Enqueue(character);
                            break;                            
                    }
                }
            }
            _operands.Enqueue(int.Parse(currentOperand));
        }

        [When("the calculation is solved")]
        public void WhenTheCalculationIsSolved()
        {
            _result = _operands.Dequeue();

            while (_operators.Count > 0)
            {
                _calculator.FirstNumber = _result;
                _calculator.SecondNumber = _operands.Dequeue();

                switch (_operators.Dequeue())
                {
                    case '+':
                        _result = _calculator.Add();
                        break;
                    case '-':
                        _result = _calculator.Sub();
                        break;
                    case '*':
                        _result = _calculator.Multiply();
                        break;
                    case '/':
                        _result = _calculator.Divide();
                        break;
                }
            }
        }
    }
}
