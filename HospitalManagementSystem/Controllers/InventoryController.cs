﻿using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.PharmacyManagement;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    [Authorize(Roles = "MainAdmin")]
    public class InventoryController : ControllerBase
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;
        private readonly IInventoryRepo inventoryRepo;
        private readonly IMapper mapper;

        public InventoryController(HospitalSysDbContext hospitalSysDbContext,IInventoryRepo inventoryRepo,IMapper mapper)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
            this.inventoryRepo = inventoryRepo;
            this.mapper = mapper;
        }



        [HttpGet("inventory-total")]
        public async Task<IActionResult> GetAllAsync()
        {

            var domain = await inventoryRepo.GetAllInventoriesAsync();


           var domdto = mapper.Map<List<InventoryDto>>(domain);


           return Ok(domdto);

        }


        [HttpGet]
        [Route("{id:long}")]

        public async Task<IActionResult> GetById([FromRoute] long id)
        {

            var eco = await inventoryRepo.GetInvIdAsync(id);

            if (eco == null)
            {
               return NotFound();
            }


           return Ok(mapper.Map<InventoryDto>(eco));

        }


        [HttpPost("inventory-add")]

        public async Task<IActionResult> Create([FromBody] AddInventoryDto addInventoryDto)
        {


           var ecodomainmodel = mapper.Map<Inventory>(addInventoryDto);


           ecodomainmodel = await inventoryRepo.CreateAsync(ecodomainmodel);


           var ecoDto = mapper.Map<InventoryDto>(ecodomainmodel);


            return CreatedAtAction(nameof(GetById), new { id = ecoDto.Id }, ecoDto);


        }


        [HttpPut]
        [Route("{id:long}")]

        public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] UpdateInventoryDto updateInventoryDto)
        {


            var ecodomainmodel = mapper.Map<Inventory>(updateInventoryDto);


            ecodomainmodel = await inventoryRepo.UpdateInventoryAsync(id, ecodomainmodel);

            if (ecodomainmodel == null)
            {
                return NotFound();
            }


            // return Ok(mapper.Map<InventoryDto>(ecodomainmodel));

            return Ok(new
            {
                Message = "Inventory Updated!",
                Inventory = mapper.Map<InventoryDto>(ecodomainmodel)
            });


        }


        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var domainModel = await inventoryRepo.DeleteInventoryAsync(id);

            if (domainModel == null)
            {
                return NotFound();
            }

            // Return only the success message
            return Ok("Deleted successfully");
        }


    }
}
