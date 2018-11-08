using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace MarioPirates
{
    internal sealed class AudioManager
    {

        public static readonly AudioManager Ins = new AudioManager();

        public Song OverworldTheme;
        public SoundEffect JumpSmall;


        public void LoadContent(ContentManager content)
        {

            OverworldTheme = content.Load<Song>("OverworldTheme");

            JumpSmall = content.Load<SoundEffect>("jumpsmall");


            System.Console.WriteLine(OverworldTheme.Duration);
            System.Console.WriteLine(JumpSmall.Duration);
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




    }

}


