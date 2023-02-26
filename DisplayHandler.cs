using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Carpet_Wizard;

public class DisplayHander
{
    private GraphicsDeviceManager graphics;
    private RenderTarget2D  renderTarget;
    private int width, height;


    public DisplayHander(GraphicsDeviceManager _graphics, int _width, int _height){
        graphics = _graphics;

        width = _width;
        height = _height;

        Initialize();
    }

    private void Initialize(){
        graphics.PreferredBackBufferWidth = width;
        graphics.PreferredBackBufferHeight = height;

        graphics.HardwareModeSwitch = true;

        graphics.ApplyChanges();

        renderTarget = new RenderTarget2D(graphics.GraphicsDevice, width, height);
    }

    public void ToggleFullscreen(){
        if (!graphics.IsFullScreen){
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            graphics.IsFullScreen = true;
        }
        else{
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;

            graphics.IsFullScreen = false;
        }


        graphics.ApplyChanges();
    }

    public RenderTarget2D GetRenderTarget(){
        return renderTarget;
    }

    public int GetPreferredWidth(){
        return width;
    }
}