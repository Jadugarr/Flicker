//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity playerInputEntity { get { return GetGroup(InputMatcher.PlayerInput).GetSingleEntity(); } }
    public SemoGames.GameInput.PlayerInputComponent playerInput { get { return playerInputEntity.playerInput; } }
    public bool hasPlayerInput { get { return playerInputEntity != null; } }

    public InputEntity SetPlayerInput(UnityEngine.InputSystem.PlayerInput newValue) {
        if (hasPlayerInput) {
            throw new Entitas.EntitasException("Could not set PlayerInput!\n" + this + " already has an entity with SemoGames.GameInput.PlayerInputComponent!",
                "You should check if the context already has a playerInputEntity before setting it or use context.ReplacePlayerInput().");
        }
        var entity = CreateEntity();
        entity.AddPlayerInput(newValue);
        return entity;
    }

    public void ReplacePlayerInput(UnityEngine.InputSystem.PlayerInput newValue) {
        var entity = playerInputEntity;
        if (entity == null) {
            entity = SetPlayerInput(newValue);
        } else {
            entity.ReplacePlayerInput(newValue);
        }
    }

    public void RemovePlayerInput() {
        playerInputEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public SemoGames.GameInput.PlayerInputComponent playerInput { get { return (SemoGames.GameInput.PlayerInputComponent)GetComponent(InputComponentsLookup.PlayerInput); } }
    public bool hasPlayerInput { get { return HasComponent(InputComponentsLookup.PlayerInput); } }

    public void AddPlayerInput(UnityEngine.InputSystem.PlayerInput newValue) {
        var index = InputComponentsLookup.PlayerInput;
        var component = (SemoGames.GameInput.PlayerInputComponent)CreateComponent(index, typeof(SemoGames.GameInput.PlayerInputComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerInput(UnityEngine.InputSystem.PlayerInput newValue) {
        var index = InputComponentsLookup.PlayerInput;
        var component = (SemoGames.GameInput.PlayerInputComponent)CreateComponent(index, typeof(SemoGames.GameInput.PlayerInputComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerInput() {
        RemoveComponent(InputComponentsLookup.PlayerInput);
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

    static Entitas.IMatcher<InputEntity> _matcherPlayerInput;

    public static Entitas.IMatcher<InputEntity> PlayerInput {
        get {
            if (_matcherPlayerInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.PlayerInput);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherPlayerInput = matcher;
            }

            return _matcherPlayerInput;
        }
    }
}
