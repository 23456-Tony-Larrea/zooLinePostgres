using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using prueba.Data;

namespace ZooLine.Controllers
{

    public class ControlladorBase : Controller
    {
    
        protected readonly IMapper _Mapper;
        protected readonly ApplicationDbContext _context;
        protected readonly IWebHostEnvironment _hostEnvironment;
        public ControlladorBase(IMapper mapper, ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _Mapper = mapper;
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }
        protected T Map<T>(object input)
        {
            return _Mapper.Map<T>(input);
        }
    }
}
