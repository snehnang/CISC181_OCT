using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OCTOBER.EF.Data;
using OCTOBER.Server.Controllers.Base;
using OCTOBER.Shared.DTO;

namespace OCTOBER.Server.Controllers.UD
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : BaseController, GenericRestController<StudentDTO>
    {
        public StudentController(OCTOBEROracleContext context,
            IHttpContextAccessor httpContextAccessor,
            IMemoryCache memoryCache)
        : base(context, httpContextAccessor)
        {
        }

        [HttpDelete]
        [Route("Delete/{KeyVal}")]
        public Task<IActionResult> Delete(int KeyVal)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                var result = await _context.Students.Select(sp => new StudentDTO
                {
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    Employer = sp.Employer,
                    FirstName = sp.FirstName,
                    LastName = sp.LastName,
                    ModifiedBy = sp.ModifiedBy,
                    ModifiedDate = sp.ModifiedDate,
                    Phone = sp.Phone,
                    RegistrationDate = sp.RegistrationDate,
                    Salutation = sp.Salutation,
                    SchoolId = sp.SchoolId,
                    StreetAddress = sp.StreetAddress,
                    StudentId = sp.StudentId,
                    Zip = sp.Zip
                })
                .ToListAsync();
                await _context.Database.RollbackTransactionAsync();
                return Ok(result);
            }
            catch (Exception Dex)
            {
                await _context.Database.RollbackTransactionAsync();
                //List<OraError> DBErrors = ErrorHandling.TryDecodeDbUpdateException(Dex, _OraTranslateMsgs);
                return StatusCode(StatusCodes.Status417ExpectationFailed, "An Error has occurred");
            }
        }

        [HttpGet]
        [Route("Get/{KeyVal}")]
        public async Task<IActionResult> Get(int KeyVal)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                StudentDTO? result = await _context.Students
                    .Where(x => x.StudentId == KeyVal)
                    .Select(sp => new StudentDTO
                {
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    Employer = sp.Employer,
                    FirstName = sp.FirstName,
                    LastName = sp.LastName,
                    ModifiedBy = sp.ModifiedBy,
                    ModifiedDate = sp.ModifiedDate,
                    Phone = sp.Phone,
                    RegistrationDate = sp.RegistrationDate,
                    Salutation = sp.Salutation,
                    SchoolId = sp.SchoolId,
                    StreetAddress = sp.StreetAddress,
                    StudentId = sp.StudentId,
                    Zip = sp.Zip
                })
                .SingleAsync();
                await _context.Database.RollbackTransactionAsync();
                return Ok(result);
            }
            catch (Exception Dex)
            {
                await _context.Database.RollbackTransactionAsync();
                //List<OraError> DBErrors = ErrorHandling.TryDecodeDbUpdateException(Dex, _OraTranslateMsgs);
                return StatusCode(StatusCodes.Status417ExpectationFailed, "An Error has occurred");
            }
        }

        [HttpPost]
        [Route("Post")]
        public Task<IActionResult> Post([FromBody] StudentDTO _T)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("Put")]
        public Task<IActionResult> Put([FromBody] StudentDTO _T)
        {
            throw new NotImplementedException();
        }
    }
}