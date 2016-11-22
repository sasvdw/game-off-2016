using UnityEngine;

namespace GGO2016.Domain.Ships
{
    public interface IVelocityComponent
    {
        Vector2 CurrentVelocity { get; }
    }
}