namespace Turbo.Plugins.PsychosPlugins
{
    using Turbo.Plugins.Default;
 
    public class ShrineLabelsPlugin : BasePlugin
    {
 
        public ShrineLabelsPlugin() {
            Enabled = true;
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
        }
        
        public override void Customize()
        {
            Hud.RunOnPlugin<ShrinePlugin>(plugin =>
            {
                plugin.AllShrineDecorator.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                });
            });
        }
    }
}