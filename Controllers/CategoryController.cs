using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("v1/categories/{id:int}")]
        public IActionResult GetByIdAsyc(int id, [FromServices] BlogDataContext context)
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == id);
            return Ok(category);
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromBody] CreateCategoryViewModel model, [FromServices] BlogDataContext context)
        {
            try
            {

                var category = new Category
                {
                    Id = 0,
                    Name = model.Name,
                    Slug = model.Slug
                };


            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return Created($"v1/categories/{category.Id}", category);
        }
            catch (DbUpdateException ex)
            {
                return StatusCode(500,"erro interno do servidor - EX14B");

    }catch(Exception ex){
                    return StatusCode(500, "server internal error - EX14AA");
}
        }
        [HttpPut("v1/categories/{id:int}")]
public async Task<IActionResult> PutAsync(int id, [FromBody] Category model, [FromServices] BlogDataContext context)
{
    var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    if (category == null) return NotFound();

    category.Name = model.Name;
    category.Slug = model.Slug;
    category.Posts = model.Posts;

    context.Categories.Update(category);
    await context.SaveChangesAsync();
    return Ok(category);
}
[HttpDelete("v1/categories/{id:int}")]
public async Task<IActionResult> DeleteAsync(int id, [FromServices] BlogDataContext context)
{
    var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    if (category == null) return NotFound();

    context.Categories.Remove(category);
    await context.SaveChangesAsync();
    return Ok(category);
}


    }
}