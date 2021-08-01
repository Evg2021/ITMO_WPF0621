using System.Reflection;
using System;

namespace WPFCalculator
{
	public class CalcEngine
	{
		//
		// Operation Constants.
		//
		public enum Operator:int
		{
			eUnknown = 0,
			eAdd = 1,
			eSubtract = 2,
			eMultiply = 3,
			eDivide = 4,
			ePow = 5
		}

		//
		// Module-Level Constants
		//

		private static double negativeConverter = -1;
		
		private static string versionInfo = "Калькулятор Савкова 2021";

		//
		// Module-level Variables.
		//
	
		private static double numericAnswer;
		private static string stringAnswer;
		private static Operator calcOperation;
		private static double firstNumber;
		private static double secondNumber;
		private static bool secondNumberAdded;
		private static bool decimalAdded;
 
		//
		// Class Constructor.
		//

		public CalcEngine ()
		{
			decimalAdded = false;
			secondNumberAdded = false;
		}

		//
		// Returns the custom version string to the caller.
		//

		public static string GetVersion ()
		{
			return versionInfo;
		}
		//
		// Called when the Date key is pressed.
		//

		public static string GetDate ()
		{
            DateTime curDate = DateTime.Now;

			stringAnswer = string.Concat (curDate.ToShortDateString(), " ", curDate.ToLongTimeString());

			return stringAnswer;
		}

		//
		// Called when a number key is pressed on the keypad.
		//

		public static string CalcNumber (string KeyNumber)
		{
			stringAnswer += KeyNumber;
			return stringAnswer;
		}

		//
		// Called when an operator is selected (+, -, *, /)
		//

		public static void CalcOperation (Operator calcOper)
		{
			if (stringAnswer != "" && !secondNumberAdded)
			{
                firstNumber = Convert.ToDouble(stringAnswer);
				calcOperation = calcOper;
				stringAnswer = "";
				decimalAdded = false;
			}			
		}

		//
		// Called when the +/- key is pressed.
		//

		public static string CalcSign ()
		{
			double numHold;

			if (stringAnswer != "")
			{
				numHold = Convert.ToDouble (stringAnswer);
				stringAnswer = Convert.ToString(numHold * negativeConverter);
			}
		
			return stringAnswer;
		}

		//
		// Called when the . key is pressed.
		//

		public static string CalcDecimal ()
		{
			if (!decimalAdded && !secondNumberAdded)
			{
				if (stringAnswer != "")
					stringAnswer = stringAnswer + ".";
				else
					stringAnswer = "0.";

				decimalAdded = true;
			}

			return stringAnswer;
        }
		//
		// Called when Sqrt is pressed.
		//
		public static string CalcSqrt()
		{
			double numHold;

			if (stringAnswer != "")
			{
				numHold = Convert.ToDouble(stringAnswer);
                stringAnswer = Convert.ToString(Math.Sqrt(numHold));
			}

			return stringAnswer;
		}
		//
		// Called when 1/x is pressed.
		//
		public static string CalcReverseValue()
		{
			double numHold;

			if (stringAnswer != "")
			{
				numHold = Convert.ToDouble(stringAnswer);
				stringAnswer = Convert.ToString(1/numHold);
			}

			return stringAnswer;
		}
		//
		// Called when x^2 is pressed.
		//
		public static string CalcSquare()
		{
			double numHold;

			if (stringAnswer != "")
			{
				numHold = Convert.ToDouble(stringAnswer);
				stringAnswer = Convert.ToString(numHold*numHold);
			}

			return stringAnswer;
		}
		//
		// Called when n! is pressed.
		//
		public static string CalcFactorial()
		{
			int numHold;
			if (stringAnswer != "" && !decimalAdded)
			{
				numHold = Convert.ToInt32(stringAnswer);
				if (numHold > 0)
				{
					try
					{
						int numFactorial = 1;
						checked
						{
							for (int i = 1; i <= numHold; i++)
							{
								numFactorial *= i;
							}
						}
						stringAnswer = Convert.ToString(numFactorial);
					}
					catch (OverflowException)
					{
						stringAnswer = "ERROR (BIG VALUE)";
					}
				}
				else if (numHold == 0)
				{
					stringAnswer = "1";
				}
				else
				{
					stringAnswer = "ERROR";
				}
				return stringAnswer;
			}
			else
			{
				stringAnswer = "ERROR";
            }
			return stringAnswer;
        }
		//
		// Called when Cubic is pressed.
		//
		public static string CalcCubic()
		{
			double numHold;

			if (stringAnswer != "")
			{
				numHold = Convert.ToDouble(stringAnswer);
				stringAnswer = Convert.ToString(Math.Pow(numHold, 1 / 3f));
			}

			return stringAnswer;
		}

		public static string CalcQuad(double A, double B, double C)
		{
			string Result;
			double D = Math.Pow(B, 2) - (4 * A * C);
			if( D == 0)
            {
                double x = (-1 * B) / (2 * A);
                Result = Convert.ToString(Math.Round(x, 2));
			}
			else if (D > 0)
            {
				double x1 = (-1 * B + Math.Sqrt(D)) / (2 * A);
				double x2 = (-1 * B - Math.Sqrt(D)) / (2 * A);
				Result = Convert.ToString(Math.Round(x1, 2)) +';'+ Convert.ToString(Math.Round(x2, 2));
			}
			else
            {
				Result = "н/д";
            }
			return Result;
		}


		//
		// Called when = is pressed.
		//

		public static string CalcEqual ()
		{
            if (stringAnswer != "")
            {
                secondNumber = Convert.ToDouble(stringAnswer);
                secondNumberAdded = true;

                bool validEquation;
                switch (calcOperation)
                {
                    case Operator.eUnknown:
                        validEquation = false;
                        break;

                    case Operator.eAdd:
                        numericAnswer = firstNumber + secondNumber;
                        validEquation = true;
                        break;

                    case Operator.eSubtract:
                        numericAnswer = firstNumber - secondNumber;
                        validEquation = true;
                        break;

                    case Operator.eMultiply:
                        numericAnswer = firstNumber * secondNumber;
                        validEquation = true;
                        break;

                    case Operator.eDivide:
                        numericAnswer = firstNumber / secondNumber;
                        validEquation = true;
                        break;
					case Operator.ePow:
						numericAnswer = 1;
						for (int i = 0; i < secondNumber; i++)
                        {
                            numericAnswer *= firstNumber;
                        }
                        validEquation = true;
						break;
					
					default:
                        validEquation = false;
                        break;
                }

                if (validEquation)
                    stringAnswer = Convert.ToString(numericAnswer);
            }

            return stringAnswer;
		}

		//
		// Resets the various module-level variables for the next calculation.
		//

		public static void CalcReset ()
		{
			numericAnswer = 0;
			firstNumber = 0;
			secondNumber = 0;
			stringAnswer = "";
			calcOperation = Operator.eUnknown;
			decimalAdded = false;
            secondNumberAdded = false;
        }
	}
}