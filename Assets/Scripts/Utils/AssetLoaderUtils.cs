using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SemoGames.Utils
{
    public static class AssetLoaderUtils
    {
        public static void LoadAssetAsync(AssetReference assetReference, GameEntity entityToAttach, Action<GameObject> resultCallback)
        {
            Addressables.LoadAssetAsync<GameObject>(assetReference).Completed += handle =>
            {
                entityToAttach.AddAsyncOperationHandle(handle);
                resultCallback(handle.Result);
            };
        }
    }
}