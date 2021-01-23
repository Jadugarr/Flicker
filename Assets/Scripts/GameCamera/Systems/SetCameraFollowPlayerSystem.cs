using System.Collections.Generic;
using Cinemachine;
using Entitas;
using UnityEngine;

namespace SemoGames.GameCamera
{
    public class SetCameraFollowPlayerSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private IGroup<GameEntity> _followCameraGroup;
        private IGroup<GameEntity> _virtualCameraGroup;
        
        public SetCameraFollowPlayerSystem(IContext<GameEntity> context) : base(context)
        {
            _followCameraGroup = context.GetGroup(GameMatcher.CameraFollow);
            _virtualCameraGroup = context.GetGroup(GameMatcher.VirtualCamera);
        }

        public SetCameraFollowPlayerSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CameraFollow);
        }

        protected override bool Filter(GameEntity entity)
        {
            return CheckCondition();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            SetFollowPlayer();
        }

        private bool CheckCondition()
        {
            return _virtualCameraGroup.count > 0 && _followCameraGroup.count > 0 && _followCameraGroup.GetSingleEntity().hasView;
        }

        public void Initialize()
        {
            if (CheckCondition())
            {
                SetFollowPlayer();
            }
        }

        private void SetFollowPlayer()
        {
            GameObject followView = _followCameraGroup.GetSingleEntity().view.Value;
            CinemachineVirtualCamera virtualCamera = _virtualCameraGroup.GetSingleEntity().virtualCamera.Value;

            if (virtualCamera.Follow == null)
            {
                virtualCamera.Follow = followView.transform;
            }
        }
    }
}