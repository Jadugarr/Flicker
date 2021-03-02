using Entitas.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SemoGames.Extensions
{
    public static class GameEntityExtensions
    {
        public static void DestroyEntity(this GameEntity entity)
        {
            if (entity.hasAsyncOperationHandle)
            {
                Addressables.Release(entity.asyncOperationHandle.Value);
            }
            
            if (entity.hasView && entity.view.Value != null)
            {
                entity.view.Value.Unlink();
                GameObject.Destroy(entity.view.Value);
            }
        
            entity.Destroy();
        }
    }
}