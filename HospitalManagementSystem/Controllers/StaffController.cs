using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.StaffManagement;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;
        private readonly IStaffRepo staffRepo;
        private readonly IMapper mapper;

        public StaffController(HospitalSysDbContext hospitalSysDbContext,IStaffRepo staffRepo,IMapper mapper)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
            this.staffRepo = staffRepo;
            this.mapper = mapper;
        }



      [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var domain = await staffRepo.GetAllStaffAsync();


            var domdto = mapper.Map<List<StaffDto>>(domain);


            return Ok(domdto);

        }


        [HttpGet]
        [Route("{id:long}")]

        public async Task<IActionResult> GetById([FromRoute] long id)
        {




            var eco = await staffRepo.GetStaffIdAsync(id);

            if (eco == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<StaffDto>(eco));

        }




        [HttpPost]
        public async Task<IActionResult> AddStaff([FromBody] AddStaffDto addStaffDto)
        {
            var ecodomainmodel = mapper.Map<Staff>(addStaffDto);


            ecodomainmodel = await staffRepo.CreateAsync(ecodomainmodel);


            var ecoDto = mapper.Map<StaffDto>(ecodomainmodel);


            return CreatedAtAction(nameof(GetById), new { id = ecoDto.Id }, ecoDto);


        }



        [HttpPut]
        [Route("{id:long}")]

        public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] UpdateStaffDto updateStaffDto)
        {


            var updates = mapper.Map<Staff>(updateStaffDto);


            updates = await staffRepo.UpdateStaffAsync(id, updates);

            if (updates == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<StaffDto>(updates));


        }



        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var domainModel = await staffRepo.DeleteStaffAsync(id);

            if (domainModel == null)
            {
                return NotFound();
            }

            // Return only the success message
            return Ok("Deleted successfully");
        }


    }

}
