using System;
using System.Threading.Tasks;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SemoGames.Utils
{
    public static class AssetLoaderUtils
    {
        public static async Task InstantiateAssetAsyncTask(AssetReference assetReference, GameEntity entityToAttach, Vector3 position, Quaternion rotation)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetReference, position, rotation);
            await AddAdditionalInfo(entityToAttach, handle);
        }
        
        
        public static async Task InstantiateAssetAsyncTask(AssetReference assetReference, GameEntity entityToAttach, Transform parent, bool worldPositionStays = false)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetReference, parent, worldPositionStays);
            await AddAdditionalInfo(entityToAttach, handle);
        }

        private static async Task AddAdditionalInfo(GameEntity entity, AsyncOperationHandle<GameObject> handle)
        {
            GameObject resultObject = await handle.Task;
            
            if (entity != null && entity.isEnabled)
            {
                entity.AddAsyncOperationHandle(handle);
                entity.AddView(resultObject);
                entity.AddPosition(resultObject.transform.position);
                resultObject.Link(entity);
            }
        }
    }
}