using Entitas;

namespace GameInput.Systems
{
    public class CleanupInputActionsSystem : ICleanupSystem
    {
        public void Cleanup()
        {
            IGroup<InputEntity> inputActionGroup = Contexts.sharedInstance.input.GetGroup(InputMatcher.InputAction);

            foreach (InputEntity inputEntity in inputActionGroup.GetEntities())
            {
                inputEntity.Destroy();
            }
        }
    }
}