using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DILifecycle.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public SingletonService SingletonService1;
        public SingletonService SingletonService2;
        public ScopeService ScopeService1;
        public ScopeService ScopeService2;
        public TransientService TransientService1;
        public TransientService TransientService2;

        public IndexModel(SingletonService singletonService1, SingletonService singletonService2, ScopeService scopeService1, ScopeService scopeService2, TransientService transientService1, TransientService transientService2)
        {
            SingletonService1 = singletonService1;
            SingletonService2 = singletonService2;
            ScopeService1 = scopeService1;
            ScopeService2 = scopeService2;
            TransientService1 = transientService1;
            TransientService2 = transientService2;
        }

        public void OnGet()
        {

        }
    }
}