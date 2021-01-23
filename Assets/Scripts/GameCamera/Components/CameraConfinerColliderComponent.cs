using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace SemoGames.GameCamera
{
    [Game, Unique]
    public class CameraConfinerColliderComponent : IComponent
    {
        public Collider2D Value;
    }
}