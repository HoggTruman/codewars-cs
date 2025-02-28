// https://www.codewars.com/kata/578b4f9b7c77f535fc00002f



namespace ConstructingACar1EngineAndFuelTank;

using System;

public interface ICar
{
    bool EngineIsRunning { get; }
    void EngineStart();
    void EngineStop();
    void Refuel(double liters);
    void RunningIdle();
}

public interface IEngine
{
    bool IsRunning { get; }
    void Consume(double liters);
    void Start();
    void Stop();
}

public interface IFuelTank
{
    double FillLevel { get; }
    bool IsOnReserve { get; }
    bool IsComplete { get; }
    void Consume(double liters);
    void Refuel(double liters);        
}

public interface IFuelTankDisplay
{
    double FillLevel { get; }
    bool IsOnReserve { get; }
    bool IsComplete { get; }
}


public class Car : ICar
{   
    private const double IdleConsumption = 0.0003;
    private readonly IEngine _engine = new Engine();
    private readonly IFuelTank _fuelTank;

    public IFuelTankDisplay fuelTankDisplay;
    public bool EngineIsRunning { get => _engine.IsRunning; }

    public Car(double fuelLevel = 20)
    {
        _fuelTank = new FuelTank(fuelLevel);
        fuelTankDisplay = new FuelTankDisplay(_fuelTank);
    }
    

    public void EngineStart()
    {
        if (_fuelTank.FillLevel > 0)
            _engine.Start();
    }

    public void EngineStop()
    {
        _engine.Stop();
    }

    public void Refuel(double liters)
    {
        _fuelTank.Refuel(liters);
    }

    public void RunningIdle()
    {
        if (EngineIsRunning)
            _fuelTank.Consume(IdleConsumption);

        if (_fuelTank.FillLevel == 0)
            EngineStop();
    }
}


public class Engine : IEngine
{
    private bool _isRunning = false;
    public bool IsRunning { get => _isRunning; }

    public void Consume(double liters) => throw new System.NotImplementedException();

    public void Start()
    {
        _isRunning = true;
    }

    public void Stop()
    {
        _isRunning = false;
    }
}

public class FuelTank : IFuelTank
{
    private const double MaxCapacity = 60;
    private const double ReserveLevel = 5;

    private double _fillLevel = 0;

    public double FillLevel { get => _fillLevel; }
    public bool IsOnReserve { get => _fillLevel < ReserveLevel; }
    public bool IsComplete { get => _fillLevel == MaxCapacity; }

    public FuelTank(double fuelLevel)
    {
        Refuel(fuelLevel);
    }

    public void Consume(double liters)
    {
        if (liters < 0) { return; }
        _fillLevel = Math.Round(_fillLevel - liters, 10);
        if (_fillLevel < 0)
            _fillLevel = 0;
    }

    public void Refuel(double liters)
    {
        if (liters < 0) { return; }
        _fillLevel = Math.Round(_fillLevel + liters, 10);
        if (_fillLevel > MaxCapacity)
            _fillLevel = MaxCapacity;
    }
}

public class FuelTankDisplay : IFuelTankDisplay
{
    private IFuelTank _fuelTank;
    public double FillLevel { get => Math.Round(_fuelTank.FillLevel, 2); }
    public bool IsOnReserve { get => _fuelTank.IsOnReserve; }
    public bool IsComplete { get => _fuelTank.IsComplete; }

    public FuelTankDisplay(IFuelTank fuelTank)
    {
        _fuelTank = fuelTank;
    }
}
