

using ProjectManagement.Modules.Tags.Domain.Entitites;
using ProjectManagement.Modules.Tags.Infraestructure.Adapters.Output.Persistence.Entity;

namespace ProjectManagement.Modules.Tags.Infraestructure.Adapters.Output.Persistence.Mapper
{
    public static class TagMapperEntity
    {
        public static TagDomain MapToDomain(TagEntity tag)
        {
            return new TagDomain(tag.Id, tag.Name,tag.CreatedAt,tag.UpdatedAt);
        }

        public static TagEntity MapToEntity(TagDomain domain)
        {
            return new TagEntity(domain.Id, domain.Name);
        }

    }
}
