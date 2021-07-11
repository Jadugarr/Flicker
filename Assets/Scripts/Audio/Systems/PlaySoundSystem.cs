using System.Collections.Generic;
using Entitas;

namespace SemoGames.Audio
{
    public class PlaySoundSystem : ReactiveSystem<GameEntity>
    {
        public PlaySoundSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.PlaySound, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAudioSource && entity.isPlaySound;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.audioSource.Value.Play();
                entity.isPlaySound = false;
            }
        }
    }
}