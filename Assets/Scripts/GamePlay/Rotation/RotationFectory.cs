using System;
using System.Collections.Generic;

public class RotationFectory : Singleton<RotationFectory>
{
    private readonly IRotationStrategy hexagonRotation = new HexagonRotation();
    private readonly IRotationStrategy squareRotation = new SqureRotation();

    public IRotationStrategy GetStrategy(GameElement element)
    {
        return element.UseHexagonRotation ? hexagonRotation : squareRotation;
    }
}