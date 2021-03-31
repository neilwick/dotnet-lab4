using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab4.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab4.Pages.Cards
{
    public class CreateModel : PageModel
    {
        private readonly Lab4.Models.MtgContext _context;
        private UserManager<TcgUser> _userManager;

        public CreateModel(Lab4.Models.MtgContext context, UserManager<TcgUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Card Card { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Cards.Add(Card);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            } else
            {
                ViewData["error"] = "Not logged in!";
                return Page();
            }
        }
    }
}
