using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CovidStatsAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CovidInfoController : ControllerBase
	{
		private readonly ILogger<CovidInfoController> _logger;

		public CovidInfoController(ILogger<CovidInfoController> logger)
		{
			_logger = logger;
		}
		public CovidInfoController()
		{
			
		}
		// GET covidinfo
		[HttpGet]
		public IEnumerable<string[]> Get()
		{
			CovidInfo info = new CovidInfo();
			return info.GetInfo("");
		}

		// GET covidinfo/Romania
		[HttpGet("{country}")]
		public IEnumerable<string[]> Get(string country)
		{
			CovidInfo info = new CovidInfo();
			return info.GetInfo(country);
		}

	}
}
