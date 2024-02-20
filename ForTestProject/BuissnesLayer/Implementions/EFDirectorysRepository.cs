using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLayer.Implementions
{
    public class EFDirectorysRepository : IDirectrysRepository
    {
        private EFDBContext context;
        public EFDirectorysRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Directry> GetAllDirectrys(bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directry>().Include(x => x.Materials).AsNoTracking().ToList();
            else
                return context.Directry.ToList();
        }

        public Directry GetDirectryById(int directryId, bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directry>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directryId);
            else
                return context.Directry.FirstOrDefault(x => x.Id == directryId);
        }

        public void SaveDirectry(Directry directry)
        {
            if (directry.Id == 0)
                context.Directry.Add(directry);
            else
                context.Entry(directry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDirectry(Directry directry)
        {
            context.Directry.Remove(directry);
            context.SaveChanges();
        }
    }
}
