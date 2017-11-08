using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void HelloFunctionDelegate(string message);

namespace Exam1Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Model m = new Model();
            Controller c = new Controller(m);
            InputViewForm i = new InputViewForm(c.handle);  // recall that  c.handle  has type InputHandler
            OutputViewForm f = new OutputViewForm(m);
            f.Show();    // C# requires that you tell an output form to show itself
            c.register(f.update);   //  f.update  has type  Observer
        }
        
    }

    class OutputViewForm : IObserver
    {
        public void update()
        {

        }
    }

    class Model
    {
        int data = 1;
    }

    class InputViewForm
    {
        public void ViewForm(IInputHandler han)
        {

        }

        public void OnEnter()
        {

        }
    }

    class Controller : IInputHandler
    {
        List<IObserver> registry = new List<IObserver>();

        Model _m;
        public Controller(Model m)
        {
            _m = m;
        }

        public void Handle()
        {
        }

    }

    interface IObserver
    {
        void update();
    }
    interface IInputHandler
    {
        void Handle();

    }

}
