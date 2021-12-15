using System.Linq;
using System.Threading.Tasks;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Manager.Infra.Context;
using System.Collections.Generic;
using Manager.Domain.Entities;

namespace  Manager.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }
         /*-------------------------------------------------------------
         Metedo é VIRTUAL, pois, ele pode ser sobrescrito                 
         EX: se quiser fazer uma insersão usando Dapper ou EF tanto faz.

         OBS: Os OBJ's do Entity são Trackeados, isso quer dizer que eles
         refletem para o programa o Id que é gerado automático no banco.
         ----------------------------------------------------------------*/
        public virtual async Task<T> Create(T obj )
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }
        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            //Não esquecer do Save para podermodificar o banco. 
            await _context.SaveChangesAsync();

            return obj;
        }
        public virtual async Task Remove(long id)
        {
            //Verifica se o OBJ recebido no construtor existe
            var obj = await Get(id);
            //Se existir verifica se é diferente de nulo
            if(obj != null)
            {   
                //Remove e salva no banco.
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Get(long id)
        {
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x=> x.Id == id)
                                    .ToListAsync();
            return obj.FirstOrDefault();
        }
        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                .AsNoTracking()
                                .ToListAsync();
        }
 
    }
}