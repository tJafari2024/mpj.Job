﻿using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Web.ViewComponents
{
    #region site header

    public class SiteHeaderViewComponent : ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return View("SiteHeader");
           
            
        }
    }
  

    #endregion

    #region site footer

    public class SiteFooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteFooter");
        }
    }
  

    #endregion

   
}
