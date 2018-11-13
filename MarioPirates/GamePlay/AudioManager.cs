using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace MarioPirates
{
    internal sealed class 
        AudioManager
    {
        public static readonly AudioManager Ins = new AudioManager();

        private AudioManager()
        {
        }

        public Song OverworldTheme { get; private set; }
        public SoundEffect JumpSmall { get; private set; }
        public SoundEffect CollectCoin { get; private set; }
        public SoundEffect PowerUp { get; private set; }
        public SoundEffect PowerUpAppear { get; private set; }


        public void LoadContent(ContentManager content)
        {
            OverworldTheme = content.Load<Song>("OverworldTheme");
            JumpSmall = content.Load<SoundEffect>("jumpsmall");
            CollectCoin = content.Load<SoundEffect>("collectcoin");
            PowerUp = content.Load<SoundEffect>("powerup");
            PowerUpAppear = content.Load<SoundEffect>("powerupappear");
        }

        public void StartTheme()
        {
            MediaPlayer.Play(OverworldTheme);
            MediaPlayer.IsRepeating = true;
        }

        public void SmallMarioJump()
        {
            JumpSmall.Play();
        }

        public void PowerupCoin()
        {
            CollectCoin.Play();
        }

        public void ItemAppear()
        {
            PowerUpAppear.Play();
        }

        public void GetPower()
        {
            PowerUp.Play();
        }
    }
}
