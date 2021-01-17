using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace SemoGames.GameCamera
{
    [Game,Unique]
    public class CameraComponent : IComponent
    {
        public Camera Value;
    }
}