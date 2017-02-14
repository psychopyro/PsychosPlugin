namespace Turbo.Plugins.PsychosPlugins
{
    using Turbo.Plugins.Default;

    public class ClassMarkersPlugin : BasePlugin
    {
        public MapShapeDecorator BarbarianCircleDecorator {get; set;} 
        public MapShapeDecorator CrusaderCircleDecorator {get; set;} 
        public MapShapeDecorator DemonhunterCircleDecorator {get; set;}
        public MapShapeDecorator MonkCircleDecorator {get; set;} 
        public MapShapeDecorator WitchDoctorCircleDecorator {get; set;} 
        public MapShapeDecorator WizardCircleDecorator {get; set;}
        public GroundCircleDecorator BarbarianGroundCircleDecorator {get; set;}
        public GroundCircleDecorator CrusaderGroundCircleDecorator {get; set;}
        public GroundCircleDecorator DemonhunterGroundCircleDecorator {get; set;}
        public GroundCircleDecorator MonkGroundCircleDecorator {get; set;}
        public GroundCircleDecorator WitchDoctorGroundCircleDecorator {get; set;}
        public GroundCircleDecorator WizardGroundCircleDecorator {get; set;}
        public WorldDecoratorCollection MyGroundCircle {get; set;}
        public bool MyPlayerCircle {get; set;}
        public bool OtherPlayersCircles {get; set;}
        public bool MyPlayerCircleColorOverride {get; set;}

        public ClassMarkersPlugin()
        {
            Enabled = true;
            MyPlayerCircle = true;
            OtherPlayersCircles = true;
            MyPlayerCircleColorOverride = false;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);



                BarbarianCircleDecorator = new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 250, 10, 10, 5),
                    ShapePainter = new CircleShapePainter(Hud),
                    Radius = 2f,
                };

                BarbarianGroundCircleDecorator = new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 250, 10, 10, 5),
                    Radius = 4f,
                };

                CrusaderCircleDecorator = new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(240, 0, 200, 250, 5),
                    ShapePainter = new CircleShapePainter(Hud),
                    Radius = 2f,
                };

                CrusaderGroundCircleDecorator = new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(240, 0, 200, 250, 5),
                    Radius = 4f
                };

                DemonhunterCircleDecorator = new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 0, 200, 5),
                    ShapePainter = new CircleShapePainter(Hud),
                    Radius = 2f,
                };

                DemonhunterGroundCircleDecorator = new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 0, 200, 5),
                    Radius = 4f
                };

                MonkCircleDecorator = new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(245, 120, 0, 200, 5),
                    ShapePainter = new CircleShapePainter(Hud),
                    Radius = 2f,
                };

                MonkGroundCircleDecorator = new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(245, 120, 0, 200, 5),
                    Radius = 4f
                };

                WitchDoctorCircleDecorator = new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(155, 0, 155, 125, 5),
                    ShapePainter = new CircleShapePainter(Hud),
                    Radius = 2f,
                };

                WitchDoctorGroundCircleDecorator = new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(155, 0, 155, 125, 5),
                    Radius = 4f
                };

                WizardCircleDecorator = new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 250, 50, 180, 5),
                    ShapePainter = new CircleShapePainter(Hud),
                    Radius = 2f,
                };

                WizardGroundCircleDecorator = new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 250, 50, 180, 5),
                    Radius = 4f
                };
                MyGroundCircle = new WorldDecoratorCollection(
                 new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 255, 5),
                    ShapePainter = new CircleShapePainter(Hud),
                    Radius = 4f,
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 255, 5),
                    Radius = 4f
                }
                );
        }

           

        public override void Customize()
        {
            if (OtherPlayersCircles == true)
            {
                Hud.RunOnPlugin<OtherPlayersPlugin>(plugin =>
                {
                    plugin.NameOffsetZ = 0;              
                    plugin.DecoratorByClass[HeroClass.Barbarian].Decorators.Add(BarbarianCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.Barbarian].Decorators.Add(BarbarianGroundCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.Crusader].Decorators.Add(CrusaderCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.Crusader].Decorators.Add(CrusaderGroundCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.DemonHunter].Decorators.Add(DemonhunterCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.DemonHunter].Decorators.Add(DemonhunterGroundCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.Monk].Decorators.Add(MonkCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.Monk].Decorators.Add(MonkGroundCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.WitchDoctor].Decorators.Add(WitchDoctorCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.WitchDoctor].Decorators.Add(WitchDoctorGroundCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.Wizard].Decorators.Add(WizardCircleDecorator);
                    plugin.DecoratorByClass[HeroClass.Wizard].Decorators.Add(WizardGroundCircleDecorator);
                });
            }
        }

        public override void PaintWorld(WorldLayer layer)
        {
            if (MyPlayerCircle == false) return;

            if (MyPlayerCircleColorOverride == true)
            {
                MyGroundCircle.Paint(layer, Hud.Game.Me, Hud.Game.Me.FloorCoordinate, string.Empty);
                return;
            }
            if (OtherPlayersCircles == true)
            {             
                Hud.RunOnPlugin<OtherPlayersPlugin>(plugin =>
                {
                    plugin.DecoratorByClass[Hud.Game.Me.HeroClassDefinition.HeroClass].Paint(layer, Hud.Game.Me, Hud.Game.Me.FloorCoordinate, string.Empty);
                    return;
                });  
            }               
        }
    }
}