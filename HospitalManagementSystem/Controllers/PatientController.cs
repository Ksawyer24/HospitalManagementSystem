using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "MainAdmin,Admin")]
        public async Task<IActionResult> GetAllAsync()
          {


            // Eager loading the MedicalHistory with Include
            var patient = await hospitalSysDbContext.Patients
                .Include(p => p.MedicalHistory)  // Eager load MedicalHistory
                .ToListAsync();

                if (patient == null)
                {
                  return NotFound();
                }

                   return Ok(patient);







            //var domain = await patientRepo.GetAllPatientsAsync();


            //var domdto = mapper.Map<List<PatientDto>>(domain);


            //return Ok(domdto);


          }



          [HttpGet]
          [Route("{id:long}")]
          [Authorize(Roles = "MainAdmin,Admin")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
             // Eager loading the MedicalHistory with Include
              var patient = await hospitalSysDbContext.Patients
                .Include(p => p.MedicalHistory)  // Eager load MedicalHistory
                .FirstOrDefaultAsync(p => p.Id == id);

               if (patient == null)
               {
                  return NotFound();
               }

                  return Ok(patient);



            //var eco = await patientRepo.GetPatientIdAsync(id);

            //if (eco == null)
            //{
            //    return NotFound();
            //}

            //return Ok(mapper.Map<PatientDto>(eco));

          }


          [HttpPost]
          [Authorize(Roles = "MainAdmin")]
        public async Task<IActionResult> Create([FromBody] AddPatientDto addPatientDto)
          {


              var ecodomainmodel = mapper.Map<Patient>(addPatientDto);


              ecodomainmodel = await patientRepo.CreateAsync(ecodomainmodel);


              var ecoDto = mapper.Map<PatientDto>(ecodomainmodel);


             return CreatedAtAction(nameof(GetById), new { id = ecoDto.Id }, ecoDto);


          }


          [HttpPut]
          [Route("{id:long}")]
          [Authorize(Roles = "MainAdmin")]

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
        [Authorize(Roles = "MainAdmin")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {

            var domainModel = await patientRepo.DeletePatientAsync(id);

            if (domainModel == null)
            {
                return NotFound();
            }

            // Return only the success message
            return Ok("Deleted successfully");
        }

    }
}
