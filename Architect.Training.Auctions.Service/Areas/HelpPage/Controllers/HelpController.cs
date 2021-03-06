using System;
using System.Web.Http;
using System.Web.Mvc;
using Architect.Training.Auctions.Service.Areas.HelpPage.ModelDescriptions;
using Architect.Training.Auctions.Service.Areas.HelpPage.Models;

namespace Architect.Training.Auctions.Service.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";


        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        /// <summary>
        ///  the issue was that there are two constructors in the HelpController. One that takes an HttpConfiguration, 
        /// and another that takes a GlobalConfiguration. I forced StructureMap to call the GlobalConfiguration 
        /// constuctor by making the Http constructor private
        /// </summary>
        /// <param name="config"></param>
        private HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}