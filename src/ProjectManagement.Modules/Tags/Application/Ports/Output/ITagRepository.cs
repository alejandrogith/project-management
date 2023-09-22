using ProjectManagement.Modules.Commons.Application.Dtos;
using ProjectManagement.Modules.Tags.Application.Dtos;
using ProjectManagement.Modules.Tags.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Modules.Tags.Application.Ports.Output
{
    public interface ITagRepository
    {

        public Task<TagDomain> Save(TagDomain tagDomain);

        public Task<TagDomain> FindById(int TagId);

        public Task<bool> Exist(int TagId);

        public Task<PaginatedDataDto<TagDomain>> FindAll(TagRequestParams requestParams);

        public Task Update( TagDomain tagDomain);

        public Task Delete(int TagId);
    }
}
