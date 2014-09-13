using System.Web.Mvc;
using Core;
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

        public VisitorRetrievalFilter() : this(VisitorRepositoryFactory.Build())
        {
            
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Visitor[] visitors = _repository.GetRecentVisitors(10);
            filterContext.Controller.ViewData["Visitors"] = visitors;
        }
    }
}