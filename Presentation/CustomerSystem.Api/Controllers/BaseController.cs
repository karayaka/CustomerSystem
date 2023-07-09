using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomerSystm.Domain.DTOModels.BaseDtos;
using CustomerSystm.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected IActionResult ErrorHadler(Exception eror)
        {
            if (eror is UnAuthorizedException)
                return Unauthorized(new ErrorResponse(eror.Message));
            if (eror is NotFoundException)
                return NotFound(new ErrorResponse(eror.Message));
            if (eror is ValidationException)
                return UnprocessableEntity(new ErrorResponse(eror.Message));
            else
                return BadRequest(new ErrorResponse("Beklenmedik Bir Hata Oluştu"));
        }

    }
}

