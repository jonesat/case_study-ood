using System;
using System.Collections.Generic;
using System.Text;

namespace IFN563_Project
{
    interface IMove : IGameElement
    {
        int Row { get; set; }
        int Column { get; set; }
        char Token { get; set; }
        User Controller { get; set; }
        int Turn_Created { get;}

        bool IsPlaced { get; }

        public void PlaceMove();
        public void UnPlaceMove();
        
        public string GetHash();

    }
}
