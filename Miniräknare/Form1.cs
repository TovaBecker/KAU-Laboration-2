using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* I have started from getting a calculator that is as similar to the image in the task as possible.
 * Has also assumed that the calculation should be correct. Times and share should go before plus and minus. To cope with this, I have limited myself to 3 digits in a row.
 * The caluculation also needs to be cleard before a new calculation can begin.
 */

namespace Miniräknare
{
    public partial class mainForm : Form
    {
        //Declare and initialize int variables that can be used in all methods
        int resualt = 0;
        int inputValue = 0;
        int savedValue = 0;
        int numberListPosition = 0;

        //Declare and initialize string variabl that can be used in all methods
        string textOutCal = "0";
        string textOutMin = "";

        //Declare and initialize integer array that can be used in all methods for numbers
        int[] numbersList = new int[3];

        //Declare and initialize string array that can be used in all methods for operators
        string[] operatorList = new string[2];


        public mainForm()
        {
            InitializeComponent();

        }

        private void numberClick(object sender, EventArgs e)
        {
            //Check what button that was pressed and assign value too inputValue
            if (sender == btnNr0)
                inputValue = 0;
            if (sender == btnNr1)
                inputValue = 1;
            if (sender == btnNr2)
                inputValue = 2;
            if (sender == btnNr3)
                inputValue = 3;
            if (sender == btnNr4)
                inputValue = 4;
            if (sender == btnNr5)
                inputValue = 5;
            if (sender == btnNr6)
                inputValue = 6;
            if (sender == btnNr7)
                inputValue = 7;
            if (sender == btnNr8)
                inputValue = 8;
            if (sender == btnNr9)
                inputValue = 9;

            //Check integers
            try
            {
                //Check if savedValue is over ingerger max and min
                checked
                {
                    //Set the SavedValue 
                    savedValue = savedValue * 10 + inputValue;
                }

                //Present the number to the user
                calculateTextBox.Text = $"{savedValue}";
            }
            catch (OverflowException)
            {
                //Present an error message and clear the values
                calculateTextBox.Text = "Value Error ";

                //Disabel operators +, - ,* , /, =
                btnAdd.Enabled = false;
                btnSub.Enabled = false;
                btnMulti.Enabled = false;
                btnDivi.Enabled = false;
                btnEqual.Enabled = false;

                //Disabel numemr button
                btnNr0.Enabled = false;
                btnNr1.Enabled = false;
                btnNr2.Enabled = false;
                btnNr3.Enabled = false;
                btnNr4.Enabled = false;
                btnNr5.Enabled = false;
                btnNr6.Enabled = false;
                btnNr7.Enabled = false;
                btnNr8.Enabled = false;
                btnNr9.Enabled = false;
            }

        }

        private void operandClick(object sender, EventArgs e)
        {
            //Save number in list
            numbersList[numberListPosition] = savedValue;

            //Check what button that was clicked
            if (sender == btnAdd)
            {
                if(numbersList[1] == 0)
                { 
                    //Save number in list
                    operatorList[0] = "+";
                }
                else if (numbersList[2] == 0)
                {
                    //Save number in list
                    operatorList[1] = "+";
                }

            }
            else if (sender == btnSub)
            {
                if (numbersList[1] == 0)
                {
                    //Save number in list
                    operatorList[0] = "-";
                }
                else if (numbersList[2] == 0)
                {
                    //Save number in list
                    operatorList[1] = "-";
                }
            }
            else if (sender == btnMulti)
            {
                if (numbersList[1] == 0)
                {
                    //Save number in list
                    operatorList[0] = "*";
                }
                else if (numbersList[2] == 0)
                {
                    //Save number in list
                    operatorList[1] = "*";
                }
            }
            else if (sender == btnDivi)
            {
                if (numbersList[1] == 0)
                {
                    //Save number in list
                    operatorList[0] = "/";
                }
                else if (numbersList[2] == 0)
                {
                    //Save number in list
                    operatorList[1] = "/";
                }
            }

            try
            {

                switch (operatorList[0])
                {
                    case "+":


                        if (operatorList[1] == null)
                        {
                            //Resualt when there is only one value
                            resualt = numbersList[0];

                            //Present resualt in minnelable and clear calculator textbox
                            textOutMin = $"{resualt}{operatorList[0]}";
                            textOutCal = "0";
                        }
                        else
                        {
                            checked
                            {
                                //Resualt when there is two values with + between them
                                resualt = numbersList[0] + numbersList[1];
                            }

                            //Present resualt in minnelable and clear calculator textbox
                            textOutMin = $"{resualt}{operatorList[1]}";
                            textOutCal = "0";

                        }

                        //Present resualt/error to user
                        minneLabel.Text = $"{textOutMin}";
                        calculateTextBox.Text = $"{textOutCal}";
                        break;

                    case "-":
                        if (operatorList[1] == null)
                        {
                            //Resualt when there is only one value
                            resualt = numbersList[0];

                            //Present resualt in minnelable and clear calculator textbox
                            textOutMin = $"{resualt}{operatorList[0]}";
                            textOutCal = "0";
                        }
                        else
                        {
                            checked
                            {
                                //Resualt when there is two values with - between them
                                resualt = numbersList[0] - numbersList[1];
                            }

                            //Present resualt in minnelable and clear calculator textbox
                            textOutMin = $"{resualt}{operatorList[1]}";
                            textOutCal = "0";

                            
                        }

                        //Present resualt/error to user
                        minneLabel.Text = $"{textOutMin}";
                        calculateTextBox.Text = $"{textOutCal}";
                        break;

                    case "*":
                        if (operatorList[1] == null)
                        {
                            //Resualt when there is only one value
                            resualt = numbersList[0];

                            //Present resualt in minnelable and clear calculator textbox
                            textOutMin = $"{resualt}{operatorList[0]}";
                            textOutCal = "0";
                        }
                        else
                        {
                            checked
                            {
                                //Resualt when there is two values with * between them
                                resualt = numbersList[0] * numbersList[1];
                            }

                            //Present resualt in minnelable and clear calculator textbox
                            textOutMin = $"{resualt}{operatorList[1]}";
                            textOutCal = "0";

                        }

                        //Present resualt/error to user
                        minneLabel.Text = $"{textOutMin}";
                        calculateTextBox.Text = $"{textOutCal}";
                        break;

                    case "/":
                        if (operatorList[1] == null)
                        {
                            //Resualt when there is only one value
                            resualt = numbersList[0];

                            //Present resualt in minnelable and clear calculator textbox
                            textOutMin = $"{resualt}{operatorList[0]}";
                            textOutCal = "0";
                        }
                        else
                        {

                            if (numbersList[1] == 0)
                            {
                                //Present error message and clear minnelable
                                textOutMin = "";
                                textOutCal = "DIV/ZERO!";

                                //Disabel operators +, - ,* , /, =
                                btnAdd.Enabled = false;
                                btnSub.Enabled = false;
                                btnMulti.Enabled = false;
                                btnDivi.Enabled = false;
                                btnEqual.Enabled = false;

                                //Disabel numemr button
                                btnNr0.Enabled = false;
                                btnNr1.Enabled = false;
                                btnNr2.Enabled = false;
                                btnNr3.Enabled = false;
                                btnNr4.Enabled = false;
                                btnNr5.Enabled = false;
                                btnNr6.Enabled = false;
                                btnNr7.Enabled = false;
                                btnNr8.Enabled = false;
                                btnNr9.Enabled = false;
                            }
                            else
                            {
                                checked
                                {
                                    //Resualt when there is two values with / between them
                                    resualt = numbersList[0] / numbersList[1];
                                }

                                //Present resualt in minnelable and clear calculator textbox
                                textOutMin = $"{resualt}{operatorList[1]}";
                                textOutCal = "0";
                                
                            }
                        }

                        //Present resualt/error to user
                        minneLabel.Text = $"{textOutMin}";
                        calculateTextBox.Text = $"{textOutCal}";
                        break;

                }
                
                if (operatorList[1] != null)
                {
                    //NumberListPosition for next number
                    numberListPosition = 2;
                }
                else
                {
                    //NumberListPosition for next number
                    numberListPosition = 1;
                }
                
                //clear saved values for next input
                savedValue = 0;
                inputValue = 0;


            }
            catch (OverflowException)
            {
                //Present an error message and clear the values
                calculateTextBox.Text = "Value Error";
                minneLabel.Text = "";

                //Disabel operators +, - ,* , /, =
                btnAdd.Enabled = false;
                btnSub.Enabled = false;
                btnMulti.Enabled = false;
                btnDivi.Enabled = false;
                btnEqual.Enabled = false;

                //Disabel numemr button
                btnNr0.Enabled = false;
                btnNr1.Enabled = false;
                btnNr2.Enabled = false;
                btnNr3.Enabled = false;
                btnNr4.Enabled = false;
                btnNr5.Enabled = false;
                btnNr6.Enabled = false;
                btnNr7.Enabled = false;
                btnNr8.Enabled = false;
                btnNr9.Enabled = false;
            }

        }
        private void btnCClick(object sender, EventArgs e)
        {
            //Clear the calculator
            inputValue = 0;
            savedValue = 0;
            resualt = 0;
            numberListPosition = 0;
            calculateTextBox.Text = "0";
            minneLabel.Text = "";

            //Clear integer array 
            numbersList[0] = 0;
            numbersList[1] = 0;
            numbersList[2] = 0;

            //Clear string array 
            operatorList[0] = null;
            operatorList[1] = null;

            //Enable operators +, - ,* , /, =
            btnAdd.Enabled = true;
            btnSub.Enabled = true;
            btnMulti.Enabled = true;
            btnDivi.Enabled = true;
            btnEqual.Enabled = true;


            //Enable numemr button
            btnNr0.Enabled = true;
            btnNr1.Enabled = true;
            btnNr2.Enabled = true;
            btnNr3.Enabled = true;
            btnNr4.Enabled = true;
            btnNr5.Enabled = true;
            btnNr6.Enabled = true;
            btnNr7.Enabled = true;
            btnNr8.Enabled = true;
            btnNr9.Enabled = true;
        }

        private void equalClick(object sender, EventArgs e)
        {
            //Save number in list
            numbersList[numberListPosition] = savedValue;

            try
            {
                switch (operatorList[0])
                {
                    case "+":


                        switch (operatorList[1])
                        {
                            case "+":


                                checked
                                {
                                    //Calculate the resualt when there is two values with + and + between them
                                    resualt = numbersList[0] + numbersList[1] + numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "-":


                                checked
                                {
                                    //Calculate the resualt when there is two values with + and - between them
                                    resualt = numbersList[0] + numbersList[1] - numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "*":


                                checked
                                {
                                    //Calculate the resualt when there is two values with + and * between them
                                    resualt = numbersList[0] + numbersList[1] * numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "/":


                                if (numbersList[2] == 0)
                                {
                                    //Present error message and clear minnelable
                                    textOutMin = "";
                                    textOutCal = "DIV/ZERO!";
                                }
                                else
                                {
                                    checked
                                    {
                                        //Resualt when there is two values with + and / between them
                                        resualt = numbersList[0] + numbersList[1] / numbersList[2];
                                    }
                                    //Present resualt in calculator textbox and clear minnelable
                                    textOutMin = "";
                                    textOutCal = $"{resualt}";
                                }
                                break;

                            default:
                                checked
                                {
                                    //Calculate the resualt when there is one values with + between them
                                    resualt = numbersList[0] + numbersList[1];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                        }
                        break;


                    case "-":


                        switch (operatorList[1])
                        {
                            case "+":
                                checked
                                {
                                    //Calculate the resualt when there is two values with - and + between them
                                    resualt = numbersList[0] - numbersList[1] + numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "-":
                                checked
                                {
                                    //Calculate the resualt when there is two values with - and - between them
                                    resualt = numbersList[0] - numbersList[1] - numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "*":
                                checked
                                {
                                    //Calculate the resualt when there is two values with - and * between them
                                    resualt = numbersList[0] - numbersList[1] * numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "/":
                                if (numbersList[2] == 0)
                                {
                                    //Present error message and clear minnelable
                                    textOutMin = "";
                                    textOutCal = "DIV/ZERO!";

                                    //Disabel operators +, - ,* , /, =
                                    btnAdd.Enabled = false;
                                    btnSub.Enabled = false;
                                    btnMulti.Enabled = false;
                                    btnDivi.Enabled = false;
                                    btnEqual.Enabled = false;

                                    //Disabel numemr button
                                    btnNr0.Enabled = false;
                                    btnNr1.Enabled = false;
                                    btnNr2.Enabled = false;
                                    btnNr3.Enabled = false;
                                    btnNr4.Enabled = false;
                                    btnNr5.Enabled = false;
                                    btnNr6.Enabled = false;
                                    btnNr7.Enabled = false;
                                    btnNr8.Enabled = false;
                                    btnNr9.Enabled = false;
                                }
                                else
                                {
                                    checked
                                    {
                                        //Resualt when there is two values with - and / between them
                                        resualt = numbersList[0] - numbersList[1] / numbersList[2];
                                    }
                                    //Present resualt in calculator textbox and clear minnelable
                                    textOutMin = "";
                                    textOutCal = $"{resualt}";
                                }
                                break;

                            default:
                                checked
                                {
                                    //Calculate the resualt when there is one values with - between them
                                    resualt = numbersList[0] - numbersList[1];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                        }
                        break;

                    case "*":

                        switch (operatorList[1])
                        {
                            case "+":
                                checked
                                {
                                    //Calculate the resualt when there is two values with * and + between them
                                    resualt = numbersList[0] * numbersList[1] + numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "-":
                                checked
                                {
                                    //Calculate the resualt when there is two values with * and - between them
                                    resualt = numbersList[0] * numbersList[1] - numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "*":
                                checked
                                {
                                    //Calculate the resualt when there is two values with * and * between them
                                    resualt = numbersList[0] * numbersList[1] * numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "/":

                                if (numbersList[2] == 0)
                                {
                                    //Present error message and clear minnelable
                                    textOutMin = "";
                                    textOutCal = "DIV/ZERO!";

                                    //Disabel operators +, - ,* , /, =
                                    btnAdd.Enabled = false;
                                    btnSub.Enabled = false;
                                    btnMulti.Enabled = false;
                                    btnDivi.Enabled = false;
                                    btnEqual.Enabled = false;

                                    //Disabel numemr button
                                    btnNr0.Enabled = false;
                                    btnNr1.Enabled = false;
                                    btnNr2.Enabled = false;
                                    btnNr3.Enabled = false;
                                    btnNr4.Enabled = false;
                                    btnNr5.Enabled = false;
                                    btnNr6.Enabled = false;
                                    btnNr7.Enabled = false;
                                    btnNr8.Enabled = false;
                                    btnNr9.Enabled = false;
                                }
                                else
                                {
                                    checked
                                    {
                                        //Resualt when there is two values with * and / between them
                                        resualt = numbersList[0] * numbersList[1] / numbersList[2];
                                    }
                                    //Present resualt in calculator textbox and clear minnelable
                                    textOutMin = "";
                                    textOutCal = $"{resualt}";
                                }
                                break;

                            default:
                                checked
                                {
                                    //Calculate the resualt when there is one values with * between them
                                    resualt = numbersList[0] * numbersList[1];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;
                        }
                        break;

                    case "/":

                        switch (operatorList[1])
                        {
                            case "+":
                                checked
                                {
                                    //Calculate the resualt when there is two values with / and + between them
                                    resualt = numbersList[0] / numbersList[1] + numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "-":
                                checked
                                {
                                    //Calculate the resualt when there is two values with / and - between them
                                    resualt = numbersList[0] / numbersList[1] - numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "*":
                                checked
                                {
                                    //Calculate the resualt when there is two values with / and * between them
                                    resualt = numbersList[0] / numbersList[1] * numbersList[2];
                                }
                                //Present resualt in calculator textbox and clear minnelable
                                textOutMin = "";
                                textOutCal = $"{resualt}";
                                break;

                            case "/":
                                if (numbersList[2] == 0)
                                {
                                    //Present error message and clear minnelable
                                    textOutMin = "";
                                    textOutCal = "DIV/ZERO!";

                                    //Disabel operators +, - ,* , /, =
                                    btnAdd.Enabled = false;
                                    btnSub.Enabled = false;
                                    btnMulti.Enabled = false;
                                    btnDivi.Enabled = false;
                                    btnEqual.Enabled = false;

                                    //Disabel numemr button
                                    btnNr0.Enabled = false;
                                    btnNr1.Enabled = false;
                                    btnNr2.Enabled = false;
                                    btnNr3.Enabled = false;
                                    btnNr4.Enabled = false;
                                    btnNr5.Enabled = false;
                                    btnNr6.Enabled = false;
                                    btnNr7.Enabled = false;
                                    btnNr8.Enabled = false;
                                    btnNr9.Enabled = false;
                                }
                                else
                                {
                                    checked
                                    {
                                        //Resualt when there is two values with / and / between them
                                        resualt = numbersList[0] / numbersList[1] / numbersList[2];
                                    }
                                    //Present resualt in calculator textbox and clear minnelable
                                    textOutMin = "";
                                    textOutCal = $"{resualt}";
                                }
                                break;
                            default:
                                if (numbersList[1] == 0)
                                {
                                    //Present error message and clear minnelable
                                    textOutMin = "";
                                    textOutCal = "DIV/ZERO!";

                                    //Disabel operators +, - ,* , /, =
                                    btnAdd.Enabled = false;
                                    btnSub.Enabled = false;
                                    btnMulti.Enabled = false;
                                    btnDivi.Enabled = false;
                                    btnEqual.Enabled = false;

                                    //Disabel numemr button
                                    btnNr0.Enabled = false;
                                    btnNr1.Enabled = false;
                                    btnNr2.Enabled = false;
                                    btnNr3.Enabled = false;
                                    btnNr4.Enabled = false;
                                    btnNr5.Enabled = false;
                                    btnNr6.Enabled = false;
                                    btnNr7.Enabled = false;
                                    btnNr8.Enabled = false;
                                    btnNr9.Enabled = false;
                                }
                                else
                                {
                                    checked
                                    {
                                        //Calculate the resualt when there is one values with / between them
                                        resualt = numbersList[0] / numbersList[1];
                                    }
                                    //Present resualt in calculator textbox and clear minnelable
                                    textOutMin = "";
                                    textOutCal = $"{resualt}";
                                }

                                break;

                        }
                        break;
                }
            }
            catch (OverflowException)
            {
                //Present an error message and clear the values
                textOutCal = "Value Error";
                textOutMin = "";

                //Disabel operators +, - ,* , /, =
                btnAdd.Enabled = false;
                btnSub.Enabled = false;
                btnMulti.Enabled = false;
                btnDivi.Enabled = false;
                btnEqual.Enabled = false;

                //Disabel numemr button
                btnNr0.Enabled = false;
                btnNr1.Enabled = false;
                btnNr2.Enabled = false;
                btnNr3.Enabled = false;
                btnNr4.Enabled = false;
                btnNr5.Enabled = false;
                btnNr6.Enabled = false;
                btnNr7.Enabled = false;
                btnNr8.Enabled = false;
                btnNr9.Enabled = false;
            }
            //Present resualt/error to user
            minneLabel.Text = $"{textOutMin}";
            calculateTextBox.Text = $"{textOutCal}";

            //Disabel operators +, - ,* , /, =
            btnAdd.Enabled = false;
            btnSub.Enabled = false;
            btnMulti.Enabled = false;
            btnDivi.Enabled = false;
            btnEqual.Enabled = false;

            //Disabel numemr button
            btnNr0.Enabled = false;
            btnNr1.Enabled = false;
            btnNr2.Enabled = false;
            btnNr3.Enabled = false;
            btnNr4.Enabled = false;
            btnNr5.Enabled = false;
            btnNr6.Enabled = false;
            btnNr7.Enabled = false;
            btnNr8.Enabled = false;
            btnNr9.Enabled = false;

        }

        private void CalculateTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
