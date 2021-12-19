using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forsa_Horison_8
{
    public partial class Form1 : Form
    {
        int timerSpeed;
        int gameSpeed;
        int carTurnSpeed;
        bool isGameOver;

        PictureBox[] roadlines;
        PictureBox[] enemys;
        PictureBox[] coins;
        Random random;
        int collectedCoins;

        public Form1()
        {
            InitializeComponent();
            init_game();
        }
        void init_game()
        {
            timerSpeed = 1000;
            gameSpeed = 4;
            carTurnSpeed = 15;
            isGameOver = false;

            roadlines = new PictureBox[] { pbRoadLine1, pbRoadLine2, pbRoadLine3, pbRoadLine4 };
            enemys = new PictureBox[] { Enemy1, Enemy2, Enemy3 };
            coins = new PictureBox[] { Coin1, Coin2, Coin3, Coin4 };
            random = new Random();
            collectedCoins = 0;

            gen_start_pos();

            Car.Image = Properties.Resources.car;
            lblGameOver.Visible = false;

            GameTimer.Interval = 10000 / timerSpeed;
            GameTimer.Start();
        }




        void gen_start_pos()
        {
            int startY = -Enemy1.Height;
            int x;
            for (int i = 0; i < enemys.Length; i++)
            {
                x = random.Next(pbBoundLeft.Right, pbBoundRight.Left);
                enemys[i].Location = new Point(x, startY);
                startY -= this.Height / enemys.Length;
            }
        }

        void move_enemys()
        {
            int x;
            for (int i = 0; i < enemys.Length; i++)
            {
                if (enemys[i].Top > this.Height)
                {
                    x = random.Next(pbBoundLeft.Right, pbBoundRight.Left);
                    enemys[i].Location = new Point(x, -enemys[i].Height);
                }
                else
                {
                    enemys[i].Top += gameSpeed;
                }
            }
        }

        void move_coins()
        {
            int x;
            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i].Top > this.Height)
                {
                    x = random.Next(pbBoundLeft.Right, pbBoundRight.Left - coins[i].Width);
                    coins[i].Location = new Point(x, -coins[i].Height);
                }
                else
                {
                    coins[i].Top += gameSpeed;
                }
            }
        }

        void move_lines()
        {
            int x;
            for (int i = 0; i < roadlines.Length; i++)
            {
                if (roadlines[i].Top > this.Height)
                {
                    roadlines[i].Top = -roadlines[i].Height;
                }
                else
                {
                    roadlines[i].Top += gameSpeed;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            move_enemys();
            move_coins();
            move_lines();
        }
    }
}
