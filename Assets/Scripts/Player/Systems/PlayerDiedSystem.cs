using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using Entitas;

namespace SemoGames.Player
{
    public class PlayerDiedSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _virtualCameraGroup;
        
        public PlayerDiedSystem(IContext<GameEntity> context) : base(context)
        {
            _virtualCameraGroup = context.GetGroup(GameMatcher.VirtualCamera);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Dead));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.isDead;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity playerEntity in entities)
            {
                CinemachineBasicMultiChannelPerlin cameraPerlin = _virtualCameraGroup.GetSingleEntity().virtualCamera.Value.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cameraPerlin.m_AmplitudeGain = 6;
                DOTween.To(() => cameraPerlin.m_AmplitudeGain, value => cameraPerlin.m_AmplitudeGain = value, 0f, 0.2f);
                playerEntity.isStopSimulation = true;
                playerEntity.animation.Value.Play("DissolveAnimation");
            }
        }
    }
}