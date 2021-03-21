using Entitas;
using UnityEngine;

namespace SemoGames.Common
{
    [Game]
    public class CircleColliderComponent : IComponent
    {
        public CircleCollider2D Value;
    }
}