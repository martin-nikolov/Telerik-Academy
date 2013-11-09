using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public interface IUserInterface
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnActionPressed;

        void ProcessInput();
    }
}
