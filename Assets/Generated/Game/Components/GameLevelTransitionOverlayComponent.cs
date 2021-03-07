//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity levelTransitionOverlayEntity { get { return GetGroup(GameMatcher.LevelTransitionOverlay).GetSingleEntity(); } }
    public SemoGames.GameTransition.LevelTransitionOverlayComponent levelTransitionOverlay { get { return levelTransitionOverlayEntity.levelTransitionOverlay; } }
    public bool hasLevelTransitionOverlay { get { return levelTransitionOverlayEntity != null; } }

    public GameEntity SetLevelTransitionOverlay(UnityEngine.UI.Image newValue) {
        if (hasLevelTransitionOverlay) {
            throw new Entitas.EntitasException("Could not set LevelTransitionOverlay!\n" + this + " already has an entity with SemoGames.GameTransition.LevelTransitionOverlayComponent!",
                "You should check if the context already has a levelTransitionOverlayEntity before setting it or use context.ReplaceLevelTransitionOverlay().");
        }
        var entity = CreateEntity();
        entity.AddLevelTransitionOverlay(newValue);
        return entity;
    }

    public void ReplaceLevelTransitionOverlay(UnityEngine.UI.Image newValue) {
        var entity = levelTransitionOverlayEntity;
        if (entity == null) {
            entity = SetLevelTransitionOverlay(newValue);
        } else {
            entity.ReplaceLevelTransitionOverlay(newValue);
        }
    }

    public void RemoveLevelTransitionOverlay() {
        levelTransitionOverlayEntity.Destroy();
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
public partial class GameEntity {

    public SemoGames.GameTransition.LevelTransitionOverlayComponent levelTransitionOverlay { get { return (SemoGames.GameTransition.LevelTransitionOverlayComponent)GetComponent(GameComponentsLookup.LevelTransitionOverlay); } }
    public bool hasLevelTransitionOverlay { get { return HasComponent(GameComponentsLookup.LevelTransitionOverlay); } }

    public void AddLevelTransitionOverlay(UnityEngine.UI.Image newValue) {
        var index = GameComponentsLookup.LevelTransitionOverlay;
        var component = (SemoGames.GameTransition.LevelTransitionOverlayComponent)CreateComponent(index, typeof(SemoGames.GameTransition.LevelTransitionOverlayComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLevelTransitionOverlay(UnityEngine.UI.Image newValue) {
        var index = GameComponentsLookup.LevelTransitionOverlay;
        var component = (SemoGames.GameTransition.LevelTransitionOverlayComponent)CreateComponent(index, typeof(SemoGames.GameTransition.LevelTransitionOverlayComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLevelTransitionOverlay() {
        RemoveComponent(GameComponentsLookup.LevelTransitionOverlay);
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

    static Entitas.IMatcher<GameEntity> _matcherLevelTransitionOverlay;

    public static Entitas.IMatcher<GameEntity> LevelTransitionOverlay {
        get {
            if (_matcherLevelTransitionOverlay == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTransitionOverlay);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTransitionOverlay = matcher;
            }

            return _matcherLevelTransitionOverlay;
        }
    }
}
