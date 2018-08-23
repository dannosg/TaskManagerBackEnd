using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskProject.Contracts;
using TaskProject.Dtos;
using TaskProject.Entities;

namespace TaskProject.Controllers
{
    [Produces("application/json")]
    [Route("api/tasks")]
    [ApiController]

    public class TasksController : Controller
    {
        private readonly ITaskRepository _repo;
        private readonly IMapper  _mapper;

        public TasksController(ITaskRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostTaskEntity([FromBody] TaskEntity task)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            
            await _repo.AddTask(task);

            var submittedTask = _repo.FindTask(task.Id);

            return new JsonResult(submittedTask);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(Guid id)
        {
            var task = _repo.FindTask(id);

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            return new JsonResult(task);
        }

        [HttpGet]
        public IActionResult GetTaskEntities()
        {
            var tasksFromRepo = _repo.GetAllTasks();

            var tasks = _mapper.Map<IEnumerable<TaskEntity>, IEnumerable<TaskDto>>(tasksFromRepo);

            return new JsonResult(tasks);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskEntity(Guid id)
        {
            TaskEntity task = await _repo.DeleteTask(id);
                        
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            return new JsonResult(task);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskEntity([FromBody] TaskEntity task)
        {
            await _repo.UpdateTask(task);

            var updatedTask = _repo.FindTask(task.Id);

            return new JsonResult(updatedTask);
        }


    }
}