using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4.Models;

namespace Lab4.Pages.Cards
{
    public class IndexModel : PageModel
    {
        private readonly Lab4.Models.MtgContext _context;

        public IndexModel(Lab4.Models.MtgContext context)
        {
            _context = context;
        }

        public IList<Card> Card { get;set; }

        public async Task OnGetAsync()
        {
            Card = await _context.Cards.ToListAsync();
        }
    }
}
