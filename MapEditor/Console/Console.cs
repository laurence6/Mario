﻿using Microsoft.Xna.Framework.Graphics;
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
                sprite[i] = SpriteFactory.Ins.CreateSmallFontSprite(() => line.Prefix + line.Text);
            }
        }

        private static readonly char[] sepChars = new char[] { ' ' };

        private class Line
        {
            public string Prefix { get; set; } = string.Empty;
            public string Text { get; set; } = string.Empty;

            public bool IsEmpty => string.IsNullOrWhiteSpace(Text);
        }

        private readonly SpriteText[] sprite = new SpriteText[Constants.CONSOLE_NUM_LINES];

        private readonly Line[] lines = new Line[Constants.CONSOLE_NUM_LINES];

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
            upperCase = false;
            lines.ForEach(line => line.Text = string.Empty);
            CurrLine = 0;
            lines[CurrLine].Prefix = Constants.CONSOLE_PROMOT;
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
            var s = string.Empty;
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
                case Keys k when (Constants.KeyMapping.ContainsKey(key)):
                    Input(Constants.KeyMapping[k]);
                    break;
                case Keys.LeftShift:
                    upperCase = true;
                    break;
                case Keys.Back:
                    lines[currLine].Text = lines[currLine].Text.Substring(0, (lines[currLine].Text.Length - 1).Max(0));
                    break;
                case Keys.Enter:
                    if (!lines[CurrLine].IsEmpty)
                    {
                        var cmd = lines[CurrLine].Text.Split(sepChars, 2, StringSplitOptions.RemoveEmptyEntries);
                        if (cmd.Length == 1)
                            cmd = new string[] { cmd[0], string.Empty };
                        CurrLine++;

                        if (!Commands.Execute(cmd[0], cmd[1]))
                            Input(Constants.CONSOLE_ERROR + cmd[0]);

                        if (!lines[CurrLine].IsEmpty)
                            CurrLine++;

                        lines[CurrLine].Prefix = Constants.CONSOLE_PROMOT;
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
            lines[CurrLine].Text += s.Replace('\n', ' ');
        }

        private void Scroll()
        {
            var i = 0;
            for (; i < Constants.CONSOLE_NUM_LINES - 1; i++)
            {
                lines[i].Prefix = lines[i + 1].Prefix;
                lines[i].Text = lines[i + 1].Text;
            }
            CurrLine = i;
            lines[CurrLine].Text = string.Empty;
            lines[CurrLine].Prefix = string.Empty;
        }
    }
}