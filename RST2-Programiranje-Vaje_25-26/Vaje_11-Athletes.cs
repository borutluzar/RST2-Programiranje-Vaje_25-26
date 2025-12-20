using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RST2_Programiranje_Vaje_25_26
{
    public abstract class Athlete
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Athlete(string name, int age)
        {
            Name = name;
            Age = age;
        }
        protected IJump JumpStyle { get; set; }
        protected IRun RunStyle { get; set; }
        protected IThrow ThrowStyle { get; set; }
        public void Jumping()
        {
            if (JumpStyle != null)
            {
                JumpStyle.TakeOff();
                JumpStyle.Jump();
                JumpStyle.Land();
            }
        }
        public void Running()
        {
            if (RunStyle != null)
            {
                RunStyle.StartRunning();
                RunStyle.Run();
                RunStyle.Run();
                RunStyle.Run();
                RunStyle.Run();
                RunStyle.Run();
                RunStyle.StopRunning();
            }
        }
        public void Throwing()
        {
            if (ThrowStyle != null)
            {
                ThrowStyle.Throw();
            }
        }
    }
    public class Sprinter : Athlete
    {
        public Sprinter(string name, int age) : base(name, age)
        {
            this.RunStyle = new Sprinting();
        }
    }

    public class Thrower : Athlete
    {
        public Thrower(string name, int age) : base(name, age)
        {
            this.ThrowStyle = new JavelinThrow();
        }

    }
    public class Jumper : Athlete
    {
        public Jumper(string name, int age) : base(name, age)
        {
            this.JumpStyle = new JumpHigh();
        }
    }
    public class Decathloner : Athlete
    {
        public Decathloner(string name, int age) : base(name, age)
        {
            this.JumpStyle = new JumpDistance();
            this.RunStyle = new Sprinting();
        }
    }

    public interface IJump
    {
        void TakeOff();
        void Jump();
        void Land();
    }
    public interface IRun
    {
        void StartRunning();
        void StopRunning();
        void Run();
    }
    public interface IThrow
    {
        void Throw();
    }
    public class JumpDistance : IJump
    {
        public void TakeOff()
        {
            Console.WriteLine("Taking off for distance jump");
        }
        public void Jump()
        {
            Console.WriteLine("I jumped");
        }
        public void Land()
        {
            Console.WriteLine("I tried landing.");
        }
    }
    public class JumpHigh : IJump
    {
        public void TakeOff()
        {
            Console.WriteLine("Taking off for height jump");
        }
        public void Jump()
        {
            Console.WriteLine("I jumped");
        }
        public void Land()
        {
            Console.WriteLine("I tried landing.");
        }
    }

    public class Sprinting : IRun
    {
        public void StartRunning()
        {
            Console.WriteLine("Starting sprint");
        }
        public void Run()
        {
            Console.WriteLine("I am sprinting");
        }
        public void StopRunning()
        {
            Console.WriteLine("Stopping sprint");
        }
    }

    public class JavelinThrow : IThrow
    {
        public void Throw()
        {
            Console.WriteLine("Throwing javelin");
        }
    }
}
