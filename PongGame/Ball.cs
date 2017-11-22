/*
 * Ball class - holds information and methods for making and moving a ball
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame
{
    class Ball
    {
        //declare variables and objects
        private const int CHANGEDIR = -1;

        private Graphics graphics;
        private Point position;
        private Point velocity;
        private int size;
        private Brush brush;
        private Size boundary;

        //constructor
        public Ball(Graphics graphics, Color colour, Point position, Point velocity, int size, Size boundary)
        {
            //initialise 
            this.graphics = graphics;
            brush = new SolidBrush(colour);
            this.position = position;
            this.velocity = velocity;
            this.size = size;
            this.boundary = boundary;

        }

        //move the ball
        public void Move()
        {
            position.X += velocity.X;
            position.Y += velocity.Y;
        }

        //create the ball
        public void Draw()
        {
            graphics.FillEllipse(brush, position.X, position.Y, size, size);
        }

        //make the ball bounce off the top and bottom of the window
        public void BounceTopBottom()
        {     
            if ((position.Y <= 0) || (position.Y >= boundary.Height - size))
            {
                velocity.Y *= CHANGEDIR;
            }

        }

        //position property
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public Point Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Size Boundary
        {
            get { return boundary; }
            set { boundary = value; }
        }
       
        
    }
}
