using AreaCalculatingLib.Figures;

namespace AreaCalculatingLib.Interfaces;

public interface IAbstractFigureFactory
{
    Circle CreateCircle(CircleData circleData);
    Triangle CreateTriangle(TriangleData triangleData);
    bool TryGetArea(object obj, out double area);
}