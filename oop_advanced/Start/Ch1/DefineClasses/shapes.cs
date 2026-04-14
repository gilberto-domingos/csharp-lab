class Retangle
{
    int width;
    int height;

    public Retangle(int w, int h)
    {
        width = w;
        height = h;
    }

    public Retangle(int side)
    {
        width = height = side;
    }

    public int GetArea()
    {
        return width * height;
    }

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public int Height
    {
        get { return height; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Height", "must be >=0");
            }
            height = value;
        }
    }

    public int BorderSize
    {
        get; set;
    } = 1;
}