using System;

namespace SpecFlowCalculator
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }


        public int Add()
        {
            return FirstNumber + SecondNumber;
        }

        public int Sub()
        {
            return FirstNumber - SecondNumber;
        }

        public int Multiply()
        {
            return FirstNumber * SecondNumber;
        }

        public int Divide()
        {
            if (SecondNumber == 0)
            {
                throw new ArgumentException("You can't divide by zero.");
            }
            return FirstNumber / SecondNumber;
        }
    }
}
