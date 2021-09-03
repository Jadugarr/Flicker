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
        public static async Task<bool> InstantiateAssetAsyncTask(AssetReference assetReference, GameEntity entityToAttach, Vector3 position, Quaternion rotation)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetReference, position, rotation);
            return await AddAdditionalInfo(entityToAttach, handle);
        }
        
        
        public static async Task<bool> InstantiateAssetAsyncTask(AssetReference assetReference, GameEntity entityToAttach, Transform parent, bool worldPositionStays = false)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetReference, parent, worldPositionStays);
            return await AddAdditionalInfo(entityToAttach, handle);
        }

        private static async Task<bool> AddAdditionalInfo(GameEntity entity, AsyncOperationHandle<GameObject> handle)
        {
            bool isStillValid = true;
            entity.OnDestroyEntity += entity1 =>
            {
                isStillValid = false;
            };
            GameObject resultObject = await handle.Task;

            if (!isStillValid)
            {
                Addressables.Release(handle);
                return false;
            }
            
            if (entity != null && entity.isEnabled)
            {
                entity.AddAsyncOperationHandle(handle);
                entity.AddView(resultObject);
                entity.AddPosition(resultObject.transform.position);
                resultObject.Link(entity);
            }
            else
            {
                Addressables.Release(handle);
            }

            return isStillValid;
        }
    }
}