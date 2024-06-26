using DTOs;

namespace Services
{
  public interface ICommonService<T, TI, TU>
  {
    public List<string> Errors { get; }
    Task<IEnumerable<T>> Get();
    Task<T> GetById(int id);
    Task<T> Add(TI commonInsertDto);
    Task<T> Update(int id, TU commonUpdateDto);
    Task<T> Delete(int id);
    bool Validate(TI commonInsertDto);
    bool Validate(TU commonUpdateDto);
  }

}