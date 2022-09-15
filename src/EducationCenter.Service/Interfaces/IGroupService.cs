using EducationCenter.Domain.Entities.Groups;
using EducationCenter.Service.DTOs.Groups;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationCenter.Service.Interfaces
{
    public interface IGroupService
    {
        Task<Group> CreateAsync(GroupForCreationDto groupDto);
        Task<Group> GetAsync(Expression<Func<Group, bool>> expression);
        Task<IEnumerable<Group>> GetAllAsync(Expression<Func<Group, bool>> expression = null);
        Task<bool> DeleteAsync(Expression<Func<Group, bool>> expression);
        Task<Group> UpdateAsync(long id, GroupForCreationDto groupDto);
    }
}
