using System.Collections.Generic;
using UnityEngine;

namespace Desolation
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] protected List<EntityComponent> components;
        
        public void Initialize()
        {
            if (components is { Count: > 0 })
            { foreach(var c in components) c.Initialize(); }
            
            G.Resolve<Entities>().RegisterEntity(this);
            OnInitialize();
        }
        
        private void OnDestroy()
        {
            if (components is { Count: > 0 })
            { foreach(var c in components) c.Deinitialize(); }
            
            G.Resolve<Entities>().UnregisterEntity(this);
            OnDeinitialize();
        }
        
        protected virtual void OnInitialize() { }
        protected virtual void OnDeinitialize() { }
    }
}