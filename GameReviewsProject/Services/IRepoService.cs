using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameReviewSolution.Services;

public interface IRepoService<TEntity, TDto>
{
    public Task<TDto> Add(TDto dtoInput);
    public Task<TEntity> GetEntityById(int id);
    public Task<TDto> GetDtoById(int id);

    public Task<IList<TEntity>> GetAllEntities();
    public Task<IList<TDto>> GetAllDtos();


    public Task<TEntity> EntityFrom(TDto dto);
    public TDto DtoFrom(TEntity entity);
}