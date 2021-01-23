using System;
using System.Collections.Generic;
using Cinemachine;
using Entitas;
using UnityEngine;

namespace SemoGames.GameCamera
{
    public class SetCameraConfinerSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private IGroup<GameEntity> _cameraConfinerColliderGroup;
        private IGroup<GameEntity> _cameraConfinerGroup;
        
        public SetCameraConfinerSystem(IContext<GameEntity> context) : base(context)
        {
            _cameraConfinerGroup = context.GetGroup(GameMatcher.CameraConfiner);
            _cameraConfinerColliderGroup = context.GetGroup(GameMatcher.CameraConfinerCollider);
        }

        public SetCameraConfinerSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.AnyOf(GameMatcher.CameraConfiner, GameMatcher.CameraConfinerCollider), GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return CheckCondition();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            SetConfiner();
        }

        public void Initialize()
        {
            if (CheckCondition())
            {
                SetConfiner();
            }
        }

        private bool CheckCondition()
        {
            return _cameraConfinerGroup.count > 0 && _cameraConfinerColliderGroup.count > 0;
        }

        private void SetConfiner()
        {
            CinemachineConfiner confiner = _cameraConfinerGroup.GetSingleEntity().cameraConfiner.Value;
            Collider2D confinerCollider = _cameraConfinerColliderGroup.GetSingleEntity().cameraConfinerCollider.Value;

            confiner.m_BoundingShape2D = confinerCollider;
        }
    }
}