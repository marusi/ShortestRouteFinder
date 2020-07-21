using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouteSafi.Application.Routes.FindBestRoute;
using RouteSafi.Application.Services;

namespace RouteSafi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        public IRouteService _service { get; set; }

        public RouteController(IRouteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<RouteResponse>> GetBestRoute([FromQuery] RouteRequest routeRequest)
        {
            return Ok(await _service.FindBestRoute(routeRequest));
        }
    }
}
