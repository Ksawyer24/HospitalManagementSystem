using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.DoctorManagement;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     
    public class AppointmentController : ControllerBase
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;
        private readonly IAppointmentRepo appointmentRepo;
        private readonly IMapper mapper;

        public AppointmentController(HospitalSysDbContext hospitalSysDbContext, IAppointmentRepo appointmentRepo, IMapper mapper)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
            this.appointmentRepo = appointmentRepo;
            this.mapper = mapper;
        }


        [HttpGet]
        [Authorize(Roles = "MainAdmin,Admin")]
       
        public async Task<IActionResult> GetAllDocs()
        {

            var dom = await appointmentRepo.GetAllAppointmentsAsync();


            var dto = mapper.Map<List<AppointmentDto>>(dom);


            return Ok(dto);

        }



        [HttpGet]
        [Route("{id:long}")]
        [Authorize(Roles = "MainAdmin,Admin")]
       
        public async Task<IActionResult> GetById([FromRoute] long id)
        {

            var doc = await appointmentRepo.GetAppointmentsIdAsync(id);

            if (doc == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AppointmentDto>(doc));

        }



        [HttpPost]
        [Authorize(Roles = "MainAdmin")]
        public async Task<IActionResult> AddDoc([FromBody] AddAppointmentDto addAppointmentDto)
        {
            //Map or convert dto to domain model

            var domainModel = mapper.Map<Appointment>(addAppointmentDto);


            //Use domain model to create 

            domainModel = await appointmentRepo.CreateAsync(domainModel);

            //map domain model back to dto
            var docDto = mapper.Map<AppointmentDto>(domainModel);


            return CreatedAtAction(nameof(GetById), new { id = docDto.AppointmentId }, domainModel);

        }


        [HttpPut]
        [Route("{id:long}")]
        [Authorize(Roles = "MainAdmin")]
        public async Task<IActionResult> UpdateDoc([FromRoute] long id, UpdateAppointmentDto updateAppointmentDto)
        {

            //map dto to domain model
            var regionDomainmodel = mapper.Map<Appointment>(updateAppointmentDto);


            //Check if appointment exists
            regionDomainmodel = await appointmentRepo.UpdateAppointmentsAsync(id, regionDomainmodel);

            if (regionDomainmodel == null)
            {
                return NotFound();
            }

            //map dto to domain model

            //convert domain model to dto


            return Ok(mapper.Map<AppointmentDto>(regionDomainmodel));

        }




        [HttpDelete]
        [Route("{id:long}")]
        [Authorize(Roles = "MainAdmin")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var domainModel = await appointmentRepo.DeleteAppointmentsAsync(id);

            if (domainModel == null)
            {
                return NotFound();
            }


            
            // Return only the success message
            return Ok("Deleted successfully");

        }
    }
}
