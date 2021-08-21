using Entitas;

namespace SemoGames.GameTransition
{
    public static class TransitionUtils
    {
        private static IGroup<GameEntity> _transitionEntityGroup =
            Contexts.sharedInstance.game.GetGroup(GameMatcher.TransitionCommands);
        
        public static bool IsTransitionRunning()
        {
            return _transitionEntityGroup.count > 0;
        }
        
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
    }
}