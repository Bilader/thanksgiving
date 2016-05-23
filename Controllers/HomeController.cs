using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using TurkeyBase.Models;

namespace TurkeyBase.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        private TurkeyContext Context =>
            new TurkeyContext();
        public ActionResult Index() => View();
        
        public async Task<ActionResult> Search(Search search)
        {
            if ( !ModelState.IsValid )
                return View( "Index", search );
            IQueryable<Turk> query = Context.People.AsNoTracking();
            if (search.NationalIdentifier != null)
            {
                var ni = (long) search.NationalIdentifier;
                query = query.Where( a => a.NationalIdentifier == ni );
            }
            else
            { 
                var f = search.First?.Trim()??string.Empty;
                var l = search.Last?.Trim() ?? string.Empty;
                var fn = string.IsNullOrWhiteSpace(f);
                var ln = string.IsNullOrWhiteSpace(l);
                if (fn && ln)
                    return View("Index", search);
                if (!ln)
                    query = query.Where( a => a.Last.StartsWith( l ));
                if (!fn )
                    query = query.Where( a => a.First.StartsWith( f ) );
            }
            query = query.Where( a => a.Deleted < 2);

            var model = await query.Select(a => new TurkList {
                    First = a.First,
                    Last = a.Last,
                    NationalIdentifier = a.NationalIdentifier,
                    Uid = a.Uid,
                    date_of_birth = a.date_of_birth,
                    father_first = a.father_first,
                    mother_first = a.mother_first
                }
            )
            .ToArrayAsync().ConfigureAwait( false );
            return View(model);
        }
        
        [Route("u/{id:int}")]
        public async Task<ActionResult> Get(int id) {
            var model = await Context.People.AsNoTracking().FirstOrDefaultAsync(a => a.Uid == id).ConfigureAwait( false );
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
        

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
            base.Dispose(disposing);
        }
    }


}