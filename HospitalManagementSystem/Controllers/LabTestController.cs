using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.DoctorManagement;
using HospitalManagementSystem.Models.LabManagement;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/labtests")]
    [ApiController]
    [Authorize(Roles = "MainAdmin")]
    public class LabTestController : ControllerBase
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;
        private readonly ILabTestRepo labTestRepo;
        private readonly IMapper mapper;

        public LabTestController(HospitalSysDbContext hospitalSysDbContext,ILabTestRepo labTestRepo,IMapper mapper)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
            this.labTestRepo = labTestRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocs()
        {

            var dom = await labTestRepo.GetAllTestsAsync();


            var dto = mapper.Map<List<LabTestDto>>(dom);


            return Ok(dto);

        }



        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {

            var doc = await labTestRepo.GetTestIdAsync(id);

            if (doc == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<LabTestDto>(doc));
        }


        [HttpPost("labtest-add")]
        public async Task<IActionResult> AddDoc([FromBody] AddLabTestDto addLabTestDto)
        {
            //Map or convert dto to domain model

            var domainModel = mapper.Map<LabTest>(addLabTestDto);


            //Use domain model to create test

            domainModel = await labTestRepo.CreateAsync(domainModel);

            //map domain model back to dto
            var docDto = mapper.Map<LabTestDto>(domainModel);


            return CreatedAtAction(nameof(GetById), new { id = docDto.Id }, domainModel);


        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateDoc([FromRoute] long id, UpdateLabTestDto updateLabTestDto)
        {
            //map dto to domain model
            var testDomainmodel = mapper.Map<LabTest>(updateLabTestDto);



            //Check if doc exists
            testDomainmodel = await labTestRepo.UpdateTestAsync(id, testDomainmodel);

            if (testDomainmodel == null)
            {
                return NotFound();
            }


            //map dto to domain model

            //convert domain model to dto


            return Ok(mapper.Map<DoctorDto>(testDomainmodel));
        }




        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var domainModel = await labTestRepo.DeleteTestAsync(id);

            if (domainModel == null)
            {
                return NotFound();
            }

            // Return only the success message
            return Ok("Deleted successfully");
        }




    }
}

