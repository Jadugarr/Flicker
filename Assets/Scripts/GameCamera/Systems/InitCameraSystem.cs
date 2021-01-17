using Entitas;
using UnityEngine;

namespace SemoGames.GameCamera
{
    public class InitCameraSystem : IInitializeSystem
    {
        public void Initialize()
        {
            GameContext context = Contexts.sharedInstance.game;
            
            context.ReplaceCamera(Camera.main);
        }
    }
}