using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace GameOfLife
{
    public class City
    {
        private int _x;
        private int _y;
        public bool Live;
        public string Display = "-";
        
        private Array Neighbours = new Array[8];
        public City(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void SetLifeDisplay()
        {
            Display = Live ? "0" : "-";
        }
    }
}