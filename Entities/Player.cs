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

    //Localized Variables
    private PhysicsBody physicsBody;
    private Animator animator;
    private Collider collider;

    public Player(){
        AddComponent(new PhysicsBody(this, GetComponent<Transform>()));

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

        Animator animator = new Animator(this, new AnimationBranch[]{
            //Grounded Path
            new AnimationBranch(new AnimationBranchable[]{
                Anim_Idle,
                Anim_Run
            })
        });

        AddComponent(animator);
        AddComponent(new Collider(this));

        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();

        transform = GetComponent<Transform>();
        physicsBody = GetComponent<PhysicsBody>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
        spriteRenderer.SetSprite(Globals.s_Player[0]);
    }

    public override void Update(GameTime gameTime)
    {
        KeyboardState keyState = Keyboard.GetState();

        if (keyState.IsKeyDown(Keys.D)){
            physicsBody.AddForce(new Vector2(moveSpeed * Globals.DeltaTime, 0));
            transform.SetScale(new Vector2(transform.GetScaleABS().X, transform.GetScale().Y));
        }
        if (keyState.IsKeyDown(Keys.A)){
            physicsBody.AddForce(new Vector2(-moveSpeed * Globals.DeltaTime, 0));
            transform.SetScale(new Vector2(-transform.GetScaleABS().X, transform.GetScale().Y));
        }

        collider.Update(gameTime);

        bool isMoving = (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.D));
        animator.SetGlobalDriver("isMoving", ConvertsExtended.BoolToInt(isMoving));

        animator.Update(gameTime);

        base.Update(gameTime);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteRenderer.SetSprite(animator.GetActiveSprite());

        collider.Draw(spriteBatch);

        base.Draw(spriteBatch);
    }
}
