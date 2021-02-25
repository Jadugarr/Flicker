using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace SemoGames.GameInput
{
    [Game, Unique]
    public class MousePositionComponent : IComponent
    {
        public Vector2 Value;
    }
}