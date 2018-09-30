using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    internal sealed class Scene
    {
        public static Scene Instance { get; } = new Scene();

        private List<GameObject> gameObjects = new List<GameObject>();

        private Scene() { }

        public void Reset()
        {
            gameObjects.Clear();

            var mario = new Mario(600, 200);
            gameObjects.Add(mario);

            var hiddenBlock = new UsedBlock(100, 0);
            hiddenBlock.SetHidden(true);
            gameObjects.Add(hiddenBlock);

            var brickBlock = new BrickBlock(100, 150);
            gameObjects.Add(brickBlock);

            var brokenBlock = new BrokenBlock(100, 200);
            gameObjects.Add(brokenBlock);

            var usedBlock = new UsedBlock(100, 250);
            gameObjects.Add(usedBlock);

            var orangeBlock = new OrangeBlock(100, 100);
            gameObjects.Add(orangeBlock);

            var questionBlock = new QuestionBlock(100, 50);
            gameObjects.Add(questionBlock);

            var pipe = new Pipe(200, 200);
            gameObjects.Add(pipe);

            var flower = new Flower(400, 100);
            gameObjects.Add(flower);

            var coin = new Coin(600, 100);
            gameObjects.Add(coin);

            var star = new Star(500, 100);
            gameObjects.Add(star);

            var redMush = new RedMushroom(200, 100);
            gameObjects.Add(redMush);

            var greenMush = new GreenMushroom(300, 100);
            gameObjects.Add(greenMush);

            var koopa = new Koopa(700, 100);
            gameObjects.Add(koopa);

            var goomba = new Goomba(0, 400);
            gameObjects.Add(goomba);
        }

        public void Update()
        {
            gameObjects.ForEach(o => o.Update());
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameObjects.ForEach(o => o.Draw(spriteBatch, textures));
            spriteBatch.End();
        }
    }
}
