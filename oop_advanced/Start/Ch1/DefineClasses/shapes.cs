class Retangle
{
    public int width;
    public int height;

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
}