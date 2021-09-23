using LibraryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Controllers
{
    public class BaseController : Controller
    {
        public ViewResult GetView(object viewModel = null)
        {
            if (viewModel == null)
                viewModel = new BaseViewModel();

            if(viewModel != null && viewModel is BaseViewModel)
            {

            }

            return View(viewModel);
        }
    }
}
