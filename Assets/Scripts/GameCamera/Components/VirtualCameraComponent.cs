using Cinemachine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SemoGames.GameCamera
{
    [Game, Unique]
    public class VirtualCameraComponent : IComponent
    {
        public CinemachineVirtualCamera Value;
    }
}