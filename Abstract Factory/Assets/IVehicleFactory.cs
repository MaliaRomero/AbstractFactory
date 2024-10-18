using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements requirements);
}

public class CycleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.NumberOfWheels == 1) return new Unicycle();
                return new Bicycle();
            default:
                return new Bicycle();
        }
    }
}

//Motor factory inherits from IVehicle
public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                return new Motorbike();
            default:
                return new Truck();
        }
    }
}


//New Abstract Factory Class
public abstract class AbstractVehicleFactory
{
    public abstract IVehicle Create();
}


//New VVehicle factory inherets from abstract factory
public class VehicleFactory : AbstractVehicleFactory
{
    //Initialize privste varibles
    private readonly IVehicleFactory _factory;
    private readonly VehicleRequirements _requirements;


    public VehicleFactory(VehicleRequirements requirements)
    {
        //Condition, if ture get motor vehicle factory, if false cycle factory
        //If engine, get motor vehicle, if not cycle
        _factory = requirements.Engine ? (IVehicleFactory) new MotorVehicleFactory() : new CycleFactory();
        _requirements = requirements;
    }

    //Create the vehicle
    public override IVehicle Create()
    {
        return _factory.Create(_requirements);
    }
}
