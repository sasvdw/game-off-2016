using UnityEngine;

namespace GOO2016.Domain.Gravity
{
    public interface IPositionProvider
    {
        Vector2 Position { get; }
    }
}