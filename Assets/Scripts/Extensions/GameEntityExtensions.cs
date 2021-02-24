using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Extensions
{
    public static class GameEntityExtensions
    {
        public static void DestroyEntity(this GameEntity entity)
        {
            if (entity.hasView)
            {
                entity.view.Value.Unlink();
                GameObject.Destroy(entity.view.Value);
            }
        
            entity.Destroy();
        }
    }
}