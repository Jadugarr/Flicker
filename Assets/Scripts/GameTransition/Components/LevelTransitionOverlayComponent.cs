using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine.UI;

namespace SemoGames.GameTransition
{
    [Game, Unique]
    public class LevelTransitionOverlayComponent : IComponent
    {
        public Image Value;
    }
}