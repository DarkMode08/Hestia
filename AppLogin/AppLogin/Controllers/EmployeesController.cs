﻿using AppLogin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppLogin.Models;
using AppLogin.ViewModels;
using Microsoft.Win32;
using System.Runtime.ConstrainedExecution;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AppLogin.Controllers
{
    public class EmployeesController : Controller
    {
        // Agregar una Variable unicamente para la lectura
        private readonly AppDBContext _dbContext;

        // Este constructor es para recibir el DBContext - DataBase
        public EmployeesController(AppDBContext appDBContext) {
            _dbContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> DashBoard()
        {
            List<_Employees> DashBoard = await _dbContext.Employees.ToListAsync();
            return View(DashBoard);
        }

        [HttpPost]
        public async Task<IActionResult> Create(_Employees employee)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("DashBoard"); // Redirige al tablero después de guardar
            }

            return View("NewEmployee", employee); // Regresa a la vista de nuevo empleado si hay errores
        }

        [HttpGet]
        // Se obtiene la vista del Empleado por el ID Registrado en la base de datos
        public async Task<IActionResult> Edit(int id) {
            _Employees employees = await _dbContext.Employees.FirstAsync(e => e.ID_Employees == id);

            // Se devuelve la vista con los datos del empleado para que el usuario pueda editarlos
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(_Employees employees)
        {
            if (!ModelState.IsValid)
            {
                // Si no es válido, devuelve la vista con los datos que el usuario ha ingresado hasta el momento
                return View(employees);
            }

            // Esto asegura que solo los campos modificados se actualizarán
            var employeeToUpdate = await _dbContext.Employees.FirstAsync(e => e.ID_Employees == employees.ID_Employees);

            if (employeeToUpdate != null)
            {
                // Actualizar cada propiedad individualmente
                employeeToUpdate.FirstName = employees.FirstName;
                employeeToUpdate.LastName = employees.LastName;
                employeeToUpdate.HireDate = employees.HireDate;
                employeeToUpdate.Email = employees.Email;
                employeeToUpdate.Status = employees.Status;
                // Otros campos a actualizar

                await _dbContext.SaveChangesAsync();
            }
            // Redirige a la acción DashBoard después de guardar los cambios
            return RedirectToAction(nameof(DashBoard));
            /*
            _dbContext.Employees.Update(employees);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(DashBoard));
            */
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _Employees employees = await _dbContext.Employees.FirstAsync(e => e.ID_Employees == id);
            _dbContext.Employees.Remove(employees);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(DashBoard));
        }

        [HttpGet]
        public IActionResult NewEmployee()
        {
            return View();
        }
    }
}
