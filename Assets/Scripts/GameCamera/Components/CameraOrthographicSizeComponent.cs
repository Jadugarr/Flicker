using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace SemoGames.GameCamera
{
    [Game, Unique]
    public class CameraOrthographicSizeComponent : IComponent
    {
        public float Value;
    }
}