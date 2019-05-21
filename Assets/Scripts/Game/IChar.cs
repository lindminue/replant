using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Char {

    interface IChar {

        List< int > getMoveList( );

        void init( );

    }
}
