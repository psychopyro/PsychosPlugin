namespace Turbo.Plugins.PsychosPlugins
{
    //special thanks to http://turbohud.freeforums.net/user/12675 for updating the code!

    using Turbo.Plugins.Default;

    public class DPSMeterPlugin : BasePlugin
    {
        public TopLabelDecorator DpsLabelDecorator { get; set; }

        private long HighestDPS;

        public DPSMeterPlugin()
        {
            Enabled = true;
        }
        public override void Load(IController hud)
        {
            base.Load(hud);

            HighestDPS = 0;

            DpsLabelDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 255, 255, 255, true, false, false),
                BackgroundTexture1 = hud.Texture.ButtonTextureBlue,
                BackgroundTexture2 = hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.5f,

                TextFunc = () => ValueToString(Hud.Game.Me.Damage.CurrentDps, ValueFormat.LongNumber),
                HintFunc = () => ValueToString(HighestDPS, ValueFormat.LongNumber),
            };
        }
        public override void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Game.Me.Damage.CurrentDps > HighestDPS) HighestDPS = Hud.Game.Me.Damage.CurrentDps;

            var xPos = Hud.Window.Size.Width / 2;
            var yPos = Hud.Window.Size.Height / 3;
            var bgWidth = Hud.Window.Size.Width * 0.08f;
            var bgHeight = Hud.Window.Size.Height * 0.04f;

            if (clipState == ClipState.BeforeClip)
            {
                DpsLabelDecorator.Paint(xPos - (bgWidth / 2), yPos, bgWidth, bgHeight, HorizontalAlign.Center);
            }
        }
    }
}