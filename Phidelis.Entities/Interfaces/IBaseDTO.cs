namespace Phidelis.Entities.Interfaces
{
    public interface IBaseDTO<T>
        where T : IBaseModel
    {
        T ConvertToModel();
    }
}
