using AUBNB.Application.Features.Hostings;
using AUBNB.Application.Features.Hostings.Commands;
using AUBNB.Domain.Features.Hostings;
using AUBNB.Web.API.Controllers.Hostings.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AUBNB.Web.API.Controllers.Hostings
{
    [ApiController]
    [Route("api/[controller]")]
    public class HostingsController : ControllerBase
    {
        private readonly IHostingService _hostingService;

        public HostingsController(IHostingService hostingService)
        {
            _hostingService = hostingService;
        }

        [HttpGet]
        [Route("{userId:int}")]
        public IQueryable<HostingResumeViewModel> GetAll(int userId)
        {
            var resumeViewModels = new List<HostingResumeViewModel>();
            var resumeViewModel = new HostingResumeViewModel();

            var hostings = _hostingService.GetAll(userId);

            foreach (var hosting in hostings)
            {
                resumeViewModel.Id = hosting.Id;
                resumeViewModel.Description = hosting.Description;
                resumeViewModel.Price = hosting.Price;
                resumeViewModel.Note = hosting.Note;
                resumeViewModel.Neighborhood = hosting.Neighborhood;
                resumeViewModel.City = hosting.City;
                resumeViewModel.AnimalSize = hosting.AnimalSize;
                resumeViewModel.HasDog = hosting.HasDog;
                resumeViewModel.PlaceDescription = hosting.PlaceDescription;
                resumeViewModel.PatioSize = hosting.PatioSize;
                resumeViewModel.HousingType = hosting.HousingType;
                resumeViewModel.User = hosting.User.Name;

                resumeViewModels.Add(resumeViewModel);
                resumeViewModel = new HostingResumeViewModel();
            }

            return resumeViewModels.AsQueryable();
        }

        [HttpGet]
        [Route("by-id/{id:int}")]
        public async Task<HostingResumeViewModel> GetById(int id)
        {
            var resumeViewModel = new HostingResumeViewModel();

            var hosting = await _hostingService.GetById(id);

            resumeViewModel.Id = hosting.Id;
            resumeViewModel.Description = hosting.Description;
            resumeViewModel.Price = hosting.Price;
            resumeViewModel.Note = hosting.Note;
            resumeViewModel.Neighborhood = hosting.Neighborhood;
            resumeViewModel.City = hosting.City;
            resumeViewModel.AnimalSize = hosting.AnimalSize;
            resumeViewModel.HasDog = hosting.HasDog;
            resumeViewModel.PlaceDescription = hosting.PlaceDescription;
            resumeViewModel.PatioSize = hosting.PatioSize;
            resumeViewModel.HousingType = hosting.HousingType;
            resumeViewModel.User = hosting.User.Name;
            resumeViewModel.TelephoneNumber = hosting.User.TelephoneNumber;

            return resumeViewModel;
        }

        [HttpPost]
        public async Task<ObjectResult> PostAsync(HostingCreateCommand command)
        {
            ValidationResult resultadoValidacao = command.Validate();

            if (!resultadoValidacao.IsValid)
                throw new Exception("Erro de validação!");

            await _hostingService.AddAsync(command);

            return StatusCode(201, command);
        }
    }
}
