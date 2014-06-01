using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ravi_Sinha_s_SuccessiveApproximationGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*
             * 
             * Definitions
             * 
             * */
            string vrefs = "0", vins = "0", bits, error, hexcode = "", bitcodea = ""; //String forms of Vref, Vin, and Bits also holds the error (%), the hexcode and the bitcode for displaying.
            double vref = 0.0, vin = 0.0, bit = 1, stps, temp = 0.0, x = 0.0; //integer value of Resolution, Vref, Vin, Bits, and decimal equivilant of binary.
            vrefs = textBox1.Text; //receive vref from textbox
            vref = Convert.ToDouble(vrefs); //convert to double
            vins = textBox3.Text; //receive vin from textbox
            vin = Convert.ToDouble(vins); //convert to double
            bits = textBox2.Text; //retrieve bit from textbox
            bit = Math.Floor(Convert.ToDouble(bits)); //floor it to make it whole (listed in disclaimers) and make a double
            stps = (vref / (Math.Pow(2.0, bit))); // find step size for the gui
            string[] filething = new string[(int)bit];
            string[] bitcode = new string[(int)bit];
            bool[] ar = new bool[(int)bit];
            int[] aq = new int[(int)bit];
            /*
             * 
             * Binary Conversion
             * 
             * */
            label9.Text = stps.ToString(); //display step size
            for (int i = (int)bit - 1; i >= 0; i--) //Initialize ar[] and aq[] to 0;
            {
                ar[i] = false;
                aq[i] = 0;
            }
            using (StreamWriter write = File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Steps.txt")))//File IO (added 4/9/2014)
            {
                for (int i = (int)bit - 1; i >= 0; i--)
                {
                    ar[i] = true; //make the first bit a 1
                    aq[i] = 1; //make first bit a 1
                    write.WriteLine((bit - i) + "\t" + reverse(SWAG(aq,(int)bit)) + "\t" + (vref / Math.Pow(2.0, bit)) * (temp + Math.Pow(2.0, (double)(i)))); //write to file the step number, Binary Value, and the Analog Output
                    if ((vref / Math.Pow(2.0, bit)) * (temp + Math.Pow(2.0, i)) > vin)
                    {
                        ar[i] = false; //If the output is more than input, then make the bit a 0
                        aq[i] = 0;
                    }
                    else if (((vref / Math.Pow(2.0, bit)) * (temp + Math.Pow(2.0, (double)(i))) < vin))
                        temp += Math.Pow(2.0, (double)(i)); //if the output is less than the input, then add to temp.
                    else if ((vref / Math.Pow(2.0, bit)) * (temp + Math.Pow(2.0, (double)(i))) == vin)
                    {
                        temp += Math.Pow(2.0, (double)(i)); //if output is equal to input, add to temp and break
                        break;
                    }
                    bitcodea = "";
                }
            }
            for (int j = (int)bit - 1; j >= 0; j--)
            {
                if (ar[j] == true)
                    bitcode[j] = "1"; //initialize j to match ar[]
                else
                    bitcode[j] = "0";
            }
            for (int i = 0; i < bitcode.Length; i++)
                bitcodea += bitcode[i]; //convert bitcode to bitcodea. This could've been avoided with the function SWAG (String Whole-number Array Generator) but due to Murphey's Law,I did not want to mess with the code.
            label10.Text = reverse(Convert.ToString(bitcodea));//display binary output
            Array.Reverse(bitcode);
              /*
               * 
               * Hex conversion!
               * 
               * */
            if (bit % 8 == 0)
                x = 0; //make number of bits divisible by 8
           else
                x = 4-(bit % 4);
           string[] a = new string[(int)(bit + x)]; //new binary array for hex values including any pertinent leading 0's
           for (int i = 0; i < x; i++ )
                a[i] = "0"; //add leading zeros
           for (int i = (int)x; i < (int)(bit + x); i++)
                a[i] = bitcode[i - (int)(x)]; //initialize the rest of the array

           for(int i =0; i < (int)(bit+x); i+=4)
           {
                switch (a[i]+a[i+1]+a[i+2]+a[i+3]) //Take four elements of the array at a time and form a complete 4 element string. Then convert this to Hexadecimal using a massive switch statement (courtesy of Ajay)
                {
                     case "0000":
                         hexcode += "0";
                         break;
                     case "0001":
                         hexcode += "1";
                         break;
                     case "0010":
                         hexcode += "2";
                         break;
                     case "0011":
                         hexcode += "3";
                         break;
                     case "0100":
                         hexcode += "4";
                         break;
                     case "0101":
                         hexcode += "5";
                         break;
                     case "0110":
                         hexcode += "6";
                         break;
                     case "0111":
                         hexcode += "7";
                         break;
                     case "1000":
                         hexcode += "8";
                         break;
                     case "1001":
                         hexcode += "9";
                         break;
                     case "1010":
                         hexcode += "A";
                         break;
                     case "1011":
                         hexcode += "B";
                         break;
                     case "1100":
                         hexcode += "C";
                         break;
                     case "1101":
                         hexcode += "D";
                         break;
                     case "1110":
                         hexcode += "E";
                         break;
                     case "1111":
                         hexcode += "F";
                         break;
                     default:
                         hexcode+=0;
                         break;
                    } 
                } 
            label18.Text = "0x" + hexcode; // add 0x to the start of the hexcode and display the hexcode
            error = Convert.ToString((((temp * vref / Math.Pow(2.0, bit)) - vin) / ((temp * vref / Math.Pow(2.0, bit)))) * 100); //compute error and convert to string
            error += "%"; //add percent sign to error
            label11.Text = error; //display error
            label13.Text = Convert.ToString((vref / Math.Pow(2.0, bit)) * temp); //display output voltage!
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("          Ravi Sinha\n          2014"); //Maintaining the fact that I coded the GUI
        }

        private void resourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The internet is extremely helpful (StackOverflow+Ravi = <3)\nMr. Paterno's Slide\n\n\n\n                     ALL CODE WAS MADE BY RAVI SINHA."); //Giving credit and still maintaining the fact that I coded this program.
        }

        private void problemcurrrentlyToolStripMenuItem_Click(object sender, EventArgs e) //Disclaimers! EXTREMELY long. That is why a Tl;dr (Too long; didn't read) is included.
        {
            MessageBox.Show("\tAt the moment, the program does not use the 2's compliment, nor does it have a sign bit for negative numbers. If you do use negative numbers, a box (not from the program) will pop up and the program will not perform. Hit continue if this pops up and try different numbers.\n\tAlso, don't input decimals for the number of bits! This is due to the fact that the arrays contained within the program are based upon the number of bits. Since you can not have a floating point value for an array size, please enter positive integers for the number of bits. Bits will be floored otherwise (2.5 -> 2).\n\tAfter a certian point, the program's number of bits will go out of bounds. Sometimes I've reached 1019 bits, or even as high as 2000 bits depending on the Vref (the higher the vref, more amount of bits you can contain). However, the code may not support that high of a number because the computer is processing numbers too large/small to compute. Beyond a certain point, there will be no error value and the GUI will display 0, NAN% and NAN for the StepSize, Percentage Error, and Analog Output, respectively. Due to floating point rounding, there is not finite value. The number is usually extremely small so it is close enough to 0 to assume it is 0 (ie. 7.3635741024940601277690601211899e-593 is EXTREMELY close to 0.). Since the step size is so close to 0, the computer automatically rounds down to 0. Don't use bits that are more than 100 to be safe with the calculations. If entering above 1000 bits, the program may glitch and return a 0xFFF...F...FFF. Other times, the program will crash completely (as it did with 20,000)\n\n\ntl;dr: Don't use negative numbers in general and floating point numbers for bits. If the numbers outputted don't seem right, or aren't numbers in general (except at the hex approximation), don't worry, you just created extremely small stepsizes! Enjoy!");
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for using this program!"); //Courtesy is always great.
            Application.Exit(); //exit the app.
        }
        public string reverse(string t) //reverse string. (ie. "Ravi Sinha is cool!"  -> "!looc si ahniS Ivar" and "RACECAR" -> "RACECAR")
        {
            char[] array = t.ToCharArray();
            string reverse = String.Empty;
            for (int i = array.Length - 1; i > -1; i--)
                reverse += array[i];
            return reverse;
        }

        public string  SWAG (int[] array, int bit) //String of Whole-num Array Generator
        {
            string num = "";
            for (int i = 0; i < bit; i++ )
            {
                if (array[i] == 0)
                    num += "0";
                else
                    num += "1"; //form string that forms a string from a whole number array (there was code that did this before but I didn't touch it due to Murphey's Law)
            }
            return num;
        }
    }
}
