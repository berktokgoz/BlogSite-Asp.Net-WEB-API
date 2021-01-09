using BerkTokgozBlogSitesi.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace BerkTokgozBlogSitesi.Api.Controllers
{
    public class HakkımızdaController : ApiController
    {
        BerkTokgozBlogSitesi.Api.Entitiy.BerkTokgoz_BlogEntities db = new Entitiy.BerkTokgoz_BlogEntities();

        public JsonResult Düzenle(HakkımızdaModel model)
        {
            
            if (model?.Başlık == null || model?.Icerik == null)
            {
                return new JsonResult { Data = false };

            }

            var entity = db.Hakkimizda.FirstOrDefault();

            if (entity != null)
            {
                entity.Baslik = model.Başlık;
                entity.Icerik = model.Icerik;
                
            }
            else
            {
                db.Hakkimizda.Add(new Entitiy.Hakkimizda
                {
                    Baslik = model.Başlık,
                    Icerik = model.Icerik
                });
            }
            
            db.SaveChanges();

            return new JsonResult { Data = true };
        }
    }
}
