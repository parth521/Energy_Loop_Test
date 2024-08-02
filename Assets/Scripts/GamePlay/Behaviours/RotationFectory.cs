using System;
using System.Collections.Generic;


public class RotationFectory :Singleton<RotationFectory>
{
    private readonly Dictionary<GameElementType, IRotation> strategies = new Dictionary<GameElementType, IRotation>
    {
        { GameElementType.Square, new SqureRotation() },
        { GameElementType.Hexagon, new HexagonRotation() }
        // Add more mappings here for other GameElementType
    };

    public IRotation GetStrategy(GameElementType elementType)
    {
        if (strategies.TryGetValue(elementType, out var strategy))
        {
            return strategy;
        }

        throw new NotImplementedException($"No rotation strategy implemented for {elementType}");
    }
}
