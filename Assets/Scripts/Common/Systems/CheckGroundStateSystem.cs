using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Common
{
    public class CheckGroundStateSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entitiesToCheck;

        public CheckGroundStateSystem(GameContext gameContext)
        {
            _entitiesToCheck = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.CircleCollider, GameMatcher.GroundState));
        }

        public void Execute()
        {
            foreach (GameEntity gameEntity in _entitiesToCheck.GetEntities())
            {
                ContactFilter2D contactFilter = new ContactFilter2D {layerMask = LayerMask.GetMask(Layers.Ground)};
                List<RaycastHit2D> results = new List<RaycastHit2D>();
                gameEntity.circleCollider.Value.Cast(Vector2.down, contactFilter, results, 0.01f);

                if (results.Count > 0)
                {
                    if (results[0].collider.gameObject.layer == LayerMask.NameToLayer(Layers.Ground))
                    {
                        gameEntity.ReplaceGroundState(GroundState.Ground);
                    }
                }
                else
                {
                    gameEntity.ReplaceGroundState(GroundState.Airborne);
                }
            }
        }
    }
}