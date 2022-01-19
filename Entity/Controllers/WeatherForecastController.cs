using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Entity.Controllers
{
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly PavyzdinisDbContext _dbContext;



        public WeatherForecastController(PavyzdinisDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpGet]
        [Route("/daiktai")]
        public List<Daiktas> VisiDaiktai()
        {
            return _dbContext.Daiktai.Where(x => x.Pavadinimas != "kazkas").ToList();
        }

        [HttpGet]
        [Route("/automobiliai")]
        [Authorize]
        public List<Automobilis> Automobiliai()
        {
            return _dbContext.Automobiliai.Where(x => x.Marke != "kazkas").ToList();
        }





        [HttpGet]
        [Route("/daiktai/{daiktoId}")]
        public ActionResult<Daiktas?> GautiDaikta(int daiktoId)
        {
            var daiktas = _dbContext.Daiktai.Where(x => x.Id == daiktoId).FirstOrDefault();
            if (daiktas == null)
            {
                return NotFound();
            }
            return daiktas;

            
        }

        [HttpGet]
        [Route("/savininkai/{savininkoId}")]

        public ActionResult<Savininkas?> GautiSavininka (int savininkoId)
        {
            var savininkas = _dbContext.Savininkai.Where(x => x.Id == savininkoId).FirstOrDefault();
            if (savininkas ==null)
            {
                return NotFound();
            }
            return savininkas;
        }



        [HttpGet]
        [Route("/savininkai")]
        public List<Savininkas> VisiSavininkai()
        {
            return _dbContext.Savininkai.Where(x => x.Vardas != "kazkas").ToList();
        }



        [HttpGet]
        [Route("/pridetiDaikta/{savininkoId}")]
        public void PridetiDaikta(int? savininkoId)
        {
            var savininkas = _dbContext.Savininkai.Where(x => x.Id == savininkoId).FirstOrDefault();
            _dbContext.Daiktai.Add(new Daiktas() { Pavadinimas = "Telefonas", SavininkasId = savininkas != null ? savininkas.Id : 1 });
            _dbContext.SaveChanges();
        }


        [HttpPost]
        [Route("/pridetiDaikta")]
        public void PridetiDaiktaPost([FromBody] DaiktasJSON daiktas)
        {
            var savininkas = _dbContext.Savininkai.Where(x => x.Id == daiktas.SavininkasId).FirstOrDefault();
            _dbContext.Daiktai.Add(new Daiktas()
            { 
               Pavadinimas = daiktas.Pavadinimas,
               SavininkasId = daiktas.SavininkasId
            });
            _dbContext.SaveChanges();
        }



        [HttpGet]
        [Route("/pridetiSavininka")]
        public void PridetiSavininka()
        {
            _dbContext.Savininkai.Add(new Savininkas() { Vardas = "Jonas" });
            _dbContext.SaveChanges();
        }

        [HttpDelete]
        [Route("/daiktas/{daiktoId:int?}")]

        public void IstrintiDaikta (int? daiktoId)
        {
            var daiktas = _dbContext.Daiktai.Where(x => x.Id == daiktoId).FirstOrDefault();

            if (daiktas != null)
            {
                _dbContext.Daiktai.Remove(daiktas);
                _dbContext.SaveChanges();
            }

            
        }

        [HttpDelete]
        [Route("/savininkas/{savininkoId}")]

        public void IstrintiSavininkas(int? savininkoId)
        {
            var savininkas = _dbContext.Savininkai.Where(x => x.Id == savininkoId).FirstOrDefault();

            if (savininkas != null)
            {
                _dbContext.Savininkai.Remove(savininkas);
                _dbContext.SaveChanges();
            }

            
        }



    }
}