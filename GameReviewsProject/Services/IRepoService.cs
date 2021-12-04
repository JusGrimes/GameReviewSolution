using System.Collections.Generic;

namespace GameReviewSolution.Services;

public interface IRepoService<TEntity, TDto>
{
    public TEntity GetEntityById(int id);
    public TDto GetDtoById(int id);

    public ICollection<TEntity> GetAllEntities();
    public ICollection<TDto> GetAllDtos();


    public TEntity EntityFrom(TDto dto);
    public TDto DtoFrom(TEntity entity);
}