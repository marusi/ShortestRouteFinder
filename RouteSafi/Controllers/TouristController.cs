
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RouteSafi.Domain.Services;
using RouteSafi.Infrastructure;


using RouteSafi.Domain.Models;

using RouteSafi.Infrastructure.DTO;

namespace TouristChallenge1.Controllers
{
    [Route("/api/tourists")]
    public class TouristController : Controller
    {
        private readonly IMapper mapper;
        private readonly ITouristRepository repository;
        private readonly IUnitOfWork unitOfWork;

        private readonly AppDbContext context;
       


        public TouristController(AppDbContext context, IMapper mapper, ITouristRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.context = context;
            this.repository = repository;
            this.unitOfWork = unitOfWork;

        }


        [HttpPost]
        /// <summary>
        /// Create and Post a name and ID of a person to associate with a CSV Document.
        /// </summary>
        /// <remarks>
        /// Here is a sample remarks placeholder.
        /// </remarks>
       
   
        /// <returns>A string status</returns>
        public async Task<IActionResult> CreateTourist([FromBody] SaveTouristDTO touristResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);




            var tourist = mapper.Map<SaveTouristDTO, Tourist>(touristResource);

            tourist.LastUpdate = DateTime.Now;

            repository.Add(tourist);
            await unitOfWork.CompleteAsync();



            tourist = await repository.GetTourist(tourist.Id);

            var result = mapper.Map<Tourist, TouristDTO>(tourist);
            return Ok(result);
        }

       



    }
}
