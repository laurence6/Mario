using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MarioPirates
{
    internal sealed class Console
    {
        public static readonly Console Ins = new Console();

        private Console()
        {
            for (var i = 0; i < Constants.CONSOLE_NUM_LINES; i++)
            {
                var line = new Line();
                lines[i] = line;
                sprite[i] = SpriteFactory.Ins.CreateSmallFontSprite(() => ((i & 1) == 0 ? Constants.CONSOLE_PROMOT : "") + line.text);
            }
        }

        private static readonly char[] sepChars = new char[] { ' ' };

        private class Line
        {
            public string text = "";

            public bool IsEmpty => text.Trim(sepChars) == "";
        }

        private SpriteText[] sprite = new SpriteText[Constants.CONSOLE_NUM_LINES];

        private Line[] lines = new Line[Constants.CONSOLE_NUM_LINES];

        private int currLine = 0;
        public int CurrLine
        {
            get
            {
                if (currLine >= Constants.CONSOLE_NUM_LINES)
                    Scroll();
                return currLine;
            }
            set => currLine = value;
        }


        private bool upperCase = false;

        public void Reset()
        {
            lines.ForEach(line => line.text = "");
            CurrLine = 0;
            upperCase = false;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (var i = 0; i < Constants.CONSOLE_NUM_LINES; i++)
                if (i == CurrLine || !lines[i].IsEmpty)
                    sprite[i].Draw(spriteBatch, Constants.CONSOLE_POSITION.X, Constants.CONSOLE_POSITION.Y + Constants.CONSOLE_LINE_HEIGHT * i);
            spriteBatch.End();
        }

        public void HandleKeyDown(Keys key)
        {
            var s = "";
            switch (key)
            {
                case Keys k when (Keys.A <= k && k <= Keys.Z):
                    s = k.ToString();
                    if (!upperCase)
                        s = s.ToLower();
                    Input(s);
                    break;
                case Keys k when (Keys.D0 <= k && k <= Keys.D9):
                    s = (k - Keys.D0).ToString();
                    Input(s);
                    break;
                case Keys.Space:
                    Input(" ");
                    break;
                case Keys.LeftShift:
                    upperCase = true;
                    break;
                case Keys.Enter:
                    if (!lines[CurrLine].IsEmpty)
                    {
                        var cmd = lines[CurrLine].text.Split(sepChars, 2, StringSplitOptions.RemoveEmptyEntries);
                        CurrLine++;
                        foreach (var f in typeof(Commands).GetMethods())
                        {
                            if (cmd[0].ToLower() == f.Name.ToLower())
                            {
                                f.Invoke(null, new object[] { });
                            }
                        }
                        if (!lines[CurrLine].IsEmpty)
                            CurrLine++;
                    }
                    break;
            }
        }
        public void HandleKeyUp(Keys key)
        {
            switch (key)
            {
                case Keys.LeftShift:
                    upperCase = false;
                    break;
            }
        }

        public void Input(string s)
        {
            lines[CurrLine].text += s;
        }

        private void Scroll()
        {
            var i = 0;
            for (; i < Constants.CONSOLE_NUM_LINES - 1; i++)
                lines[i].text = lines[i + 1].text;
            CurrLine = i;
            lines[CurrLine].text = "";
        }
    }
}
