﻿using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.PharmacyManagement;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;
        private readonly IPrescriptionRepo prescriptionRepo;
        private readonly IMapper mapper;

        public PrescriptionController(HospitalSysDbContext hospitalSysDbContext,IPrescriptionRepo prescriptionRepo,IMapper mapper)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
            this.prescriptionRepo = prescriptionRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var domain = await prescriptionRepo.GetAllAsync();


            var domdto = mapper.Map<List<PrescriptionDto>>(domain);


            return Ok(domdto);


        }


        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {



            var eco = await prescriptionRepo.GetPrescriptionIdAsync(id);

            if (eco == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PrescriptionDto>(eco));


        }

        


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddPrescriptionDto addPrescriptionDto)
        {


            var ecodomainmodel = mapper.Map<Prescriptions>(addPrescriptionDto);


            ecodomainmodel = await prescriptionRepo.CreateAsync(ecodomainmodel);


            var ecoDto = mapper.Map<PrescriptionDto>(ecodomainmodel);

            return CreatedAtAction(nameof(GetById), new { id = ecoDto.Id }, ecoDto);


        }


        [HttpPut]
        [Route("{id:long}")]

        public async Task<IActionResult> UpdatePrescription([FromRoute] long id, [FromBody] UpdatePrescription updatePrescription)
        {


            var ecodomainmodel = mapper.Map<Prescriptions>(updatePrescription);


            ecodomainmodel = await prescriptionRepo.UpdatePrescriptionAsync(id, ecodomainmodel);

            if (ecodomainmodel == null)
            {
               return NotFound();
            }


            return Ok(mapper.Map<PrescriptionDto>(ecodomainmodel));


        }


        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var domainModel = await prescriptionRepo.DeletePrescriptionAsync(id);

            if (domainModel == null)
            {
                return NotFound();
            }

            // Return only the success message
            return Ok("Deleted successfully");
        }
    }
}