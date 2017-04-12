using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Politics.Service;
using Politics.Web.ViewModels;
using Politics.Model;
namespace Politics.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        IRegionService regionService;
        IOrderService orderService;
        public HomeController(IRegionService regionService, IOrderService orderService)
        {
            this.regionService = regionService;
            this.orderService = orderService;
        }

        [HttpGet]
        public ViewResult Index(int id = 1)
        {
            Region region = regionService.GetRegion(id);
            var regionViewModel = RegionModel.Init(region);

            return View(regionViewModel);
        }
        [HttpGet]
        public PartialViewResult Regions(int id)
        {
            var region = regionService.GetRegion(id);
            return PartialView(RegionModel.Init(region));
        }
        [HttpGet]
        public PartialViewResult Orders(int id)
        {
            var region = regionService.GetRegion(id);
            var ordersOf = orderService.GetOrdersOf(id);
            var ordersIn = orderService.GetOrdersIn(id);
            return PartialView(RegionWithOrdersModel.Init(region, ordersOf, ordersIn));
        }
        [HttpGet]
        public PartialViewResult CreateRegion(int parentid)
        {
            ViewBag.ParentID = parentid;
            return PartialView(new RegionCreateModel());
        }

        [HttpPost]
        public ActionResult CreateRegion(RegionCreateModel region, int parentId)
        {
            if (ModelState.IsValid)
            {
                regionService.CreateRegion(region.DomainRegion, parentId);
                return RedirectToAction("Regions", new { id = parentId });
            }
            else
            {
                ViewBag.ParentID = parentId;
                return PartialView(region);
            }
        }
        [HttpGet]
        public PartialViewResult CreateOrder(int regionId)
        {
            ViewBag.RegionID = regionId;
            return PartialView(new OrderCreateModel());
        }
        [HttpPost]
        public ActionResult CreateOrder(OrderCreateModel order, int regionId)
        {
            if (ModelState.IsValid)
            {
                var region = regionService.GetRegion(regionId);
                orderService.CreateOrder(order.GetDomainModel(region));
                return RedirectToAction("Orders", new { id = regionId }); // Orders(regionId);
            }
            else
            {
                ViewBag.RegionID = regionId;
                return PartialView(new OrderCreateModel());
            }
        }
        [HttpGet]
        public ActionResult Order(int id)
        {
            var order = orderService.GetOrder(id);
            var regions = orderService.GetRegions(order);
            return View(OrderModel.Init(order, regions));
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            ServiceException se = filterContext.Exception as ServiceException;
            if (se != null)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = View("ServiceError", (object)se.Message);
            }
        }
    }
}