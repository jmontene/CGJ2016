using UnityEngine;
using System.Collections;

public class BattleManager : UnitySingleton<BattleManager> {

    private bool isBombing;
    private bool isProfAware;
    private bool noP;

	// Use this for initialization
	public override void Awake () {
        base.Awake();
        isBombing = false;
        isProfAware = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void setBombing(bool bombing)
    {
        isBombing = bombing;
    }

    public bool getBombing() {
        return isBombing;
    }

    public void setProfAware(bool aware) {
        isProfAware = aware;
    }

    public bool profAware() {
        return isProfAware;
    }
    
}
