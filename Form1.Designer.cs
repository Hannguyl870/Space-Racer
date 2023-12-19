namespace Space_Race
{
    partial class spaceracer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(spaceracer));
            this.Titlelable = new System.Windows.Forms.Label();
            this.Finishlinelable = new System.Windows.Forms.Label();
            this.Score1lable = new System.Windows.Forms.Label();
            this.Score2lable = new System.Windows.Forms.Label();
            this.Subtitlelable = new System.Windows.Forms.Label();
            this.Astroidtimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Titlelable
            // 
            this.Titlelable.BackColor = System.Drawing.Color.Transparent;
            this.Titlelable.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlelable.ForeColor = System.Drawing.Color.White;
            this.Titlelable.Location = new System.Drawing.Point(3, 54);
            this.Titlelable.Name = "Titlelable";
            this.Titlelable.Size = new System.Drawing.Size(699, 84);
            this.Titlelable.TabIndex = 0;
            this.Titlelable.Text = "Titlelable";
            this.Titlelable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Finishlinelable
            // 
            this.Finishlinelable.Image = ((System.Drawing.Image)(resources.GetObject("Finishlinelable.Image")));
            this.Finishlinelable.Location = new System.Drawing.Point(-32, -1);
            this.Finishlinelable.Name = "Finishlinelable";
            this.Finishlinelable.Size = new System.Drawing.Size(734, 23);
            this.Finishlinelable.TabIndex = 2;
            // 
            // Score1lable
            // 
            this.Score1lable.BackColor = System.Drawing.Color.Transparent;
            this.Score1lable.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score1lable.ForeColor = System.Drawing.Color.White;
            this.Score1lable.Location = new System.Drawing.Point(76, 22);
            this.Score1lable.Name = "Score1lable";
            this.Score1lable.Size = new System.Drawing.Size(151, 23);
            this.Score1lable.TabIndex = 4;
            this.Score1lable.Text = "Score1lable";
            this.Score1lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Score2lable
            // 
            this.Score2lable.BackColor = System.Drawing.Color.Transparent;
            this.Score2lable.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score2lable.ForeColor = System.Drawing.Color.White;
            this.Score2lable.Location = new System.Drawing.Point(473, 22);
            this.Score2lable.Name = "Score2lable";
            this.Score2lable.Size = new System.Drawing.Size(153, 23);
            this.Score2lable.TabIndex = 5;
            this.Score2lable.Text = "Score2lable";
            this.Score2lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Subtitlelable
            // 
            this.Subtitlelable.BackColor = System.Drawing.Color.Transparent;
            this.Subtitlelable.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitlelable.ForeColor = System.Drawing.Color.White;
            this.Subtitlelable.Location = new System.Drawing.Point(3, 167);
            this.Subtitlelable.Name = "Subtitlelable";
            this.Subtitlelable.Size = new System.Drawing.Size(699, 112);
            this.Subtitlelable.TabIndex = 6;
            this.Subtitlelable.Text = "Subtitlelable";
            this.Subtitlelable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Astroidtimer
            // 
            this.Astroidtimer.Interval = 50;
            this.Astroidtimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // spaceracer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.Subtitlelable);
            this.Controls.Add(this.Score2lable);
            this.Controls.Add(this.Score1lable);
            this.Controls.Add(this.Finishlinelable);
            this.Controls.Add(this.Titlelable);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "spaceracer";
            this.Text = "Space Racer ";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.spaceracer_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spaceracer_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.spaceracer_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Titlelable;
        private System.Windows.Forms.Label Finishlinelable;
        private System.Windows.Forms.Label Score1lable;
        private System.Windows.Forms.Label Score2lable;
        private System.Windows.Forms.Label Subtitlelable;
        private System.Windows.Forms.Timer Astroidtimer;
    }
}

