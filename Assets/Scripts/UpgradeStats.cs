using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStats
{
    public int moneyNeededToUpgrade;
    public int moneyGotIfSold;
    public int dmgBeforeUpgrade;
    public int dmgAfterUpgrade;

    public UpgradeStats(int moneyNeededToUpgrade, int moneyGotIfSold)
    {
        this.moneyNeededToUpgrade = moneyNeededToUpgrade;
        this.moneyGotIfSold = moneyGotIfSold;
    }

    public UpgradeStats(int moneyNeededToUpgrade, int moneyGotIfSold, int dmgBeforeUpgrade, int dmgAfterUpgrade)
    {
        this.moneyNeededToUpgrade = moneyNeededToUpgrade;
        this.moneyGotIfSold = moneyGotIfSold;
        this.dmgBeforeUpgrade = dmgBeforeUpgrade;
        this.dmgAfterUpgrade = dmgAfterUpgrade;
    }
}
