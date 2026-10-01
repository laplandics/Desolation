namespace Desolation
{
    public class GameUIMainScreen : UIElement
    {
        protected override void OnAdd()
        {
            var root = G.Resolve<UI>().UIRoot;
            root.Add(Element);
        }
        
        protected override void OnRemove()
        {
            var root = G.Resolve<UI>().UIRoot;
            root.Remove(Element);
        }
    }
}