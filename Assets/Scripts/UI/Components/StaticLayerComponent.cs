using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace SemoGames.UI
{
    [Game, Unique]
    public class StaticLayerComponent : IComponent
    {
        public GameObject Value;
    }
}