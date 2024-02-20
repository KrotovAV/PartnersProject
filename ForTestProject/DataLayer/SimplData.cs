using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SimplData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Directry.Any())
            {
                context.Directry.Add(new Entityes.Directry() { Title = "First Directory", Html = "<b>Directory Content</b>" });
                context.Directry.Add(new Entityes.Directry() { Title = "Second Directory", Html = "<b>Directory Content</b>" });
                context.SaveChanges();

                context.Material.Add(new Entityes.Material() { Title = "First Material", Html = "<i>Material Content</i>", DirectryId = context.Directry.First().Id });
                context.Material.Add(new Entityes.Material() { Title = "Second Material", Html = "<i>Material Content</i>", DirectryId = context.Directry.First().Id });
                context.Material.Add(new Entityes.Material() { Title = "Third Material", Html = "<i>Material Content</i>", DirectryId = context.Directry.Last().Id });
                context.SaveChanges();
            }
        }
    }
}
