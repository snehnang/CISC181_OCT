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

    public class GradeConversionController : BaseController, GenericRestController<GradeConversionDTO>
    {
        public GradeConversionController(OCTOBEROracleContext context,
            IHttpContextAccessor httpContextAccessor,
            IMemoryCache memoryCache)
        : base(context, httpContextAccessor)
        {
        }

        [HttpDelete]
        [Route("Delete/{SchoolId}/{LetterGrade}")]
        public Task<IActionResult> Delete(int SchoolId, string LetterGrade)
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

                var result = await _context.GradeConversions.Select(sp => new GradeConversionDTO
                {
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    GradePoint = sp.GradePoint,
                    LetterGrade = sp.LetterGrade,
                    MaxGrade = sp.MaxGrade,
                    MinGrade = sp.MinGrade,
                    ModifiedBy = sp.ModifiedBy,
                    ModifiedDate = sp.ModifiedDate,
                    SchoolId = sp.SchoolId
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
        [Route("Get/{SchoolId}/{LetterGrade}")]
        public async Task<IActionResult> Get(int SchoolId, string LetterGrade)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                GradeConversionDTO? result = await _context.GradeConversions
                    .Where(x => x.SchoolId == SchoolId)
                    .Where(x => x.LetterGrade == LetterGrade)
                    .Select(sp => new GradeConversionDTO
                {
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    GradePoint = sp.GradePoint,
                    LetterGrade = sp.LetterGrade,
                    MaxGrade = sp.MaxGrade,
                    MinGrade = sp.MinGrade,
                    ModifiedBy = sp.ModifiedBy,
                    ModifiedDate = sp.ModifiedDate,
                    SchoolId = sp.SchoolId
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
        public Task<IActionResult> Post([FromBody] GradeConversionDTO _T)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("Put")]
        public Task<IActionResult> Put([FromBody] GradeConversionDTO _T)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> GenericRestController<GradeConversionDTO>.Delete(int KeyVal)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> GenericRestController<GradeConversionDTO>.Get(int KeyVal)
        {
            throw new NotImplementedException();
        }
    }
}