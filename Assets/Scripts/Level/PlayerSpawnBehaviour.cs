using Entitas.Unity;
using SemoGames.Extensions;
using UnityEngine;

namespace SemoGames.Level
{
    public class PlayerSpawnBehaviour : MonoBehaviour
    {
        private void Start()
        {
            GameEntity playerSpawnEntity = Contexts.sharedInstance.game.CreateEntity();
            playerSpawnEntity.isPlayerSpawn = true;
            playerSpawnEntity.AddView(gameObject);
            gameObject.Link(playerSpawnEntity);
        }

        private void OnDestroy()
        {
            GameEntity linkedEntity = gameObject.GetEntityLink().entity as GameEntity;
            linkedEntity.DestroyEntity();
        }
    }
}