using FormDesing.Models.DB;

namespace FormDesing.Repositories.FormRepository
{
    public interface IFormRepository
    {
        Task<Formulario> GetFormById(Guid id);
        Task<IEnumerable<Formulario>> GetAllForms();
        Task<Formulario> AddForm(Formulario form);
        Task<Formulario> UpdateForm(Formulario form);
        Task<Formulario> DeleteForm(Guid id);
        Task<IEnumerable<Formulario>> GetAllFormByUser(Guid userId);
        Task<int> TotalForms(Guid userId);
        Task<IEnumerable<Formulario>> GetTopForms(int num, Guid idUser);
    }
}
