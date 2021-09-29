using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Collectables
{
    public class CollectableSpawnBehaviour : MonoBehaviour
    {
        [SerializeField] private int collectableId;

        public int CollectableId => collectableId;

        private void Start()
        {
            GameEntity collectableSpawnEntity = Contexts.sharedInstance.game.CreateEntity();
            collectableSpawnEntity.isCollectableSpawn = true;
            collectableSpawnEntity.AddView(gameObject);
            collectableSpawnEntity.AddPosition(gameObject.transform.position);
            collectableSpawnEntity.AddCollectableId(collectableId);
            gameObject.Link(collectableSpawnEntity);

            /*GameEntity collectableEntity = Contexts.sharedInstance.game.CreateEntity();
            collectableEntity.isCollectable = true;
            collectableEntity.AddView(gameObject);
            collectableEntity.AddPosition(gameObject.transform.position);
            collectableEntity.AddAnimator(GetComponentInChildren<Animator>());
            gameObject.Link(collectableEntity);*/
        }
    }
}