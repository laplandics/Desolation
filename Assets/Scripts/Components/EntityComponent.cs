using UnityEngine;

namespace Desolation
{
    public abstract class EntityComponent : MonoBehaviour
    {
        public virtual void Initialize() {}
        public virtual void Deinitialize() {}
    }
}