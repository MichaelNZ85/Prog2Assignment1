/*
 * Controller class - used to control the game
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongGame
{
    class Controller
    {
        //declare variables and objects
        private const int BALLXINIT = 450;
        private const int BALLYINIT = 100;
        private const int BALLSIZE = 13;
        private const int BALLPOS = 5;
        private const int PADDLEY = 150;
        private const int PADDLE1X = 30;
        private const int PADDLE2X = 580;
        private const int PADDLEHSIZE = 130;
        private const int PADDLEVSIZE = 10;

        private bool gameOver;
        private Ball ball;
        private Paddle paddle1;
        private Paddle paddle2;
        private int p1Score;
        private int p2Score;
        private Random random;
        private int ballXPosition;
        private int ballYPosition;

        public Controller(Graphics graphics, Size ClientSize)
        {
            //initialize
            random = new Random();
                        
            ballXPosition = random.Next(BALLXINIT);
            ballYPosition = random.Next(BALLYINIT);
            ball = new Ball(graphics, Color.White, new Point(ballXPosition, ballYPosition), new Point(BALLPOS, BALLPOS), BALLSIZE, ClientSize);
            paddle1 = new Paddle(graphics, Color.White, new Point(PADDLE1X, PADDLEY), PADDLEHSIZE, PADDLEVSIZE, random);
            paddle2 = new Paddle(graphics, Color.White, new Point(PADDLE2X, PADDLEY), PADDLEHSIZE, PADDLEVSIZE, random);
            
        }

        //creates the balls and makes them bounce
        public void GoBall()
        {
            ball.Move();
            ball.BounceTopBottom();
            ball.Draw();
                        
        }

        //creates the paddles
        public void GoPaddle()
        {
            paddle1.Draw();
            paddle2.Draw();
            
        }

        //moves the paddle up by 20
        public void MovePaddle1Up()
        {
            paddle1.MoveUp();

        }

        //moves the paddle down by 20
        public void MovePaddle1Down()
        {
            paddle1.MoveDown();
        }

        public void MovePaddle2Up()
        {
            paddle2.MoveUp();

        }

        public void MovePaddle2Down()
        {
            paddle2.MoveDown();
        }

        //detects collisions on the paddles
        public void DetectCollisions()//Matt helped with this
        {
            paddle1.CollisionDetect(ball);
            paddle2.CollisionDetect(ball);
            
        }

        //scores for player 2
        public void ScoreP2(Label myLabel)
        {
            
            if (ball.Position.X <= 0)
            {
                p2Score++;
                myLabel.Text = Convert.ToString(p2Score);
                ballXPosition = random.Next(BALLXINIT);
                ballYPosition = random.Next(BALLYINIT);
                ball.Position = new Point(ballXPosition, ballYPosition);
               
            }

        }

        //scores for player 1
        public void ScoreP1(Label myLabell)
        {
            if (ball.Position.X >= ball.Boundary.Width)
            {
                p1Score++;
                myLabell.Text = Convert.ToString(p1Score);
                ballXPosition = random.Next(BALLXINIT);
                ballYPosition = random.Next(BALLYINIT);
                ball.Position = new Point(ballXPosition, ballYPosition);

            }
        }

        //runs the game
        public void Run(Label label1, Label label2)
        {
            GoBall();
            GoPaddle();
            DetectCollisions();
            ScoreP1(label1);
            ScoreP2(label2);
            CompPaddle();
        }

        //moves the computer's paddle
        public void CompPaddle()
        {
           paddle2.SmartMove(ball.Position.Y);
        }

        //p1score property
        public int P1Score
        {
            get { return p1Score; }
            set { p1Score = value; }
        }

        //p2score property
        public int P2Score
        {
            get { return p2Score; }
            set { p2Score = value; }
        }

        //gameOver property
        public bool GameOver
        {
            get { return gameOver; }
            set { gameOver = value; }
        }

    }
}
