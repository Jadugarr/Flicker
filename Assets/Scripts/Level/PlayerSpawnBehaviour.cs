using Entitas.Unity;
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
            playerSpawnEntity.AddPosition(gameObject.transform.position);
            gameObject.Link(playerSpawnEntity);
        }
    }
}