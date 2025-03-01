// https://www.codewars.com/kata/578df8f3deaed98fcf0001e9

namespace ConstructingACar2Driving;

using System;

public interface ICar
{
    bool EngineIsRunning { get; }
    void BrakeBy(int speed);
    void Accelerate(int speed);
    void EngineStart();
    void EngineStop();
    void FreeWheel();
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

public interface IDrivingInformationDisplay
{
  int ActualSpeed { get; }
}

public interface IDrivingProcessor
{
  int ActualSpeed { get; }
  void IncreaseSpeedTo(int speed);
  void ReduceSpeed(int speed);
}


public class Car : ICar
{   
    private const double IdleConsumption = 0.0003;
    private readonly IEngine _engine = new Engine();
    private readonly IFuelTank _fuelTank;
    private readonly IDrivingProcessor _processor;

    public IFuelTankDisplay fuelTankDisplay;
    public IDrivingInformationDisplay drivingInformationDisplay;

    public bool EngineIsRunning { get => _engine.IsRunning; }

    public Car(double fuelLevel=20, int maxAcceleration=10)
    {
        _fuelTank = new FuelTank(fuelLevel);
        _processor = new DrivingProcessor(maxAcceleration);
        fuelTankDisplay = new FuelTankDisplay(_fuelTank);
        drivingInformationDisplay = new DrivingInformationDisplay(_processor);
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

    public void BrakeBy(int speed)
    {
        _processor.ReduceSpeed(speed);
    }

    public void Accelerate(int speed)
    {
        if (!EngineIsRunning) 
            return;

        if (speed < _processor.ActualSpeed)
        {
            FreeWheel();
        }
        else
        {
            _processor.IncreaseSpeedTo(speed);
            _fuelTank.Consume(CalculateConsumption());
        }

        if (_fuelTank.FillLevel == 0)
            EngineStop();
    }

    public void FreeWheel()
    {
        if (_processor.ActualSpeed == 0)
        {
            RunningIdle();
        }
        else
        {
            _processor.ReduceSpeed(1);
        }        
    }

    private double CalculateConsumption()
    {
        if (_processor.ActualSpeed <= 60) return 0.002;
        if (_processor.ActualSpeed <= 100) return 0.0014;
        if (_processor.ActualSpeed <= 140) return 0.002;
        if (_processor.ActualSpeed <= 200) return 0.0025;
        if (_processor.ActualSpeed <= 250) return 0.003;
        return 0;
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

public class DrivingProcessor : IDrivingProcessor
{
    private const int MaxSpeed = 250;
    private const int MaxDeceleration = 10;
    private readonly int MaxAcceleration;
    private int _actualSpeed = 0;

    public int ActualSpeed { get => _actualSpeed; }

    public DrivingProcessor(int maxAcceleration)
    {
        if (maxAcceleration > 20) { MaxAcceleration = 20; }            
        else if (maxAcceleration < 5) { MaxAcceleration = 5; }            
        else { MaxAcceleration = maxAcceleration; }            
    }

    public void IncreaseSpeedTo(int speed)
    {
        _actualSpeed = Math.Min(speed, _actualSpeed + MaxAcceleration);
        if (_actualSpeed > MaxSpeed)
            _actualSpeed = MaxSpeed;
    }

    public void ReduceSpeed(int speed)
    {
        _actualSpeed -= Math.Min(speed, MaxDeceleration);
        if (_actualSpeed < 0)
            _actualSpeed = 0;
    }
}

public class DrivingInformationDisplay : IDrivingInformationDisplay
{
    private IDrivingProcessor _processor;

    public DrivingInformationDisplay(IDrivingProcessor processor)
    {
        _processor = processor;
    }

    public int ActualSpeed { get => _processor.ActualSpeed; }
}
