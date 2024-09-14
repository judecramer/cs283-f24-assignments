using System;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

public class Hole
{
    private int holesize = 40;
    public int Holesize
    {
        get { return holesize; }
    }

    private float holex = 0;
    public float Holex
    {
        get { return holex; }
        set { holex = value; }
    }

    private float holey = 0;
    public float Holey
    {
        get { return holey; }
        set { holey = value; }
    }
    private Random rand;

    public Hole(int size)   //CONSTRUCTOR
	{
        rand = new Random(69);
        holesize = size;
        Place();
    }

    public void Place()
    {
        holex = (float)rand.NextDouble() * ((float)Window.width - 40f) + 2f;
        holey = (float)rand.NextDouble() * ((float)Window.height - 40f) + 2f;
    }

    public void Draw(Graphics g)                            //draw
    {
        Brush brush = new SolidBrush(Color.Black);
        g.FillEllipse(brush, holex, holey, holesize, holesize);
    }

}
