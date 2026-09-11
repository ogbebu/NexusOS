using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NexusOS.System.Processing
{
    public class Process
    {
        public virtual void Run()
        {

        }

        public virtual void Start()
        {

        }

        public string Name, User, Description;
        public float Ussage;
        public int PID;

        public WindowData WindowData = new WindowData();
    }

    public class WindowData
    {
        public Rectangle WinPos = new Rectangle { X=100, Y=100, Height=100, Width=100};
        public bool Moveable = true;
    }
}
