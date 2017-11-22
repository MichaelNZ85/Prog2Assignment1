/*
 * Paddle.cs - holds information and methods for making and moving a paddle
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame
{
    class Paddle
    {
        //declare variables and objects
        private const int CHANGEDIR = -1;
        private const int MAXSPEED = 8;
        private const int MOVEINTERVAL = 20;

        private Graphics graphics;
        private Point position;
        private Brush brush;
        private int hSize;
        private int vSize;

        private int paddleLeft;
        private int paddleRight;
        private Random random;

        //paddle constructor
        public Paddle(Graphics graphics, Color colour, Point position, int hSize, int vSize, Random random)
        {
            //initialise
            this.graphics = graphics;
            brush = new SolidBrush(colour);
            this.position = position;
            this.hSize = hSize;
            this.vSize = vSize;

            //set initial paddle position
            paddleLeft = position.X;
            paddleRight = position.X + vSize;
            this.random = random;
        }// end constructor

        //creates ball
        public void Draw()
        {
            graphics.FillRectangle(brush, position.X, position.Y, vSize, hSize);
        }
        //Collision detection
        public void CollisionDetect(Ball theBall)
        {
            if ((theBall.Position.Y > position.Y) && (theBall.Position.Y < position.Y + hSize))
            {
                if ((theBall.Position.X < paddleRight) && (theBall.Position.X > paddleLeft))
                {
                    Point temppoint = theBall.Velocity;
                    temppoint.X *= CHANGEDIR;
                    theBall.Velocity = temppoint;
                }
            }
        }
        
        //move paddle up by 20
        public void MoveUp()
        {
            position.Y -= MOVEINTERVAL;
        }

        //move paddle down
        public void MoveDown()
        {
            position.Y += MOVEINTERVAL;
        }

        //moves paddle with a randomising factor - Matt helped with this method
        public void SmartMove(int ballYPos) 
        {
            int speed = random.Next(0, MAXSPEED);
            
            if (ballYPos < position.Y)
            {
                position.Y -= speed;
            }
            else
            {
                position.Y += speed;
            }
        }

        //Position property
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
    
    }
}
