using Entitas;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SemoGames.Common
{
    [Game]
    public class AsyncOperationHandleComponent : IComponent
    {
        public AsyncOperationHandle Value;
    }
}