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
        public static void LoadAssetAsync(AssetReference assetReference, GameEntity entityToAttach, Action<GameObject> resultCallback)
        {
            Addressables.LoadAssetAsync<GameObject>(assetReference).Completed += handle =>
            {
                if (entityToAttach != null && entityToAttach.isEnabled)
                {
                    entityToAttach.AddAsyncOperationHandle(handle);
                    resultCallback(handle.Result);
                }
            };
        }
        public static async Task InstantiateAssetAsyncTask(AssetReference assetReference, GameEntity entityToAttach)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(assetReference);
            GameObject resultObject = await handle.Task;
            
            if (entityToAttach != null && entityToAttach.isEnabled)
            {
                entityToAttach.AddAsyncOperationHandle(handle);
                entityToAttach.AddView(resultObject);
                resultObject.Link(entityToAttach);
            }
        }
    }
}