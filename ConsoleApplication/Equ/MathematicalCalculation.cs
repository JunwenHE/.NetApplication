using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equ
{
    /* This class is used to calculate the constant numbers based on the mathematics  expression rules. 
     * Split the numbers and operators into two different arrayList and calculate by the index of operators list,
     * For example: num > ops > num can be convert to:
     *                                           num num
     *                                           ops
     * That means the ops can deal with the two numbers in the operator list.
     */
    class MathematicalCalculation
    {
        public ArrayList Calculation(string userInput)
        {
            ArrayList numberList = FindNumber(userInput);
            ArrayList operatorList = FindOperator(userInput);

            //Based on the rule of mathematical expression, calculate * and / first, then sum and subtract the constants.
            for (int operatorLoopIndex = 0; operatorLoopIndex < operatorList.Count; operatorLoopIndex++)
            {
                if (operatorList[operatorLoopIndex].ToString().Contains('*') || operatorList[operatorLoopIndex].ToString().Contains('/'))
                {
                    //Remove the operator from the operator list once stored into string variable.
                    string operatorSymbol = operatorList[operatorLoopIndex].ToString();
                    operatorList.RemoveAt(operatorLoopIndex);

                    if (operatorSymbol.Equals("*"))
                    {
                        //Collect the two numbers from number list that related to the operator index and, once again remove then. 
                        int previousNumber = Convert.ToInt32(numberList[operatorLoopIndex]);
                        numberList.RemoveAt(operatorLoopIndex);

                        int nextNumber = Convert.ToInt32(numberList[operatorLoopIndex]);
                        numberList.RemoveAt(operatorLoopIndex);

                        //The calculated result stored into the number list for further compute until no more operators in the operator list.
                        int multiplyResult = previousNumber * nextNumber;
                        numberList.Insert(operatorLoopIndex, multiplyResult);
                    }

                    if (operatorSymbol.Equals("/"))
                    {
                        int previousNumber = Convert.ToInt32(numberList[operatorLoopIndex]);
                        numberList.RemoveAt(operatorLoopIndex);

                        int nextNumber = Convert.ToInt32(numberList[operatorLoopIndex]);
                        numberList.RemoveAt(operatorLoopIndex);

                        //Make the exception handling to avoid the calcualtation error from the system.
                        try
                        {
                            int divisionResult = previousNumber / nextNumber;
                            numberList.Insert(operatorLoopIndex, divisionResult);
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Error: divisied by zero");
                            break;
                        }
                    }

                    //Since the elements of the number list are removed twice, than insear new one. 
                    //So the index should decremenent for catch next element while i++;
                    operatorLoopIndex--;
                }

            }

            for (int operatorLoopIndex = 0; operatorLoopIndex < operatorList.Count; operatorLoopIndex++)
            {
                if (operatorList[operatorLoopIndex].ToString().Contains('+') || operatorList[operatorLoopIndex].ToString().Contains('-'))
                {
                    string operatorSymbol = operatorList[operatorLoopIndex].ToString();
                    operatorList.RemoveAt(operatorLoopIndex);

                    if (operatorSymbol.Equals("+"))
                    {
                        int previousNumber = Convert.ToInt32(numberList[operatorLoopIndex]);
                        numberList.RemoveAt(operatorLoopIndex);

                        int nextNumber = Convert.ToInt32(numberList[operatorLoopIndex]);
                        numberList.RemoveAt(operatorLoopIndex);

                        int sumResult = previousNumber + nextNumber;
                        numberList.Insert(operatorLoopIndex, sumResult);
                    }

                    if (operatorSymbol.Equals("-"))
                    {
                        int previousNumber = Convert.ToInt32(numberList[operatorLoopIndex]);
                        numberList.RemoveAt(operatorLoopIndex);

                        int nextNumber = Convert.ToInt32(numberList[operatorLoopIndex]);
                        numberList.RemoveAt(operatorLoopIndex);

                        int differenceResult = previousNumber - nextNumber;
                        numberList.Insert(operatorLoopIndex, differenceResult);
                    }

                    operatorLoopIndex--;
                }
            }

            return numberList;
        }

        //Generate the number list by splitting from operators, and restored the negative symbol from $ to insert negative number.
        public ArrayList FindNumber(string userInput)
        {
            userInput = DetectNegativeSymbol(userInput);
            ArrayList digitList = new ArrayList();
            string[] operatorSplitList = userInput.Split('+', '*', '/', '-');

            for (int IndexOfSplitList = 0; IndexOfSplitList < operatorSplitList.Length; IndexOfSplitList++)
            {
                string singleNumber = operatorSplitList[IndexOfSplitList];

                if (singleNumber.Contains("$"))
                {
                    singleNumber = '-' + singleNumber.Substring(1);
                }

                digitList.Add(singleNumber);
            }

            return digitList;
        }

        //Generate the operator list by splitting  from numbers and $.
        public ArrayList FindOperator(string userInput)
        {
            userInput = DetectNegativeSymbol(userInput);
            ArrayList symbolList = new ArrayList();

            string[] numberSplitList = userInput.Split('1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '$');

            for (int IndexOfSplitList = 0; IndexOfSplitList < numberSplitList.Length; IndexOfSplitList++)
            {
                if (numberSplitList[IndexOfSplitList].Contains("+") || numberSplitList[IndexOfSplitList].Contains("-") || numberSplitList[IndexOfSplitList].Contains("*") || numberSplitList[IndexOfSplitList].Contains("/"))
                {
                    symbolList.Add(numberSplitList[IndexOfSplitList]);
                }
            }

            return symbolList;
        }

        /*Find out the first operator is minus which represents the negative number.
         *Also, find out other minus symbols from other elements to avoid the conflicts with other operators.
         * Using $ to replace and prepare for previous methods of generating number list and operator list.
         */
        public string DetectNegativeSymbol(string userInput)
        {
            char[] characterList = userInput.ToCharArray();

            for (int characterListIndex = 0; characterListIndex < characterList.Length; characterListIndex++)
            {
                if (characterListIndex == 0 && characterList[characterListIndex] == '-')
                {
                    userInput = '$' + userInput.Substring(characterListIndex + 1);
                }

                if (characterList[characterListIndex] == '*' && characterList[characterListIndex + 1] == '-' || characterList[characterListIndex] == '/' && characterList[characterListIndex + 1] == '-')
                {
                    userInput = userInput.Substring(0, characterListIndex + 1) + '$' + userInput.Substring(characterListIndex + 2);
                }
            }

            return userInput;
        }
    }
}
