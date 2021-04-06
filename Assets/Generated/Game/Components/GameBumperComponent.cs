//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SemoGames.Bumpers.BumperComponent bumperComponent = new SemoGames.Bumpers.BumperComponent();

    public bool isBumper {
        get { return HasComponent(GameComponentsLookup.Bumper); }
        set {
            if (value != isBumper) {
                var index = GameComponentsLookup.Bumper;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : bumperComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherBumper;

    public static Entitas.IMatcher<GameEntity> Bumper {
        get {
            if (_matcherBumper == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Bumper);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBumper = matcher;
            }

            return _matcherBumper;
        }
    }
}