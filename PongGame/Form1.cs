/* ******************************************************************************************************
 * Program name:            Pong Game              
 * Project file name:       PongGame
 * Author:                  Michael Inglis
 * Date:                    16 September 2015
 * Language:                C#
 * Platform:                Microsoft Visual Studio 2013
 * Purpose:                 The object of the program is to create a game with a 
 *                          bouncing ball which the player and computer can move 
 *                          around with the use of paddles. Points are scored when
 *                          the ball leaves the screen on one’s opponent’s side, 
 *                          and the first to 10 is the winner.  
 * Known Bugs:              None    
 * Additional Features:     Start screen
 *******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;    
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongGame
{
    public partial class Form1 : Form
    {
        //declare variables and objects
        private Graphics graphics;
        private Controller controller;
        private Bitmap canvas;
        private Graphics OffScreenGraphics;

        //form1 constructor
        public Form1()
        {
            InitializeComponent();
            //initialize
            canvas = new Bitmap(this.Width, this.Height);
            OffScreenGraphics = Graphics.FromImage(canvas);
            graphics = CreateGraphics();
            controller = new Controller(OffScreenGraphics, ClientSize);
            timer1.Enabled = false;

        }

        //timer event handler
        private void timer1_Tick(object sender, EventArgs e)
        {
            OffScreenGraphics.Clear(Color.Green);
            RunGame();
            graphics.DrawImage(canvas, 0, 0);
        }

        //Run game method
        private void RunGame()
        {
            //if neither player's score is 10 or more, run the game
            if ((controller.P1Score < 10) && (controller.P2Score < 10))
            {
               controller.Run(p1ScoreLabel, p2ScoreLabel);
            }
            else if (controller.P1Score > controller.P2Score)
            {
                timer1.Enabled = false;//disable the timer
                MessageBox.Show("You win!");
                //Got help from Dan with the MessageBox
                if (MessageBox.Show("Do you want to play again?", "Play Again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
	             {
                     timer1.Enabled = true;
                     controller.P1Score = 0;//Joy helped with this
                     controller.P2Score = 0;
                     p1ScoreLabel.Text = "0";
                     p2ScoreLabel.Text = "0";
  	             }
                 else
                 {
                    Application.Exit();
                 }


                //controller.GameOver = true;
            }
            else
            {
                timer1.Enabled = false;//disable the timer
                MessageBox.Show("You lose!");
                if (MessageBox.Show("Do you want to play again?", "Play Again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    timer1.Enabled = true;
                    controller.P1Score = 0;
                    controller.P2Score = 0;
                    p1ScoreLabel.Text = "0";
                    p2ScoreLabel.Text = "0";
                }
                else
                {
                    Application.Exit();
                }

                //controller.GameOver = true;
            }
            
        }
        
        //key event handler
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                        controller.MovePaddle1Up();
                        break;
                case Keys.Down:
                        controller.MovePaddle1Down();
                        break;
             }
        }

       
        //not used - was for attempt to use mouse to control paddle which didn't work
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

       //button 1 event handler
        private void button1_Click(object sender, EventArgs e)
        {
            //panel1.Visible = false;
            panel1.Dispose();//Dan helped with this
            timer1.Enabled = true;
            //this.Activate();
            //this.BringToFront();
        }

    }
}