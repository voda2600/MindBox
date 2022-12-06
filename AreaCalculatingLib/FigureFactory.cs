using AreaCalculatingLib.Figures;
using AreaCalculatingLib.Interfaces;

namespace AreaCalculatingLib;

public class FigureFactory : IAbstractFigureFactory
{
    public Circle CreateCircle(CircleData circleData)
    {
        return new Circle(circleData);
    }

    public Triangle CreateTriangle(TriangleData triangleData)
    {
        return new Triangle(triangleData);
    }
    
    public bool TryGetArea(object obj, out double area)
    {
        if (obj is IHasAreaFigure figure)
        {
            area = figure.CalculateArea();
            return true;
        }

        area = default;
        return false;
    }
}