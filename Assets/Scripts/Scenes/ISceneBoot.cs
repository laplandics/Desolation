using System.Collections;

namespace Desolation
{
    public interface ISceneBoot
    {
        public string SceneName { get; }
        public IEnumerator Boot();
    }
}