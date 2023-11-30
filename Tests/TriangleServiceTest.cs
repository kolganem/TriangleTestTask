using NUnit.Framework;
using Triangle;

namespace Tests;

public class Tests
{
    [TestCase(3, 4, 5, TriangleTypeEnum.Rectangular)]
    [TestCase(5, 12, 13, TriangleTypeEnum.Rectangular)] 
    [TestCase(8.4, 7.2, 9.1, TriangleTypeEnum.AcuteAngled)]
    [TestCase(8, 7, 9, TriangleTypeEnum.AcuteAngled)]
    [TestCase(2, 5, 8, TriangleTypeEnum.Obtuse)]
    [TestCase(1, 4, 7, TriangleTypeEnum.Obtuse)]
    [TestCase(-12, 14, 5, TriangleTypeEnum.NotExist)]
    [TestCase(12, -14, 5, TriangleTypeEnum.NotExist)]
    [TestCase(12, 14, -5, TriangleTypeEnum.NotExist)]
    [TestCase(0, 14, 5, TriangleTypeEnum.NotExist)]
    [TestCase(12, 0, 5, TriangleTypeEnum.NotExist)]
    [TestCase(12, 14, 0, TriangleTypeEnum.NotExist)]
    [TestCase(0, 0, 0, TriangleTypeEnum.NotExist)]
    public void CheckGetTriangleType(double firstSide, double secondSide, double thirdSide, TriangleTypeEnum expectedResult)
    {
        TriangleService triangleService = new(firstSide, secondSide, thirdSide);
        string type = triangleService.GetTriangleType();
        
        StringAssert.AreEqualIgnoringCase(expectedResult.ToString(), type);
    }
    
}