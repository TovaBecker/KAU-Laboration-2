using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lottoprogram
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
 
        private void checkLottoNr(object sender, EventArgs e)
        {
            //Declare and initialize string variabl
            string lott = (sender as TextBox).Text;

            //Disenabled btnStart button and amountDraw
            btnStart.Enabled = false;
            amountDraw.Enabled = false;

            //Checks if lottonummer input only contains digits
            if (!Regex.IsMatch(lott, "^[0-9]+$"))
            {
                //Show error message
                infoError.Text = "Ange lottonummer";
            }
            else
            {
                //Check if lottonummer is a valid number between 1 - 35
                if (int.Parse(lott) < 1 || int.Parse(lott) > 35)
                {
                    //Show error message
                    infoError.Text = "Ange lottonummer mellan 1-35";
                }
                else
                {
                    // Check that all the lotto number text boxes has numbers
                    if (LottoNr1.Text == "" || 
                        LottoNr2.Text == "" || 
                        LottoNr3.Text == "" || 
                        LottoNr4.Text == "" || 
                        LottoNr5.Text == "" || 
                        LottoNr6.Text == "" || 
                        LottoNr7.Text == "")
                    {
                        //Remove error message
                        infoError.Text = "";
                    }
                    else
                    {
                        //Check if all the lottonummbers only contains digits
                        if (!Regex.IsMatch(LottoNr1.Text, "^[0-9]+$") ||
                            !Regex.IsMatch(LottoNr2.Text, "^[0-9]+$") ||
                            !Regex.IsMatch(LottoNr3.Text, "^[0-9]+$") ||
                            !Regex.IsMatch(LottoNr4.Text, "^[0-9]+$") ||
                            !Regex.IsMatch(LottoNr5.Text, "^[0-9]+$") ||
                            !Regex.IsMatch(LottoNr6.Text, "^[0-9]+$") ||
                            !Regex.IsMatch(LottoNr7.Text, "^[0-9]+$"))
                        {
                            //Show error message
                            infoError.Text = "En eller flera rutor innehåller inte ett lottonummer";
                        }
                        else
                        {
                            //Check if all the lottonummbers is valid numbers between 1 - 35
                            if (int.Parse(LottoNr1.Text) < 1 || int.Parse(LottoNr1.Text) > 35 ||
                                int.Parse(LottoNr2.Text) < 1 || int.Parse(LottoNr2.Text) > 35 ||
                                int.Parse(LottoNr3.Text) < 1 || int.Parse(LottoNr3.Text) > 35 ||
                                int.Parse(LottoNr4.Text) < 1 || int.Parse(LottoNr4.Text) > 35 ||
                                int.Parse(LottoNr5.Text) < 1 || int.Parse(LottoNr5.Text) > 35 ||
                                int.Parse(LottoNr6.Text) < 1 || int.Parse(LottoNr6.Text) > 35 ||
                                int.Parse(LottoNr7.Text) < 1 || int.Parse(LottoNr7.Text) > 35)
                            {
                                //Show error message
                                infoError.Text = "En eller flera rutor innehåller inte ett lottonummer mellan 1-35";
                            }
                            else
                            {
                                // Cerate a string array with the lotto numbers
                                string[] lottList = new string[] {LottoNr1.Text,
                                                                  LottoNr2.Text,
                                                                  LottoNr3.Text,
                                                                  LottoNr4.Text,
                                                                  LottoNr5.Text,
                                                                  LottoNr6.Text,
                                                                  LottoNr7.Text };

                                //Check that all the numbers in the array is unique
                                if (lottList.Distinct().Count() != 7)
                                {
                                    //Show error message
                                    infoError.Text = "En eller flera rutor innehåller samma lottonummer";
                                }
                                else
                                {
                                    //Enable btnStart button and amountDraw if input is valid numbers and remove error message
                                    btnStart.Enabled = true;
                                    amountDraw.Enabled = true;
                                    infoError.Text = "";
                                }
                            }
                        }

                    }
                }
            }
        }

        private void checkIfOnlyDigits(object sender, EventArgs e)
        {
            //Checks if draw input only contains digits
            if (!Regex.IsMatch(amountDraw.Text, "^[0-9]+$"))
            {
                //Disenabled btnStart button and show error message
                btnStart.Enabled = false;
                infoError.Text = "Ange antal dragningar i siffror";
            }
            else
            {
                //Enable btnStart button if input is only digits and remove error message
                btnStart.Enabled = true;
                infoError.Text = "";
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        { 
            //Disenabled btnStart button
            btnStart.Enabled = false;

            //Declare and initialize int variabels for resualt and input
            int CorrectFive = 0;
            int CorrectSix = 0;
            int CorrectSeven = 0;
            int numbersOfDraw = 0;

            //Check if all the lottonummbers only contains digits
            if (!Regex.IsMatch(LottoNr1.Text, "^[0-9]+$") ||
                !Regex.IsMatch(LottoNr2.Text, "^[0-9]+$") ||
                !Regex.IsMatch(LottoNr3.Text, "^[0-9]+$") ||
                !Regex.IsMatch(LottoNr4.Text, "^[0-9]+$") ||
                !Regex.IsMatch(LottoNr5.Text, "^[0-9]+$") ||
                !Regex.IsMatch(LottoNr6.Text, "^[0-9]+$") ||
                !Regex.IsMatch(LottoNr7.Text, "^[0-9]+$"))
            {
                //Show error message
                infoError.Text = "En eller flera rutor innehåller inte ett lottonummer";
            }
            else
            {
                // Cerate a int array with the lotto numbers
                int[] lottList = new int[] {int.Parse(LottoNr1.Text),
                                        int.Parse(LottoNr2.Text),
                                        int.Parse(LottoNr3.Text),
                                        int.Parse(LottoNr4.Text),
                                        int.Parse(LottoNr5.Text),
                                        int.Parse(LottoNr6.Text),
                                        int.Parse(LottoNr7.Text) };

                //Randome generator
                Random random = new Random();

                try
                {
                    //Convert the string representation of the number to its single int-point number equivalent
                    numbersOfDraw = int.Parse(amountDraw.Text);
                }
                catch
                {
                    //Disenabled btnStart button and show error message
                    btnStart.Enabled = false;
                    infoError.Text = "Ange antal dragningar";
                }
               
                //Go through the numbers of draws given by the user
                for (int draw = 0; draw < numbersOfDraw; draw++)
                {
                    //Declare and initialize int array with 7 slots
                    int[] roundList = new int[7];

                    //Create the lotto numbers for this draw, Check that all the numbers in the array is unique
                    while (roundList.Distinct().Count() != 7)
                    {
                        //Create 7 distinct numbers
                        for (int round = 0; round < 7; round++)
                        {
                            //Get a randome number
                            roundList[round] = random.Next(1, 35);
                        }
                    }

                    //Compare the two lists and take out the numbers that are the same
                    IEnumerable<int> bigoNumbers = lottList.Intersect(roundList);

                    //Count how many numbers that are the same
                    int bigoResualt = bigoNumbers.Count();

                    //Check resualt of the draw and save resualt
                    if (bigoResualt > 4)
                    {
                        if (bigoResualt == 7)
                        {
                            CorrectSeven++;
                        }
                        else if (bigoResualt == 6)
                        {
                            CorrectSix++;
                        }
                        else
                        {
                            CorrectFive++;
                        }
                    }

                }
            }

            //Print out the result of the draws
            resultCorrect7.Text = $"{CorrectSeven}";
            resultCorrect6.Text = $"{CorrectSix}";
            resultCorrect5.Text = $"{CorrectFive}";

            //Enable btnStart button
            btnStart.Enabled = true;
        }
    }
}
