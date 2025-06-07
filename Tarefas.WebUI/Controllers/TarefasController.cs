using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.WebUI.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefaService _tarefaService;

        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        // GET: /Tarefas
        public async Task<IActionResult> Index()
        {
            var tarefas = await _tarefaService.GetTarefasAsync();
            return View(tarefas);
        }

        // GET: /Tarefas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Tarefas/Create
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create(TarefaDTO tarefaDto)
        {
            if (ModelState.IsValid)
            {
                tarefaDto.Id = Guid.NewGuid(); // Gera um novo ID para criação

                await _tarefaService.CreateAsync(tarefaDto);
                return RedirectToAction(nameof(Index));
            }
            return View(tarefaDto);
        }

        // GET: /Tarefas/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var tarefaDto = await _tarefaService.GetByIdAsync(id);
            if (tarefaDto == null)
                return NotFound();

            return View(tarefaDto);
        }

        // POST: /Tarefas/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(TarefaDTO tarefaDto)
        {
            if (ModelState.IsValid)
            {
                await _tarefaService.UpdateAsync(tarefaDto);
                return RedirectToAction(nameof(Index));
            }
            return View(tarefaDto);
        }

        // GET: /Tarefas/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            var tarefaDto = await _tarefaService.GetByIdAsync(id);
            if (tarefaDto == null)
                return NotFound();

            return View(tarefaDto);
        }

        // POST: /Tarefas/DeleteConfirmed/{id}
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _tarefaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Tarefas/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var tarefaDto = await _tarefaService.GetByIdAsync(id);
            if (tarefaDto == null)
                return NotFound();

            return View(tarefaDto);
        }
    }
}
