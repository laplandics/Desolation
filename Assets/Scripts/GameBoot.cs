using System.Collections;

namespace Desolation
{
    public class GameBoot
    {
        public IEnumerator Boot()
        {
            Main.LoadGameData();
            Main.BeginGame();
            
            yield return G.Resolve<Scenes>().LoadSceneAdditive("Map");
            yield return G.Resolve<Scenes>().LoadSceneAdditive("Asteroid");
            yield return null;
            
            var mainScreen = new GameUIMainScreen();
            var mainScreenId = mainScreen.Add();

            var cameraView = new GameUICameraView();
            var cameraViewId = cameraView.Add();
            
            G.Register(new Map());
            yield return null;
            
            G.Resolve<Map>().Run();
            yield return null;
        }
    }
}