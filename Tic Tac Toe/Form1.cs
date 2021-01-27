using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true;//true means x false means o
        int turnCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        public  delegate void checkWinner();
        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            checkWinner cw = new checkWinner(CheckWinner);

            if (turn)
            {
                b.Text = "X";
                turn = !turn;
                b.Enabled = false;
                turnCount++;
                cw();
                
            }
            else
            {
                b.Text = "O";
                turn = !turn;
                b.Enabled = false;
                turnCount++;
                cw();
            }
        }
        private void CheckWinner()
        {
            bool win = false;
           if (button1.Text == button2.Text && button2.Text == button3.Text && !button1.Enabled)
                win = true;
           else if (button4.Text == button5.Text && button5.Text == button6.Text && !button4.Enabled)
                win = true;
           else if (button7.Text == button8.Text && button8.Text == button9.Text && !button7.Enabled)
                win = true;
           else if (button1.Text == button4.Text && button4.Text == button7.Text && !button1.Enabled)
                win = true;
           else if (button2.Text == button5.Text && button5.Text == button8.Text && !button2.Enabled)
                win = true;
           else if (button3.Text == button6.Text && button6.Text == button9.Text && !button3.Enabled)
                win = true;
           else if (button1.Text == button5.Text && button5.Text == button9.Text && !button1.Enabled)
                win = true;
           else if (button3.Text == button5.Text && button5.Text == button7.Text && !button3.Enabled)
                win = true;
            if (win)
            {
                disableButton();
                string winner = "";
                if (turn)
                {
                    winner = "O";
                    
                }
                else
                {
                    winner = "X";
                }
                MessageBox.Show($"{winner} wins!!");
            }
            else if (turnCount == 9)
            {
                MessageBox.Show("draw");
            }
        }
        private void disableButton()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            b.Enabled = true;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This provides help", "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
    }
}
