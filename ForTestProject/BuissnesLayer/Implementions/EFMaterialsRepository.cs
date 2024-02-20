using BuissnesLayer.Interfaces;
using DataLayer.Entityes;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BuissnesLayer.Implementions
{
    public class EFMaterialsRepository : IMaterialsRepository
    {
        private EFDBContext context;
        public EFMaterialsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Material> GetAllMaterials(bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directry).AsNoTracking().ToList();
            else
                return context.Material.ToList();
        }

        public Material GetMaterialById(int materialId, bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directry).AsNoTracking().FirstOrDefault(x => x.Id == materialId);
            else
                return context.Material.FirstOrDefault(x => x.Id == materialId);
        }

        public void SaveMaterial(Material material)
        {
            if (material.Id == 0)
                context.Material.Add(material);
            else
                context.Entry(material).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteMaterial(Material material)
        {
            context.Material.Remove(material);
            context.SaveChanges();
        }
    }
}
