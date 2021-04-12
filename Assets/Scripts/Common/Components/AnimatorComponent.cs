using Entitas;
using UnityEditor.Animations;
using UnityEngine;

namespace SemoGames.Common
{
    [Game]
    public class AnimatorComponent : IComponent
    {
        public Animator Value;
    }
}