using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/medicalhistory")]
    [ApiController]

    public class MedicalHistoryController : ControllerBase
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;
        private readonly IMedicalHistoryRepo medicalHistoryRepo;
        private readonly IMapper mapper;

        public MedicalHistoryController(HospitalSysDbContext hospitalSysDbContext,IMedicalHistoryRepo medicalHistoryRepo,IMapper mapper)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
            this.medicalHistoryRepo = medicalHistoryRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "MainAdmin,Admin")]
        public async Task<IActionResult> GetAllAsync()
        {

            var domain = await medicalHistoryRepo.GetAllHistoriesAsync();


            var domdto = mapper.Map<List<MedicalHistoryDto>>(domain);


            return Ok(domdto);


        }



        [HttpGet]
        [Route("{id:long}")]
        [Authorize(Roles = "MainAdmin,Admin")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {

            var eco = await medicalHistoryRepo.GetHistoryIdAsync(id);

            if (eco == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<MedicalHistoryDto>(eco));

        }


      //[HttpPost]
      //  public async Task<IActionResult> Create([FromBody] AddMedicalHistory addMedicalHistory)
      //  {

      //      var ecodomainmodel = mapper.Map<MedicalHistory>(addMedicalHistory);


      //      ecodomainmodel = await medicalHistoryRepo.CreateAsync(ecodomainmodel);


      //      var ecoDto = mapper.Map<MedicalHistoryDto>(ecodomainmodel);


      //      return CreatedAtAction(nameof(GetById), new { id = ecoDto.Id }, ecoDto);

      //  }
      


        [HttpPut]
        [Route("{id:long}")]
        [Authorize(Roles = "MainAdmin")]

        public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] UpdateMedicalHistory updateMedicalHistory)
        {




            var ecodomainmodel = mapper.Map<MedicalHistory>(updateMedicalHistory);




            ecodomainmodel = await medicalHistoryRepo.UpdateHistoryAsync(id, ecodomainmodel);

            if (ecodomainmodel == null)
            {
                return NotFound();
            }




            return Ok(mapper.Map<MedicalHistoryDto>(ecodomainmodel));




        }


        [HttpDelete]
        [Route("{id:long}")]
        [Authorize(Roles = "MainAdmin")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var domainModel = await medicalHistoryRepo.DeleteHistoryAsync(id);

            if (domainModel == null)
            {
                return NotFound();
            }

            // Return only the success message
            return Ok("Deleted successfully");
        }


    }
}
