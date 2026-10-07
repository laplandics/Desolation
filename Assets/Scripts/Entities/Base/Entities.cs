using System.Collections.Generic;
using Desolation;

public class Entities
{
    private readonly Dictionary<string, Entity> _entitiesMap = new();
    
    public void RegisterEntity(Entity entity) => _entitiesMap.TryAdd(entity.GetType().Name, entity);
    public void UnregisterEntity(Entity entity) => _entitiesMap.Remove(entity.GetType().Name);
    
    public bool TryGetEntity<T>(out T tEntity) where T : Entity
    {
        tEntity = null;
        if (!_entitiesMap.TryGetValue(typeof(T).Name, out var entity)) return false;
        tEntity = entity as T;
        return tEntity != null;
    }
}