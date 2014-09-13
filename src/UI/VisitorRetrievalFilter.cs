using System.Web.Mvc;
using Core;
using Core.DataAccess;

namespace UI
{
	public class VisitorRetrievalFilter : ActionFilterAttribute
	{
		private readonly VisitorRepository _repository;

		public VisitorRetrievalFilter(VisitorRepository repository)
		{
			_repository = repository;
		}

		public VisitorRetrievalFilter() : this(
			new VisitorRepository())
		{
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			Visitor[] visitors = _repository.GetRecentVisitors(10);
			filterContext.Controller.ViewData["Visitors"] = visitors;
		}
	}
}