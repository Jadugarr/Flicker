//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public SemoGames.GameInput.InputActionComponent inputAction { get { return (SemoGames.GameInput.InputActionComponent)GetComponent(InputComponentsLookup.InputAction); } }
    public bool hasInputAction { get { return HasComponent(InputComponentsLookup.InputAction); } }

    public void AddInputAction(UnityEngine.InputSystem.InputAction.CallbackContext newValue) {
        var index = InputComponentsLookup.InputAction;
        var component = (SemoGames.GameInput.InputActionComponent)CreateComponent(index, typeof(SemoGames.GameInput.InputActionComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputAction(UnityEngine.InputSystem.InputAction.CallbackContext newValue) {
        var index = InputComponentsLookup.InputAction;
        var component = (SemoGames.GameInput.InputActionComponent)CreateComponent(index, typeof(SemoGames.GameInput.InputActionComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputAction() {
        RemoveComponent(InputComponentsLookup.InputAction);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInputAction;

    public static Entitas.IMatcher<InputEntity> InputAction {
        get {
            if (_matcherInputAction == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputAction);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputAction = matcher;
            }

            return _matcherInputAction;
        }
    }
}
