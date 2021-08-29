using System.Collections.Generic;
using Cinemachine;
using Entitas;

namespace SemoGames.GameCamera
{
    public class SetCameraSizeSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly IGroup<GameEntity> _cameraSizeGroup;
        private readonly IGroup<GameEntity> _cameraGroup;

        public SetCameraSizeSystem(IContext<GameEntity> context) : base(context)
        {
            _cameraGroup = context.GetGroup(GameMatcher.VirtualCamera);
            _cameraSizeGroup = context.GetGroup(GameMatcher.CameraOrthographicSize);
        }

        public SetCameraSizeSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(
                GameMatcher.AnyOf(GameMatcher.VirtualCamera, GameMatcher.CameraOrthographicSize), GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return CheckCondition();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            SetOrthographicSize();
        }

        public void Initialize()
        {
            if (CheckCondition())
            {
                SetOrthographicSize();
            }
        }

        private bool CheckCondition()
        {
            return _cameraSizeGroup.count > 0 && _cameraGroup.count > 0;
        }

        private void SetOrthographicSize()
        {
            CinemachineVirtualCamera virtualCamera = _cameraGroup.GetSingleEntity().virtualCamera.Value;
            float size = _cameraSizeGroup.GetSingleEntity().cameraOrthographicSize.Value;

            virtualCamera.m_Lens.OrthographicSize = size;
        }
    }
}