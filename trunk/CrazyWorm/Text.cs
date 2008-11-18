using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyWorm
{
    public class Text : Entity
    {
        protected string textStr;
        protected Color textCol;
        protected SpriteFont textFont;

        public Text(string t)
        {
            textStr = t;
            textCol = Color.White;
            textFont = BaseGame.GetDebugFont();
        }

        public Text(string t, Color c)
        {
            textStr = t;
            textCol = c;
            textFont = BaseGame.GetDebugFont();
        }

        public Text(string t, Color c, SpriteFont f)
        {
            textStr = t;
            textCol = c;
            textFont = f;
        }

        public string TextStr
        {
            get { return textStr; }
            set { textStr = value; }
        }

        public Color TextCol
        {
            get { return textCol; }
            set { textCol = value; }
        }

        public override void Draw()
        {
            BaseGame.GetSpriteBatch().DrawString(textFont,
                                                 textStr,
                                                 Position,
                                                 textCol,
                                                 Rotation,
                                                 Origin,
                                                 Scale,
                                                 SpriteEffects.None,
                                                 0);
        }
    }
}
