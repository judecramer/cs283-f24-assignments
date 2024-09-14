using System;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

public class Game
{
    //Static variables that may be tweaked
    private static String BACKGROUND = "Background.jpg";
    //private static float STARTX = 100;
    //private static float STARTY = 100;
    private static int BALLSIZE = 15;
    private static int HOLESIZE = 40;
    private static float GRAVITY = 15f;

    //Internal game-wide objects
    private System.Drawing.Image backgroundIMG = null;
    private Ball mainGuy;
    private Hole blackHole;
    private Boolean isVisible = true;

    //called once upon opening
    public void Setup()
    {
        backgroundIMG = System.Drawing.Image.FromFile(BACKGROUND);             //Load image
        mainGuy = new Ball(BALLSIZE, GRAVITY);
        blackHole = new Hole(HOLESIZE);
    }

    //called once per frame. dt = elapsed time in seconds
    public void Update(float dt)
    {
        mainGuy.Update(dt, blackHole);
  
    }

    //called when the window is refreshed
    public void Draw(Graphics g)
    {
        g.DrawImage(backgroundIMG, 0, 0, Window.width, Window.height);
        mainGuy.Draw(g);
        blackHole.Draw(g);

        //draw bounce counter
        Brush labelBrush = new SolidBrush(Color.White);
        g.FillRectangle(labelBrush, 2, 2, 100, 20);

        Font font = new Font("Arial", 10);
        Brush fontBrush = new SolidBrush(Color.Black);
        if (mainGuy.State == 0)
        {
            g.DrawString("Click to shoot!", font, fontBrush, 4, 4);
        } else
        {
            g.DrawString("Bounces: " + (mainGuy.Bounces + 1), font, fontBrush, 4, 4);
        }


        if (isVisible)
        {
            g.FillRectangle(labelBrush, 2, Window.height - 22, 220, 20);
            g.DrawString("BALL GAME by Jude Cramer (2026)", font, fontBrush, 4, Window.height - 20);
        }
        
    }

    //called when the user clicks with a mouse (location returned as an integer)
    public void MouseClick(MouseEventArgs mouse)
    {
        if (mouse.Button == MouseButtons.Left)
        {
            if (mainGuy.State == 0)
            {
                mainGuy.Shoot(mouse.Location.X, mouse.Location.Y);
            }
            System.Console.WriteLine(mouse.Location.X + ", " + mouse.Location.Y);
        }
    }

    //called when a key is pressed
    public void KeyDown(KeyEventArgs key)
    {
        if (key.KeyCode == Keys.Oemplus || key.KeyCode == Keys.Add)
        {
            if (isVisible)
            {
                isVisible = false;
            } else
            {
                isVisible = true;
            }
        }
        /*else if (key.KeyCode== Keys.S || key.KeyCode == Keys.Down)
        {
        }
        else if (key.KeyCode == Keys.A || key.KeyCode == Keys.Left)
        {
        }
        else if (key.KeyCode == Keys.W || key.KeyCode == Keys.Up)
        {
        }*/
    }
}
