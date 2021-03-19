using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace SemoGames.Flipper
{
    public class InitializeFlipperSystem : ReactiveSystem<GameEntity>
    {
        public InitializeFlipperSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Level, GameMatcher.View));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.isLevel;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity levelEntity in entities)
            {
                List<GameObject> flipperObjects = new List<GameObject>();
                GameContext gameContext = Contexts.sharedInstance.game;
                FindAllFlipperChildren(levelEntity.view.Value.transform, ref flipperObjects);

                foreach (GameObject flipperObject in flipperObjects)
                {
                    GameEntity flipperEntity = gameContext.CreateEntity();
                    flipperEntity.isFlipper = true;
                    flipperObject.Link(flipperEntity);
                    flipperEntity.AddView(flipperObject);
                    flipperEntity.AddHingeJoint(flipperObject.GetComponent<HingeJoint2D>());
                }
            }
        }

        private void FindAllFlipperChildren(Transform parent, ref List<GameObject> flipperObjectList)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform childTransform = parent.GetChild(i);
                if (childTransform.CompareTag(Tags.Flipper))
                {
                    flipperObjectList.Add(childTransform.gameObject);
                }

                if (childTransform.childCount > 0)
                {
                    FindAllFlipperChildren(childTransform, ref flipperObjectList);
                }
            }
        }
    }
}