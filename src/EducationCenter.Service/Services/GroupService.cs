using EducationCenter.Domain.Entities.Groups;
using EducationCenter.Service.DTOs.Groups;
using EducationCenter.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.Repositories;

namespace EducationCenter.Service.Services
{
    public class GroupService : IGroupService
    {

        private readonly GroupRepository groupRepository;

        public GroupService(GroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public async Task<Group> CreateAsync(GroupForCreationDto groupDto)
        {
            var result = await groupRepository.CreateAsync(groupDto.Adapt<Group>());
            await groupRepository.SaveAsync();
            return result;
        }
        public async Task<bool> DeleteAsync(Expression<Func<Group, bool>> expression)
        {
            var isDeleted = await groupRepository.DeleteAsync(expression);
            await groupRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<IEnumerable<Group>> GetAllAsync(Expression<Func<Group, bool>> expression = null)
            => await groupRepository.GetAllAsync(expression);

        public async Task<Group> GetAsync(Expression<Func<Group, bool>> expression)
        {
            var groups = await groupRepository.GetAsync(expression);
            return groups;
        }

        public async Task<Group> UpdateAsync(long id, GroupForCreationDto groupDto)
        {
            var group = await groupRepository.GetAsync(p => p.Id == id);
            var result = await groupRepository.UpdateAsync(groupDto.Adapt(group));

            await groupRepository.SaveAsync();

            return result;
        }
    }
}
