using Entitas;
using UnityEngine;

namespace SemoGames.Obstacles
{
    [Game]
    public class WaypointsComponent : IComponent
    {
        public Transform[] Value;
    }
}