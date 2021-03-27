//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity interactingEntity { get { return GetGroup(InputMatcher.Interacting).GetSingleEntity(); } }

    public bool isInteracting {
        get { return interactingEntity != null; }
        set {
            var entity = interactingEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isInteracting = true;
                } else {
                    entity.Destroy();
                }
            }
        }
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

    static readonly SemoGames.Flipper.InteractingComponent interactingComponent = new SemoGames.Flipper.InteractingComponent();

    public bool isInteracting {
        get { return HasComponent(InputComponentsLookup.Interacting); }
        set {
            if (value != isInteracting) {
                var index = InputComponentsLookup.Interacting;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : interactingComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<InputEntity> _matcherInteracting;

    public static Entitas.IMatcher<InputEntity> Interacting {
        get {
            if (_matcherInteracting == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Interacting);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInteracting = matcher;
            }

            return _matcherInteracting;
        }
    }
}