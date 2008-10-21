using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrazyWorm
{
    public enum KeyPressedState
    {
        Pressed,
        Released,
        JustPressed,
        JustReleased
    }

    public class InputManager
    {        
        private KeyboardState NewKeyState;
        private KeyboardState OldKeyState;

        public InputManager()
        {
            NewKeyState = new KeyboardState();
            OldKeyState = new KeyboardState();
        }

        public KeyPressedState GetKeyPressedState(Keys input)
        {
            if (NewKeyState.IsKeyDown(input))
            {
                if (OldKeyState.IsKeyDown(input))
                    return KeyPressedState.Pressed;
                else
                    return KeyPressedState.JustPressed;
            }
            else
            {
                if (OldKeyState.IsKeyDown(input))
                    return KeyPressedState.JustReleased;
                else
                    return KeyPressedState.Released;
            }
        }

        public void UpdateNewInput() { NewKeyState = Keyboard.GetState(); }
        public void UpdateOldInput() { OldKeyState = Keyboard.GetState(); }
    }
}
