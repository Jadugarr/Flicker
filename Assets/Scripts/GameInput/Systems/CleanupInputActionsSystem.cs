using Entitas;

namespace SemoGames.GameInput
{
    public class CleanupInputActionsSystem : IExecuteSystem
    {
        public void Execute()
        {
            IGroup<InputEntity> inputActionGroup = Contexts.sharedInstance.input.GetGroup(InputMatcher.InputAction);

            foreach (InputEntity inputEntity in inputActionGroup.GetEntities())
            {
                inputEntity.Destroy();
            }
        }
    }
}