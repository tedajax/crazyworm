using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Valix
{
    enum KeyPressedState
    {
        Pressed,
        Released,
        JustPressed,
        JustReleased
    }

    static class InputManager
    {        
        public static KeyPressedState GetKeyPressedState(Keys input)
        {
            if (BaseGame.NewKeyState.IsKeyDown(input))
            {
                if (BaseGame.OldKeyState.IsKeyDown(input))
                    return KeyPressedState.Pressed;
                else
                    return KeyPressedState.JustPressed;
            }
            else
            {
                if (BaseGame.OldKeyState.IsKeyDown(input))
                    return KeyPressedState.JustReleased;
                else
                    return KeyPressedState.Released;
            }
        }
    }
}
