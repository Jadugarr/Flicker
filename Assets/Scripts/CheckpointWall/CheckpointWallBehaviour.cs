using System;
using Entitas.Unity;
using UnityEngine;

namespace SemoGames.CheckpointWall
{
    public class CheckpointWallBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject wallEndMarker;
        [SerializeField] private GameObject wallTriggerObject;
        [SerializeField] private SpriteRenderer wallSpriteRenderer;
        
        private void Start()
        {
            GameEntity checkpointWallEntity = Contexts.sharedInstance.game.CreateEntity();
            checkpointWallEntity.isCheckpointWall = true;
            checkpointWallEntity.AddCheckpointEndMarker(wallEndMarker.transform);
            checkpointWallEntity.AddCheckpointTriggerObject(wallTriggerObject);
            checkpointWallEntity.AddView(gameObject);
            checkpointWallEntity.AddPosition(gameObject.transform.position);
            checkpointWallEntity.AddSpriteRenderer(wallSpriteRenderer);
            gameObject.Link(checkpointWallEntity);
        }
    }
}