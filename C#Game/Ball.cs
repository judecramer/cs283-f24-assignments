using System;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

public class Ball
{

	private int ballsize = 10;
	public int Ballsize
	{
		get { return ballsize; }
	}

	private float ballx = 0;
	public float Ballx
	{
		get { return ballx; }
		set { ballx = value;  }
	}

	private float bally = 0;
    public float Bally
    {
        get { return bally; }
        set { bally = value; }
    }

    private float ballvx = 10;
	public float xvelocity
	{
		get { return ballvx; }
		set { ballvx = value;  }
	}
    private float ballvy = 10;
    public float yvelocity
    {
        get { return ballvy; }
        set { ballvy = value; }
    }

	private float gravity = 1;
	public float Gravity
	{
		get { return gravity; }
		set { gravity = value; }
	}

	public const int BOUNCES = 2;
	private int bounces = BOUNCES;
	public int Bounces
	{
		get { return bounces; }
		set { bounces = value;  }
	}

	// CURRENT BALL STATE
	//0: no gravity, pinned in place. waiting for mouse click
	//1: moving, affected by gravity
	private int state = 0; 
	public int State
	{
		get { return state; }
		set { state = value;  }
	}

	private Random rand;

    public Ball(int size, float x, float y, float grav)
	{
		ballsize = size;
		ballx = x;
		bally = y;
		gravity = grav;
		state = 0;

		rand = new Random();

	}

    public Ball(int size, float grav) //constructed with a random placement
    {
        rand = new Random(420);
        ballsize = size;
        gravity = grav;
		Place();
        state = 0;
    }


    public void Update(float dt, Hole blackHole)							//Update
    {
		if (state == 1)     //code runs when ball is in moving state (1)
		{
			yvelocity += gravity;   //gravity applied
			yvelocity *= .99f;      //air resistance
			xvelocity *= .99f;
			ballx = ballx + xvelocity * dt;
			bally = bally + yvelocity * dt;

			//BORDER COLLISION
			if (ballx + ballsize > Window.width || ballx < 0)
			{
				xvelocity = xvelocity * -1f;
				bounces--;
			}
			if (bally + ballsize > Window.height || bally < 0)
			{
				yvelocity = yvelocity * -1f;
				bounces--;
			}

			//BOUNCE COUNTER
			if (bounces < 0)
			{
				state = 0;
				xvelocity = 0;
				yvelocity = 0;
				Place();
				//blackHole.Place();
			}

		}

		//DETECTS COLLISION WITH HOLE
		if (DetectCollision(blackHole)) {

			Place();
			blackHole.Place();
		}
		
    }

	public void Draw(Graphics g)							//draw
	{	
        Brush brush = new SolidBrush(Color.Cornsilk);
        g.FillEllipse(brush, ballx, bally, ballsize, ballsize);
    }

	public void Shoot(int mouseX, int mouseY)
	{
		state = 1;
		bounces = BOUNCES;
		xvelocity = ((float)mouseX - ballx)*2f;
		yvelocity = ((float)mouseY - bally)*2f;
	}

	public void Place()
    {
        ballx = (float)rand.NextDouble() * ((float)Window.width - 20f) + 10f;
        bally = (float)rand.NextDouble() * ((float)Window.height - 20f) + 10f;
	}

	public Boolean DetectCollision(Hole blackHole)
	{
		if (ballx > blackHole.Holex && ballx < blackHole.Holex+blackHole.Holesize  &&  bally > blackHole.Holey && bally < blackHole.Holey + blackHole.Holesize)
		{
			//collision detected
			return true;
		} else
		{
			return false;
		}
	}

}
