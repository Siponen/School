using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        T[] vehicles;
        public T[] Vehicles { get { return vehicles; } }
        public string Name { get; private set; }
        public uint Count { get; private set; }
        public uint Capacity { get; private set; }

        public Garage(string name, uint numberOfSlots)
        {
            Name = name;
            Capacity = numberOfSlots;
            vehicles = new T[numberOfSlots];
            Count = 0;
        }

        public bool Add(T vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicle.ParkingSlot = i;
                    vehicles[i] = vehicle;
                    Count += 1;
                    return true;
                }
            }

            return false;
        }

        public bool Remove(int registerNumber)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if(vehicles[i]?.RegisterNumber == registerNumber)
                {
                    vehicles[i] = null;
                    Count -= 1;
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < vehicles.Length; i++)
            {
                if(vehicles[i] != null)
                {
                    yield return vehicles[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
