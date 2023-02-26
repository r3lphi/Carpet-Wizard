using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Diagnostics;

namespace Carpet_Wizard;

public class Player : Creature
{
    private float moveSpeed = 40f;
    private float acceleration = 2f;
    private Animation Anim_Idle, Anim_Run;
    private Animator animator;
    private Collider collider;

    public Player(){
        transform = new Transform();

        Initialize();
    }
    public Player(Transform _transform){
        transform = _transform;

        Initialize();
    }

    public override void Initialize()
    {
        sprite = Globals.s_Player[0];

        physicsBody = new PhysicsBody(transform);

        Anim_Idle = new Animation(new AnimationFrame[]{
            new AnimationFrame(Globals.s_Player[0], .2f),
            new AnimationFrame(Globals.s_Player[1], .2f),
            new AnimationFrame(Globals.s_Player[2], .2f)
        });
        Anim_Idle.SetDriver("isMoving", 0);

        Anim_Run = new Animation(new AnimationFrame[]{
            new AnimationFrame(Globals.s_Player[3], .15f),
            new AnimationFrame(Globals.s_Player[4], .15f),
        });
        Anim_Run.SetDriver("isMoving", 1);

        animator = new Animator(new AnimationBranch[]{
            //Grounded Path
            new AnimationBranch(new AnimationBranchable[]{
                Anim_Idle,
                Anim_Run
            })
        });

        collider = new Collider(transform, physicsBody);
    }

    public override void Update(GameTime gameTime)
    {
        KeyboardState keyState = Keyboard.GetState();

        if (keyState.IsKeyDown(Keys.D)){
            physicsBody.AddForce(new Vector2(moveSpeed * Globals.DeltaTime, 0));
            direction = 1;
        }
        if (keyState.IsKeyDown(Keys.A)){
            physicsBody.AddForce(new Vector2(-moveSpeed * Globals.DeltaTime, 0));
            direction = -1;
        }

        collider.Update();

        bool isMoving = (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.D));
        animator.SetGlobalDriver("isMoving", ConvertsExtended.BoolToInt(isMoving));

        Debug.WriteLine(ConvertsExtended.BoolToInt(isMoving));

        animator.Update();

        base.Update(gameTime);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        sprite = animator.GetActiveSprite();

        collider.Draw(spriteBatch);

        base.Draw(spriteBatch);
    }
}
