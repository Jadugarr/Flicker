//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SemoGames.Speedrun.FinishSpeedrunDialogComponent finishSpeedrunDialogComponent = new SemoGames.Speedrun.FinishSpeedrunDialogComponent();

    public bool isFinishSpeedrunDialog {
        get { return HasComponent(GameComponentsLookup.FinishSpeedrunDialog); }
        set {
            if (value != isFinishSpeedrunDialog) {
                var index = GameComponentsLookup.FinishSpeedrunDialog;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : finishSpeedrunDialogComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherFinishSpeedrunDialog;

    public static Entitas.IMatcher<GameEntity> FinishSpeedrunDialog {
        get {
            if (_matcherFinishSpeedrunDialog == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FinishSpeedrunDialog);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFinishSpeedrunDialog = matcher;
            }

            return _matcherFinishSpeedrunDialog;
        }
    }
}
