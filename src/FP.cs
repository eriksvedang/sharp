using System.Collections;
using UnityEngine;

namespace Jam
{
    public static class FP
    {
        public static T Identity<T>(T x)
        {
            return x;
        }
    }
}