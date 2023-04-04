using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Diagnostics;

namespace Carpet_Wizard;

public class Player : Creature
{
    private float moveSpeed = 20f;
    private float acceleration = 2f;
    private float jumpHeight = 0.5f;
    private Animation Anim_Idle, Anim_Run;

    //Localized Variables
    private PhysicsBody physicsBody;
    private Animator animator;

    public Player(){
        Anim_Idle = new Animation(new AnimationFrame[]{
            new AnimationFrame(Globals.s_Player[0], .1f),
            new AnimationFrame(Globals.s_Player[1], .1f),
            new AnimationFrame(Globals.s_Player[2], .1f)
        });
        Anim_Idle.SetDriver("isMoving", 0);

        Anim_Run = new Animation(new AnimationFrame[]{
            new AnimationFrame(Globals.s_Player[3], .075f),
            new AnimationFrame(Globals.s_Player[4], .075f),
        });
        Anim_Run.SetDriver("isMoving", 1);

        Animator animator = new Animator(this, new AnimationBranch[]{
            //Grounded Path
            new AnimationBranch(new AnimationBranchable[]{
                Anim_Idle,
                Anim_Run
            })
        });

        AddComponent(animator);

        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();

        spriteRenderer.SetSprite(Globals.s_Player[0]);

        if (PhysicsBody.CreateBoxBody(this, transform, new Vector2(Globals.Tile_Size, Globals.Tile_Size), Vector2.Zero, 1, 0, false, out physicsBody, out string err)){
            AddComponent(physicsBody);
        }
        else{
            throw new System.Exception(err);
        }

        transform = GetComponent<Transform>();
        physicsBody = GetComponent<PhysicsBody>();
        animator = GetComponent<Animator>();
    }

    public override void Update(GameTime gameTime)
    {
        KeyboardState keyState = Keyboard.GetState();

        if (keyState.IsKeyDown(Keys.D)){
            physicsBody.AddForce(new Vector2(moveSpeed, 0));
            transform.SetScale(new Vector2(transform.GetScaleABS().X, transform.GetScale().Y));
        }
        if (keyState.IsKeyDown(Keys.A)){
            physicsBody.AddForce(new Vector2(-moveSpeed, 0));
            transform.SetScale(new Vector2(-transform.GetScaleABS().X, transform.GetScale().Y));
        }
        if (keyState.IsKeyDown(Keys.W)){
            physicsBody.AddForce(new Vector2(0, -moveSpeed));
        }
        if (keyState.IsKeyDown(Keys.S)){
            physicsBody.AddForce(new Vector2(0, moveSpeed));
        }

        if (keyState.IsKeyDown(Keys.Space)){
            transform.SetPosition(transform.GetPosition() + new Vector2(0, 5 * Globals.DeltaTime));
        }

        bool isMoving = (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.D));
        animator.SetGlobalDriver("isMoving", ConvertsExtended.BoolToInt(isMoving));

        // Debug.WriteLine("Velocity: " + GetComponent<PhysicsBody>().GetVelocity());

        // physicsBody.Rotate(2 * Globals.DeltaTime);

        // physicsBody.AddForce(new Vector2(0, Globals.Gravity));

        base.Update(gameTime);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteRenderer.SetSprite(animator.GetActiveSprite());

        base.Draw(spriteBatch);
    }
}
