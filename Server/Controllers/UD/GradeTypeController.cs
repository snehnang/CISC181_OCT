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

    public class GradeTypeController : BaseController, GenericRestController<GradeTypeDTO>
    {
        public GradeTypeController(OCTOBEROracleContext context,
            IHttpContextAccessor httpContextAccessor,
            IMemoryCache memoryCache)
        : base(context, httpContextAccessor)
        {
        }

        [HttpDelete]
        [Route("Delete/{SchoolId}/{GradeTypeCode}")]
        public Task<IActionResult> Delete(int SchoolId, string GradeTypeCode)
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

                var result = await _context.GradeTypes.Select(sp => new GradeTypeDTO
                {
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    Description = sp.Description,
                    GradeTypeCode = sp.GradeTypeCode,
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
        [Route("Get/{SchoolId}/{GradeTypeCode}")]
        public async Task<IActionResult> Get(int SchoolId, string GradeTypeCode)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();

                GradeTypeDTO? result = await _context.GradeTypes
                    .Where(x => x.SchoolId == SchoolId)
                    .Where(x => x.GradeTypeCode == GradeTypeCode)
                    .Select(sp => new GradeTypeDTO
                {
                    CreatedBy = sp.CreatedBy,
                    CreatedDate = sp.CreatedDate,
                    Description = sp.Description,
                    GradeTypeCode = sp.GradeTypeCode,
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
        public Task<IActionResult> Post([FromBody] GradeTypeDTO _T)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("Put")]
        public Task<IActionResult> Put([FromBody] GradeTypeDTO _T)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> GenericRestController<GradeTypeDTO>.Delete(int KeyVal)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> GenericRestController<GradeTypeDTO>.Get(int KeyVal)
        {
            throw new NotImplementedException();
        }
    }
}