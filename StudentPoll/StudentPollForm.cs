// Ex. 17.8: StudentPoll.cs
// Allow student to take a survey
// and view the results in a TextBox
using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Xsl;
using System.Globalization;

namespace StudentPoll
{
   public partial class StudentPollForm : Form
   {

      //initiliaze StreamWriter, StreamWriter and int variables
      StreamWriter writer = null;
      StreamReader input;
      int number;
      
      // parameterless constructor
      public StudentPollForm()
      {
         InitializeComponent();

         //set the app to write everything to a text document called "numbers.txt"
         writer = new StreamWriter("numbers.txt");
         //TODO ***************************
         //Create the StreamWriter object

      } // end constructor

      private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
      {
         //checks to see if user presses the user button
         if (e.KeyCode == Keys.Enter)
         {
            if (e.KeyCode != Keys.Enter)
                {
                    //if user does not press the enter button, show this message
                    MessageBox.Show("Must press the enter button to submit.", "Press enter",
                        MessageBoxButtons.OK);
                }
            //TODO ************************
            //Add exception handling

            if (String.IsNullOrEmpty(inputTextBox.Text))
            {
               //if the user tries to submit blank text, show this message
               MessageBox.Show("Please fill in the TextBox.");
            } // end if
            else
            {
               //takes user input and translates it to a number
               number = int.Parse(inputTextBox.Text);

                    //if user types in a number not between 1-10, show this message
                    if (number < 1 || number > 10)
                    {
                        MessageBox.Show("The number has to be between 1 and 10", "Wrong number choice",
                        MessageBoxButtons.OK);
                    }
                    else
                    {
                        //otherwise, take the user number and print it to the "numbers.txt" document
                        writer.Write(number + " ");
                    }    
               //TODO ******************************
               //  Validate that the number is 1 - 10. When valid, use method Write to put the value into the file

               
            } // end else

            //clear the input text box
            inputTextBox.Clear();
         } // end if
      }

      private void doneButton_Click(object sender, EventArgs e)
      {
         //makes it so that nothing else can be inputted to the "numbers.txt" document
         writer.Close();
            //TODO *********************************
            //Change properties such that the display button can be used and this button can't be used. The textbox should be read-only

            //enables the display button and display Text box, disables the done button
            displayButton.Enabled = true;
            doneButton.Enabled = false;
            displayTextBox.ReadOnly = true;
      }

      private void displayButton_Click(object sender, EventArgs e)
      {
         //reads the data from the "numbers.txt" document
         input = new StreamReader("numbers.txt");

         //reads what the user typed in
         string inputString = input.ReadToEnd();
         string[] stringArray;
         int[] frequency = new int[11];

            //TODO ******************
            //makes every "word" in the document and adds them to indexes of the array
            stringArray = inputString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int x = 0; x < stringArray.Length; x++)
            {
                int anotherInteger = Convert.ToInt32(stringArray[x]);
                ++frequency[anotherInteger];
            }
         //Split the read data into the array. Populate another integer array with the values from the string array converted
         //   to integers. Update the frequency array to include a count for each of the responses. Refer to Figure 8.8

        
         //clears the display text box and prints off the headers
         displayTextBox.Clear();
         displayTextBox.AppendText("Rating\tFrequency\n");

            //TODO *******************
            //Write out the ratings and frequencies
            //prints off the numbers for which the user could have typed in
            //and prints off how many each rating was typed in
            for (var ratings = 1; ratings < frequency.Length; ++ratings)
            {
                displayTextBox.AppendText(("\r\n" + ratings + "\t                " + frequency[ratings]));
                //displayTextBox.AppendText(String.Format("\r\n{0,10}{1,10}", ratings, frequency[ratings]));
            }
        } // end method displayButton_Click
   } // end class StudentPollForm
} // end namespace StudentPoll

