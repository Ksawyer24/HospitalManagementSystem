using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Dto;
using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.Billing_Management;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingInvoiceController : ControllerBase
    {
        private readonly HospitalSysDbContext hospitalSysDbContext;
        private readonly IBillingInvoiceRepo billingInvoiceRepo;
        private readonly IMapper mapper;

        public BillingInvoiceController(HospitalSysDbContext hospitalSysDbContext, IBillingInvoiceRepo billingInvoiceRepo, IMapper mapper)
        {
            this.hospitalSysDbContext = hospitalSysDbContext;
            this.billingInvoiceRepo = billingInvoiceRepo;
            this.mapper = mapper;
        }





        [HttpGet]
        public async Task<ActionResult<List<BillingInvoiceDto>>> GetInvoices()
        {

            var dom = await billingInvoiceRepo.GetAllInvoicesAsync();


            var dto = mapper.Map<List<BillingInvoiceDto>>(dom);


            return Ok(dto);
           
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<BillingInvoiceDto>> GetInvoice(long id)
        {

            var doc = await billingInvoiceRepo.GetInvoiceByIdAsync(id);

            if (doc == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BillingInvoiceDto>(doc));
           
        }


        [HttpPost]
        public async Task<ActionResult> AddInvoice([FromBody] AdddBillingInvoiceDto adddBillingInvoiceDto)
        {
            var invoice = new BillingInvoice
            {
                InvoiceNumber = adddBillingInvoiceDto.InvoiceNumber,
                Patient = adddBillingInvoiceDto.Patient,
                PatientAddress = adddBillingInvoiceDto.PatientAddress,
                PatientContact = adddBillingInvoiceDto.PatientContact,
                Items = adddBillingInvoiceDto.Items.Select(item => new InvoiceItem
                {
                    ItemName = item.ItemName,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity
                }).ToList()
            };

            await billingInvoiceRepo.AddInvoiceAsync(invoice);
            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, adddBillingInvoiceDto);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInvoice(long id, [FromBody] BillingInvoiceDto invoiceDto)
        {
            var existingInvoice = await billingInvoiceRepo.GetInvoiceByIdAsync(id);
            if (existingInvoice == null) return NotFound();

            existingInvoice.InvoiceNumber = invoiceDto.InvoiceNumber;
            existingInvoice.Patient = invoiceDto.Patient;
            existingInvoice.PatientAddress = invoiceDto.PatientAddress;
            existingInvoice.PatientContact = invoiceDto.PatientContact;
            existingInvoice.Items = invoiceDto.Items.Select(item => new InvoiceItem
            {
                Id = item.Id,
                ItemName = item.ItemName,
                UnitPrice = item.UnitPrice,
                Quantity = item.Quantity
            }).ToList();

            await billingInvoiceRepo.UpdateInvoiceAsync(existingInvoice);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoice(long id)
        {
            await billingInvoiceRepo.DeleteInvoiceAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
