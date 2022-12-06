using AreaCalculatingLib.Interfaces;

namespace AreaCalculatingLib.Figures;

public class Triangle : IHasAreaFigure
{
    private readonly TriangleData _triangleData;

    public Triangle(TriangleData triangleData)
    {
        Validate(triangleData);
        _triangleData = triangleData;
    }

    public double CalculateArea()
    {
        var halfPerimeter = (_triangleData.A + _triangleData.B + _triangleData.C) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - _triangleData.A) * (halfPerimeter - _triangleData.B) *
                         (halfPerimeter - _triangleData.C));
    }

    public bool IsRectangular()
    {
        return _triangleData.A * _triangleData.A + _triangleData.B * _triangleData.B -
               _triangleData.C * _triangleData.C == 0
               || _triangleData.A * _triangleData.A + _triangleData.C * _triangleData.C -
               _triangleData.B * _triangleData.B == 0
               || _triangleData.C * _triangleData.C + _triangleData.B * _triangleData.B -
               _triangleData.A * _triangleData.A == 0;
    }

    private static void Validate(TriangleData triangleData)
    {
        if (triangleData is null)
        {
            throw new ArgumentException();
        }

        var triangleIsValid = triangleData.A > 0
                              && triangleData.B > 0
                              && triangleData.C > 0
                              && triangleData.A + triangleData.B > triangleData.C
                              && triangleData.A + triangleData.C > triangleData.B
                              && triangleData.B + triangleData.C > triangleData.A;
        if (!triangleIsValid)
        {
            throw new ArgumentException("Треугольник с такими сторонами не существует");
        }
    }
}