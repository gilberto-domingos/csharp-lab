class Shape2D {
    public Shape2D() {}

    public virtual float GetArea()
    {
        return 0.0f;
    }

    public override string ToString() => $"This object is a '{GetType()}'";
}

class Circle : Shape2D {
    public Circle(int r) {
        radius = r;
    }

    public override float GetArea()
    {
        return (3.14f * (radius * radius));
    }

    int radius;
}

class Rectangle : Shape2D {
    public Rectangle(int w, int h) {
        width = w;
        height = h;
    }

    // TODO: Override the GetArea() function for the Rectangle
    public override float GetArea()
    {
        return width * height;
    }

    int width;
    int height; 
}

class Square : Rectangle
{
    public Square(int side) : base (side, side){}
}
