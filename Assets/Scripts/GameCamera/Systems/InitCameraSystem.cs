using Cinemachine;
using Entitas;
using UnityEngine;

namespace SemoGames.GameCamera
{
    public class InitCameraSystem : IInitializeSystem
    {
        public void Initialize()
        {
            GameContext context = Contexts.sharedInstance.game;
            Camera gameCamera = Camera.main;
            context.ReplaceCameraConfiner(gameCamera.GetComponent<CinemachineConfiner>());
            context.ReplaceVirtualCamera(gameCamera.GetComponent<CinemachineVirtualCamera>());
            context.ReplaceCamera(gameCamera);
        }
    }
}