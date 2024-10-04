using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.DoctorManagement;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    [Authorize(Roles = "MainAdmin")]
    public class DoctorController : ControllerBase
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;
        private readonly IDoctorRepo doctorRepo;
        private readonly IMapper mapper;

        public DoctorController(HospitalSysDbContext hospitalSysDbContext,IDoctorRepo doctorRepo,IMapper mapper)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
            this.doctorRepo = doctorRepo;
            this.mapper = mapper;
        }

       [HttpGet]
       public async Task<IActionResult> GetAllDocs()
       {

            var dom = await doctorRepo.GetAllDoctorsAsync();


            var dto = mapper.Map<List<DoctorDto>>(dom);


            return Ok(dto);

       }



        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {

            var doc = await doctorRepo.GetDoctorsIdAsync(id);

            if (doc == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DoctorDto>(doc));
        }


        [HttpPost]
        public async Task<IActionResult> AddDoc([FromBody] AddDoctorDto addDoctorDto)
        {
            //Map or convert dto to domain model

            var domainModel = mapper.Map<Doctor>(addDoctorDto);


            //Use domain model to create doctor 

            domainModel = await doctorRepo.CreateAsync(domainModel);

            //map domain model back to dto
            var docDto = mapper.Map<DoctorDto>(domainModel);


            return CreatedAtAction(nameof(GetById), new { id = docDto.Id }, domainModel);


        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateDoc([FromRoute] long id , UpdateDoctorDto updateDoctorDto)
        {
            //map dto to domain model
            var regionDomainmodel = mapper.Map<Doctor>(updateDoctorDto);



            //Check if doc exists
            regionDomainmodel = await doctorRepo.UpdateDoctorAsync(id, regionDomainmodel);

            if (regionDomainmodel == null)
            {
                return NotFound();
            }



            //map dto to domain model


            //convert domain model to dto


            return Ok(mapper.Map<DoctorDto>(regionDomainmodel));
        }




        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var domainModel = await doctorRepo.DeleteDoctorsAsync(id);

            if (domainModel == null)
            {
                return NotFound();
            }

            // Return only the success message
            return Ok("Deleted successfully");
        }




    }
}
