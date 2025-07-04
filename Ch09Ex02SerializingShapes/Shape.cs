
public abstract class Shape
{
    public string Colour { get; set; } = null!;

}

public class Circle : Shape
{
    public double Radius { get; set; }
    public double Area
    {
        get
        {
            return Math.PI * Radius * Radius;
        }
    }
}

public class Rectangle : Shape
{
    public double Height { get; set; }
    public double Width { get; set; }

    public double Area
    {
        get
        {
            return Height * Width;
        }
    }

}