using System;
using AreaCalculatingLib;
using AreaCalculatingLib.Figures;
using Xunit;

namespace AreaLibTest;

public class FigureLibTest
{
    [Fact]
    public void TestCircleArea()
    {
        var c = new Circle(new CircleData() { R = 10 });
        var c2 = new Circle(new CircleData() { R = 99 });
        Assert.Equal(Math.Round(Math.PI * 10 * 10, 3), Math.Round(c.CalculateArea(), 3));
        Assert.Equal(Math.Round(Math.PI * 99 * 99, 3), Math.Round(c2.CalculateArea(), 3));
    }

    [Fact]
    public void TestInvalidCircle()
    {
        Assert.Throws<ArgumentException>(() => new Circle(new CircleData() { R = -1 }));
    }

    [Fact]
    public void TestNullRadiusCircle()
    {
        Assert.Throws<ArgumentException>(() => new Circle(null));
    }

    [Fact]
    public void TestZeroCircle()
    {
        var c = new Circle(new CircleData() { R = 0 });
        Assert.Equal(0, c.CalculateArea());
    }

    [Fact]
    public void TestTriangleArea()
    {
        var t = new Triangle(new TriangleData()
        {
            A = 3,
            B = 4,
            C = 5
        });
        Assert.Equal(6, t.CalculateArea());
    }

    [Fact]
    public void TestInvalidTriangle()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(new TriangleData()
        {
            A = 1,
            B = 2,
            C = 3
        }));

        Assert.Throws<ArgumentException>(() => new Triangle(new TriangleData()
        {
            A = -3,
            B = 4,
            C = 5
        }));

        Assert.Throws<ArgumentException>(() => new Triangle(null));
    }

    [Fact]
    public void TestRectangularTriangle()
    {
        var rectangular = new Triangle(new TriangleData()
        {
            A = 29,
            B = 20,
            C = 21
        });
        var notRectangular = new Triangle(new TriangleData()
        {
            A = 5,
            B = 5,
            C = 3
        });
        Assert.True(rectangular.IsRectangular());
        Assert.False(notRectangular.IsRectangular());
    }

    [Fact]
    public void TestFigureFactory()
    {
        var factory = new FigureFactory();
        var circle = factory.CreateCircle(new CircleData()
        {
            R = 10
        });
        var triangle = factory.CreateTriangle(new TriangleData()
        {
            A = 3,
            B = 4,
            C = 5
        });

        Assert.NotNull(circle);
        Assert.NotNull(triangle);
    }

    [Fact]
    public void TestTryGetAreaFactory()
    {
        var factory = new FigureFactory();
        var circle = factory.CreateCircle(new CircleData()
        {
            R = 2
        });

        var objCircle = (object)circle;
        var isAreaCalculated = factory.TryGetArea(objCircle, out var area);
        
        var objInt = (object)25;
        var isAreaCalculatedForInt = factory.TryGetArea(objInt, out var areaInt);
        
        Assert.True(isAreaCalculated);
        Assert.Equal(Math.PI * 4, area);
        Assert.False(isAreaCalculatedForInt);
    }
}