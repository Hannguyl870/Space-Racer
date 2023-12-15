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
        List<SolidBrush> colours = new List<SolidBrush>();


        string mainmenue = "waiting";

        Rectangle player1 = new Rectangle(150, 200, 20, 20);
        Rectangle player2 = new Rectangle(450, 200, 20, 20);
        int player1score = 0;
        int player2score = 0;

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

            Astroidtimer.Enabled = false;

            player1score = 0;
            player2score = 0;

            astroids.Clear();
            astroidspeed.Clear();
            colours.Clear();

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

                Titlelable.Text = "CATCH GAME";
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
                //update labels
                Score1lable.Text = $"Score: {player1score}";
                //update labels
                Score2lable.Text = $"Score: {player2score}";
                //draw hero
                //e.Graphics.FillRectangle(lightblueBrush, player);

                //draw balls
                for (int i = 0; i < astroids.Count(); i++)
                {
                    e.Graphics.FillEllipse(colours[i], astroids[i]);
                }
                Astroidtimer.Enabled = true;
        }   }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
