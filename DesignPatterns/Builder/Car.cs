using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class Car
    {
        public int TopSpeedMPH { get; set; }
        public int HorsePower { get; set; }
        public string MostImpressiveFeature { get; set; }

    }

    /// <summary>
    /// Builder builds the car and sets specific properties of the car- This process can be done differently by different type of builders
    /// </summary>

    public abstract class CarBuilder {
        protected readonly Car _car = new Car();
        public abstract void SetHorsePower();
        public abstract void SetTopSpeed();
        public abstract void SetImpressiveFeature();
        //Retreive the modified car
        public virtual Car GetCar() {
            return _car;
        }
    }
    /// <summary>
    /// Factory directs builder to build the car
    /// </summary>
    public class CarFactory {
        public Car Build(CarBuilder builder) {
            builder.SetHorsePower();
            builder.SetTopSpeed();
            builder.SetImpressiveFeature();
            return builder.GetCar();

        }
    }

    //Concrete Builder 1
    public class NotSoSuperCarBuilder : CarBuilder {
        public override void SetHorsePower() =>
            _car.HorsePower = 120;
        public override void SetTopSpeed() =>
            _car.TopSpeedMPH = 70;
        public override void SetImpressiveFeature() =>
            _car.MostImpressiveFeature = "Has air conditioning";
    }
    //Concrete builder 2
    public class SuperCarBuilder : CarBuilder
    {
        public override void SetHorsePower() =>
            _car.HorsePower = 1640;
        public override void SetTopSpeed() =>
            _car.TopSpeedMPH = 600;
        public override void SetImpressiveFeature() =>
            _car.MostImpressiveFeature = "Can Fly";
    }
}
