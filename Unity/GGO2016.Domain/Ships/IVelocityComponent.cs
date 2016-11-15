using UnityEngine;

namespace GOO2016.Domain.Ships
{
    public interface IVelocityComponent
    {
        Vector2 CurrentVelocity { get; }
    }
}