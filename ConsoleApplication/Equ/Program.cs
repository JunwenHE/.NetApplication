using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Subject: 32998 .NET Applications Development
 * Student name: Junwen HE
 * Student ID: 12207080
 * The purpose fo this console application is to calculate the equation the has unknown variable X 
 * by the assusmion of the following expression: 
 *                                  aX+b=c
 * Where a , b , c are constant numbers and a != 0. The X can be calculated in both side of the equation.
 * This program contains servial files that based on the code splitting:
 * Program.cs is the main file that start to implement the quation solver process.
 * MathematicalCalculation.cs is the code of constant numbers calculation by mathematics rules.
 * IEquation.cs is the code to solve the quation that contains the unknown variable.
 */
namespace Equ
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = string.Join("", args);
            InputChecking(userInput,args);
            //Console.ReadKey();
        }

        //Check the input contains X and = or not, before implement into calculation process.
        public static void InputChecking(string userInput, string[] args)
        {
            if(!userInput.ToLower().Contains("x") || !userInput.Contains("="))
            {
                string errorMessage = (!userInput.ToLower().Contains("x") ? "Error: missing X or x" : "Error missing '='");
                Console.WriteLine(errorMessage);
            }
            else
            {
                EquationPrecessing(userInput, args);
            }
        }

        /* Split the equation into two parts based on the equal operator, 
         * to identify which hand side contains the unknown variable or constant 
         * numbers only. Then implement different calculation process based on the certain content.
         * E.g. if right hand side has unknown variable, then it will deal with X in FindResultInEquation calss,  
         * next left hand side starts the constant calculation in MathmaticalCalculation calss.
         */
        public static void EquationPrecessing(string userInput, string[] args)
        {
            MathematicalCalculation mathCal = new MathematicalCalculation();
            CalculateX calculateX = new CalculateX();
            ArrayList leftList = new ArrayList();
            ArrayList rightList = new ArrayList();
            string leftInput = userInput.Split('=')[0];
            string rightInput = userInput.Split('=')[1];
            int equalIndex = Array.IndexOf(args, "=");

            if (leftInput.ToString().ToLower().Contains('x'))
            {
                ArrayList constantResult = mathCal.Calculation(rightInput);

                //To gain the length of left hand side quation stap at equal operator.
                for (int variableLoopInLeftList = 0; variableLoopInLeftList < equalIndex; variableLoopInLeftList++)
                {
                    leftList.Add(args[variableLoopInLeftList]);
                }

                int xResultFromLeft = calculateX.FindResultInEquation(leftList, constantResult);
                Console.WriteLine("X = " + xResultFromLeft);

            }
            else if (rightInput.ToString().ToLower().Contains('x'))
            {
                ArrayList constantResult = mathCal.Calculation(leftInput);

                //To gain the length of right hand side quation from equal operator.
                int rightElementsLength = args.Length - equalIndex;
                
                //Since the initial index 0 is '=', skip it and gain the whole right hand side equation.
                for (int variableLoopInRightList = 1; variableLoopInRightList < rightElementsLength; variableLoopInRightList++)
                {
                    rightList.Add(args[variableLoopInRightList + equalIndex]);
                }

                int xResultFromRight = calculateX.FindResultInEquation(rightList, constantResult);
                Console.WriteLine("X = " + xResultFromRight);
            }
        }
    }
}