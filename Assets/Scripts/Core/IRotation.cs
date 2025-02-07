using System;
public interface IRotationStrategy
{
    void Start();
    void Rotate(GameElement gameElement);
}
public interface IRotatable
{
    void SetRotationStrategy(IRotationStrategy strategy);
    void Rotate();
}
