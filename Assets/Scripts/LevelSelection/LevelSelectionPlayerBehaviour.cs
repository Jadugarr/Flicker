using Entitas.Unity;
using UnityEngine;

namespace SemoGames.LevelSelection
{
    public class LevelSelectionPlayerBehaviour : MonoBehaviour
    {
        private void Start()
        {
            GameEntity goalEntity = Contexts.sharedInstance.game.CreateEntity();
            goalEntity.isLevelSelectionPlayer = true;
            goalEntity.AddView(gameObject);
            goalEntity.AddPosition(transform.position);
            goalEntity.AddAudioSource(gameObject.GetComponent<AudioSource>());
            gameObject.Link(goalEntity);
        }
    }
}