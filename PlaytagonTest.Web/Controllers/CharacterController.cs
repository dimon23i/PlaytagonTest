using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PlaytagonTest.DAL;
using PlaytagonTest.Web.Models;

namespace PlaytagonTest.Web.Controllers
{
    public class CharacterController : ApiController
    {
        public IEnumerable<Character> Get()
        {
            using (var session = DbContext.OpenSession())
            {
                var query = session.CreateQuery("FROM Character");
                var characters = query.List<Character>().OrderBy(c => c.Name);

                return characters;
            }
        }

        public void Post([FromBody]Character character)
        {
            using (var session = DbContext.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(character);
                    transaction.Commit();
                }
            }
        }

        public void Put([FromBody]Character character)
        {
            using (var session = DbContext.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(character);
                    transaction.Commit();
                }
            }
        }

        public void Delete(int id)
        {
            using (var session = DbContext.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var character = session.Load<Character>(id);
                    session.Delete(character);
                    transaction.Commit();
                }
            }
        }
    }
}
