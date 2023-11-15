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

    public class SectionController : BaseController, GenericRestController<SectionDTO>
    {
        public SectionController(OCTOBEROracleContext context,
            IHttpContextAccessor httpContextAccessor,
            IMemoryCache memoryCache)
        : base(context, httpContextAccessor)
        {
        }

        [HttpDelete]
        [Route("Delete/{SectionId}")]
        public Task<IActionResult> Delete(int SectionId)
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

                var result = await _context.Sections.Select(sp => new SectionDTO
                {
                     Capacity = sp.Capacity,
                     CourseNo = sp.CourseNo,
                     CreatedBy = sp.CreatedBy,
                     CreatedDate = sp.CreatedDate,
                     InstructorId = sp.InstructorId,
                     Location = sp.Location,
                     ModifiedBy = sp.ModifiedBy,
                     ModifiedDate = sp.ModifiedDate,
                     SchoolId = sp.SchoolId,
                     SectionId = sp.SectionId,
                     SectionNo = sp.SectionNo,
                     StartDateTime = sp.StartDateTime                                 
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
        [Route("Get/{SectionId}")]
        public async Task<IActionResult> Get(int SectionId)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                SectionDTO? result = await _context.Sections
                    .Where(x=>x.SectionId == SectionId)
                    .Select(sp => new SectionDTO
                {
                    Capacity = sp.Capacity,
                    CourseNo = sp.CourseNo,
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    InstructorId = sp.InstructorId,
                    Location = sp.Location,
                    ModifiedBy = sp.ModifiedBy,
                    ModifiedDate = sp.ModifiedDate,
                    SchoolId = sp.SchoolId,
                    SectionId = sp.SectionId,
                    SectionNo = sp.SectionNo,
                    StartDateTime = sp.StartDateTime
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
        public Task<IActionResult> Post([FromBody] SectionDTO _T)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("Put")]
        public Task<IActionResult> Put([FromBody] SectionDTO _T)
        {
            throw new NotImplementedException();
        }
    }
}