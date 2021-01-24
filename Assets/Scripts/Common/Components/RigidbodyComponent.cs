using Entitas;
using UnityEngine;

namespace SemoGames.Common
{
    [Game]
    public class RigidbodyComponent : IComponent
    {
        public Rigidbody2D Value;
    }
}