using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    using Controller;

    internal class MapEditor : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public List<IController> Controllers { get; } = new List<IController>();

        public MapEditorState State { get; set; }

        public MapEditor()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = Constants.CONTENT_ROOT;
        }

        protected override void Initialize()
        {
            base.Initialize();

            graphics.IsFullScreen = false;
            IsMouseVisible = true;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Ins.LoadContent(Content);
            AudioManager.Ins.LoadContent(Content);

            Reset();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            State.DoUpdate(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            State.DoDraw(spriteBatch);
        }

        private void Reset()
        {
            EventManager.Ins.Reset();
            Camera.Ins.Reset();
            Scene.Ins.Reset();

            State = new MapEditorStateNormal(this);

            EventManager.Ins.Subscribe(EventEnum.KeyDown, (s, e) => State.HandleKeyDown((e as KeyDownEventArgs).key));
            EventManager.Ins.Subscribe(EventEnum.KeyUp, (s, e) => State.HandleKeyUp((e as KeyUpEventArgs).key));

            Controllers.Clear();

            Controllers.Add(new KeyboardController());
        }
    }
}
