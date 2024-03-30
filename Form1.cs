using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int gravity = 15;
        int pipeSpeed = 8;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15; 
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipe.Left -= pipeSpeed;
            pipedown.Left -= pipeSpeed;
            scoreText.Text = "Score:" + score;
            if(pipe.Left < -100)
            {
                pipe.Left = 650;
                score++;
            }
            if (pipedown.Left < -150)
            {
                pipedown.Left = 700;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipe.Bounds)|| flappyBird.Bounds.IntersectsWith(pipedown.Bounds)||flappyBird.Bounds.IntersectsWith(ground.Bounds)|| flappyBird.Top < -25)
            {
                gameover();
             
            }
        }

        private void gameover()
        {
              timer1.Stop();
            scoreText.Text = "Game Over!! Score:" + score;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }
    }
}
