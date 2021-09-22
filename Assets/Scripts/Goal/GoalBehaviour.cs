using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Goal
{
    public class GoalBehaviour : MonoBehaviour
    {
        private void Start()
        {
            GameEntity goalEntity = Contexts.sharedInstance.game.CreateEntity();
            goalEntity.isGoal = true;
            goalEntity.AddView(gameObject);
            goalEntity.AddPosition(transform.position);
            goalEntity.AddAudioSource(gameObject.GetComponent<AudioSource>());
            gameObject.Link(goalEntity);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
            {
                GameEntity playerEntity = (GameEntity) other.gameObject.GetEntityLink().entity;
                if (playerEntity.isIsInGoal == false)
                {
                    playerEntity.isIsInGoal = true;
                    playerEntity.isStopSimulation = true;
                    playerEntity.isDissolve = true;
                
                    GameEntity goalEntity = (GameEntity) gameObject.GetEntityLink().entity;
                    goalEntity.isPlaySound = true;
                }
            }
        }
    }
}