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

    public class GradeController : BaseController, GenericRestController<GradeDTO>
    {
        public GradeController(OCTOBEROracleContext context,
            IHttpContextAccessor httpContextAccessor,
            IMemoryCache memoryCache)
        : base(context, httpContextAccessor)
        {
        }

        [HttpDelete]
        [Route("Delete/{SchoolId}/{StudentId}/{SectionId}/{GradeTypeCode}/{GradeCodeOccurrence}")]
        public Task<IActionResult> Delete(int SchoolId, int StudentId, int SectionId, string GradeTypeCode, int GradeCodeOccurrence)
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

                var result = await _context.Grades.Select(sp => new GradeDTO
                {
                    Comments = sp.Comments,
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    GradeCodeOccurrence = sp.GradeCodeOccurrence,
                    GradeTypeCode = sp.GradeTypeCode,
                    ModifiedBy = sp.ModifiedBy,
                    ModifiedDate = sp.ModifiedDate,
                    NumericGrade = sp.NumericGrade,
                    SchoolId = sp.SchoolId,
                    SectionId = sp.SectionId,
                    StudentId = sp.StudentId
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
        [Route("Get/{SchoolId}/{StudentId}/{SectionId}/{GradeTypeCode}/{GradeCodeOccurrence}")]
        public async Task<IActionResult> Get(int SchoolId, int StudentId, int SectionId, string GradeTypeCode, int GradeCodeOccurrence)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                GradeDTO? result = await _context.Grades
                    .Where(x => x.SchoolId == SchoolId)
                    .Where(x => x.StudentId == StudentId)
                    .Where(x => x.SectionId == SectionId)
                    .Where(x => x.GradeTypeCode == GradeTypeCode)
                    .Where(x => x.GradeCodeOccurrence == GradeCodeOccurrence)
                    .Select(sp => new GradeDTO
                {
                    Comments = sp.Comments,
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    GradeCodeOccurrence = sp.GradeCodeOccurrence,
                    GradeTypeCode = sp.GradeTypeCode,
                    ModifiedBy = sp.ModifiedBy,
                    ModifiedDate = sp.ModifiedDate,
                    NumericGrade = sp.NumericGrade,
                    SchoolId = sp.SchoolId,
                    SectionId = sp.SectionId,
                    StudentId = sp.StudentId
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
        public Task<IActionResult> Post([FromBody] GradeDTO _T)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("Put")]
        public Task<IActionResult> Put([FromBody] GradeDTO _T)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> GenericRestController<GradeDTO>.Delete(int KeyVal)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> GenericRestController<GradeDTO>.Get(int KeyVal)
        {
            throw new NotImplementedException();
        }
    }
}