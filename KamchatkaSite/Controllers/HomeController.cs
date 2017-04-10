using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KamchatkaSite.Controllers
{
    public class HomeController : Controller
    {
        KmTableEntities context = new KmTableEntities();
        public ActionResult Service(string seasonName, string categoryName)
        {
          
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
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
        [HttpPost]
        public ActionResult ServiceAjaxData(int id)
        {
            
                ServiceTable serv = context.ServiceTable.FirstOrDefault(c => c.ServiceID == id);
            var result = new
            {
                ServiceDescriptionRus = serv.ServiceDescriptionRus,
                ServiceNameRus = serv.ServiceNameRus
            };
                return Json(result, JsonRequestBehavior.AllowGet);
            
            
        }

    }
}