﻿using FormDesing.DTOs;
using FormDesing.Models.DB;

namespace FormDesing.Services.FormService
{
    public interface IFormService
    {
        Task<FormDTO> CreateForm(FormDTO form);
        Task<FormDTO> UpdateForm(FormDTO form);
        Task<FormDTO> DeleteForm(Guid id);
        Task<FormDTO> GetFormsById(Guid id);
        Task<IEnumerable<FormDTO>> getAllForms();
        Task<IEnumerable<FormDTO>> GetAllFormByUser(Guid userId);
    }
}
