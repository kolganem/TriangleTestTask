namespace Triangle;
public class TriangleService 
{
    private readonly double _firstSideLength;
    private readonly double _secondSideLength;
    private readonly double _thirdSideLength;
    private readonly double[] _sides;

    public TriangleService(double firstSideLength, double secondSideLength, double thirdSideLength)
    {
        _firstSideLength = firstSideLength;
        _secondSideLength = secondSideLength;
        _thirdSideLength = thirdSideLength;
        _sides = new[] { firstSideLength, secondSideLength, thirdSideLength };
    }

    public string GetTriangleType()
    {
        TriangleTypeEnum type = TriangleTypeEnum.Notfound;
        
        if (IsNotValid())
        {
            type = TriangleTypeEnum.NotExist;
        }
        else
        {
            double maxSideLength = GetMaxSideLength();
            double maxSideSquare = maxSideLength * maxSideLength;
            double sumSquareOtherTwoSides = GetSquaresSumOtherTwoSides(maxSideLength);

            if (maxSideSquare > sumSquareOtherTwoSides)
            {
                type = TriangleTypeEnum.Obtuse;
            }
            else if (maxSideSquare < sumSquareOtherTwoSides)
            {
                type = TriangleTypeEnum.AcuteAngled;
            }
            else if(Math.Abs(maxSideSquare - sumSquareOtherTwoSides) < double.Epsilon)
            {
                type = TriangleTypeEnum.Rectangular;
            }
        }


        return type.ToString();
    }
    
    private double GetSquaresSumOtherTwoSides(double maxSideLength)
    {
        double sumOtherTwoSides = 0;

        foreach (double side in _sides)
        {
            if (Math.Abs(maxSideLength - side) > double.Epsilon)
            {
                sumOtherTwoSides += side * side;
            }
        }

        return sumOtherTwoSides;
    }

    private double GetMaxSideLength()
    {
        double max = 0;
        
        if (_firstSideLength > max)
        {
            max = _firstSideLength;
        }

        if (_secondSideLength > max)
        {
            max = _secondSideLength;
        }
        
        if (_thirdSideLength > max)
        {
            max = _thirdSideLength;
        }

        return max;

    }

    private bool IsNotValid()
    {
        return _firstSideLength <= 0 ||
               _secondSideLength <= 0 ||
               _thirdSideLength <= 0;
    }
}
