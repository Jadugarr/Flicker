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
    }
}