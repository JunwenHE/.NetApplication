using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equ
{
    /* This part is used to find out the unknown variable value by the following format:
     *                              aX+b=c
     * Where a,b are constant numbers from the user input and a is not equal 0 and default is 1, c is result 
     * of constant calculation of right hand side. Thus the X can be calculated  by following:
     *                            X = (b-c)/a
     * So, the CalculateX is to detected  the operators symbol and convert the adverse arithmetics.
     * Like + convert to - in the right hand side, or * convert to / in the right hand side.
     * Then the right hand side can generate the traditional mathematic  expression and calculated by previous functions.
     * Therefore, the X can have solution from previous processes.
     */
    public interface IEquation
    {
        int FindResultInEquation(ArrayList xUnsolvedList, ArrayList constantResultList);
    }

    public class CalculateX : IEquation
    {
        public int FindResultInEquation(ArrayList xUnsolvedList, ArrayList constantResultList)
        {
            MathematicalCalculation mathCal = new MathematicalCalculation();
            int constantNumber = 1;
            int resultX = new int();

            //Detected the constant number that is next to X and would contain negative number.
            bool hasMinusSymbol = false;

            //Generate a new constants mathmatics equation without X and convert appropriate arthmetics from the left hand side.
            //Also, remove the elements once finished the convertion.
            for (int indexOfxUnsolvedList = 0; indexOfxUnsolvedList < xUnsolvedList.Count; indexOfxUnsolvedList++)
            {
                int constantValueNearToX;
                string indexValue = xUnsolvedList[indexOfxUnsolvedList].ToString();

                for (int nextIndexOfxUnsolvedList = indexOfxUnsolvedList + 1; nextIndexOfxUnsolvedList < xUnsolvedList.Count; nextIndexOfxUnsolvedList++)
                {
                    string nextNlementValue = xUnsolvedList[nextIndexOfxUnsolvedList].ToString().ToLower();

                    if (indexValue.Contains('+') || indexValue.Contains('-'))
                    {
                        if (indexValue.Equals("+") && !nextNlementValue.Contains('x'))
                        {
                            constantResultList.Add('-');
                            xUnsolvedList.RemoveAt(indexOfxUnsolvedList);
                        }

                        if (indexValue.Equals("-") && !nextNlementValue.Contains('x'))
                        {
                            constantResultList.Add('+');
                            xUnsolvedList.RemoveAt(indexOfxUnsolvedList);
                        }
                    }


                    if (indexValue.Contains('*') || indexValue.Contains('/'))
                    {
                        if (indexValue.Equals("*"))
                        {
                            constantResultList.Add('/');
                            xUnsolvedList.RemoveAt(indexOfxUnsolvedList);
                        }

                        if (indexValue.Equals("/"))
                        {
                            constantResultList.Add('*');
                            xUnsolvedList.RemoveAt(indexOfxUnsolvedList);
                        }

                    }

                    //If the left hand side constant number is positive and is the first element,
                    //then move to the right hand side with minus.
                    if (int.TryParse(xUnsolvedList[indexOfxUnsolvedList].ToString(), out constantValueNearToX))
                    {
                        if (xUnsolvedList.IndexOf(indexValue) == 0)
                        {
                            constantResultList.Add('-');
                        }

                        constantResultList.Add(constantValueNearToX);
                        xUnsolvedList.RemoveAt(indexOfxUnsolvedList);
                    }
                }
            }

            //Find out the constant number a where close the X by substring method and assume the minus represents the negative value of constant.
            for (int indexOfxUnsolvedList = 0; indexOfxUnsolvedList < xUnsolvedList.Count; indexOfxUnsolvedList++)
            {
                string indexValue = xUnsolvedList[indexOfxUnsolvedList].ToString().ToLower();

                if (indexValue.Contains('-'))
                {
                    hasMinusSymbol = true;
                }

                if (indexValue.Contains("x") && xUnsolvedList[indexOfxUnsolvedList].ToString().Length > 1)
                {
                    int xElementValue = xUnsolvedList[indexOfxUnsolvedList].ToString().ToLower().IndexOf("x");
                    string constantValue = xUnsolvedList[indexOfxUnsolvedList].ToString().Substring(0, xElementValue);
                    constantNumber = Convert.ToInt32(constantValue);
                }
            }

            if (hasMinusSymbol == true)
            {
                constantNumber = constantNumber * -1;
            }

            string finalConstantResult = string.Join("", constantResultList.ToArray());
            ArrayList finalConstantResultList = mathCal.Calculation(finalConstantResult);

            //Handle the error if the result is out of range or invalid input.
            try
            {
                int finalConstantValue = Convert.ToInt32(finalConstantResultList[0]);
                resultX = finalConstantValue / constantNumber;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: invalid input");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: out of integer range");
            }

            return resultX;
        }
    }
}