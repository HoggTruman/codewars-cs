// https://www.codewars.com/kata/57961d4e4be9121ec90001bd

namespace ConstructingACar3OnBoardComputer;

using System;
using System.Collections.Generic;
using System.Linq;

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
    double ActualConsumption { get; }
    int ActualSpeed { get; }
    void EngineStart();
    void EngineStop();
    void IncreaseSpeedTo(int speed);
    void ReduceSpeed(int speed);
}

public interface IOnBoardComputer
{
    int TripRealTime { get; }
    int TripDrivingTime { get; }
    int TripDrivenDistance { get; }
    int TotalRealTime { get; }
    int TotalDrivingTime { get; }
    int TotalDrivenDistance { get; }
    double TripAverageSpeed { get; }
    double TotalAverageSpeed { get; }
    int ActualSpeed { get; }
    double ActualConsumptionByTime { get; }
    double ActualConsumptionByDistance { get; }
    double TripAverageConsumptionByTime { get; }
    double TotalAverageConsumptionByTime { get; }
    double TripAverageConsumptionByDistance { get; }
    double TotalAverageConsumptionByDistance { get; }
    int EstimatedRange { get; }
    void ElapseSecond();
    void TripReset();
    void TotalReset();
}

public interface IOnBoardComputerDisplay
{
    int TripRealTime { get; }
    int TripDrivingTime { get; }
    double TripDrivenDistance { get; }
    int TotalRealTime { get; }
    int TotalDrivingTime { get; }
    double TotalDrivenDistance { get; }
    int ActualSpeed { get; }
    double TripAverageSpeed { get; }
    double TotalAverageSpeed { get; }
    double ActualConsumptionByTime { get; }
    double ActualConsumptionByDistance { get; }
    double TripAverageConsumptionByTime { get; }
    double TotalAverageConsumptionByTime { get; }
    double TripAverageConsumptionByDistance { get; }
    double TotalAverageConsumptionByDistance { get; }
    int EstimatedRange { get; }
    void TripReset();
    void TotalReset();
}










public class Car : ICar
{   
    private const double IdleConsumption = 0.0003;
    private readonly IEngine _engine = new Engine();
    private readonly FuelTank _fuelTank;
    private readonly DrivingProcessor _processor;
    private readonly OnBoardComputer _onBoardComputer;

    public IFuelTankDisplay fuelTankDisplay;
    public IDrivingInformationDisplay drivingInformationDisplay;
    public IOnBoardComputerDisplay onBoardComputerDisplay;

    public bool EngineIsRunning { get => _engine.IsRunning; }

    public Car(double fuelLevel=20, int maxAcceleration=10)
    {
        _fuelTank = new FuelTank(fuelLevel);
        _processor = new DrivingProcessor(maxAcceleration);
        _onBoardComputer = new OnBoardComputer(_processor, _fuelTank);
        fuelTankDisplay = new FuelTankDisplay(_fuelTank);
        drivingInformationDisplay = new DrivingInformationDisplay(_processor);
        onBoardComputerDisplay = new OnBoardComputerDisplay(_onBoardComputer);
    }
    

    public void EngineStart()
    {
        if (_fuelTank.FillLevel == 0)
            return;

        _onBoardComputer.TripReset();
        _onBoardComputer.UpdateConsumption(0, 0);
        _onBoardComputer.IncrementIdleTime();        
        _engine.Start();                 
    }

    public void EngineStop()
    {
        _engine.Stop();
        _onBoardComputer.IncrementIdleTime();
        _onBoardComputer.UpdateConsumption(0, _processor.ActualSpeed);
    }

    public void Refuel(double liters)
    {
        _fuelTank.Refuel(liters);
    }

    public void RunningIdle()
    {
        if (!EngineIsRunning)
        {
            _onBoardComputer.UpdateConsumption(0, _processor.ActualSpeed);
            return;
        }            

        _onBoardComputer.IncrementIdleTime();
        _fuelTank.Consume(IdleConsumption);
        _onBoardComputer.UpdateConsumption(IdleConsumption, 0);

        if (_fuelTank.FillLevel == 0)
            _engine.Stop();
    }

    public void BrakeBy(int speed)
    {
        if (!EngineIsRunning)
        {
            _onBoardComputer.UpdateConsumption(0, _processor.ActualSpeed);
            return;
        }

        if (_processor.ActualSpeed == 0)
        {
            RunningIdle();
            return;
        }

        _processor.ReduceSpeed(speed);
        _onBoardComputer.UpdateDistance(_processor.ActualSpeed);

        if (_processor.ActualSpeed == 0)
        {
            _onBoardComputer.IncrementIdleTime();    
            _fuelTank.Consume(IdleConsumption);
            _onBoardComputer.UpdateConsumption(IdleConsumption, _processor.ActualSpeed);
            _onBoardComputer.UpdateRange(IdleConsumption, _processor.ActualSpeed);
        }
        else
        {
            _onBoardComputer.IncrementDrivingTime();
            _onBoardComputer.UpdateConsumption(0, _processor.ActualSpeed);
        }
    }

    public void Accelerate(int speed)
    {
        if (!EngineIsRunning)
        {
            _onBoardComputer.UpdateConsumption(0, _processor.ActualSpeed);
            return;
        }            

        if (speed < _processor.ActualSpeed)
        {
            FreeWheel();
        }
        else
        {            
            _processor.IncreaseSpeedTo(speed);
            _onBoardComputer.IncrementDrivingTime();
            _fuelTank.Consume(CalculateConsumption());
            _onBoardComputer.UpdateConsumption(CalculateConsumption(), _processor.ActualSpeed);
            _onBoardComputer.UpdateRange(CalculateConsumption(), _processor.ActualSpeed);
            _onBoardComputer.UpdateDistance(_processor.ActualSpeed);
        }

        if (_fuelTank.FillLevel == 0)
            _engine.Stop();
    }

    public void FreeWheel()
    {
        Console.WriteLine("Free Wheel");
        if (!EngineIsRunning)
        {
            _onBoardComputer.UpdateConsumption(0, _processor.ActualSpeed);
            return;
        }            

        if (_processor.ActualSpeed == 0)
        {
            RunningIdle();
            return;
        }

        _onBoardComputer.IncrementDrivingTime();
        _processor.ReduceSpeed(1);     
        _onBoardComputer.UpdateDistance(_processor.ActualSpeed);

        if (_processor.ActualSpeed == 0)
        {
            _fuelTank.Consume(IdleConsumption);
            _onBoardComputer.UpdateConsumption(IdleConsumption, _processor.ActualSpeed);
            _onBoardComputer.UpdateRange(IdleConsumption, _processor.ActualSpeed);
        }
        else
        {
            _onBoardComputer.UpdateConsumption(0, _processor.ActualSpeed);
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

    public double ActualConsumption => throw new NotImplementedException();

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

    public void EngineStart() => throw new NotImplementedException();
    public void EngineStop() => throw new NotImplementedException();
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

public class OnBoardComputer(DrivingProcessor processor, FuelTank fuelTank) : IOnBoardComputer
{
    private readonly DrivingProcessor _processor = processor;
    private readonly FuelTank _fuelTank = fuelTank;

    private int _tripTime = 0;
    private int _tripDrivingTime = 0;
    private decimal _tripDistance = 0;
    private int _totalTime = 0;
    private int _totalDrivingTime = 0;
    private decimal _totalDistance = 0;
    private List<double> _tripConsumptionByTime = [];
    private List<double> _totalConsumptionByTime = [];
    private List<double> _tripConsumptionByDistance = [];
    private List<double> _totalConsumptionByDistance = [];
    private Queue<double> _consumptionLast100 = new(Enumerable.Repeat(4.8, 100));

    public int TripRealTime { get => _tripTime; }
    public int TripDrivingTime { get => _tripDrivingTime; }
    public double TripDistance { get => (double)_tripDistance; }
    public int TotalRealTime { get => _totalTime; }
    public int TotalDrivingTime { get => _totalDrivingTime; }
    public double TotalDistance { get => (double)_totalDistance; }
    public double TripAverageSpeed { get => (double)(_tripDistance / (_tripDrivingTime / 3600m)); }
    public double TotalAverageSpeed { get => (double)(_totalDistance / (_totalDrivingTime / 3600m)); }
    public int ActualSpeed { get => _processor.ActualSpeed; }
    public double ActualConsumptionByTime { get => _tripConsumptionByTime.LastOrDefault(); }
    public double ActualConsumptionByDistance { get => _tripConsumptionByDistance.LastOrDefault(double.NaN); }

    public double TripAverageConsumptionByTime { get => CalcAverage(_tripConsumptionByTime); }
    public double TotalAverageConsumptionByTime { get => CalcAverage(_totalConsumptionByTime); }

    public double TripAverageConsumptionByDistance { get => CalcAverage(_tripConsumptionByDistance); }
    public double TotalAverageConsumptionByDistance { get => CalcAverage(_totalConsumptionByDistance); }

    public int EstimatedRange { get => (int)Math.Round(_fuelTank.FillLevel / _consumptionLast100.Average() * 100d); }    

    #region UNUSED
    public void ElapseSecond() => throw new NotImplementedException();
    public int TripDrivenDistance  => throw new NotImplementedException(); // WHY INT!?!?!?!??!!?
    public int TotalDrivenDistance => throw new NotImplementedException(); // WHY INT!?!?!?!??!!?
    #endregion

    public void IncrementDrivingTime()
    {
        ++_tripTime;
        ++_tripDrivingTime;
        ++_totalTime;        
        ++_totalDrivingTime;
    }

    public void IncrementIdleTime()
    {        
        ++_tripTime;        
        ++_totalTime;
    }

    public void UpdateDistance(int speedAtEndOfSecond)
    {
        decimal distance = speedAtEndOfSecond / 3600m;
        _tripDistance += distance;
        _totalDistance += distance;
    }

    public void UpdateConsumption(double consumption, int speed)
    {
        double litersPer100Km = speed > 0 ? 
            100d / speed * consumption * 3600d : 
            double.NaN;
        _tripConsumptionByDistance.Add(litersPer100Km);
        _totalConsumptionByDistance.Add(litersPer100Km);

        _tripConsumptionByTime.Add(consumption);
        _totalConsumptionByTime.Add(consumption);        
    }

    public void UpdateRange(double consumption, int speed)
    {
        double litersPer100Km = speed > 0 ? 
            Math.Round(100d / speed * consumption * 3600, 10) : 
            0;

        _consumptionLast100.Enqueue(litersPer100Km);
        _consumptionLast100.Dequeue();
    }

    public void TripReset()
    {
        _tripTime = 0;
        _tripDrivingTime = 0;
        _tripDistance = 0;
        _tripConsumptionByTime = [];
        _tripConsumptionByDistance = [];
    }   

    public void TotalReset()
    {
        _totalTime = 0;
        _totalDrivingTime = 0;
        _totalDistance = 0;
        _totalConsumptionByTime = [];
        _totalConsumptionByDistance = [];
    }

    private static double CalcAverage(List<double> values)
    {
        double sum = 0;
        int count = 0;
        foreach (double value in values)
        {
            if (!double.IsNaN(value))
            {
                ++count;
                sum += value;
            }
        }

        return count > 0? sum / count : 0; 
    }     
}

public class OnBoardComputerDisplay : IOnBoardComputerDisplay
{
    private readonly OnBoardComputer _onBoardComputer;
    public OnBoardComputerDisplay(OnBoardComputer onBoardComputer)
    {
        _onBoardComputer = onBoardComputer;
    }

    public int TripRealTime { get => _onBoardComputer.TripRealTime; }
    public int TripDrivingTime { get => _onBoardComputer.TripDrivingTime; }
    public double TripDrivenDistance { get => Math.Round(_onBoardComputer.TripDistance, 2); }
    public int TotalRealTime { get => _onBoardComputer.TotalRealTime; }
    public int TotalDrivingTime { get => _onBoardComputer.TotalDrivingTime; }
    public double TotalDrivenDistance { get => Math.Round(_onBoardComputer.TotalDistance, 2); }
    public int ActualSpeed { get => _onBoardComputer.ActualSpeed; }
    public double TripAverageSpeed { get => Math.Round(_onBoardComputer.TripAverageSpeed, 1); }
    public double TotalAverageSpeed { get => Math.Round(_onBoardComputer.TotalAverageSpeed, 1); }
    public double ActualConsumptionByTime { get => Math.Round(_onBoardComputer.ActualConsumptionByTime, 5); }
    public double ActualConsumptionByDistance { get => Math.Round(_onBoardComputer.ActualConsumptionByDistance, 1); }
    public double TripAverageConsumptionByTime { get => Math.Round(_onBoardComputer.TripAverageConsumptionByTime, 5); }
    public double TotalAverageConsumptionByTime { get => Math.Round(_onBoardComputer.TotalAverageConsumptionByTime, 5); }
    public double TripAverageConsumptionByDistance { get => Math.Round(_onBoardComputer.TripAverageConsumptionByDistance, 1); }
    public double TotalAverageConsumptionByDistance { get => Math.Round(_onBoardComputer.TotalAverageConsumptionByDistance, 1); }

    public int EstimatedRange { get => _onBoardComputer.EstimatedRange; }

    public void TotalReset()
    {
        _onBoardComputer.TotalReset();
    }

    public void TripReset()
    {
        _onBoardComputer.TripReset();
    }
}
