using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuissnesLayer.Interfaces
{
    public interface IDirectrysRepository
    {
        IEnumerable<Directry> GetAllDirectrys(bool includeMaterials = false);
        Directry GetDirectryById(int directoryId, bool includeMaterials = false);
        void SaveDirectry(Directry achieve);
        void DeleteDirectry(Directry achieve);
    }
}
