using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

namespace Space_Race
{


    public partial class spaceracer : Form
    {

        SoundPlayer sp;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        List<Rectangle> astroids1 = new List<Rectangle>();
        List<Rectangle> astroids2 = new List<Rectangle>();

        List<int> astroidspeed = new List<int>();
        List<int> astroidsize = new List<int>();
        //List<SolidBrush> colours = new List<SolidBrush>();
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Pen white = new Pen(Color.White);
        string mainmenue = "waiting";

        Rectangle player1 = new Rectangle(150, 300, 15, 20);
        Rectangle player2 = new Rectangle(350, 300, 15, 20);

        Rectangle lighta = new Rectangle(150, 320, 5, 10);
        Rectangle lightb = new Rectangle(160, 320, 5, 10);

        //PictureBox flame1 = new PictureBox();

        Rectangle line = new Rectangle(260, 40, 10, 300);

        int light1speed = 4;

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

            astroids1.Clear();
            astroids2.Clear();
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
                    if (mainmenue == "waiting" || mainmenue == "player1winning" || mainmenue == "player2winning")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (mainmenue == "waiting" || mainmenue == "player1winning"|| mainmenue == "player2winning")
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
            Graphics g = this.CreateGraphics();

            if (mainmenue == "waiting")
            {

                Score1lable.Text = "";

                Titlelable.Text = "SPACE RACER";
                Subtitlelable.Text = "Press Space to start or Esc to exit";
                
            }
           
            else if (mainmenue == "player1winning")
            {
                Titlelable.Visible = true;
                Subtitlelable.Visible = true;

                Score1lable.Text = "You Win";
                Score2lable.Text = "You lose";

                Titlelable.Text = "player 1 wins ";
                Subtitlelable.Text = "Press Space to start or Esc to exit";

               
                Astroidtimer.Enabled = false;
            }
            else if (mainmenue == "player2winning")
            {
              
                Titlelable.Visible = true;
                Subtitlelable.Visible = true;

                Score1lable.Text = "You lose";
                Score2lable.Text = "you win";

                Titlelable.Text = "player 2 wins ";
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

                e.Graphics.FillRectangle(yellowBrush, lighta);
                e.Graphics.FillRectangle(yellowBrush, lightb);


                //g.DrawPie(white, -25, 6, 90, 90, 30, 60);
                //e.Graphics.FillPie(whiteBrush, rocket);

                //draw balls
                for (int i = 0; i < astroids1.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, astroids1[i]);
                }
                Astroidtimer.Enabled = true;

                for (int i = 0; i < astroids2.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, astroids2[i]);
                }
                Astroidtimer.Enabled = true;
            }   }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //Titlelable.Visible = false;
            //Subtitlelable.Visible = false;


            if (upArrowDown == true && player2.Y > Finishlinelable.Height-3)
            {
                player2.Y -= player1Speed;
                
                
            }
            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player1Speed;
               
            }


            if (wDown == true && player1.Y > Finishlinelable.Height-3)
            {
               
                player1.Y -= player1Speed;
                //lighta.Y -= light1speed;
                //lightb.Y -= light1speed;

            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player2Speed;
               
            }
            

            
            // make balls
            randValue = randgen.Next(1, 10);

            if (randValue < 2)
            {

                astroidspeed.Add(randgen.Next(1,5));
                astroidsize.Add(randgen.Next(5, 15));
                int y = randgen.Next(20, 400);
                Rectangle newastroid1 = new Rectangle(0, y, 20, 20);
                astroids1.Add(newastroid1);
               

            }
            if (randValue > 8)
            {
                astroidspeed.Add(randgen.Next(1, 5));
                astroidsize.Add(randgen.Next(5, 15));
                int y = randgen.Next(20, 400);
                Rectangle newastroid2 = new Rectangle(800, y, 20, 20);
                astroids2.Add(newastroid2);
            }
            //Move all the balls
            randValue = randgen.Next(1, 800);
            for (int i = 0; i < astroids1.Count(); i++)
            {
                //get new possision of y based on speed
                
                int x = astroids1[i].X + astroidspeed[i] ;
                astroids1[i] = new Rectangle(x,astroids1[i].Y,astroidsize[i],astroidsize[i]);
                
            }

            for (int i = 0; i < astroids2.Count(); i++)
            {
                //get new possision of y based on speed

                int x = astroids2[i].X - astroidspeed[i];
                astroids2[i] = new Rectangle(x, astroids2[i].Y, astroidsize[i], astroidsize[i]);
               
            }

            for (int i = 0; i < astroids1.Count(); i++)
            {

                if (astroids1[i].IntersectsWith(player1))
                {
                    astroids1.RemoveAt(i);
                    astroidspeed.RemoveAt(i);
                    astroidsize.RemoveAt(i);
                    player1.Y = 300;
                    sp = new SoundPlayer(Properties.Resources.explotion);
                    sp.Play();

                }
               
                else if (astroids1[i].IntersectsWith(player2))
                {
                    astroids1.RemoveAt(i);
                   astroidspeed.RemoveAt(i);
                    astroidsize.RemoveAt(i);
                    player2.Y = 300;
                    sp = new SoundPlayer(Properties.Resources.explotion);
                    sp.Play();
                }
            

                else if (player1.Y < Finishlinelable.Height)
                {
                    player1.Y = 300;
                    player1score++;

                    Score1lable.Text = $"{player1score}";
                }
                else if (player2.Y < Finishlinelable.Height)
                {
                    player2.Y = 300;
                    player2score++;
                    Score2lable.Text = $"{player2score}";
                }

                if (player1score == 2)
                {
                    Astroidtimer.Enabled = false;
                    mainmenue = "player1winning";
                }
                else if (player2score == 2)
                {
                    Astroidtimer.Enabled = false;
                    mainmenue = "player2winning";
                }
            }
            for (int i = 0; i < astroids2.Count(); i++)
            {
                //astroids2 
                if (astroids2[i].IntersectsWith(player1))
                {
                    astroids2.RemoveAt(i);
                    astroidspeed.RemoveAt(i);
                    astroidsize.RemoveAt(i);
                    player1.Y = 300;
                    sp = new SoundPlayer(Properties.Resources.explotion);
                    sp.Play();
                }
                else if (astroids2[i].IntersectsWith(player2))
                {
                    astroids2.RemoveAt(i);
                    astroidspeed.RemoveAt(i);
                    astroidsize.RemoveAt(i);
                    player2.Y = 300;
                    sp = new SoundPlayer(Properties.Resources.explotion);
                    sp.Play();
                }
                else if (player2.Y < Finishlinelable.Height)
                {
                    player2.Y = 300;
                    player2score++;
                    Score2lable.Text = $"{player2score}";
                }
                if (player1score == 2)
                {
                    Astroidtimer.Enabled = false;
                    mainmenue = "player1winning";
                }
                else if (player2score == 2)
                {
                    Astroidtimer.Enabled = false;
                    mainmenue = "player2winning";
                }

            }
               
            Refresh();
        }
    }
}
