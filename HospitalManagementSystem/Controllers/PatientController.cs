using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;
        private readonly IPatientRepo patientRepo;
        private readonly IMapper mapper;

        public PatientController(HospitalSysDbContext hospitalSysDbContext, IPatientRepo patientRepo,IMapper mapper)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
            this.patientRepo = patientRepo;
            this.mapper = mapper;
        }


        
         [HttpGet]
          public async Task<IActionResult> GetAllAsync()
          {

              var domain = await patientRepo.GetAllPatientsAsync();


              var domdto = mapper.Map<List<PatientDto>>(domain);


              return Ok(domdto);


          }



          [HttpGet]
          [Route("{id:long}")]


          public async Task<IActionResult> GetById([FromRoute] long id)
          {




              var eco = await patientRepo.GetPatientIdAsync(id);

              if (eco == null)
              {
                  return NotFound();
              }

              return Ok(mapper.Map<PatientDto>(eco));

          }


          [HttpPost]

          public async Task<IActionResult> Create([FromBody] AddPatientDto addPatientDto)
          {


              var ecodomainmodel = mapper.Map<Patient>(addPatientDto);


              ecodomainmodel = await patientRepo.CreateAsync(ecodomainmodel);


              var ecoDto = mapper.Map<PatientDto>(ecodomainmodel);


             return CreatedAtAction(nameof(GetById), new { id = ecoDto.Id }, ecoDto);


          }


          [HttpPut]
          [Route("{id:long}")]

          public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] UpdatePatientDto updatePatientDto)
          {


              var ecodomainmodel = mapper.Map<Patient>(updatePatientDto);


              ecodomainmodel = await patientRepo.UpdatePatientAsync(id, ecodomainmodel);

              if (ecodomainmodel == null)
              {
                  return NotFound();
              }


              return Ok(mapper.Map<PatientDto>(ecodomainmodel));


          }



          [HttpDelete]
          [Route("{id:long}")]

          public async Task<IActionResult> Delete([FromRoute] long id)
          {

              var regionDomainModel = await patientRepo.DeletePatientAsync(id);


              if (regionDomainModel == null)
              {
                  return NotFound("Product has been deleted or is not found");
              }




              return Ok(mapper.Map<PatientDto>(regionDomainModel));


          }
         
    }
}
