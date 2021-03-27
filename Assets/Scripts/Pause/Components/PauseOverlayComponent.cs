using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine.UI;

namespace SemoGames.Pause
{
    [Game, Unique]
    public class PauseOverlayComponent : IComponent
    {
        public Image Value;
    }
}