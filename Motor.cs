using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Curso_MotoresIndustriales
{
    // S.O.L.I.D.
    

    public interface IStartable
    {
        void Start();
    }

    /// <summary>
    /// Proporciona el metodo para parar el motor.
    /// </summary>
    public interface IStopable
    {        
        void Stop();
    }



    public abstract class Motor
    {
        public double Power { get; set; }
        public double RPM { get; set; }
      
        public abstract void Start();
    }


    public class Ladron : IStopable
    {
        public event EventHandler StopChanged;



        public void Stop()
        {
            OnStopChanged();
        }

        protected void OnStopChanged()
        {
            var handler = StopChanged;

            if (handler != null)
                StopChanged.Invoke(this, EventArgs.Empty);
        }
    }






    public class Tank
    {
        public event EventHandler RefillRequired;

        public double Volumne { get; set; }

        public void Refill()
        {
        }
    }

    public abstract class CombMotor : Motor, IStartable, IStopable
    {
 
    

        public void Stop()
        {
            throw new NotImplementedException();            
        }

        public Tank Tank { get; }

    }





    public class DieselMotor : CombMotor
    {
        public override void Start()
        {
            throw new NotImplementedException();
        }
        
    }

    public class GasMotor : CombMotor
    {
        public override void Start()
        {
            throw new NotImplementedException();
        }
    }


    public class GravityMotor : Motor
    {
        public override void Start()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class ElectricMotor : Motor, IStartable, IStopable
    {
        public double? Voltage { get;  set; }
        public double? Current { get; set; }
        public double? Resistence { get; set; }

        public abstract double? GetPower();

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
    public class DCElectricMotor : ElectricMotor
    {
        public override double? GetPower()
        {
            return this.Voltage * this.Current;
        }

        public void XX()
        {
            this.Start();
        }
    }

    public class ACElectricMotor : ElectricMotor
    {
        public double? CosPhi { get; set; }

        public override double? GetPower()
        {
            return this.Voltage * this.Current * this.CosPhi;
        }

        public bool CheckFrequencyBHJBJHBDSD()
        {
            return true;
        }

        public override void Start()
        {
            base.Start();

            if (this.CheckFrequencyBHJBJHBDSD())
            {
                // arranque
            }
        }

        void FFF()
        {
            
        }

    }

 

    public class Inverter
    {
        void Start()
        {

        }

        public bool CheckFrequency()
        {
            CountarMotores(new List<Motor> { new DieselMotor() , new GasMotor(), new ACElectricMotor() });

            return true;            
        }

        public void CountarMotores(List<Motor> motores)
        {
            int m = 0, c = 0, d = 0;

            foreach (var motor in motores)
            {
                if (motor is Motor)
                    m++;

                if (motor is CombMotor)
                    c++;

                if (motor is DieselMotor)
                    d++;
            }


            
        }

        public void ArrancarMotores(List<Motor> motores)
        {
            foreach (var motor in motores)
            {
                motor.Start();
            }

            this.StopAll(new List<IStopable> { new ACElectricMotor(), new Ladron() });

        }

        public void StopAll(List<IStopable> devices)
        {
            foreach (var device in devices)
            {
                device.Stop();
            }
        }
    }
}
