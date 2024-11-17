using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrder
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }



        private float GetSelectedSizePrice()
        {

            if(radSmall.Checked) 
            { return Convert.ToSingle(radSmall.Tag); }

            else if(radMeduim.Checked) 
            { return Convert.ToSingle(radMeduim.Tag); }

            else { return Convert.ToSingle(radLarg.Tag); }

        }
        private float CalculateToppingsPrice()
        {
            float Toppings = 0;

            if (checkExtraChees.Checked)
            { Toppings += Convert.ToSingle(checkExtraChees.Tag);}

            if (checkMushroom.Checked)
            { Toppings += Convert.ToSingle(checkMushroom.Tag); }

            if (checkTomatoes.Checked)
            { Toppings += Convert.ToSingle(checkTomatoes.Tag); }

            if (checkBOnion.Checked)
            { Toppings += Convert.ToSingle(checkBOnion.Tag); }

            if (checkOlives.Checked)
            { Toppings += Convert.ToSingle(checkOlives.Tag); }

            if (checkGreenPeppers.Checked)
            { Toppings += Convert.ToSingle(checkGreenPeppers.Tag); }
            
            return Toppings;
        }
        private float GetSelectedCrutPrice()
        {
            if(radThink.Checked)
            { return Convert.ToSingle(radThink.Tag); }
            return 0;
        }

        private float CalculateTotalPrice()
        {

            return GetSelectedSizePrice() + CalculateToppingsPrice() + GetSelectedCrutPrice();

        }
        private void UpdateTotalPrice()
        {
          labelprice.Text = "$"+ CalculateTotalPrice().ToString();
        }



        private void UpdateToppings()
        {
            UpdateTotalPrice();

            string Toppings = "";

            if (checkExtraChees.Checked)
            { Toppings += ",Extra Chees "; }

            if (checkMushroom.Checked)
            { Toppings += ",Mushroom "; }

            if (checkTomatoes.Checked)
            { Toppings += ",Tomatoes "; }

            if (checkBOnion.Checked)
            { Toppings +=  ",Onion " ; }

            if (checkOlives.Checked)
            { Toppings += ",Olives " ; }

            if (checkGreenPeppers.Checked)
            { Toppings += ",GreenPeppers "; }

            if(Toppings.StartsWith(","))
            {
                Toppings= Toppings.Substring(1,Toppings.Length-1).Trim();
            }
            

            if (Toppings == "")
                Toppings = "No Toppings";

            labelToppings.Text = Toppings;


            labelToppings.Text = Toppings;

        }

        private void UpdateSize()
        {
            UpdateTotalPrice();
            if (radSmall.Checked)
            {
                Sizelabel.Text = "Small";
                return;
            }

            if (radMeduim.Checked) 
            {
                Sizelabel.Text = "Meduim";
                return;
            }

            if (radLarg.Checked) 
            {
                Sizelabel.Text = "Larg";
                return;
            }

        }


        private void UpdateCrust()
        {
            UpdateTotalPrice();
            if (radThin.Checked) 
            {
                Crustlabel1.Text = "Crust Thin";
            }

            if(radThink.Checked) 
            {
                Crustlabel1.Text = "Crust Think";
            }

        }

        private void UpdateWhereToEat()
        {
            if(radEatIn.Checked)
            { labelWhereYouEat.Text = "Eat In "; }

            if(radTakeOut.Checked)
            { labelWhereYouEat.Text = "Take Out"; }

        }

        private void ResetFrom()
        {
            //reset Groups
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;


            //reset Size
            radMeduim.Checked = true;

            //reset Toppings
            checkExtraChees.Checked = false;
            checkMushroom.Checked = false;
            checkTomatoes.Checked = false;
            checkBOnion.Checked = false;
            checkOlives.Checked = false;
            checkGreenPeppers.Checked = false;


            //reset Where you Eat
            radEatIn.Checked = true;
            //reset Crust Type
            radThin.Checked = true;
            //reset order button
            button1.Enabled = true;

       


        }

        private void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            ResetFrom();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();  
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }


        private void checkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void checkMushroom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void checkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void checkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }


        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void radEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void radTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          if( MessageBox.Show("Confirm Order", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
           {

                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                button1.Enabled = false;

                MessageBox.Show("Order Placed Successfully", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
          else 
                MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetFrom();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
    }
}
