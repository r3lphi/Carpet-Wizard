using System.Collections.Generic;

namespace Carpet_Wizard;

public class AnimationBranch : AnimationBranchable
{
    public AnimationBranchable[] childPaths;

    public AnimationBranch(AnimationBranchable[] _childAnims){
        childPaths = _childAnims;
    }

    public override void Update(Dictionary<string, int> globalDrivers, Animator _root)
    {
        foreach (AnimationBranchable path in childPaths){
            bool requirementsMet = true;

            foreach (string key in globalDrivers.Keys){
                if (!path.MatchesDriverValue(key, globalDrivers[key])){
                    requirementsMet = false;
                }
            }

            if (!requirementsMet){
                continue;
            }

            path.Update(globalDrivers, _root);
        }
    }
}