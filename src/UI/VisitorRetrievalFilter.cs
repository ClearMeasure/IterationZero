using System.Configuration;
using System.Web.Mvc;
using Core;
using Core.Model;
using Microsoft.Ajax.Utilities;

namespace UI
{
    public class VisitorRetrievalFilter : ActionFilterAttribute
    {
        private readonly IVisitorRepository _repository;

        public VisitorRetrievalFilter(IVisitorRepository repository)
        {
            _repository = repository;
        }

        public VisitorRetrievalFilter() : this(DependencyResolver.Current.GetService<IVisitorRepository>())
        {
            
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Visitor[] visitors = _repository.GetRecentVisitors(10);
            filterContext.Controller.ViewData["Visitors"] = visitors;
        }
    }
}