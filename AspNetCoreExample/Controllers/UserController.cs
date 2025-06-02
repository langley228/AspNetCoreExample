using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AspNetCoreWebApiExample.Models;
using AspNetCoreWebApiExample.Services;

namespace AspNetCoreWebApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// 取得分頁使用者清單
        /// </summary>
        /// <param name="query">分頁與排序查詢參數</param>
        /// <returns>分頁結果</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<UserViewModel>), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<ActionResult<PagedResult<UserViewModel>>> GetAll([FromQuery] PagedQuery query)
        {
            try
            {
                var result = await _service.GetPagedAsync(query);
                return Ok(result);
            }
            catch (InvalidSortFieldException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// 取得單一使用者
        /// </summary>
        /// <param name="id">使用者 Id</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UserViewModel), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserViewModel>> Get(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="userViewModel">使用者資料</param>
        [HttpPost]
        [ProducesResponseType(typeof(UserViewModel), 201)]
        public async Task<ActionResult<UserViewModel>> Create([FromBody] UserViewModel userViewModel)
        {
            var created = await _service.CreateAsync(userViewModel);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// 更新使用者
        /// </summary>
        /// <param name="id">使用者 Id</param>
        /// <param name="userViewModel">使用者資料</param>
        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
                return BadRequest("Id 不一致");

            var success = await _service.UpdateAsync(id, userViewModel);
            if (!success)
                return NotFound();
            return Ok();
        }

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="id">使用者 Id</param>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound();
            return Ok();
        }
    }
}
