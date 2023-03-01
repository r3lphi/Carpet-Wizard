using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Carpet_Wizard;

public static class Globals
{
    //Variables
    public static float DeltaTime { get; set; }
    public static float Gravity { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static GraphicsDeviceManager Graphics { get; set; }
    public static int Tile_Size { get; set; }
    public static Vector2 Canvas_Size { get; set; }
    public static Vector2 Canvas_Offset { get; set; }

    //Assetworks
    public static Texture2D[] s_Player, s_Level, s_Misc;

    //Methods
    public static void Initialize(ContentManager _content, SpriteBatch _spriteBatch, GraphicsDeviceManager _graphics){
        Gravity = 9.81f;

        Content = _content;
        SpriteBatch = _spriteBatch;
        Graphics = _graphics;

        Tile_Size = 16;
        Canvas_Size = new Vector2(
            Graphics.PreferredBackBufferWidth / Tile_Size,
            Graphics.PreferredBackBufferHeight / Tile_Size
        );
        Canvas_Offset = new Vector2(
            0,
            0
        );

        s_Player = new Texture2D[5];
        s_Player[0] = Content.Load<Texture2D>("Player_Idle_00");
        s_Player[1] = Content.Load<Texture2D>("Player_Idle_01");
        s_Player[2] = Content.Load<Texture2D>("Player_Idle_02");
        s_Player[3] = Content.Load<Texture2D>("Player_Run_00");
        s_Player[4] = Content.Load<Texture2D>("Player_Run_01");

        s_Level = new Texture2D[1];
        s_Level[0] = Content.Load<Texture2D>("Snow");

        s_Misc = new Texture2D[1];
        s_Misc[0] = Content.Load<Texture2D>("MissingTex");

    }
    public static void Update(GameTime gameTime){
        DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}