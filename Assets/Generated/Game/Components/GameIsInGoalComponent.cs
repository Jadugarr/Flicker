//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SemoGames.Player.IsInGoalComponent isInGoalComponent = new SemoGames.Player.IsInGoalComponent();

    public bool isIsInGoal {
        get { return HasComponent(GameComponentsLookup.IsInGoal); }
        set {
            if (value != isIsInGoal) {
                var index = GameComponentsLookup.IsInGoal;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : isInGoalComponent;

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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherIsInGoal;

    public static Entitas.IMatcher<GameEntity> IsInGoal {
        get {
            if (_matcherIsInGoal == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.IsInGoal);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherIsInGoal = matcher;
            }

            return _matcherIsInGoal;
        }
    }
}
