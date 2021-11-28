﻿using System.Collections.Generic;
using GameReviewSolution.DTOs;
using GameReviewSolution.Models;

namespace GameReviewSolution.Services;

public interface IRepoService<TEntity, TDto>
{
    public TEntity GetEntityById(int id);
    public TDto GetDtoById(int id);

    public ICollection<Game> GetAllEntities();
    public ICollection<GameDto> GetAllDtos();


    public TEntity EntityFrom(TDto dto);
    public TDto DtoFrom(TEntity entity);
}