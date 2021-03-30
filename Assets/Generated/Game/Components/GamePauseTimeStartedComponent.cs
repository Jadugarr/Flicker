//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity pauseTimeStartedEntity { get { return GetGroup(GameMatcher.PauseTimeStarted).GetSingleEntity(); } }
    public SemoGames.Pause.PauseTimeStartedComponent pauseTimeStarted { get { return pauseTimeStartedEntity.pauseTimeStarted; } }
    public bool hasPauseTimeStarted { get { return pauseTimeStartedEntity != null; } }

    public GameEntity SetPauseTimeStarted(float newValue) {
        if (hasPauseTimeStarted) {
            throw new Entitas.EntitasException("Could not set PauseTimeStarted!\n" + this + " already has an entity with SemoGames.Pause.PauseTimeStartedComponent!",
                "You should check if the context already has a pauseTimeStartedEntity before setting it or use context.ReplacePauseTimeStarted().");
        }
        var entity = CreateEntity();
        entity.AddPauseTimeStarted(newValue);
        return entity;
    }

    public void ReplacePauseTimeStarted(float newValue) {
        var entity = pauseTimeStartedEntity;
        if (entity == null) {
            entity = SetPauseTimeStarted(newValue);
        } else {
            entity.ReplacePauseTimeStarted(newValue);
        }
    }

    public void RemovePauseTimeStarted() {
        pauseTimeStartedEntity.Destroy();
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

    public SemoGames.Pause.PauseTimeStartedComponent pauseTimeStarted { get { return (SemoGames.Pause.PauseTimeStartedComponent)GetComponent(GameComponentsLookup.PauseTimeStarted); } }
    public bool hasPauseTimeStarted { get { return HasComponent(GameComponentsLookup.PauseTimeStarted); } }

    public void AddPauseTimeStarted(float newValue) {
        var index = GameComponentsLookup.PauseTimeStarted;
        var component = (SemoGames.Pause.PauseTimeStartedComponent)CreateComponent(index, typeof(SemoGames.Pause.PauseTimeStartedComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePauseTimeStarted(float newValue) {
        var index = GameComponentsLookup.PauseTimeStarted;
        var component = (SemoGames.Pause.PauseTimeStartedComponent)CreateComponent(index, typeof(SemoGames.Pause.PauseTimeStartedComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePauseTimeStarted() {
        RemoveComponent(GameComponentsLookup.PauseTimeStarted);
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

    static Entitas.IMatcher<GameEntity> _matcherPauseTimeStarted;

    public static Entitas.IMatcher<GameEntity> PauseTimeStarted {
        get {
            if (_matcherPauseTimeStarted == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PauseTimeStarted);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPauseTimeStarted = matcher;
            }

            return _matcherPauseTimeStarted;
        }
    }
}
