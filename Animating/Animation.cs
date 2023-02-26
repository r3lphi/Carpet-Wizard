namespace Carpet_Wizard;

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class Animation : AnimationBranchable
{
    private Animator root;
    private AnimationFrame[] frames;
    private bool isPlaying;
    private int activeStep;

    public Animation(AnimationFrame[] _frames){
        frames = _frames;

        isPlaying = true;
        activeStep = 0;

        timer = 0;
    }

    private float timer;

    public override void Update(Dictionary<string, int> globalDrivers, Animator _root){
        if (root == null){
            root = _root;
        }

        if (!isPlaying){
            return;
        }

        timer += 1 * Globals.DeltaTime;

        if (timer >= frames[activeStep].GetLength()){
            activeStep++;
            timer = 0;
        }

        if (activeStep >= frames.Length){
            activeStep = 0;
        }

        root.SetActiveSprite(frames[activeStep].GetSprite());
    }
}