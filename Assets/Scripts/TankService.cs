using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    [SerializeField] TankView tankView;
    private void Start()
    {
        CreateNewTank();
    }

    private TankController CreateNewTank()
    {
        TankModel model = new TankModel(10, 20);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
}
