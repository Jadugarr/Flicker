using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Flipper
{
    public class InteractWithFlipperSystem : ReactiveSystem<InputEntity>
    {
        public InteractWithFlipperSystem(IContext<InputEntity> context) : base(context)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<InputEntity>(InputMatcher.Interacting, GroupEvent.Added));
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            IGroup<GameEntity> flipperEntities = Contexts.sharedInstance.game.GetGroup(GameMatcher.Flipper);
            IGroup<GameEntity> leftFlipperEntities = Contexts.sharedInstance.game.GetGroup(GameMatcher.LeftFlipper);

            foreach (GameEntity flipperEntity in flipperEntities)
            {
                JointMotor2D motor2D = new JointMotor2D {motorSpeed = 1000, maxMotorTorque = 1000};
                flipperEntity.hingeJoint.Value.motor = motor2D;
            }
            foreach (GameEntity flipperEntity in leftFlipperEntities)
            {
                JointMotor2D motor2D = new JointMotor2D {motorSpeed = -1000, maxMotorTorque = 1000};
                flipperEntity.hingeJoint.Value.motor = motor2D;
            }
        }
    }
}