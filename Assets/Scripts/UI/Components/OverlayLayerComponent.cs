using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace SemoGames.UI
{
    [Game, Unique]
    public class OverlayLayerComponent : IComponent
    {
        public GameObject Value;
    }
}