using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KamchatkaSite.Controllers
{
    public class HomeController : Controller
    {
 
        public ActionResult Service(string seasonName, string categoryName)
        {
            KmTableEntities context = new KmTableEntities();
            SeasonTable selectedSeason = context.SeasonTable.Where(c => c.SeasonUrlName.Equals(seasonName)).FirstOrDefault();
            CategoryTable selectedCategory = context.CategoryTable.Where(c => c.CategoryUrlName.Equals(categoryName)).FirstOrDefault();
            if (seasonName!=null && selectedSeason==null || categoryName!=null && selectedCategory==null)
            {
                List<SeasonTable> seasons = context.SeasonTable.ToList();
                return View("SeasonsView", seasons);
            }


            if (seasonName != null && categoryName == null)
             {
                
                selectedSeason = context.SeasonTable.Where(c => c.SeasonUrlName.Equals(seasonName)).FirstOrDefault();
                List<CategoryTable> categories = context.CategoryTable.Where(c => c.SeasonID == selectedSeason.SeasonID).ToList();
                
                return View("CategoriesView",categories);
             }
            else if (seasonName != null && categoryName != null)
            {
                selectedCategory = context.CategoryTable.Where(c => c.CategoryUrlName.Equals(categoryName)).FirstOrDefault();
                List<ServiceTable> definedServices = context.ServiceTable.Where(c => c.CategoryID == selectedCategory.CategoryID).ToList();
                return View("ServicesView", definedServices);
            }
            else
            {

                List<SeasonTable> seasons = context.SeasonTable.ToList();
                return View("SeasonsView", seasons);
            }

        }


    }
}