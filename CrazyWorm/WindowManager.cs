using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyWorm
{
    public class WindowManager
    {
        List<Window> WindowList;

        public WindowManager()
        {
            WindowList = new List<Window>();
        }

        public void AddWindow(Window newwindow)
        {
            WindowList.Add(newwindow);
        }

        public void RemoveWindow(string name)
        {
            Window w = FindWindow(name);

            if (w != null)
                WindowList.Remove(w);
        }

        public Window FindWindow(string name)
        {
            foreach (Window w in WindowList)
            {
                if (w.GetWindowName().Equals("name"))
                    return w;
            }

            return null;
        }

        public void Update(GameTime gameTime)
        {
            foreach (Window w in WindowList)
            {
                w.WindowUpdate(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Window w in WindowList)
            {
                w.WindowDraw(gameTime);
            }
        }
    }
}
