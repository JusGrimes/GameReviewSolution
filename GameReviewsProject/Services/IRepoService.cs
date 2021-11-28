using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;
using Microsoft.CodeAnalysis.Classification;

namespace GameReviewSolution.Services;

public interface IRepoService<TEntity,TDto>
{
    public TEntity GetEntityById(int id);
    public TDto GetDtoById(int id);

    public ICollection<Game> GetAllEntities();
    public ICollection<GameDto> GetAllDtos();
    
    
    public TEntity EntityFrom(TDto dto);
    public TDto DtoFrom(TEntity entity);
}