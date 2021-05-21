using Entitas;
using UnityEngine;

namespace SemoGames.Common
{
    [Game]
    public class BoxColliderComponent : IComponent
    {
        public BoxCollider2D Value;
    }
}