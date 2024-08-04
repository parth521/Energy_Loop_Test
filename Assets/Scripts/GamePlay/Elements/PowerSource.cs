
using System.Collections.Generic;


public class PowerSource : GameElement
{
  
    public override void TurnPowerOn()
    {
      //no need to propogate as it's already propogated.
    }

    private void OnEnable()
    {
        IsPowerSource = true;
        HasPower = true;
    }
    public override void TurnPowerOff()
    {
        //no need to propogate as it's already propogated.
    }

}
