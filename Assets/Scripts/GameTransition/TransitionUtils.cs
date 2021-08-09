using Entitas;

namespace SemoGames.GameTransition
{
    public static class TransitionUtils
    {
        public static GameEntity StartTransition()
        {
            GameEntity transitionCommandsEntity = Contexts.sharedInstance.game.CreateEntity();
            Contexts.sharedInstance.game.isStartLevelTransition = true;
            transitionCommandsEntity.isTransitionCommands = true;

            return transitionCommandsEntity;
        }

        public static void StartTransitionSequence(params TransitionComponentData[] components)
        {
            GameEntity test = StartTransition();
            TransitionSequence transitionSequence = new TransitionSequence(components, test);

            //return test;
        }

        public static void StartEntitySequence(IEntity observerEntity, params TransitionComponentData[] components)
        {
            TransitionSequence transitionSequence = new TransitionSequence(components, observerEntity);
        }
    }
}