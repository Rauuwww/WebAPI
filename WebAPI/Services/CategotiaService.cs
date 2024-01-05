﻿using WebAPI.Models;

namespace WebAPI.Services
{
    public class CategotiaService : ICategoriaService
    {
        TareasContext context;

        public CategotiaService(TareasContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Categoria> Get()
        {
            return context.Categorias;
        }

        public async Task Save(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id,Categoria categoria)
        {
            var cateiaActual = context.Categorias.Find(id);
            if (cateiaActual != null)
            {
                cateiaActual.Nombre = categoria.Nombre;
                categoria.Descripcion = categoria.Descripcion;
                categoria.Peso = categoria.Peso;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var categoriaActual = context.Categorias.Find(id);

            if (categoriaActual != null)
            {
                context.Remove(categoriaActual);
                await context.SaveChangesAsync();
            }
        }

    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        Task Save(Categoria categoria);
        Task Update(Guid id, Categoria categoria);
        Task Delete(Guid id);
    }
}
