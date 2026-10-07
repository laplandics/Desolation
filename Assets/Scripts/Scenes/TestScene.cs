using System.Collections;

namespace Desolation
{
    public class TestScene : ISceneBoot
    {
        public string SceneName => "Test";

        public IEnumerator Boot()
        {
            yield return null;
        }
    }
}