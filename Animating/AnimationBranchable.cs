using System.Collections.Generic;

namespace Carpet_Wizard;

public abstract class AnimationBranchable
{
    protected Dictionary<string, int> ListenedDrivers;

    public AnimationBranchable(){
        ListenedDrivers = new Dictionary<string, int>();
    }

    public void SetDriver(string driver, int value){
        ListenedDrivers[driver] = value;
    }
    public bool MatchesDriverValue(string driver, int value){
        if (!ListenedDrivers.ContainsKey(driver)){
            return false;
        }

        return ListenedDrivers[driver] == value;
    }

    public abstract void Update(Dictionary<string, int> globalDrivers, Animator _root);
}