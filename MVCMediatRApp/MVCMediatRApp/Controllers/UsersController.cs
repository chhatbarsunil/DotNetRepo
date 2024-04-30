using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_MVCMediatRApp.Entity;
using Data_MVCMediatRApp.Context;
using MediatR;
using Application_MVCMediatRApp.UserProcessor.Queries;
using Core_MVCMediatRApp.ViewModels;
using Application_MVCMediatRApp.UserProcessor.Commands;

namespace MVCMediatRApp.Controllers
{

    
    public class UsersController : Controller
    {
        private readonly MVCMediatRAppDbContext _context;
        private readonly IMediator _mediator;

        public UsersController(MVCMediatRAppDbContext context,IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            //await _context.Users.ToListAsync()
            var result = await _mediator.Send(new GetUsersQuery());
            return _context.Users != null ?
                          View(result) :
                          Problem("Entity set 'MVCMediatRAppDbContext.users'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0 || _context.Users == null)
            {
                return NotFound();
            }

            //var user = await _context.Users
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,Designation,Roles,ReportingManager,Approver,DepartmentName,IsVendor,Phone,Password")] CreateUserRequestModel user)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(user);
                //await _context.SaveChangesAsync();
                var result = await _mediator.Send(new CreateUserCommand(user));
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0 || _context.Users == null)
            {
                return NotFound();
            }

            //var user = await _context.Users.FindAsync(id);
            var user = await _mediator.Send(new GetUserUpdateByIdQuery(id));

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,Designation,Roles,ReportingManager,Approver,DepartmentName,IsVendor,Phone,Password")] UpdateUserRequestModel updateUserRequestModel)
        {
            if (id != updateUserRequestModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(user);
                    //await _context.SaveChangesAsync();
                    var user = await _mediator.Send(new UpdateUserCommand (updateUserRequestModel));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(updateUserRequestModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(updateUserRequestModel);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || _context.Users == null)
            {
                return NotFound();
            }

            //var user = await _context.Users
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'MVCMediatRAppDbContext.users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
