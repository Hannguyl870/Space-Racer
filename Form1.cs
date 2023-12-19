using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Race
{


    public partial class spaceracer : Form
    {
        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        List<Rectangle> astroids = new List<Rectangle>();

        List<int> astroidspeed = new List<int>();
        List<int> astroidsize = new List<int>();
        //List<SolidBrush> colours = new List<SolidBrush>();
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        string mainmenue = "waiting";

        Rectangle player1 = new Rectangle(150, 200, 25, 40);
        Rectangle player2 = new Rectangle(350, 270, 25, 40);

        Rectangle line = new Rectangle(260, 40, 10, 300);

        int player1score = 0;
        int player2score = 0;
        int player2Speed = 4;
        int player1Speed = 4;

        Random randgen = new Random();
        int randValue = 0;

        public spaceracer()
        {
            InitializeComponent();
        }
        public void GameInitialize()
        {
            Titlelable.Visible = false;
            Subtitlelable.Visible = false;
            Titlelable.Text = "";
            Subtitlelable.Text = "";

            Astroidtimer.Enabled = true;

            player1score = 0;
            player2score = 0;

            astroids.Clear();
            astroidspeed.Clear();
         

            //player.X = 0;
            //  hero.Y = this.Height - groundheight - hero.Height;

            mainmenue = "running";
        }

        private void spaceracer_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
               
                case Keys.Space:
                    if (mainmenue == "waiting" || mainmenue == "gameover" || mainmenue == "winning")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (mainmenue == "waiting" || mainmenue == "gameover")
                    {
                        this.Close();
                    }
                    break;
            }
        }

        private void spaceracer_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void spaceracer_Paint(object sender, PaintEventArgs e)
        {
           
            if (mainmenue == "waiting")
            {

                Score1lable.Text = "";

                Titlelable.Text = "SPACE RACER";
                Subtitlelable.Text = "Press Space to start or Esc to exit";
                

            }
            else if (mainmenue == "gameover")
            {

                Score1lable.Text = $"Player 1 Score: {player1score}";
                Score2lable.Text = $"Player 2 Score: {player2score}";

                Titlelable.Text = "GAME OVER";
                Subtitlelable.Text = "Press Space to start or Esc to exit";
                Astroidtimer.Enabled = false;
            }
            else if (mainmenue == "winning")
            {

                Titlelable.Text = "GAME OVER";
                Subtitlelable.Text = "Press Space to start or Esc to exit";
                Astroidtimer.Enabled = false;
            }
            else if (mainmenue == "running")
            {
                Titlelable.Visible = false;
                Subtitlelable.Visible = false;

                //update labels
                Score1lable.Text = $"Score: {player1score}";
                //update labels
                Score2lable.Text = $"Score: {player2score}";
                //draw hero
                e.Graphics.FillRectangle(redBrush, player1);
                e.Graphics.FillRectangle(yellowBrush, player2);
                e.Graphics.FillRectangle(whiteBrush, line);

                //draw balls
                for (int i = 0; i < astroids.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, astroids[i]);
                }
                Astroidtimer.Enabled = true;
        }   }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //Titlelable.Visible = false;
            //Subtitlelable.Visible = false;
         


            if (wDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (sDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            

            if (upArrowDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }
            if (downArrowDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }

            randValue = randgen.Next(1, 100);

            if (randValue < 50)
            {

                astroidspeed.Add(randgen.Next(2, 11));
                astroidsize.Add(randgen.Next(5, 15));
                int x = randgen.Next(1, 550);
                Rectangle newastroid = new Rectangle(x, 0, 20, 20);
                astroids.Add(newastroid);
               

            }
            //Move all the balls
            for (int i = 0; i < astroids.Count(); i++)
            {
                //get new possision of y based on speed
                int x = astroids[i].X + astroidspeed[i];
                astroids[i] = new Rectangle(astroids[i].Y, x, astroidsize[i], astroidsize[i]);
            }

            for (int i = 0; i < astroids.Count(); i++)
            {

                if (astroids[i].IntersectsWith(player1))
                {
                    astroids.RemoveAt(i);
                    astroidspeed.RemoveAt(i);
                    astroidsize.RemoveAt(i);

                }
                else if (astroids[i].IntersectsWith(player2))
                {
                    astroids.RemoveAt(i);
                   astroidspeed.RemoveAt(i);
                    astroidsize.RemoveAt(i);
                }
            }
            Refresh();
        }
    }
}
